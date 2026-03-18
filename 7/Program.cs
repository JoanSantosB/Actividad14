Dictionary<int, Producto> productos = new Dictionary<int, Producto>();
Console.Write("¿Cuántos productos desea registrar?: ");
int cantidad=int.Parse(Console.ReadLine());
if (cantidad > 0)
{
    for(int i = 0; i < cantidad; i++)
    {
        Producto p = new Producto();
        Console.WriteLine($"\tProducto {i+1}");
        Console.Write("Ingrese el código del producto: ");
        int codigo=int.Parse(Console.ReadLine());
        if (productos.ContainsKey(codigo))
        {
            Console.WriteLine("Este código ya esta registrado");
        }
        else
        {
            Console.Write("Ingrese el nombre: ");
            p.Nombre = Console.ReadLine();
            Console.Write("Ingrese el precio: ");
            p.Precio=double.Parse(Console.ReadLine());
            if(p.Precio > 0)
            {
                Console.Write("Ingrese la cantidad de stock: ");
                p.Stock=int.Parse(Console.ReadLine());
                if( p.Stock >= 0)
                {
                    productos.Add(codigo, p);
                }
                else
                {
                    Console.WriteLine("Error el stock debe ser mayor o igual que 0");
                    i--;
                }
            }
            else
            {
                Console.WriteLine("Error el precio debe ser mayor que 0");
                i--;
            }
        }
    }
    Console.WriteLine();
    Console.WriteLine("\tProductos registrados");
    foreach(KeyValuePair<int, Producto> p in productos)
    {
        Console.Write($"Código: {p.Key} | ");
        p.Value.MostrarInformacion();
    }
    Console.WriteLine();
    Console.Write("Ingrese el código a buscar: ");
    int buscar=int.Parse(Console.ReadLine());
    if(productos.ContainsKey (buscar))
    {
        productos[buscar].MostrarInformacion();
    }
    else
    {
        Console.WriteLine("No hemos encontrado el código");
    }
}
else
{
    Console.WriteLine("Error la cantidad debe ser mayor que 0");
}
class Producto
{
    public string Nombre;
    public double Precio;
    public int Stock;
    public string EstadoStock()
    {
        if (Stock <= 3)
            return "Agotado";
        else if (Stock <= 10)
            return "Bajo";
        else
            return "Normal";
    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre} | Precio: {Precio} | Stock: {Stock} | Estado: {EstadoStock()}");
    }
}