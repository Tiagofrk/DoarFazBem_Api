using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DoarFazBem_Api.Context;
using DoarFazBem.Models;
using Microsoft.EntityFrameworkCore;

[Route("v1/Usuario")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Usuario
    [Route("GetUsuarios"), HttpGet]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios()
    {
        return _context.Usuario.ToList();
    }

    // GET: api/Usuario/5
    [Route("GetUsuario"), HttpGet]
    public ActionResult<Usuario> GetUsuario(int id)
    {
        try
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
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

    // POST: api/Usuario
    [Route("PostUsuario"), HttpPost]
    public ActionResult<Usuario> PostUsuario([FromBody] Usuario usuario)
    {
        try
        {
            CriarSenhaHash(usuario.senha, out byte[] senhaHash, out byte[] senhaSalt);
            usuario.senhaHash = senhaHash;
            usuario.senhaSalt = senhaSalt;

            _context.Usuario.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.cpf }, usuario);
        }
        catch (Exception ex)
        {
            // Adicione logs ou retorne mensagens de erro para debug
            Console.WriteLine($"Erro: {ex.Message}");
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    // PUT: api/Usuario/5
    [Route("PutUsuario"), HttpGet]
    public IActionResult PutUsuario(int id, [FromBody] Usuario usuario)
    {
        try
        {
            if (id != usuario.cpf)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();

        }
        catch (Exception ex)
        {
            // Adicione logs ou retorne mensagens de erro para debug
            Console.WriteLine($"Erro: {ex.Message}");
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    // DELETE: api/Usuario/5
    [Route("DeleteUsuario"), HttpDelete]
    public IActionResult DeleteUsuario(int id)
    {
        try
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            // Adicione logs ou retorne mensagens de erro para debug
            Console.WriteLine($"Erro: {ex.Message}");
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    private void CriarSenhaHash(string? senha, out byte[] senhaHash, out byte[] senhaSalt)
    {
        if (senha == null) throw new ArgumentNullException("senha");
        if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException("A senha não pode ser vazia ou conter apenas espaços em branco.", "senha");

        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            senhaSalt = hmac.Key;
            senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
        }
    }
}
