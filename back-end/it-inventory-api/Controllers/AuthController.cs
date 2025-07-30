using it_inventory_api.Dtos;
using it_inventory_api.Services;
using it_inventory_api.Data;
using Microsoft.AspNetCore.Mvc;
using it_inventory_api.Models;

namespace it_inventory_api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto dto)
    {
        var user = _context.Usuarios.SingleOrDefault(u => u.Email == dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, user.SenhaHash))
            return Unauthorized(new { erro = "credenciais invalidas" });

        var token = TokenService.GenerateToken(user);
        return Ok(new { token });
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto dto)
    {
        var existe = _context.Usuarios.Any(u => u.Email == dto.Email);
        if (existe)
            return BadRequest(new { erro = "email ja cadastrado" });

        var senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

        var novoUsuario = new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            SenhaHash = senhaHash
        };

        _context.Usuarios.Add(novoUsuario);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Register), new { id = novoUsuario.Id }, new { mensagem = "usuario criado com sucesso" });
    }
}
