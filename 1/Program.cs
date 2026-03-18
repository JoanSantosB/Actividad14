using System.ComponentModel.Design;

List<Estudiante>estudiantes = new List<Estudiante>();
Console.Write("¿Cuántos estudiantes desea ingresar?: ");
int cantidad=int.Parse(Console.ReadLine());
if (cantidad > 0)
{
    for(int i = 0; i < cantidad; i++)
    {
        Estudiante e = new Estudiante();
        Console.WriteLine($"\tEstudiante {i+1}");
        Console.Write("Ingrese el nombre: ");
        e.Nombre = Console.ReadLine();
        Console.Write("Ingrese nota 1: ");
        e.Nota1=double.Parse(Console.ReadLine());
        if(e.Nota1 >=0 && e.Nota1 <= 100)
        {
            Console.Write("Ingrese nota 2: ");
            e.Nota2 = double.Parse(Console.ReadLine());
            if (e.Nota2 >= 0 && e.Nota2 <= 100)
            {
                Console.Write("Ingrese nota 3: ");
                e.Nota3 = double.Parse(Console.ReadLine());
                if(e.Nota3 >= 0 &&e.Nota3 <= 100)
                {
                    estudiantes.Add(e);
                }
                else
                {
                    Console.WriteLine("Error excedio el límite...La nota debe ser en un rango de 0 y 100");
                    i--;
                }
            }
            else
            {
                Console.WriteLine("Error excedio el límite...La nota debe ser en un rango de 0 y 100");
                i--;
            }
        }
        else
        {
            Console.WriteLine("Error excedio el límite...La nota debe ser en un rango de 0 y 100");
            i--;
        }
    }
    Console.WriteLine();
    Estudiante mejor = estudiantes[0];
    Console.WriteLine("\tLista de estudiantes");
    foreach(Estudiante e in estudiantes)
    {
        e.MostrarInformacion();
        if (e.Promedio() > mejor.Promedio())
        {
            mejor=e;
        }
    }
    Console.WriteLine("\nEstudiante con mejor promedio: ");
    mejor.MostrarInformacion();
}
else
{
    Console.WriteLine("Error la cantidad debe ser mayor que 0");
}
class Estudiante
{
    public string Nombre;
    public double Nota1;
    public double Nota2;
    public double Nota3;

    public double Promedio()
    {
        return (Nota1+Nota2 + Nota3)/3;
    }
    public string Estado()
    {
        if (Promedio() >= 61)
            return "Aprobado";
        else
            return "Reprobado";
    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}    |  Promedio: {Promedio():F2}    |   Estado: {Estado()}");
    }
}