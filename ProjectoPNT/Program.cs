// See https://aka.ms/new-console-template for more information

using ProjectoPNT.Controller;
using ProyectoPNT.Controller;
using ProyectoPNT.Entity;

UserController userController = new UserController();
Archivo3DController archivo3DController = new Archivo3DController();
RepositorioArchivosController repositorioArchivosController = new RepositorioArchivosController();

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


Archivo3D archivo3D = new Archivo3D
{
    Nombre = "TornilloTorx",
    Descripcion = "Tornillo de cabeza torx de 3mm",
    Ruta = "Piezas_De_Ingenieria/Tornillos",
    Formato = ".STL",
    UsuarioId = nuevoUsuario3.Id,
};
Archivo3D archivo3D2 = new Archivo3D
{
    Nombre = "TornilloHexagonal",
    Descripcion = "Tornillo de cabeza hexagonal de 3mm",
    Ruta = "Piezas_De_Ingenieria/Tornillos",
    Formato = ".STL",
    UsuarioId = nuevoUsuario3.Id,
};

bool resultado5 = archivo3DController.Save(archivo3D);
bool resultado6 = archivo3DController.Save(archivo3D2);

Console.WriteLine("Archivo 3D registrado?"+ resultado5 +" " + archivo3D.Nombre);
Console.WriteLine("Archivo 3D registrado?"+ resultado6 + " "+archivo3D2.Nombre);

// Agregar archivos al repositorio
RepositorioArchivos repositorio = new RepositorioArchivos();
repositorio.Archivos.Add(archivo3D);
repositorio.Archivos.Add(archivo3D2);



// Buscar archivo por nombre desde la consola
Console.WriteLine("Ingrese el nombre del archivo a buscar:");
string nombreArchivo = Console.ReadLine();
List<Archivo3D> archivosEncontrados = repositorioArchivosController.BuscarArchivo(nombreArchivo);

Console.WriteLine("Archivos encontrados:");
foreach (var archivo in archivosEncontrados)
{
    Console.WriteLine(" - " + archivo.Nombre);
}

// Todos los ususarios y sus archivos
List<Usuario> usuarios = userController.GetAllUsuarios();

foreach (var usuario in usuarios)
{
    Console.WriteLine("Usuario: " + usuario.Nombre + " " + usuario.Apellido);
    
    // Retrieve and display the user's files
    List<Archivo3D> archivosUsuario = repositorioArchivosController.ListarArchivos(usuario.Id);
    Console.WriteLine("Archivos:");
    foreach (var archivo in archivosUsuario)
    {
        Console.WriteLine(" - " + archivo.Nombre);
    }
    Console.WriteLine();
}