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
    [HttpGet]
    [Route("GetDonations")]
    public ActionResult<IEnumerable<Donation>> GetDonations()
    {
        return _context.Donation.ToList();
    }

    // GET: api/Donation/5
    [HttpGet("{id}")]
    [Route("GetDonation")]
    public ActionResult<Donation> GetDonation(int id)
    {
        var Donation = _context.Donation.Find(id);

        if (Donation == null)
        {
            return NotFound();
        }

        return Donation;
    }

    // POST: api/Donation
    [HttpPost]
    [Route("PostDonation")]
    public ActionResult<Donation> PostDonation(Donation Donation)
    {
        _context.Donation.Add(Donation);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetDonation), new { id = Donation.id_donation }, Donation);
    }

    // PUT: api/Donation/5
    [HttpPut("{id}")]
    [Route("PutDonation")]
    public IActionResult PutDonation(int id, Donation Donation)
    {
        if (id != Donation.id_donation)
        {
            return BadRequest();
        }

        _context.Entry(Donation).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Donation/5
    [HttpDelete("{id}")]
    [Route("DeleteDonation")]
    public IActionResult DeleteDonation(int id)
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
}
