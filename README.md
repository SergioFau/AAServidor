APLICACIÓN DE CONSOLA CREADA POR SERGIO FAU

Es una consola donde tu puedes:

1 - Iniciar Sesión (tienes un admin y un usuario normal) Admin -> Nombre: Sergio Contraseña: 123

2- Existe la posibilidad siendo admin de añadir nuevos coches o pisos y de ver el listado de los que ya existen.

3- Llevamos un registro de algunos errores mediante los cuales salen reflejados en un fichero de logs 
Tambien se pueden ver el listado de los errores con la opción 3.

4- Tras mostrar el listado de coches o pisos, puedes o bien entrar dentro de una ficha en especifico o puedes filtrar a traves del nombre de las marcas y localización. Ej: Escribimos Ferr y aparecera el id 1 -> Ferrari.

5- Una vez dentro de la ficha del objeto, puedes comprarlo, eso provoca que pase a estar comprado y se comprobara si el dinero de la persona es suficiente para comprarlo (se descuenta el dinero del coche al saldo del usuario)

6- Se ha creado una variable de entorno mediante la cual, alteramos los valores de los elementos y el dinero de los usuarios.

7- El estilo de la consola ha sido modificado con la libreria Spectre.Console, tambien se ha añadido unos modelos donde se almacenan frases o metodos.

8- Los datos de los usuarios y los coches y pisos son sacados de unos json que se encuentran en la carpeta recursos
