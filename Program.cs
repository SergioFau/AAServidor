using Classes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using Spectre.Console;
try
{
    Console.ForegroundColor = ConsoleColor.Black;
    Console.BackgroundColor = ConsoleColor.Blue;
    List<Usuario> listadoUsuarios = new List<Usuario>();
    listadoUsuarios = Usuario.recogerListadoUsuarios();
    List<Coche> listadoCoches = new List<Coche>();
    listadoCoches = Coche.recogerListadoCoches();    
    List<Piso> listaPisos = new List<Piso>();
    listaPisos = Piso.recogerListadoPisos();    
    Console.WriteLine("");
    Lineas.Pisoche();
    var dinero = Environment.GetEnvironmentVariable("dinero");
    if(dinero == "Euro"){
        Lineas.Euros();
    }
    if(dinero == "Dolar"){
        Lineas.Dolares();
    }
    Console.WriteLine(""); 
    Lineas.Bienvenido();   
    Console.WriteLine(""); 
   
    bool inicioSesion = false;
    string? variableNombre = "";
    string? variableContraseña = "";
    while (inicioSesion == false)
    {
        try{
            Console.WriteLine("");
            Console.WriteLine("Nombre:");
            variableNombre = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Contraseña:");
            variableContraseña = Console.ReadLine();
            Console.WriteLine("");
            inicioSesion = Usuario.inicioSesionUsuario(variableNombre, variableContraseña, listadoUsuarios);
            if (inicioSesion == true)
            {
                Lineas.DatosCorrectos();
            }
            else
            {
                Lineas.DatosIncorrectos();
            }
        }
        catch(Exception ex)
        {                    
            AnsiConsole.Markup("[underline red]Ha habido un error a la hora de iniciar sesión[/]");
            Console.WriteLine("");
            AnsiConsole.Markup("[underline red]"+ex.Message+"[/]");
            LogController.WriteLog("Ha habido un error a la hora de iniciar sesión: " + ex.Message);
            Console.WriteLine("");
        }    
    }

    bool verListado = false;
    if (variableNombre == "Sergio")
    {
        Console.WriteLine("");
        Console.WriteLine("Bienvenido Señor " + variableNombre);
        bool repetir = false; //USAREMOS ESTA VARIABLE PARA VOLVER AL PRINCIPIO CUANDO HAYAMOS AÑADIDO ALGO
        while (repetir == false)
        {
            Console.WriteLine("Quiere añadir un producto o ver los listados");
            Console.WriteLine("");
            Console.WriteLine("1 - Añadir Producto");
            Console.WriteLine("2 - Ver Listado");
            Console.WriteLine("3 - Ver Listado Errores");
            string variablePrivado = Console.ReadLine();
            switch (variablePrivado)
            {
                case "1":
                    Console.WriteLine("Vamos a añadir algun producto");
                    Console.WriteLine("");
                    Console.WriteLine("1 - Coche");
                    Console.WriteLine("2 - Piso");
                    string anadirProducto = Console.ReadLine();
                    switch (anadirProducto)
                    {
                        case "1":
                        try{
                            Console.WriteLine("");
                            Console.WriteLine("Vamos a añadir un nuevo coche");
                            Console.WriteLine("");
                            Console.WriteLine("Marca");
                            string marca = Console.ReadLine();
                            Console.WriteLine("Color");
                            string color = Console.ReadLine();
                            Console.WriteLine("Precio");
                            string precio = Console.ReadLine();
                            Console.WriteLine("Caballos");
                            string caballos = Console.ReadLine();
                            Coche cocheanadir = new Coche(listadoCoches.LastOrDefault().Id + 1, marca, color, DateTime.Now, Convert.ToDecimal(precio), false, null, "", Int32.Parse(caballos));
                            listadoCoches.Add(cocheanadir);
                            Console.WriteLine("");
                            AnsiConsole.Markup("[underline green]Coche añadido[/]");
                            Console.WriteLine("");
                            }
                            catch(Exception ex)
                            {                    
                                AnsiConsole.Markup("[underline red]Ha habido un error a la hora de añadir el coche[/]");
                                Console.WriteLine("");
                                AnsiConsole.Markup("[underline red]"+ex.Message+"[/]");
                                LogController.WriteLog("Ha habido un error a la hora de añadir el coche: " + ex.Message);
                                Console.WriteLine("");
                            }                        
                            break;
                         case "2":
                         try{
                            Console.WriteLine("");
                            Console.WriteLine("Vamos a añadir un nuevo piso");
                            Console.WriteLine("");
                            Console.WriteLine("Localización");
                            string localizacionPiso = Console.ReadLine();
                            Console.WriteLine("Precio");
                            string precioPiso = Console.ReadLine();
                            Piso pisoanadir = new Piso(listaPisos.LastOrDefault().Id + 1, localizacionPiso, DateTime.Now, Convert.ToDecimal(precioPiso), false, null, "");
                            listaPisos.Add(pisoanadir);
                            Console.WriteLine("");
                            AnsiConsole.Markup("[underline green]Piso añadido[/]");
                            Console.WriteLine("");
                         }catch(Exception ex)
                            {                    
                                AnsiConsole.Markup("[underline red]Ha habido un error a la hora de añadir el piso[/]");
                                Console.WriteLine("");
                                AnsiConsole.Markup("[underline red]"+ex.Message+"[/]");
                                LogController.WriteLog("Ha habido un error a la hora de añadir el piso: " + ex.Message);
                                Console.WriteLine("");
                            }  
                            break;
                    }
                    break;
                case "2":
                    verListado = true;
                    repetir = true;
                    break;
                case "3":
                    LogController.ReadLog();
                    Console.WriteLine("");
                    break;
            }

        }
    }

    if (variableNombre == "Alex")
    {
        verListado = true;

    }
    Console.WriteLine("Bienvenido Usuario " + variableNombre);
    while (verListado == true)
    {
        Console.WriteLine("");
        Console.WriteLine("Selecciona el listado que quieres ver");
        Console.WriteLine("");
        Console.WriteLine("1- Coches");
        Console.WriteLine("2- Pisos");
        Console.WriteLine("3- Salir");
        string elegir = Console.ReadLine();
        Console.WriteLine("");
        switch (elegir)
        {
            case "1":
                Lineas.ListadoCochesTexto();
                Menu.ListadoCoches();
                Console.WriteLine("");
                Console.WriteLine("Si quiere ver los detalles del coche, indique el id del coche");
                Console.WriteLine("Si quiere filtrar pulsa 0");
                string numeroListadoCoche = "0";
                numeroListadoCoche = Console.ReadLine();
                try{
                if (numeroListadoCoche == "0")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Escribe el texto para filtrarlo (solo marcas)");
                    string textoFiltro = "";
                    textoFiltro = Console.ReadLine();
                    Menu.ListadoCochesFiltro(textoFiltro);  
                    Console.WriteLine("");
                    Console.WriteLine("Si quiere ver los detalles del coche, indique el id del coche");
                    Console.WriteLine("");
                    string numeroListadoCocheFiltrado = "0";
                    numeroListadoCocheFiltrado = Console.ReadLine();
                    foreach (var coche2 in listadoCoches.Where(x => x.Id.ToString() == numeroListadoCocheFiltrado))
                    {
                        if (coche2 != null)
                        {
                            Console.WriteLine("Coche: " + coche2.Marca);
                            Console.WriteLine("Color: " + coche2.Color);
                            Console.WriteLine("Fecha Entrada : " + coche2.FechaEntrada);
                            Console.WriteLine("Precio: " + coche2.Precio);
                            Console.WriteLine("Caballos: " + coche2.Caballos);
                            Console.WriteLine("Comprado: " + (coche2.Comprado == false ? "No" : "Si"));
                            Console.WriteLine("");
                            Console.WriteLine("¿Quieres comprar este coche?");
                            Console.WriteLine("S - Si");
                            Console.WriteLine("N - No");
                            string comprarCocheString = "";
                            comprarCocheString = Console.ReadLine();
                            Coche.comprarCoche(coche2, comprarCocheString, variableNombre);
                            Console.WriteLine("");
                        }
                    }
                }                           
                else
                {
                    foreach (var coche in listadoCoches.Where(x => x.Id.ToString() == numeroListadoCoche))
                    {
                        if (coche != null)
                        {
                            Console.WriteLine("Coche: " + coche.Marca);
                            Console.WriteLine("Color: " + coche.Color);
                            Console.WriteLine("Fecha Entrada : " + coche.FechaEntrada);
                            Console.WriteLine("Precio: " + coche.Precio);
                            Console.WriteLine("Caballos: " + coche.Caballos);
                            Console.WriteLine("Comprado: " + (coche.Comprado == false ? "No" : "Si"));
                            Console.WriteLine("");
                            Console.WriteLine("¿Quieres comprar este coche?");
                            Console.WriteLine("S - Si");
                            Console.WriteLine("N - No");
                            string comprarCocheString = "";
                            comprarCocheString = Console.ReadLine();
                            Coche.comprarCoche(coche, comprarCocheString, variableNombre);
                            Console.WriteLine("");
                        }
                    }
                }
                }
                    catch(Exception ex)
                    {                    
                        AnsiConsole.Markup("[underline red]"+ex.Message+"[/]");
                        LogController.WriteLog("Ha habido un error: " + ex.Message);
                        Console.WriteLine("");
                    } 
                break;
            case "2":
                Lineas.ListadoPisosTexto();
                Menu.ListadoPisos();
                Console.WriteLine("");
                Console.WriteLine("Si quiere ver los detalles del piso, indique el id del piso");
                Console.WriteLine("Si quiere filtrar pulsa 0");
                string numeroListadoPiso = "0";
                numeroListadoPiso = Console.ReadLine();
                try{
                if (numeroListadoPiso == "0")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Escribe el texto para filtrarlo (solo localización)");
                    string textoFiltro = "";
                    textoFiltro = Console.ReadLine();
                    Menu.ListadoPisosFiltro(textoFiltro);  
                    Console.WriteLine("");
                    Console.WriteLine("Si quiere ver los detalles del coche, indique el id del piso");
                    Console.WriteLine("");
                    string numeroListadoPisoFiltrado = "0";
                        numeroListadoPisoFiltrado = Console.ReadLine();
                        foreach (var pisoDos in listaPisos.Where(x => x.Id.ToString() == numeroListadoPisoFiltrado))
                        {
                            if (pisoDos != null)
                            {
                                Console.WriteLine("Id: " + pisoDos.Id);
                                Console.WriteLine("Localización: " + pisoDos.Localizacion);
                                Console.WriteLine("Fecha Entrada : " + pisoDos.FechaEntrada);
                                Console.WriteLine("Precio: " + pisoDos.Precio);
                                Console.WriteLine("Comprado: " + (pisoDos.Comprado == false ? "No" : "Si"));
                                Console.WriteLine("");
                                Console.WriteLine("¿Quieres comprar este piso?");
                                Console.WriteLine("S - Si");
                                Console.WriteLine("N - No");
                                string comprarPisoString = "";
                                comprarPisoString = Console.ReadLine();
                                string respuesta = Piso.comprarPiso(pisoDos, comprarPisoString, variableNombre);
                                Console.WriteLine(respuesta);
                            }
                        }

                }
                else
                {
                    foreach (var piso in listaPisos.Where(x => x.Id.ToString() == numeroListadoPiso))
                    {
                        if (piso != null)
                        {
                            Console.WriteLine("Id: " + piso.Id);
                            Console.WriteLine("Localización: " + piso.Localizacion);
                            Console.WriteLine("Fecha Entrada : " + piso.FechaEntrada);
                            Console.WriteLine("Precio: " + piso.Precio);
                            Console.WriteLine("Comprado: " + (piso.Comprado == false ? "No" : "Si"));
                            Console.WriteLine("");
                            Console.WriteLine("¿Quieres comprar este piso?");
                            Console.WriteLine("S - Si");
                            Console.WriteLine("N - No");
                            string comprarPisoString = "";
                            comprarPisoString = Console.ReadLine();
                            string respuesta = Piso.comprarPiso(piso, comprarPisoString, variableNombre);
                            Console.WriteLine(respuesta);
                        }
                    }
                }
                }
                    catch(Exception ex)
                    {                    
                        AnsiConsole.Markup("[underline red]"+ex.Message+"[/]");
                        LogController.WriteLog("Ha habido un error: " + ex.Message);
                        Console.WriteLine("");
                    } 
                break;
                
           case "3":
                AnsiConsole.Markup("[underline blue]Has salido[/]");
                verListado = false;
                break;
            default:
                break;
        }
    }
}
catch(Exception ex)
{                    
    AnsiConsole.Markup("[underline red]"+ex.Message+"[/]");
    LogController.WriteLog("Ha habido un error: " + ex.Message);
    Console.WriteLine("");
}  