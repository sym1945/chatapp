using System.Security;

namespace chatapp.core
{
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}
