using DoarFazBem.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoarFazBem.Controllers;

[ApiController]
[Route("v1/Users")]
public class Users : ControllerBase
{
    [HttpPost("UsersGet")]
    public IActionResult UsersGet([FromBody] Usuario users)
    {
        if (users == null)
        {
            return BadRequest("Os dados de registro não podem ser nulos.");
        }

        // Aqui você pode processar os dados do registro, armazená-los em um banco de dados, etc.

        // Exemplo de retorno bem-sucedido
        return Ok("Registro concluído com sucesso!");
    }
}