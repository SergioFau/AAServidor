namespace Classes;
using Spectre.Console;

class Menu {

public static void ListadoCoches(){
    List<Coche> listadoCochesMostrar = Coche.recogerListado();
    var table = new Table();
    // Add some columns
    table.AddColumn("Id");
    table.AddColumn("Marca");
    table.AddColumn("Color");
    table.AddColumn("FechaEntrada");
    table.AddColumn("Precio");
    table.AddColumn("Caballos");
    table.AddColumn("Comprado");
    table.AddColumn("FechaCompra");
    table.AddColumn("Comprador");
    foreach (var coche in listadoCochesMostrar)
    {
        table.AddRow(coche.Id.ToString(), coche.Marca.ToString(), coche.Color.ToString(), coche.FechaEntrada.ToString(), coche.Precio.ToString(), coche.Caballos.ToString(), coche.Comprado.ToString(), coche.FechaCompra.ToString(), coche.IdComprador.ToString());
    }
    // Render the table to the console
    AnsiConsole.Write(table);
    }

public static void ListadoCochesFiltro(string textoFiltro){
    List<Coche> listadoCochesMostrar = Coche.recogerListado();
    var table = new Table();
    // Add some columns
    table.AddColumn("Id");
    table.AddColumn("Marca");
    table.AddColumn("Color");
    table.AddColumn("FechaEntrada");
    table.AddColumn("Precio");
    table.AddColumn("Caballos");
    table.AddColumn("Comprado");
    table.AddColumn("FechaCompra");
    table.AddColumn("IdComprador");
    foreach (var coche in listadoCochesMostrar)
    {
         if (coche != null)
            {
                if (coche.Marca.Contains(textoFiltro))
                {
                    table.AddRow(coche.Id.ToString(), coche.Marca.ToString(), coche.Color.ToString(), coche.FechaEntrada.ToString(), coche.Precio.ToString(), coche.Caballos.ToString(), coche.Comprado.ToString(), coche.FechaCompra.ToString(), coche.IdComprador.ToString());
                }
            }
    }
    // Render the table to the console
    AnsiConsole.Write(table);
    }

    public static void ListadoPisos(){
    List<Piso> listadoPisosMostrar = Piso.recogerListado();
    var table = new Table();
    // Add some columns
    table.AddColumn("Id");
    table.AddColumn("Localización");
    table.AddColumn("FechaEntrada");
    table.AddColumn("Precio");
    table.AddColumn("Comprado");
    table.AddColumn("FechaCompra");
    table.AddColumn("Comprador");
    foreach (var piso in listadoPisosMostrar)
    {
        table.AddRow(piso.Id.ToString(), piso.Localizacion.ToString(), piso.FechaEntrada.ToString(), piso.Precio.ToString(), piso.Comprado.ToString(), piso.FechaCompra.ToString(), piso.IdComprador.ToString());
    }
    // Render the table to the console
    AnsiConsole.Write(table);
    }

public static void ListadoPisosFiltro(string textoFiltro){
    List<Piso> listadoPisosMostrar = Piso.recogerListado();
    var table = new Table();
    // Add some columns
    table.AddColumn("Id");
    table.AddColumn("Localización");
    table.AddColumn("FechaEntrada");
    table.AddColumn("Precio");
    table.AddColumn("Comprado");
    table.AddColumn("FechaCompra");
    table.AddColumn("Comprador");
    foreach (var piso in listadoPisosMostrar)
    {
         if (piso != null)
            {
                if (piso.Localizacion.Contains(textoFiltro))
                {
                    table.AddRow(piso.Id.ToString(), piso.Localizacion.ToString(), piso.FechaEntrada.ToString(), piso.Precio.ToString(), piso.Comprado.ToString(), piso.FechaCompra.ToString(), piso.IdComprador.ToString());
    }
            }
    }
    // Render the table to the console
    AnsiConsole.Write(table);
    }
}