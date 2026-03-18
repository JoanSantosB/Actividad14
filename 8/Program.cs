using System.Threading.Channels;
List<Cuenta> cuentas = new List<Cuenta>();
int cantidad=0;
int opcion;
do
{
    Console.Clear();
    Console.WriteLine("1. Registre cuentas");
    Console.WriteLine("2. Deposite dinero");
    Console.WriteLine("3. Retire dinero");
    Console.WriteLine("4. Ver estados de cuentas");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione un opción: ");
    opcion=int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.WriteLine("\tArea de Registros");
            Console.WriteLine("¿Cuántas cuentas desea registrar?: ");
            cantidad=int.Parse(Console.ReadLine());
            for(int i = 0; i < cantidad; i++)
            {
                Cuenta c=new Cuenta();
                Console.WriteLine($"\tCuenta {i+1}");
                Console.WriteLine("Ingrese el titular: ");
                c.Titular = Console.ReadLine();
                Console.WriteLine("Ingrese el saldo: ");
                c.Saldo=double.Parse(Console.ReadLine());
                if (c.Saldo > 0)
                {
                    cuentas.Add(c);
                }
                else
                {
                    Console.WriteLine("No se puede registrar esta cuenta");
                    i--;
                }
            }
        break;
        case 2:
            if (cuentas.Count > 0)
            {
                Console.WriteLine("\tArea de Depositos");
                for (int i = 0; i < cantidad; i++)
                {
                    Cuenta c = cuentas[i];
                    Console.WriteLine($"\tCuenta {i + 1}");
                    Console.Write("Ingrese el deposito: ");
                    double Deposito = double.Parse(Console.ReadLine());
                    if (Deposito <= 0)
                    {
                        Console.WriteLine("No se puede hacer esta operación");
                    }
                    else
                    {
                        c.Depositar(Deposito);
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay registro en la lista");
            }
            break;
            case 3:
            if (cuentas.Count > 0)
            {
                Console.WriteLine("\tArea de Retiros");
                for (int i = 0; i < cantidad; i++)
                {
                    Cuenta c = cuentas[i];
                    Console.WriteLine($"\tCuenta {i + 1}");
                    Console.Write("Ingrese el retiro: ");
                    double Retiro = double.Parse(Console.ReadLine());
                    if (Retiro <= 0)
                    {
                        Console.WriteLine("No se puede hacer esta operación");
                    }
                    else
                    {
                        c.Retirar(Retiro);
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay registro en la lista");
            }
            break;
            case 4:
            if (cuentas.Count > 0)
            {
                Console.WriteLine("\tSaldo Final");
                foreach(Cuenta i in cuentas)
                {
                    i.MostrarInformacion();
                }
            }
            else
            {
                Console.WriteLine("No hay registro en la lista");
            }
            break;
            case 5:
            Console.WriteLine("¡GRACIAS POR UTILIZAR EL PROGRAMA!");
            break;
        default:
            Console.WriteLine("Esta opción no existe");
            break;
    }
    Console.ReadKey();
} while (opcion != 5);
class Cuenta
{
    public string Titular;
    public double Saldo;
    public double Depositar(double deposito)
    {
        if (deposito > 0)
            return Saldo += deposito;
        else
            return 0;
    }
    public double Retirar(double retiro)
    {
        if(retiro<=0)
            return 0;
        else if (retiro > 0 && retiro <= Saldo)
            return Saldo -= retiro;
        else
            Console.WriteLine("No se puede hacer este retiro, poruqe excede el límite del saldo");
            return 0;
    }
   public double SaldoActual()
    {
        return Saldo;
    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"Titular: {Titular} | Saldo Final: {SaldoActual()}");
    }
}