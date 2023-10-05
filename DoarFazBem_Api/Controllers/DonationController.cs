using Microsoft.AspNetCore.Mvc;
using DoarFazBem.Models;

namespace DoarFazBem.Controllers;

[ApiController]
[Route("v1/Donation")]
public class Donation : ControllerBase
{
    [HttpPost("DonationForm")]
    public IActionResult DonationForm([FromBody] Doador donation)
    {
        if (donation == null)
        {
            return BadRequest("Os dados de registro não podem ser nulos.");
        }

        // Aqui você pode processar os dados do registro, armazená-los em um banco de dados, etc.

        // Exemplo de retorno bem-sucedido
        return Ok("Registro concluído com sucesso!");
    }
}