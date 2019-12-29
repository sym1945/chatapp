using System.Security;

namespace chatapp
{
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}
