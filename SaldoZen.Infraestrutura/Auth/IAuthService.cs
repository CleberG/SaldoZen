using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoZen.Infraestrutura.Auth
{
    public interface IAuthService
    {
        string ComputeHash(string input);
        string GenerateToken( string senha, string role);
    }
}
