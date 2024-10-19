using LoginApp;
using System.Text.Json;

 List<User> Users = new List<User>();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Run();
app.MapGet("/usuarios",GetUser);
app.MapGet("/usuario", PostUser);


string GetUser()
{
    string Banco = Usuario();

    return Banco; 
}

string Usuario()
{
    List<User> Users = new List<User>
    {
        new User {Username = "admin", Password = "123456"},
        new User {Username = "user", Password = "password"}
    };
    string caminho = $"{Environment.CurrentDirectory}\\json\\usuario_auto.json";
    string json = JsonSerializer.Serialize(Usuario, new JsonSerializerOptions() {WriteIndented=true});
    File.WriteAllText(caminho, json);
    return json;
}

IResult PostUser(User user)
{
    Users.Add(user);

    return TypedResults.Created();
}
