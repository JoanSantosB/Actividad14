List<Pedido> pedidos = new List<Pedido>();
Console.Write("¿Cuántos pedidos desea registrar?: ");
int cantidad=int.Parse(Console.ReadLine());
if (cantidad > 0)
{
    for(int i = 0; i < cantidad; i++)
    {
        Pedido p=new Pedido();
        Console.WriteLine($"\tPedido {i+1}");
        Console.Write("Ingrese el nombre del cliente: ");
        p.Cliente = Console.ReadLine();
        Console.Write("Ingrese el producto: ");
        p.Producto = Console.ReadLine();
        Console.Write("Ingrese la cantidad: ");
        p.Cantidad = int.Parse(Console.ReadLine());
        if(p.Cantidad > 0)
        {
            Console.Write("Ingrese el precio Unitario: ");
            p.PrecioUnitario=double.Parse(Console.ReadLine());
            if( p.PrecioUnitario > 0)
            {
                pedidos.Add(p);
            }
            else
            {
                Console.WriteLine("Error el precio debe se rmayor que 0");
                i--;
            }
        }
        else
        {
            Console.WriteLine("Error la cantidad debe ser mqyor que 0");
            i--;
        }
    }
    Console.WriteLine();
    double total = 0;
    Console.WriteLine("\tLista de pedidos");
    foreach(Pedido p in pedidos)
    {
        p.MostrarInformacion();
        total += p.CalcularTotalFinal();
    }
    Console.WriteLine($"El total por todos los pedidos es: {total}");
}
else
{
    Console.WriteLine("Error la cantidad debe ser mayor que 0");
}

class Pedido
{
    public string Cliente;
    public string Producto;
    public int Cantidad;
    public double PrecioUnitario;

    public double CacluloSubtotal()
    {
        return Cantidad * PrecioUnitario;
    }
    public double CalcularCostos()
    {
        if (CacluloSubtotal() > 500)
            return 0;
        else
            return CacluloSubtotal()*0.05;
    }
    public double CalcularTotalFinal()
    {
        return CacluloSubtotal()+CalcularCostos();
    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"Cliente: {Cliente} | Producto: {Producto} | Cantidad: {Cantidad} | Calculo Subtotal: {CacluloSubtotal()} | Costos de envío: {CalcularCostos()} | Total: {CalcularTotalFinal()}");
    }
}