namespace it_inventory_api.Dtos;

public class EquipamentoDto
{
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string NumeroSerie { get; set; } = string.Empty;
    public string Localizacao { get; set; } = string.Empty;
    public string UsuarioResponsavel { get; set; } = string.Empty;
    public string Status { get; set; } = "Ativo";
    public DateTime DataAquisicao { get; set; } = DateTime.UtcNow;
}
