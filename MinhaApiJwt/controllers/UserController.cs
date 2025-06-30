using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MinhaApiJwt.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UserController : ControllerBase
    {
        private static readonly string CaminhoArquivo = "usuarios.json";
        private static List<Usuario> usuarios = CarregarUsuariosDoArquivo();

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            usuarios.Add(usuario);
            SalvarUsuariosNoArquivo(usuarios);

            return Ok(new
            {
                mensagem = "Usuário cadastrado com sucesso",
                totalUsuarios = usuarios.Count
            });
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(usuarios);
        }

        private static List<Usuario> CarregarUsuariosDoArquivo()
        {
            if (!System.IO.File.Exists(CaminhoArquivo))
                return new List<Usuario>();

            var json = System.IO.File.ReadAllText(CaminhoArquivo);
            return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
        }

        private static void SalvarUsuariosNoArquivo(List<Usuario> lista)
        {
            var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(CaminhoArquivo, json);
        }
    }

    public class Usuario
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
    