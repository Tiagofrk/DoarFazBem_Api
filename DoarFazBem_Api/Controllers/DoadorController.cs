using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DoarFazBem_Api.Context;
using DoarFazBem.Models;
using Microsoft.EntityFrameworkCore;

[Route("v1/Doador")]
[ApiController]
public class DoadorController : ControllerBase
{
    private readonly AppDbContext _context;

    public DoadorController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Doador
    [HttpGet]
    public ActionResult<IEnumerable<Doador>> GetDoadors()
    {
        return _context.Doador.ToList();
    }

    // GET: api/Doador/5
    [HttpGet("{id}")]
    public ActionResult<Doador> GetDoador(int id)
    {
        var Doador = _context.Doador.Find(id);

        if (Doador == null)
        {
            return NotFound();
        }

        return Doador;
    }

    // POST: api/Doador
    [HttpPost]
    public ActionResult<Doador> PostDoador(Doador Doador)
    {
        _context.Doador.Add(Doador);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetDoador), new { id = Doador.id_doador }, Doador);
    }

    // PUT: api/Doador/5
    [HttpPut("{id}")]
    public IActionResult PutDoador(int id, Doador Doador)
    {
        if (id != Doador.id_doador)
        {
            return BadRequest();
        }

        _context.Entry(Doador).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Doador/5
    [HttpDelete("{id}")]
    public IActionResult DeleteDoador(int id)
    {
        var Doador = _context.Doador.Find(id);

        if (Doador == null)
        {
            return NotFound();
        }

        _context.Doador.Remove(Doador);
        _context.SaveChanges();

        return NoContent();
    }
}
