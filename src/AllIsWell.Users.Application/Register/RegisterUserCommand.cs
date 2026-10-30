namespace AllIsWell.Users.Application.Register;

public class RegisterUserCommand
{
    public RegisterUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; }

    public string Password { get; }
}
