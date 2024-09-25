// See https://aka.ms/new-console-template for more information

using ProjectoPNT.Controller;
using ProjectoPNT.Entity;

UserController userController = new UserController();

Usuario nuevoUsuario = new Usuario
{
    Id = 1,
    Nombre = "Juan",
    Apellido = "Perez",
    Email = "juan.perez@gmail.com",
    Password = "password"
};
bool resultado = userController.Registrarse(nuevoUsuario);
Console.WriteLine("Usuario registrado: " + resultado);


