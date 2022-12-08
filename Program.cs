using Classes;
using System;

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
    Console.WriteLine("Bienvenido a la tienda de Pisoche, donde se venden pisos y coches.");
    Console.WriteLine("Primero de todo tenemos que iniciar sesión");
    bool inicioSesion = false;
    string? variableNombre = "";
    string? variableContraseña = "";
    while (inicioSesion == false)
    {
        Console.WriteLine("Nombre:");
        variableNombre = Console.ReadLine();
        Console.WriteLine("Contraseña:");
        variableContraseña = Console.ReadLine();
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
        Console.WriteLine("Bienvenido Señor " + variableNombre);
        bool repetir = false; //USAREMOS ESTA VARIABLE PARA VOLVER AL PRINCIPIO CUANDO HAYAMOS AÑADIDO ALGO
        while (repetir == false)
        {
            Console.WriteLine("Quiere añadir un producto o ver los listados");
            Console.WriteLine("1 - Añadir Producto");
            Console.WriteLine("2 - Ver Listado");
            int variablePrivado = Console.Read();
            if (variablePrivado > 2 || variablePrivado < 1)
            {
                Console.WriteLine("Error");
            }
            else
            {
                switch (variablePrivado)
                {
                    case 1:
                        Console.WriteLine("Vamos a añadir algun producto");
                        Console.WriteLine("1 - Coche");
                        Console.WriteLine("2 - Piso");
                        int anadirProducto = Console.Read();
                        if (variablePrivado == 2 || variablePrivado == 1)
                        {
                            switch (anadirProducto)
                            {
                                case 1:
                                    Console.WriteLine("Vamos a añadir un nuevo coche");
                                    Console.WriteLine("Marca");
                                    string marca = Console.ReadLine();
                                    Console.WriteLine("Color");
                                    string color = Console.ReadLine();
                                    Console.WriteLine("Precio");
                                    decimal precio = Console.Read();
                                    Console.WriteLine("Caballos");
                                    int caballos = Console.Read();
                                    Coche cocheanadir = new Coche(listadoCoches.LastOrDefault().Id + 1, marca, color, DateTime.Now, precio, false, null, null,caballos);
                                    Console.WriteLine("");
                                    Console.WriteLine("Coche Añadido");
                                    break;
                                case 2:

                                    break;
                            }                        
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                        break;
                    case 2:
                        verListado = true;
                        repetir = true;
                        break;
                }
            }
        }
    }
    if (variableNombre == "Alex")
    {
        verListado = true;

    }
    while (verListado == true)
    {
        Console.WriteLine("Bienvenido " + variableNombre);
        Console.WriteLine("Selecciona el listado que quieres ver");
        Console.WriteLine("1- Coches");
        Console.WriteLine("2- Pisos");
        int numeroListado = 0;
        numeroListado = Console.Read();
        switch (numeroListado)
        {
            case 1:
                Console.WriteLine("LISTADO DE COCHES");
                foreach (var coche in listadoCoches)
                {
                    Console.WriteLine("Id: " + coche.Id + " Coche: " + coche.Marca);
                }
                Console.WriteLine("");
                Console.WriteLine("Si quiere ver los detalles del coche, indique el id del coche");
                int numeroListadoCoche = 0;
                numeroListadoCoche = Console.Read();
                foreach (var coche in listadoCoches)
                {
                    Console.WriteLine("Coche: " + coche.Marca);
                    Console.WriteLine("Color: " + coche.Color);
                    Console.WriteLine("Fecha Entrada : " + coche.FechaEntrada);
                    Console.WriteLine("Precio: " + coche.Precio);
                    Console.WriteLine("Caballos: " + coche.Caballos);
                    Console.WriteLine("");
                    Console.WriteLine("¿Quieres comprar este coche?");
                    Console.WriteLine("S - Si");
                    Console.WriteLine("N - No");
                    string comprarCocheString = "";
                    comprarCocheString = Console.ReadLine();
                    string respuesta = Coche.comprarCoche(coche, comprarCocheString, variableNombre);
                    Console.WriteLine(respuesta);
                }
                break;
            case 2:
                Console.WriteLine("LISTADO DE PISOS");
                break;
            default:

                break;      
        }
    }
}
catch
{
}