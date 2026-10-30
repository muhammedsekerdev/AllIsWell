using AllIsWell.Shared.Kernel;

namespace AllIsWell.Users.Domain;

public static class UserErrors
{
    public static readonly Error EmailInvalid = Error.Validation(
        "Users.EmailInvalid",
        "Email address is not valid.");

    public static readonly Error PasswordTooShort = Error.Validation(
        "Users.PasswordTooShort",
        "Password must be at least 8 characters long.");

    public static readonly Error EmailAlreadyInUse = Error.Conflict(
        "Users.EmailAlreadyInUse",
        "This email address is already registered.");

    public static readonly Error InvalidCredentials = Error.Unauthorized(
        "Users.InvalidCredentials",
        "Email or password is incorrect.");
}
