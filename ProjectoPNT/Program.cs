// See https://aka.ms/new-console-template for more information

using ProyectoPNT.Controller;
using ProyectoPNT.Entity;

UserController userController = new UserController();

Usuario nuevoUsuario = new Usuario
{

    Nombre = "Juan",
    Apellido = "Perez",
    Email = "juan.perez@gmail.com",
    Password = "password"
};
Usuario nuevoUsuario2 = new Usuario
{

    Nombre = "Gino",
    Apellido = "Tubaro",
    Email = "gino@gmail.com",
    Password = "password"
};
Usuario nuevoUsuario3 = new Usuario
{

    Nombre = "Guido",
    Apellido = "Tubaro",
    Email = "guido@gmail.com",
    Password = "password"
};
bool resultado = userController.Registrarse(nuevoUsuario);
bool resultado2 = userController.Registrarse(nuevoUsuario2);
bool resultado3 = userController.Registrarse(nuevoUsuario3);
//insertar por linea de codigo el ID a borrar
Console.WriteLine("Ingrese el ID a borrar");
int id = Convert.ToInt32(Console.ReadLine());
bool resultado4 = userController.DeleteById(id);


Console.WriteLine("Usuario registrado: " + nuevoUsuario.Nombre);
Console.WriteLine("Usuario registrado: " + nuevoUsuario2.Nombre);
Console.WriteLine("Usuario registrado: " + nuevoUsuario3.Nombre);
Console.WriteLine("Se borro el usuario con el ID: " + id);
