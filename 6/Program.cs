Dictionary<int, Estudiante> estudientes = new Dictionary<int, Estudiante>();
Console.Write("¿Cuántos estudientes desea registrar?: ");
int cantidad=int.Parse(Console.ReadLine());
if (cantidad > 0)
{
    for (int i = 0; i < cantidad; i++)
    {
        Estudiante es = new Estudiante();
        Console.WriteLine($"\tEstudiante {i + 1}");
        Console.Write("Ingrese el carnet: ");
        int carnet = int.Parse(Console.ReadLine());
        if (estudientes.ContainsKey(carnet))
        {
            Console.WriteLine("Este carnet ya existe...Ingrese otro carnet");
            i--;
        }
        else
        {
            Console.Write("Ingrese el nombre: ");
            es.Nombre = Console.ReadLine();
            Console.Write("Ingrese el nombre de la carrera: ");
            es.Carrera = Console.ReadLine();
            Console.Write("Ingrese la nota final: ");
            es.NotaFinal = double.Parse(Console.ReadLine());
            if (es.NotaFinal >= 0 && es.NotaFinal <= 100)
            {
                estudientes.Add(carnet, es);
            }
            else
            {
                Console.WriteLine("Excedio el rango de la nota final...El rango es entre 0 y 100");
            }
        }
    }
    Console.WriteLine();
    Console.WriteLine("\tLista de estudientes");
    foreach(KeyValuePair<int,Estudiante> i in estudientes)
    {
        Console.Write($"Carnet: {i.Key} | ");
        i.Value.MostrarInformacion();
    }
    Console.WriteLine();
    Console.Write("Ingrese el carnet a buscar: ");
    int buscar=int.Parse(Console.ReadLine());
    if (estudientes.ContainsKey(buscar))
    {
        estudientes[buscar].MostrarInformacion();
    }
    else
    {
        Console.WriteLine("No se ha encontrado este carnet");
    }
}
else
{
    Console.WriteLine("Error la cantidad debe se rmayor que 0");
}
class Estudiante
{
    public string Nombre;
    public string Carrera;
    public double NotaFinal;
    public string Estado()
    {
        if (NotaFinal >= 61)
            return "Aprobado";
        else
            return "Reprobado";
    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre} | Carrera: {Carrera} | Nota Final: {NotaFinal} | Estado del estudiante: {Estado()}");
    }
}
