using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DoarFazBem_Api.Context;
using DoarFazBem.Models;
using Microsoft.EntityFrameworkCore;

[Route("v1/Donation")]
[ApiController]
public class DonationController : ControllerBase
{
    private readonly AppDbContext _context;

    public DonationController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Donation
    [Route("GetDonations"), HttpGet]
    public ActionResult<IEnumerable<Donation>> GetDonations()
    {
        return _context.Donation.ToList();
    }

    // GET: api/Donation/5
    [Route("GetDonation"), HttpGet]
    public ActionResult<Donation> GetDonation(int id)
    {
        try
        {
            var Donation = _context.Donation.Find(id);

            if (Donation == null)
            {
                return NotFound();
            }

            return Donation;

        }
        catch (Exception ex)
        {
            // Adicione logs ou retorne mensagens de erro para debug
            Console.WriteLine($"Erro: {ex.Message}");
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    // POST: api/Donation
    [Route("PostDonation"), HttpPost]
    public ActionResult<Donation> PostDonation([FromBody] Donation Donation)
    {
        try
        {
            _context.Donation.Add(Donation);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDonation), new { id = Donation.id_donation }, Donation);

        }
        catch (Exception ex)
        {
            // Adicione logs ou retorne mensagens de erro para debug
            Console.WriteLine($"Erro: {ex.Message}");
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    // PUT: api/Donation/5
    [Route("PutDonation"), HttpPut]
    public IActionResult PutDonation(int id, [FromBody] Donation Donation)
    {
        try
        {
            if (id != Donation.id_donation)
            {
                return BadRequest();
            }

            _context.Entry(Donation).State = EntityState.Modified;
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

    // DELETE: api/Donation/5
    [Route("DeleteDonation"), HttpDelete]
    public IActionResult DeleteDonation(int id)
    {
        try
        {
            var Donation = _context.Donation.Find(id);

            if (Donation == null)
            {
                return NotFound();
            }

            _context.Donation.Remove(Donation);
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
