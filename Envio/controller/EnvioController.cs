using Microsoft.AspNetCore.Mvc;
using models;       
using Servico;     

namespace Controllers
{
  [ApiController]
[Route("api/[controller]")] // Alterado para "api/[controller]"
public class EnvioController : ControllerBase
{
    [HttpPost("enviar")]
    public async Task<IActionResult> EnviarFormulario([FromBody] FeedBackModel formulario)
    {
        try
        {
            await EmailService.EnviarFormularioAsync(formulario);
            return Ok(new { mensagem = "Formulário enviado com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = $"Erro ao enviar: {ex.Message}" });
        }
    }
}
}
