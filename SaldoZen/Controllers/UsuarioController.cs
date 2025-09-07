using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaldoZen.Aplicacao.Dtos.Autorizacao;
using SaldoZen.Domain.Interfaces;
using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Model;
using SaldoZen.Domain.ValueObject;
using SaldoZen.Infraestrutura.Auth;

namespace SaldoZen.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
        readonly IAuthService _authService;
        readonly IUsuarioRepository _usuarioRepository;
        readonly IUnitOfWork _IUnitOfWork;

        public UsuarioController(IAuthService authService, IUnitOfWork iUnitOfWork, IUsuarioRepository usuarioRepository)
        {
            _authService = authService;
            _IUnitOfWork = iUnitOfWork;
            _usuarioRepository = usuarioRepository;
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

            await _usuarioRepository.AddAsync(user);
            await _IUnitOfWork.CommitAsync();

            return NoContent();
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest request)
        {

            var usuario = await _usuarioRepository.GetByEmailAsync(request.Email);
            if(usuario == null || !_authService.VerifyPassword(request.Senha, usuario.Senha.SenhaHash))
                return Unauthorized("Usuário não encontrado");

            var token = _authService.GenerateToken(usuario.Login.Email, usuario.Role);

            return Ok(new { token });
        }
    }
}
