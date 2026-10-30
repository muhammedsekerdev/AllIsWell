using System.Net.Mail;
using AllIsWell.Shared.Kernel;
using AllIsWell.Users.Application.Abstractions;
using AllIsWell.Users.Domain;

namespace AllIsWell.Users.Application.Register;

public class RegisterUserHandler
{
    private const int MinimumPasswordLength = 8;

    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> HandleAsync(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        if (!IsValidEmail(command.Email))
        {
            return UserErrors.EmailInvalid;
        }

        if (command.Password == null || command.Password.Length < MinimumPasswordLength)
        {
            return UserErrors.PasswordTooShort;
        }

        string normalizedEmail = command.Email.Trim().ToLowerInvariant();

        bool emailExists = await _userRepository.EmailExistsAsync(normalizedEmail, cancellationToken);
        if (emailExists)
        {
            return UserErrors.EmailAlreadyInUse;
        }

        string passwordHash = _passwordHasher.Hash(command.Password);

        User user = User.Create(normalizedEmail, passwordHash, UserType.Member, DateTime.UtcNow);

        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }

    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        return MailAddress.TryCreate(email.Trim(), out _);
    }
}
