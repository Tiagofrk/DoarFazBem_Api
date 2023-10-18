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
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios()
    {
        return _context.Usuario.ToList();
    }

    // GET: api/Usuario/5
    [HttpGet("{id}")]
    public ActionResult<Usuario> GetUsuario(int id)
    {
        var usuario = _context.Usuario.Find(id);

        if (usuario == null)
        {
            return NotFound();
        }

        return usuario;
    }

    // POST: api/Usuario
    [HttpPost]
    public ActionResult<Usuario> PostUsuario(Usuario usuario)
    {
        _context.Usuario.Add(usuario);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetUsuario), new { id = usuario.cpf }, usuario);
    }

    // PUT: api/Usuario/5
    [HttpPut("{id}")]
    public IActionResult PutUsuario(int id, Usuario usuario)
    {
        if (id != usuario.cpf)
        {
            return BadRequest();
        }

        _context.Entry(usuario).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Usuario/5
    [HttpDelete("{id}")]
    public IActionResult DeleteUsuario(int id)
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
}
