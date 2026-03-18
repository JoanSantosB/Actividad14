using System.Threading.Channels;
List<Venta> ventas=new List<Venta>();
Console.Write("¿Cuántas ventas desea registrar?: ");
int cantidad=int.Parse(Console.ReadLine());
if (cantidad > 0)
{
    for(int i = 0; i < cantidad; i++)
    {
        Venta v=new Venta();
        Console.WriteLine($"\tVenta {i+1}");
        Console.Write("Ingrese el producto: ");
        v.Producto = Console.ReadLine();
        Console.Write("Ingrese el precio: ");
        v.Precio=double.Parse(Console.ReadLine());
        if(v.Precio > 0)
        {
            Console.Write("Ingrese la cantidad: ");
            v.Cantidad = int.Parse(Console.ReadLine());
            if( v.Cantidad > 0)
            {
                ventas.Add(v);
            }
            else
            {
                Console.WriteLine("La cantidad debe ser mayor que 0");
                i--;
            }
        }
        else
        {
            Console.WriteLine("El precio debe ser mayor que 0");
            i--;
        }
    }
    double totalVendido = 0;
    Console.WriteLine();
    Console.WriteLine("\tLista de ventas");
    foreach(Venta v in ventas)
    {
        v.MostrarVenta();
        totalVendido += v.CalculoTotal();
    }
    Console.WriteLine();
    Console.WriteLine($"El total vendido es: {totalVendido}");
}
else
{
    Console.WriteLine("La cantidad debe ser mayor que 0");
}

class Venta
{
    public string Producto;
    public double Precio;
    public int Cantidad;
    public double CalculoSubtotal()
    {
        return Precio * Cantidad;
    }
    public double Descuento()
    {
        if (CalculoSubtotal() > 500)
            return CalculoSubtotal() * 0.15;
        else
            return CalculoSubtotal() * 0.05;
    }
    public double CalculoTotal()
    {
        return CalculoSubtotal() -Descuento();
    }
    public void MostrarVenta()
    {
        Console.WriteLine($"Producto: {Producto} | Precio: {Precio} | Cantidad: {Cantidad} | Subtotal: {CalculoSubtotal():F2} | Descuento: {Descuento():F2} | Total: {CalculoTotal():F2}");
    }
}