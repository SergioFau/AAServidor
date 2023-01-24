using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Spectre.Console;

namespace Classes;

public class Piso
{
    public int Id { get; }
    public string Localizacion { get; }
    public DateTime FechaEntrada { get; }
    public decimal Precio { get; set; }
    public bool Comprado { get;set;  }
    public DateTime? FechaCompra { get;set;  }
    public string IdComprador { get;set;  }

    public static List<Piso> listaPisos = new List<Piso>();

    public Piso(int id, string localizacion, DateTime fechaEntrada, decimal precio, bool comprado, DateTime? fechaCompra, string idComprador)
    {
        Id = id;
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
                        AnsiConsole.Markup("[underline yellow]El piso ya esta comprado[/]");
                        return inicio;
                    }
                  var usuario = Usuario.recogerUsuarioPorNombre(nombreUsuario);
                    if(piso.Precio > usuario.Dinero){
                        AnsiConsole.Markup("[underline yellow]No tienes suficiente saldo.[/]");
                    }else{
                        usuario.Dinero = usuario.Dinero - piso.Precio;
                        piso.IdComprador = usuario.Nombre;
                        piso.FechaCompra = DateTime.Now;
                        piso.Comprado = true;
                        AnsiConsole.Markup("[underline green]Piso comprado[/]");
                    }

                }
                if(respuesta == "N"){
                        AnsiConsole.Markup("[underline red]No has comprado el piso.[/]");
                }
            }
        }

        return inicio;
    }

        
    public static List<Piso> recogerListado(){
        return listaPisos;
    }
    public static List<Piso> recogerListadoPisos(){
        string personas = recogerJsonPersonas();
        List<Piso> pisosJson = deserializarPisos(personas); 
        listaPisos = pisosJson;
        return pisosJson;
    }

    public static string recogerJsonPersonas(){
        string personas;
        //var reader = new StreamReader("C:\\Users\\sergiofau\\Desktop\\CosasSergio\\ClaseServidor\\Recursos\\Usuarios.json");
        var reader = new StreamReader($@"{Path.GetFullPath(Directory.GetCurrentDirectory())}/Recursos/Pisos.json");
        personas = reader.ReadToEnd();
        return personas;
    }
    public static List<Piso> deserializarPisos(string personas){
        return JsonConvert.DeserializeObject<List<Piso>>(personas);
    }

    public static void cambiarDinero(){
        foreach (var pisos in listaPisos)
        {
            pisos.Precio = ((decimal)(pisos.Precio * 145) / 100);
        }
    }

}