using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Helper;

public class SecurityKeyHelper
{
    private static Random random = new Random();

    public static SecurityKey CreateSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
    public static string CreateToken(string securityKey,string key)
    {
        var encoding = new System.Text.ASCIIEncoding();
        byte[] keyByte = encoding.GetBytes(securityKey);
        byte[] messageBytes = encoding.GetBytes(key);
        using (var hmacsha256 = new HMACSHA256(keyByte))
        {
            byte[] hashMessage = hmacsha256.ComputeHash(messageBytes);
            return Convert.ToBase64String(hashMessage);
        }
    }
}
