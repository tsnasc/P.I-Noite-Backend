namespace LoginApp{

class LoginApp{
    public string Username {get; set;}
    public string Password {get; set;} 
}


class BancoDeDados{
    static List<User> Users = new List<User>
    {
        new User {Username = "admin", Password = "123456"},
        new User {Username = "user", Password = "password"}
    };
    static void Main(string[] args)
    {
        Console.WriteLine("Digite seu nome de usuario:");
        string? Username = Console.ReadLine();

        Console.WriteLine("Digite sua senha:");
        string? Password = Console.ReadLine();

        if (Login(Username, Password))
        {
            Console.WriteLine("Login ok!");
        }
        else{
            Console.WriteLine("login se fudeo kkk!");
        }
    }
    static bool Login(string username, string password)
    {
        foreach(var user in Users)
        {
            if (user.Username == username && user.Password == password)
            {
                return true;
            }
        }
        return false;
    }
}

}