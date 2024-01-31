using System;
using System.Xml.Linq;
using Core.Entities;
using Core.Utilities.Security.Models;

namespace Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    TokenModel CreateToken(User user);
}
