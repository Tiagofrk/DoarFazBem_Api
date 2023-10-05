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
            return BadRequest("Os dados de registro n�o podem ser nulos.");
        }

        // Aqui voc� pode processar os dados do registro, armazen�-los em um banco de dados, etc.

        // Exemplo de retorno bem-sucedido
        return Ok("Registro conclu�do com sucesso!");
    }

}