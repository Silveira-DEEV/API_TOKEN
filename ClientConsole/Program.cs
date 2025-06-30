using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

using var httpClient = new HttpClient();

    // LOGIN
    Console.Write("Usuário: ");
    var user = Console.ReadLine();

    Console.Write("Senha: ");
    var pass = Console.ReadLine();

    var loginPayload = new { username = user, password = pass };
    var loginContent = new StringContent(JsonSerializer.Serialize(loginPayload), Encoding.UTF8, "application/json");

    var loginResponse = await httpClient.PostAsync("http://localhost:5092/auth/login", loginContent);
    var loginJson = await loginResponse.Content.ReadAsStringAsync();

    if (!loginResponse.IsSuccessStatusCode)
    {
        Console.WriteLine("Falha ao logar: " + loginJson);
        return;
    }

    var token = JsonDocument.Parse(loginJson).RootElement.GetProperty("token").GetString();

    // Atribui o token no header
    httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", token);

    // CADASTRO
    Console.Write("Nome do novo usuário: ");
    var nome = Console.ReadLine();

    Console.Write("Idade: ");
    var idade = int.Parse(Console.ReadLine());

    var cadastroPayload = new { nome, idade };
    var cadastroContent = new StringContent(JsonSerializer.Serialize(cadastroPayload), Encoding.UTF8, "application/json");

    var cadastroResponse = await httpClient.PostAsync("http://localhost:5092/usuarios/cadastrar", cadastroContent);
    var cadastroJson = await cadastroResponse.Content.ReadAsStringAsync();

    Console.WriteLine("Resposta da API:");
    Console.WriteLine(cadastroJson);
