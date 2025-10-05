using System;

class Program
{
    static void Main(string[] args)
    {
        // Defino variables
        int cantOperarios = 0, cantTecnicos = 0, cantProfesionales = 0;
        double acumOperarios = 0, acumTecnicos = 0, acumProfesionales = 0;

        string[] nombres = new string[100];       // Arreglo para guardar nombres
        double[] salariosNetos = new double[100]; // Arreglo para guardar salarios netos
        int contador = 0; // Índice de empleados registrados

        string continuar = "SI";

        while (continuar.ToUpper() == "SI" && contador < 100)
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
            double salarioOrdinario = horas * salarioHora;
            double aumento = 0;

            switch (tipoEmpleado)
            {
                case 1: // Operario
                    aumento = salarioOrdinario * 0.15;
                    break;
                case 2: // Técnico
                    aumento = salarioOrdinario * 0.10;
                    break;
                case 3: // Profesional
                    aumento = salarioOrdinario * 0.05;
                    break;
                default:
                    Console.WriteLine("Tipo de empleado inválido.");
                    continue;
            }

            double salarioBruto = salarioOrdinario + aumento;
            double deduccion = salarioBruto * 0.0917;
            double salarioNeto = salarioBruto - deduccion;

            // Guardar en los arreglos
            nombres[contador] = nombre;
            salariosNetos[contador] = salarioNeto;
            contador++;

            // Salida por empleado
            Console.WriteLine("\n--- Datos del empleado ---");
            Console.WriteLine("Cédula: " + cedula);
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Tipo Empleado: " + (tipoEmpleado == 1 ? "Operario" : tipoEmpleado == 2 ? "Técnico" : "Profesional"));
            Console.WriteLine("Salario Ordinario: " + salarioOrdinario);
            Console.WriteLine("Aumento: " + aumento);
            Console.WriteLine("Salario Bruto: " + salarioBruto);
            Console.WriteLine("Deducción CCSS: " + deduccion);
            Console.WriteLine("Salario Neto: " + salarioNeto);
            Console.WriteLine("---------------------------\n");

            // Recolección de datos
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
            Console.Write("¿Desea registrar otro empleado? (Si/No): ");
            continuar = Console.ReadLine();
        }

        // Reporte final
        Console.WriteLine("\n===== DATOS RECAUDADOS =====");

        Console.WriteLine("Cantidad Empleados Operarios: " + cantOperarios);
        Console.WriteLine("Acumulado Salario Neto Operarios: " + acumOperarios);
        Console.WriteLine("Promedio Salario Neto Operarios: " + (cantOperarios > 0 ? acumOperarios / cantOperarios : 0));

        Console.WriteLine("Cantidad Empleados Técnicos: " + cantTecnicos);
        Console.WriteLine("Acumulado Salario Neto Técnicos: " + acumTecnicos);
        Console.WriteLine("Promedio Salario Neto Técnicos: " + (cantTecnicos > 0 ? acumTecnicos / cantTecnicos : 0));

        Console.WriteLine("Cantidad Empleados Profesionales: " + cantProfesionales);
        Console.WriteLine("Acumulado Salario Neto Profesionales: " + acumProfesionales);
        Console.WriteLine("Promedio Salario Neto Profesionales: " + (cantProfesionales > 0 ? acumProfesionales / cantProfesionales : 0));

        Console.WriteLine("\n--- LISTA DE EMPLEADOS REGISTRADOS ---");
        for (int i = 0; i < contador; i++)
        {
            Console.WriteLine((i + 1) + ". " + nombres[i] + " - Salario Neto: " + salariosNetos[i]);
        }

        Console.WriteLine(" -------FIN--------\n");
    }
}
