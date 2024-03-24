using Havira.Tarefas.Application.DTOs.User;
using Havira.Tarefas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Havira.Tarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public UsuariosController(IUsuarioService usuarioService,
                                  IConfiguration configuration,
                                  ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(UsuarioCreateDto usuarioDto)
        {
            try
            {
                var usuario = await _usuarioService.CreateUsuarioAsync(usuarioDto);
                return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsuarioById(Guid id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            var usuario = await _usuarioService.GetUsuarioByEmailAsync(userLogin.Email);
            if (usuario == null || !_usuarioService.VerifyPassword(userLogin.Password, usuario.Password))
            {
                return Unauthorized("Credenciais inválidas.");
            }

            var token = _tokenService.GenerateToken(usuario);
            return Ok(new { token });
        }
    }
}
