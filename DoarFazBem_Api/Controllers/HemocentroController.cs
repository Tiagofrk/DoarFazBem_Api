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
    [HttpGet]
    public ActionResult<IEnumerable<Hemocentro>> GetHemocentros()
    {
        return _context.Hemocentro.ToList();
    }

    // GET: api/Hemocentro/5
    [HttpGet("{id}")]
    public ActionResult<Hemocentro> GetHemocentro(int id)
    {
        var Hemocentro = _context.Hemocentro.Find(id);

        if (Hemocentro == null)
        {
            return NotFound();
        }

        return Hemocentro;
    }

    // POST: api/Hemocentro
    [HttpPost]
    public ActionResult<Hemocentro> PostHemocentro(Hemocentro Hemocentro)
    {
        _context.Hemocentro.Add(Hemocentro);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetHemocentro), new { id = Hemocentro.id_hemocentro }, Hemocentro);
    }

    // PUT: api/Hemocentro/5
    [HttpPut("{id}")]
    public IActionResult PutHemocentro(int id, Hemocentro Hemocentro)
    {
        if (id != Hemocentro.id_hemocentro)
        {
            return BadRequest();
        }

        _context.Entry(Hemocentro).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Hemocentro/5
    [HttpDelete("{id}")]
    public IActionResult DeleteHemocentro(int id)
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
}
