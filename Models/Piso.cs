using System;

namespace Classes;

public class Piso
{
    public int Id { get; }
    public string Localizacion { get; }
    public DateTime FechaEntrada { get; }
    public decimal Precio { get; }
    public bool Comprado { get;set;  }
    public DateTime? FechaCompra { get;set;  }
    public int? IdComprador { get;set;  }

    public Piso(int id, string localizacion, DateTime fechaEntrada, decimal precio, bool comprado, DateTime? fechaCompra, int? idComprador)
    {
        Localizacion = localizacion;
        FechaEntrada = fechaEntrada;
        Precio = precio;
        Comprado = comprado;
        FechaCompra = fechaCompra;
        IdComprador = idComprador;
    }

    
    public static string comprarPiso(Piso piso, string? respuesta, string nombreUsuario)
     {
        string inicio = "";
        if (respuesta != null)
        {
            if(respuesta == "S" || respuesta == "N"){
                if(respuesta == "S"){
                    if(piso.Comprado == true){
                        inicio = "El piso ya esta comprado";
                        return inicio;
                    }
                  var usuario = Usuario.recogerUsuarioPorNombre(nombreUsuario);
                    if(piso.Precio > usuario.Dinero){
                        inicio = "No tienes suficiente saldo.";
                    }else{
                        usuario.Dinero = usuario.Dinero - piso.Precio;
                        piso.IdComprador = usuario.Id;
                        piso.FechaCompra = DateTime.Now;
                        piso.Comprado = true;
                        inicio = "Piso comprado";
                    }

                }
                if(respuesta == "N"){
                    inicio = "No has comprado el piso.";
                }
            }
        }

        return inicio;
    }
}