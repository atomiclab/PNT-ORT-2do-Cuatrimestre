namespace ProjectoPNT.Entity;

public class RepositorioArchivos
{
    List<Archivo3D> Archivos { get; set; }
    
    // Usuario colgarle un atributo que sea collection
    // https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
    // many to one a desarrollar posteriormente.
}