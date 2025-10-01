// SAALARIOS
using System.ComponentModel;

class Program
{


    static int cantOperarios = 0, cantTecnicos = 0, cantProfesionales = 0;
    static double acumOperarios = 0, acumTecnicos = 0, acumProfesionales = 0;
    
    // Defino variables

    static void Main(string[] args)
    {
        
      
        string continuar = "si";

        while (continuar.ToUpper() == "SI")
        {
            // Datos
            Console.Write("Ingrese número de cédula: ");
            string cedula = Console.ReadLine();

            Console.Write("Ingrese nombre del empleado: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese tipo de empleado (1-Operario, 2-Técnico, 3-Profesional): ");
            int tipoEmpleado = int.Parse(Console.ReadLine());

            Console.Write("Ingrese cantidad de horas laboradas: ");
            double horas = double.Parse(Console.ReadLine());

            Console.Write("Ingrese salario por hora: ");
            double salarioHora = double.Parse(Console.ReadLine());


            // Cálculos
            double Ordinario = CalcularsalarioOrdinario(horas, salarioHora);
            double aumento = CalcularAumento(tipoEmpleado, Ordinario);
            double salarioBruto = Ordinario + aumento;
            double deduccion = salarioBruto * 0.0917;
            double salarioNeto = salarioBruto - deduccion;

            // Salida por empleado
            Console.WriteLine("\n--- Datos del empleado ---");
            Console.WriteLine("Cédula: " + cedula);
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Tipo Empleado: " + (tipoEmpleado == 1 ? "Operario" : tipoEmpleado == 2 ? "Técnico" : "Profesional"));
            Console.WriteLine("Salario por Hora: " + salarioHora);
            Console.WriteLine("Cantidad de Horas: " + horas);
            Console.WriteLine("Salario Ordinario: " + Ordinario);
            Console.WriteLine("Aumento: " + aumento);
            Console.WriteLine("Salario Bruto: " + salarioBruto);
            Console.WriteLine("Deducción CCSS: " + deduccion);
            Console.WriteLine("Salario Neto: " + salarioNeto);
            Console.WriteLine("---------------------------\n");

            // Recoopilacion de datos
            if (tipoEmpleado == 1)
            {   
                cantOperarios++;
                acumOperarios += salarioNeto;
            }
            else if (tipoEmpleado == 2)
            {
                cantTecnicos++;
                acumTecnicos += salarioNeto;
            }
            else if (tipoEmpleado == 3)
            {
                cantProfesionales++;
                acumProfesionales += salarioNeto;
            }

            // Continuar o salir
            Console.Write("¿Desea registrar otro empleado? (SI/NO o si/no): ");
            continuar = Console.ReadLine();
        }

        Reporte_final();


    }
        static void Reporte_final()
        {
        // Reporte final
        Console.WriteLine("\n===== DATOS RCAUDADOS =====");

        Console.WriteLine("Cantidad Empleados Operarios: " + cantOperarios);
        Console.WriteLine("Acumulado Salario Neto Operarios: " + acumOperarios);
        Console.WriteLine("Promedio Salario Neto Operarios: " + (cantOperarios > 0 ? acumOperarios / cantOperarios : 0));

        Console.WriteLine("Cantidad Empleados Técnicos: " + cantTecnicos);
        Console.WriteLine("Acumulado Salario Neto Técnicos: " + acumTecnicos);
        Console.WriteLine("Promedio Salario Neto Técnicos: " + (cantTecnicos > 0 ? acumTecnicos / cantTecnicos : 0));

        Console.WriteLine("Cantidad Empleados Profesionales: " + cantProfesionales);
        Console.WriteLine("Acumulado Salario Neto Profesionales: " + acumProfesionales);
        Console.WriteLine("Promedio Salario Neto Profesionales: " + (cantProfesionales > 0 ? acumProfesionales / cantProfesionales : 0));

        Console.WriteLine(" -------FIN--------\n");
         }


    static double CalcularAumento(int tipoEmpleado, double salarioOrdinario)
    {
        switch (tipoEmpleado)
        {
            case 1: return salarioOrdinario * 0.15; // Operario
            case 2: return salarioOrdinario * 0.10; // Técnico
            case 3: return salarioOrdinario * 0.05; // Profesional
            default:
                Console.WriteLine("Tipo de empleado inválido.");

                return 0;
        }
    }
    
    static double CalcularsalarioOrdinario(double horas, double salarioHora)
    {
        double salarioOrdinario = horas * salarioHora;
        return salarioOrdinario;

    }
}
    


    
    
    