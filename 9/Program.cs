List<Curso> cursos = new List<Curso>();
Console.Write("¿Cuántos cursos desea registrar?: ");
int cantidad = int.Parse(Console.ReadLine());
if (cantidad > 0)
{
    for (int i = 0; i < cantidad; i++)
    {
        Curso c = new Curso();
        Console.WriteLine($"\tCurso {i + 1}");
        Console.Write("Ingrese el nombre: ");
        c.NombreDelCurso = Console.ReadLine();
        Console.Write("Ingrese los creditos del curso: ");
        c.Creditos = int.Parse(Console.ReadLine());
        Console.Write("Ingrese la nota promedio del curso: ");
        c.NotaPromedio = double.Parse(Console.ReadLine());
        if(c.NotaPromedio >= 0&&c.NotaPromedio<=100)
        {
            cursos.Add(c);
        }
        else
        {
            Console.WriteLine("Excedio del rango entre 0 y 100");
            i--;
        }
    }
    Console.WriteLine();
    Console.WriteLine("\tLista de cursos");
    Curso mayor = cursos[0];
    foreach (Curso l in cursos)
    {
        l.MostrarInformacion();
        if (l.NotaPromedio > mayor.NotaPromedio)
        {
            mayor = l;
        }
    }
    Console.WriteLine();
    Console.WriteLine("El cursos con mayor nota del promedio es: ");
    mayor.MostrarInformacion();
}
else
{
    Console.WriteLine("La cantidad debe ser mayor que 0");
}
class Curso
{
    public string NombreDelCurso;
    public int Creditos;
    public double NotaPromedio;
    public string RendimientoDelCurso()
    {
        if ( NotaPromedio<= 60)
            return "Bajo";
        else if (NotaPromedio<=70)
            return "Aceptable";
        else
            return "Excelente";
    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre del Curso: {NombreDelCurso} | Creditos: {Creditos} | Nota promedio: {NotaPromedio} | Rendimiento del curso {RendimientoDelCurso()}");
    }
}