List<Producto> productos = new List<Producto>();
Console.Write("¿Cuántos productos desea registrar?: ");
int cantidad=int.Parse(Console.ReadLine());
if (cantidad > 0)
{
    for(int i = 0; i < cantidad; i++)
    {
        Producto p = new Producto();
        Console.WriteLine($"\tProducto {i+1}");
        Console.Write("Ingrese el nombre: ");
        p.Nombre = Console.ReadLine();
        Console.Write("Ingrese el precio: ");
        p.Precio=double.Parse(Console.ReadLine());
        if(p.Precio > 0)
        {
            Console.Write("Ingrese la cantidad: ");
            p.Cantidad =int.Parse(Console.ReadLine());
            if(p.Cantidad > 0)
            {
                productos.Add(p);
            }
            else
            {
                Console.WriteLine("Error la cantidad debe ser mayor que 0");
                i--;
            }
        }
        else
        {
            Console.WriteLine("Error el precio debe ser mayor que 0");
            i--;
        }
    }
    Console.WriteLine();
    Console.WriteLine("\tLista de productos registrados");
    Producto precio = productos[0];
    foreach (Producto p in productos)
    {
        p.MostraInformacion();
        if(p.Precio>precio.Precio)
        {
            precio = p;
        }
    }
    Console.WriteLine();
    Console.WriteLine("Producto com mayor precio: ");
    precio.MostraInformacion();
}
class Producto
{
    public string Nombre;
    public double Precio;
    public int Cantidad;

    public double Inventario()
    {
        return Precio*Cantidad;
    }
    public string Stock()
    {
        if (Cantidad == 0)
            return "Sin existencia";
        else if (Cantidad <= 5)
            return "Stock Bajo";
        else
            return "Stock Suficente";
    }
    public void MostraInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre} | Precio: {Precio} | Cantidad: {Cantidad} | Valor total del producto: {Inventario()} | Stock: {Stock()}");
    }
}

