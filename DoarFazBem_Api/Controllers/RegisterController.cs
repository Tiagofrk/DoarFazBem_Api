using Microsoft.AspNetCore.Mvc;
using DoarFazBem.Models;

[ApiController]
[Route("v1/Register")]
public class Register : ControllerBase
{
    [HttpPost("RegisterUser")]
    public IActionResult RegisterUser([FromBody] Cadastro register)
    {
        if (register == null)
        {
            return BadRequest("Os dados de registro não podem ser nulos.");
        }

        // Aqui você pode processar os dados do registro, armazená-los em um banco de dados, etc.

        // Exemplo de retorno bem-sucedido
        return Ok("Registro concluído com sucesso!");
    }

}