using it_inventory_api.Data;
using it_inventory_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace it_inventory_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipamentosController : ControllerBase
{
    private readonly AppDbContext _context;

    public EquipamentosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipamento>>> Get()
    {
        return await _context.Equipamentos.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Equipamento>> Post(Equipamento equipamento)
    {
        _context.Equipamentos.Add(equipamento);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = equipamento.Id }, equipamento);
    }
}
