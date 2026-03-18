List<Empleado> empleados = new List<Empleado>();
Console.Write("¿Cuántos empleados desea registrar?: ");
int cantidad=int.Parse(Console.ReadLine());
if (cantidad > 0)
{
    for(int i = 0; i < cantidad; i++)
    {
        Empleado em=new Empleado();
        Console.WriteLine($"Empleado {i+1}");
        Console.Write("Ingrese el nombre: ");
        em.Nombre = Console.ReadLine();
        Console.Write("Ingrese el puesto: ");
        em.Puesto = Console.ReadLine();
        Console.Write("Ingrese el salario mensual: ");
        em.SalarioMensual=double.Parse(Console.ReadLine());
        if (em.SalarioMensual > 0)
        {
            empleados.Add(em);
        }
        else
        {
            Console.WriteLine("El salario debe ser mayor que 0");
            i--;
        }
    }
    foreach(Empleado em in empleados)
    {
        em.MostrarInformacion();
    }
}
class Empleado
{
    public string Nombre;
    public string Puesto;
    public double SalarioMensual;
    public double SalarioAnual()
    {
        return SalarioMensual*12;
    }
    public double Bono()
    {
        if (SalarioAnual() <= 15000)
            return SalarioAnual() * 0.05;
        else if (SalarioAnual() <= 20000)
            return SalarioAnual() * 0.10;
        else
            return SalarioAnual() * 0.20;
    }
    public string ClasificarSalario()
    {
        if (SalarioMensual <= 15000)
            return "Salario Básico";
        else if (SalarioMensual <= 20000)
            return "Salario Medio";
        else
            return "Salario Alto";
    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre} | Puesto: {Puesto} | Salario Mensual: {SalarioMensual} | Salario Anual: {SalarioAnual()} | Bono: {Bono()} | Clacificación de salario: {ClasificarSalario()}");
    }
}
