using Havira.Tarefas.Application.DTOs.Requests.User;
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
        public async Task<IActionResult> Register(UserCreateDto usuarioDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var usuario = await _usuarioService.CreateUsuarioAsync(usuarioDto);
                return CreatedAtAction(nameof(Register), new { email = usuario.Email }, usuarioDto.Email);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var usuario = await _usuarioService.GetUsuarioByEmailAsync(userLogin.Email);

                if (usuario == null || !_usuarioService.VerifyPassword(userLogin.Password, usuario.Password))
                {
                    return Unauthorized("Credenciais inválidas.");
                }

                var token = _tokenService.GenerateToken(usuario);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
