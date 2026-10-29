using AllIsWell.Shared.Kernel;

namespace AllIsWell.Users.Domain;

public static class UserErrors
{
    public static readonly Error EmailAlreadyInUse = Error.Conflict(
        "Users.EmailAlreadyInUse",
        "This email address is already registered.");

    public static readonly Error InvalidCredentials = Error.Unauthorized(
        "Users.InvalidCredentials",
        "Email or password is incorrect.");
}
