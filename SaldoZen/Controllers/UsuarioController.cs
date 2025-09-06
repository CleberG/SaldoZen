using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaldoZen.Aplicacao.Dtos.Autorizacao;
using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Model;
using SaldoZen.Domain.ValueObject;
using SaldoZen.Infraestrutura.Auth;
using SaldoZen.Infraestrutura.Context;
using System.Threading.Tasks;

namespace SaldoZen.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IRepositoryBase<Usuario> _repository;
        private readonly IUnitOfWork _IUnitOfWork;

        public UsuarioController(IAuthService authService, IRepositoryBase<Usuario> repository, IUnitOfWork iUnitOfWork)
        {
            _authService = authService;
            _repository = repository;
            _IUnitOfWork = iUnitOfWork;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(LoginCreateRequest model)
        {
            var nome = new Nome(model.NomeCompleto);
            var email = new EmailCompleto(model.Email);

            var hash = _authService.ComputeHash(model.Senha);
            var senha = new Senha(hash);

            var user = new Usuario(nome, model.DataAniversario, email, senha, model.Role);

            await _repository.AddAsync(user);
            await _IUnitOfWork.CommitAsync();

            return NoContent();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest model)
        {

            var hash = _authService.ComputeHash(model.Senha);
            var senha = new Senha(hash);

            var user = new Usuario(nome, model.DataAniversario, email, senha, model.Role);

            await _repository.AddAsync(user);
            await _IUnitOfWork.CommitAsync();

            return NoContent();
        }
    }
}
