using Classes;
using System;
using System.Collections.Generic;

try
{
    Usuario sergio = new Usuario(1, "Sergio", "123", 1000000, true);
    Usuario.anadirUsuarioLista(sergio);
    Usuario alex = new Usuario(1, "Alex", "456", 50000, false);
    Usuario.anadirUsuarioLista(alex);

    Coche ferrari = new Coche(1, "Ferrari", "Rojo", DateTime.Now, 50000, false, null, null, 100);
    Coche lambo = new Coche(2, "Lamborghini", "Blanco", DateTime.Now, 40000, false, null, null, 200);
    Coche bugatti = new Coche(3, "Bugatti", "Naranja", DateTime.Now, 75000, false, null, null, 250);
    Coche nissan = new Coche(4, "Nissan", "Azul", DateTime.Now, 1500, false, null, null, 60);
    Coche batmovil = new Coche(5, "Batmovil", "Negro", DateTime.Now, 1000000, false, null, null, 500);
    List<Coche> listadoCoches = new List<Coche>();
    listadoCoches.Add(ferrari);
    listadoCoches.Add(lambo);
    listadoCoches.Add(bugatti);
    listadoCoches.Add(nissan);
    listadoCoches.Add(batmovil);
    Piso piso1 = new Piso(1, "Zaragoza", DateTime.Now, 50000, false, null, null);
    Piso piso2 = new Piso(2, "Madrid", DateTime.Now, 40000, false, null, null);
    Piso piso3 = new Piso(3, "Barcelona", DateTime.Now, 75000, false, null, null);
    Piso piso4 = new Piso(4, "Almeria", DateTime.Now, 1500, false, null, null);
    Piso piso5 = new Piso(5, "Mordor", DateTime.Now, 1000000, false, null, null);
    List<Piso> listadoPisos = new List<Piso>();
    listadoPisos.Add(piso1);
    listadoPisos.Add(piso2);
    listadoPisos.Add(piso3);
    listadoPisos.Add(piso4);
    listadoPisos.Add(piso5);
    Console.WriteLine("");
    Console.WriteLine("Bienvenido a la tienda de Pisoche, donde se venden pisos y coches.");
    Console.WriteLine("Primero de todo tenemos que iniciar sesión");
    bool inicioSesion = false;
    string? variableNombre = "";
    string? variableContraseña = "";
    while (inicioSesion == false)
    {
        Console.WriteLine("");
        Console.WriteLine("Nombre:");
        variableNombre = Console.ReadLine();
        Console.WriteLine("");
        Console.WriteLine("Contraseña:");
        variableContraseña = Console.ReadLine();
        Console.WriteLine("");
        inicioSesion = Usuario.inicioSesionUsuario(variableNombre, variableContraseña);
        if (inicioSesion == true)
        {
            Console.WriteLine("Datos Correctos");
        }
        else
        {
            Console.WriteLine("Datos Incorrectos");
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
                            Coche cocheanadir = new Coche(listadoCoches.LastOrDefault().Id + 1, marca, color, DateTime.Now, Convert.ToDecimal(precio), false, null, null, Int32.Parse(caballos));
                            listadoCoches.Add(cocheanadir);
                            Console.WriteLine("");
                            Console.WriteLine("Coche Añadido");
                            break;
                        case "2":
                            Console.WriteLine("");
                            Console.WriteLine("Vamos a añadir un nuevo piso");
                            Console.WriteLine("");
                            Console.WriteLine("Marca");
                            string localizacionPiso = Console.ReadLine();
                            Console.WriteLine("Precio");
                            string precioPiso = Console.ReadLine();
                            Piso pisoanadir = new Piso(listadoPisos.LastOrDefault().Id + 1, localizacionPiso, DateTime.Now, Convert.ToDecimal(precioPiso), false, null, null);
                            listadoPisos.Add(pisoanadir);
                            Console.WriteLine("");
                            Console.WriteLine("Piso Añadido");
                            break;
                    }
                    break;
                case "2":
                    verListado = true;
                    repetir = true;
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
        string elegir = Console.ReadLine();
        Console.WriteLine("");
        switch (elegir)
        {
            case "1":
                Console.WriteLine("LISTADO DE COCHES");
                foreach (var coche in listadoCoches)
                {
                    Console.WriteLine("Id: " + coche.Id + " Coche: " + coche.Marca);
                }
                Console.WriteLine("");
                Console.WriteLine("Si quiere ver los detalles del coche, indique el id del coche");
                Console.WriteLine("Si quiere filtrar pulsa 0");
                string numeroListadoCoche = "0";
                numeroListadoCoche = Console.ReadLine();
                if (numeroListadoCoche == "0")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Escribe el texto para filtrarlo (solo marcas)");
                    string textoFiltro = "";
                    textoFiltro = Console.ReadLine();
                    foreach (var coche in listadoCoches)
                    {

                        if (coche != null)
                        {
                            if (coche.Marca.Contains(textoFiltro))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Id: " + coche.Id);
                                Console.WriteLine("Coche: " + coche.Marca);
                                Console.WriteLine("Color: " + coche.Color);
                                Console.WriteLine("Fecha Entrada : " + coche.FechaEntrada);
                                Console.WriteLine("Precio: " + coche.Precio);
                                Console.WriteLine("Caballos: " + coche.Caballos);
                                Console.WriteLine("Comprado: " + (coche.Comprado == false ? "No" : "Si"));
                                Console.WriteLine("");
                            }
                        }
                    }
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
                            string respuesta = Coche.comprarCoche(coche2, comprarCocheString, variableNombre);
                            Console.WriteLine(respuesta);
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
                            string respuesta = Coche.comprarCoche(coche, comprarCocheString, variableNombre);
                            Console.WriteLine(respuesta);
                        }
                    }
                }
                break;
            case "2":
                Console.WriteLine("LISTADO DE PISOS");
                //**************************************************************************************
                foreach (var piso in listadoPisos)
                {
                    Console.WriteLine("Id: " + piso.Id + " Piso: " + piso.Localizacion);
                }
                Console.WriteLine("");
                Console.WriteLine("Si quiere ver los detalles del piso, indique el id del piso");
                Console.WriteLine("Si quiere filtrar pulsa 0");
                string numeroListadoPiso = "0";
                numeroListadoPiso = Console.ReadLine();
                if (numeroListadoPiso == "0")
                {
                    Console.WriteLine("Escribe el texto para filtrarlo (solo localización)");
                    string textoFiltro = "";
                    textoFiltro = Console.ReadLine();
                    foreach (var piso in listadoPisos.Where(x => x.Localizacion.Contains(textoFiltro)))
                    {
                        if (piso != null)
                        {
                            Console.WriteLine("Id: " + piso.Id);
                            Console.WriteLine("Localización: " + piso.Localizacion);
                            Console.WriteLine("Fecha Entrada : " + piso.FechaEntrada);
                            Console.WriteLine("Precio: " + piso.Precio);
                            Console.WriteLine("Comprado: " + (piso.Comprado == false ? "No" : "Si"));
                            Console.WriteLine("");
                            Console.WriteLine("Si quiere ver los detalles del piso, indique el id del piso");

                            string numeroListadoPisoFiltrado = "0";
                            numeroListadoPisoFiltrado = Console.ReadLine();
                            foreach (var pisoDos in listadoPisos.Where(x => x.Id.ToString() == numeroListadoPisoFiltrado))
                            {
                                if (pisoDos != null)
                                {
                                    Console.WriteLine("Id: " + pisoDos.Id);
                                    Console.WriteLine("Localización: " + pisoDos.Localizacion);
                                    Console.WriteLine("Fecha Entrada : " + pisoDos.FechaEntrada);
                                    Console.WriteLine("Precio: " + pisoDos.Precio);
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
                }
                else
                {
                    foreach (var piso in listadoPisos.Where(x => x.Id.ToString() == numeroListadoPiso))
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
                //**************************************************************************************
                break;
            default:
                break;
        }
    }
}
catch
{
}