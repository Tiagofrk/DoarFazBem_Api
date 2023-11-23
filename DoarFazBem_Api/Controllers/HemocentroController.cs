using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DoarFazBem_Api.Context;
using DoarFazBem.Models;
using Microsoft.EntityFrameworkCore;

[Route("v1/Hemocentro")]
[ApiController]
public class HemocentroController : ControllerBase
{
    private readonly AppDbContext _context;

    public HemocentroController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Hemocentro
    [Route("GetHemocentros"), HttpGet]
    public ActionResult<IEnumerable<Hemocentro>> GetHemocentros()
    {
        return _context.Hemocentro.ToList();
    }

    // GET: api/Hemocentro/5
    [Route("GetHemocentro"), HttpGet]
    public ActionResult<Hemocentro> GetHemocentro(int id)
    {
        try
        {
            var Hemocentro = _context.Hemocentro.Find(id);

            if (Hemocentro == null)
            {
                return NotFound();
            }

            return Hemocentro;

        }
        catch (Exception ex)
        {
            // Adicione logs ou retorne mensagens de erro para debug
            Console.WriteLine($"Erro: {ex.Message}");
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    // POST: api/Hemocentro
    [Route("PostHemocentro"), HttpPost]
    public ActionResult<Hemocentro> PostHemocentro([FromBody] Hemocentro Hemocentro)
    {
        try
        {
            _context.Hemocentro.Add(Hemocentro);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetHemocentro), new { id = Hemocentro.id_hemocentro }, Hemocentro);

        }
        catch (Exception ex)
        {
            // Adicione logs ou retorne mensagens de erro para debug
            Console.WriteLine($"Erro: {ex.Message}");
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    // PUT: api/Hemocentro/5
    [Route("PutHemocentro"), HttpPut]
    public IActionResult PutHemocentro(int id, [FromBody] Hemocentro Hemocentro)
    {
        try
        {
            if (id != Hemocentro.id_hemocentro)
            {
                return BadRequest();
            }

            _context.Entry(Hemocentro).State = EntityState.Modified;
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

    // DELETE: api/Hemocentro/5
    [Route("DeleteHemocentro"), HttpDelete]
    public IActionResult DeleteHemocentro(int id)
    {
        try
        {
            var Hemocentro = _context.Hemocentro.Find(id);

            if (Hemocentro == null)
            {
                return NotFound();
            }

            _context.Hemocentro.Remove(Hemocentro);
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
}
