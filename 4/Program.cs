using System.Threading.Channels;

List<Libro> libros = new List<Libro>();
Console.Write("¿Cuántos libros desea registrar?: ");
int cantidad = int.Parse(Console.ReadLine());
if (cantidad > 0)
{
    for (int i = 0; i < cantidad; i++)
    {
        Libro l = new Libro();
        Console.WriteLine($"Libro {i + 1}");
        Console.Write("Ingrese el título: ");
        l.Titulo = Console.ReadLine();
        Console.Write("Ingrese el autor: ");
        l.Autor = Console.ReadLine();
        Console.Write("Ingrese la categoría: ");
        l.Categoria = Console.ReadLine();
        Console.Write("Ingrese el número de paginas: ");
        l.NumeroDePaginas=int .Parse(Console.ReadLine());
        if (l.NumeroDePaginas > 0)
        {
            libros.Add(l);
        }
        else
        {
            Console.WriteLine("El número de paginas debe ser mayor que 0");
            i--;
        }
    }
    Console.WriteLine();
    Console.WriteLine("\tLista de libros");
    Libro mayor = libros[0];
    foreach(Libro l in libros)
    {
        l.MostrarInformacion();
        if (l.NumeroDePaginas > mayor.NumeroDePaginas)
        {
            mayor= l;
        }
    }
    Console.WriteLine();
    Console.WriteLine("El libro con mayor número de paginas es: ");
    mayor.MostrarInformacion();
}
else
{
    Console.WriteLine("La cantidad debe ser mayor que 0");
}
class Libro
{
    public string Titulo;
    public string Autor;
    public string Categoria;
    public int NumeroDePaginas;
    public string Paginas()
    {
        if (NumeroDePaginas <= 50)
            return "Corto";
        else if (NumeroDePaginas <= 100)
            return "Mediano";
        else
            return "Extenso";
    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"Título: {Titulo} | Autor: {Autor} | Categoria: {Categoria} | Número de paginas: {NumeroDePaginas} | Tamaño del libro: {Paginas()}");
    }
}