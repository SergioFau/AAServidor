namespace Classes;

public class Piso
{
    public int Id { get; }
    public string Localizacion { get; }
    public DateTime FechaEntrada { get; }
    public decimal Precio { get; }
    public bool Comprado { get; }
    public DateTime FechaCompra { get; }
    public int IdComprador { get; }

    public Piso(int id, string localizacion, string color, DateTime fechaEntrada, decimal precio, bool comprado, DateTime fechaCompra, int idComprador)
    {
        Localizacion = localizacion;
        FechaEntrada = fechaEntrada;
        Precio = precio;
        Comprado = comprado;
        FechaCompra = fechaCompra;
        IdComprador = idComprador;
    }
}