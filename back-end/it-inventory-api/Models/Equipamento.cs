namespace it_inventory_api.Models;

public class Equipamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public string NumeroSerie { get; set; }
    public string Localizacao { get; set; }
    public string UsuarioResponsavel { get; set; }
    public string Status { get; set; }
    public DateTime DataAquisicao { get; set; }
}
