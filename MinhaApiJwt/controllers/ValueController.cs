using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MinhaApiJwt.Controllers
{
    [ApiController]
    [Route("valores")]
    public class ValueController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(new { mensagem = "Você foi autenticado com sucesso" });
        }
    }
}
