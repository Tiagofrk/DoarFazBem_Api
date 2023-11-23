using DoarFazBem.Models;
using DoarFazBem_Api.Context;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

[Route("v1/Login")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly AppDbContext _context;

    public LoginController(AppDbContext context)
    {
        _context = context;
    }

    [Route("Login"), HttpPost]
    public async Task<ActionResult<Usuario>> Login([FromBody] Login loginDto)
    {
        try
        {
            var usuario = await _context.Usuario.SingleOrDefaultAsync(x => x.cpf == loginDto.cpf);

            var hmac = new HMACSHA512();
            byte[] senhaHash;

            if (usuario == null)
            {
                var error = "Cpf inválido";
                throw new ArgumentException(error);
            }

            if (usuario.senhaSalt != null)
            {
                hmac = new HMACSHA512(usuario.senhaSalt);
            }
            else
            {
                throw new ArgumentNullException(nameof(usuario.senhaSalt), "O valor de senha não pode ser nulo. Verifique se o valor está sendo definido corretamente.");
            }

            if (loginDto.password_dfb != null)
            {
                senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.password_dfb));
            }
            else
            {
                throw new ArgumentNullException(nameof(loginDto.password_dfb), "O valor de password não pode ser nulo. Verifique se o valor está sendo definido corretamente.");
            }

            for (int i = 0; i < senhaHash.Length; i++)
            {
                if (senhaHash[i] != usuario.senhaHash?[i])
                {
                    var error = "Senha inválido";
                    throw new ArgumentException(error);
                }
            }

            return usuario;

        }
        catch (Exception ex)
        {
            // Adicione logs ou retorne mensagens de erro para debug
            Console.WriteLine($"Erro: {ex.Message}");
            return BadRequest($"Erro: {ex.Message}");
        }
    }
}
