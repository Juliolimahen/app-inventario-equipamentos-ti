using it_inventory_api.Data;
using it_inventory_api.Models;
using Microsoft.EntityFrameworkCore;

namespace it_inventory_api.Services;

public class EquipamentoService
{
    private readonly AppDbContext _context;

    public EquipamentoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Equipamento>> ListarTodosAsync()
    {
        return await _context.Equipamentos.ToListAsync();
    }

    public async Task<Equipamento?> BuscarPorIdAsync(int id)
    {
        return await _context.Equipamentos.FindAsync(id);
    }

    public async Task<Equipamento> CriarAsync(Equipamento equipamento)
    {
        _context.Equipamentos.Add(equipamento);
        await _context.SaveChangesAsync();
        return equipamento;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var equipamento = await _context.Equipamentos.FindAsync(id);
        if (equipamento == null) return false;

        _context.Equipamentos.Remove(equipamento);
        await _context.SaveChangesAsync();
        return true;
    }
}
