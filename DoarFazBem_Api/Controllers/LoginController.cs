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

namespace DoarFazBem_Api.Controllers
{
    public class LoginController
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Usuario>> Login(Login loginDto)
        {
            var usuario = await _context.Usuario.SingleOrDefaultAsync(x => x.cpf == loginDto.cpf);

            if (usuario == null)
            {
                var error = "Cpf inválido";
                throw new ArgumentException(error);
            }

            using var hmac = new HMACSHA512(usuario.senhaSalt);

            var senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.password));

            for (int i = 0; i < senhaHash.Length; i++)
            {
                if (senhaHash[i] != usuario.senhaHash[i]) {
                    var error = "Senha inválido";
                    throw new ArgumentException(error);
                } 
            }

            return usuario;
        }
    }
}
