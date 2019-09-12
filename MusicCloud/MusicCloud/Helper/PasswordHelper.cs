
namespace MusicCloud.Helper
{
    public class PasswordHelper
    {
        public bool VerifyPassword(string password, string hash)
        {
            return SecurePasswordHasher.Verify(password, hash);
        }
    }
}