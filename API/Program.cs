using LoginApp;
using System.Text.Json;

 List<User> Users = new List<User>();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

  List<Cliente> clientes = new List<Cliente>();
    int contadorId = 1;

app.MapGet("/", () => "Hello World!");
app.MapPost("/cliente", PostCliente);
app.MapGet("/cliente{id}", GetCliente);
app.MapDelete("/prato/{id}", DeleteCliente);
app.MapPut("/cliente/{id}", UpdateCliente);






  
    void AdicionarCliente(string nome, string email, string senha)
    {
        var cliente = new Cliente{
            Id = 1,
            Nome = nome,
            Email = email,
            Senha = senha
        };
        clientes.Add(cliente);
        Console.WriteLine("Cliente adicionado");
    }

    void GetListar()
    {
        if (clientes.Count == 0)
        {
            Console.WriteLine("nenhum cliente cadastrado");
            return;
        }

        foreach (var cliente in clientes)
        {
            Console.WriteLine($"ID: {cliente.Id}, Nome:{cliente.Nome}, Email: {cliente.Email}");
        }
    }

    IResult PostCliente(Cliente cliente)
{
    clientes.Add(cliente);

    return TypedResults.Created();
}


    IResult GetCliente(int id)
{
    Cliente? cliente = null;
    foreach (Cliente c in clientes)
    {
        if (c.Id == id)
        {
            cliente = c;
            break;
        }
    }
        if (cliente != null)
{
    return TypedResults.Ok(cliente);
}
    return TypedResults.NotFound();
}

    IResult DeleteCliente(int id)
{
    for (int i = 0; i < clientes.Count; i++)
    {
        if (id == clientes[i].Id)
        {
            clientes.RemoveAt(i);
            return TypedResults.NoContent();
        }
    }
     return TypedResults.NotFound();
}

IResult UpdateCliente(Cliente clienteatualizado)
{
    for (int i = 0; i < clientes.Count; i++)
    {
        if(clienteatualizado.Id == clientes[i].Id)
        {
            clientes[i] = clienteatualizado;
            return TypedResults.NoContent();
        } }

        return TypedResults.NotFound();
}




     Cliente ObterClientePorId(int id)
    {
        return clientes.FirstOrDefault( c => c.Id == id);
    }
     void AtualizarCliente(int id, string novoNome, string novoEmail)
    {
        var cliente = ObterClientePorId(id);
        if (cliente != null)
        {
            cliente.Nome = novoNome;
            cliente.Email = novoEmail;
            Console.WriteLine("cliente atualizado!");
        }
        else{
            Console.WriteLine("cliente não encontrado");
        }
    }

    void DeletarClente(int id)
    {
        var cliente = ObterClientePorId(id);
        if (cliente != null){
            clientes.Remove(cliente);
            Console.WriteLine("cliente removido");
            
        }
        else{Console.WriteLine("cliente não encontrado");
        
        }
    }

class Cliente{
    public string Nome {get; set;}
    public string Senha {get; set;}
    public string Email {get; set;}
    public int Id {get; set;}
}


