using System;
using System.Diagnostics;
using System.IO;
using System.Net;
namespace CDG_Mexico
{
    // TRABAJO HECHO POR: WILLIAM ADRIAN OCHOA DE SOUZA FERREYRA(N00549692), SANTIAGO GABRIEL RIVAS RAMOS (N00544024), DANIELA NORELIS ZUÑIGA TORRES (N00542769), FABRICIO ALDAIR CARRANZA MESA (N00538080).


    internal class Program
    {
        // VARIABLES GLOBALES /-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
        static int MAX_PACIENTES = 500;
        static int Cantidad_Pacientes = 0;

        static string[] arreglo_PACIENTES = new string[MAX_PACIENTES];

      
        static string[] arreglo_DNI = new string[MAX_PACIENTES];
        static string[] arreglo_GENERO = new string[MAX_PACIENTES];
        static string[] arreglo_EDAD = new string[MAX_PACIENTES];
        static string[] arreglo_NOMBRES = new string[MAX_PACIENTES];
        static string [] arreglo_NUMTELF = new string[MAX_PACIENTES];
        static string[] arreglo_CORREO_PACIENTES = new string[MAX_PACIENTES];
        static string[] arreglo_ESPECIALIDADES = new string[MAX_PACIENTES];
        static string[] arreglo_FECHAHORA = new string[MAX_PACIENTES];
        static string[] arreglo_DOCTOR = new string[MAX_PACIENTES];
        static string[] Drs_MedicinaG = new string[] { "Dr. Juan", "Dr. Camilo", "Dr. Ramos", "Dr. Camilo" };
        static string[] Drs_Pediatria = new string[] { "Dr. Cruz", "Dr. Inga", "Dr. Chumpitaz", "Dra. Quispe" };
        static string[] Drs_Ginecologia = new string[] { "Dra. Maria", "Dra. Jimena", "Dra. Luz", "Dra. Paloma" };
        static string[] Drs_Traumatologia = new string[] { "Dra. Abigail", "Dr. Luis", "Dr. Esteban", "Dr. Quispe" };
        static string[] Drs_Cirugia = new string[] { "Dra. Camila", "Dra. Cielo", "Dr. Huaman", "Dr. Calderon" };

        static string doctor_elegido = "";

        static int especialidad_pacientes = 0;

        static string ruta_archivo = "pacientes.txt";

        // /-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/

        // F U N C I O N E S /-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/

        static public void Registrar_Paciente()
        {
            if(Cantidad_Pacientes >= MAX_PACIENTES)
            {
                Console.WriteLine("No se pueden registrar mas pacientes, se ha llegado al maximo soportado.");
                Console.ReadKey();
                return;
            }


            Console.WriteLine("***** REGISTRAR PACIENTE ****");

            Console.WriteLine("Por favor, ingrese los siguientes datos del paciente: ");

            Console.WriteLine("Ingrese el nombre del paciente: ");
            string nombre_paciente = Console.ReadLine()?.Trim();
            
            if(string.IsNullOrWhiteSpace(nombre_paciente))
            {
                Console.WriteLine("El nombre del paciente no puede estar vacío. Intente nuevamente.");
                return;
            }

            string nombre_paciente_mayus = nombre_paciente.ToUpper();
            string[] partes_nombre_paciente = nombre_paciente_mayus.ToUpper().Split(' ');

            Console.WriteLine("Ingrese la edad del paciente: ");
            string edad_paciente = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(edad_paciente))
            {
                Console.WriteLine("La edad del paciente es necesaria. Intente nuevamente.");
                return;
            }

                Console.WriteLine("Ingrese el genero del paciente: [ M / F ]");
            string genero_paciente = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(genero_paciente))
            {
                Console.WriteLine("El genero del paciente no puede estar vacio. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese el DNI del paciente: [ 8 digitos. ]");
            string dni_paciente = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrWhiteSpace(dni_paciente))
            {
                Console.WriteLine("Si el paciente no tiene DNI entonces no se puede hacer ninguna cita. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese el numero telefonico del paciente: ");
            string numero_paciente = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(numero_paciente))
            {
                Console.WriteLine("El paciente debe tener un numero al cual se le pueda contactar. Intente nuevamente.");
                return;
            }




            Console.WriteLine("Ingrese la especialidad con la que se quiere reservar una cita: ");
            Console.WriteLine("1. Medicina General");
            Console.WriteLine("2. Pediatria");
            Console.WriteLine("3. Ginecologia");
            Console.WriteLine("4. Traumatologia");
            Console.WriteLine("5. Cirugia");

            int especialidad_paciente = int.Parse(Console.ReadLine()?.Trim());


            do
            {
                if (especialidad_paciente < 1 || especialidad_paciente > 5)
                {
                    Console.WriteLine("La especialidad ingresada no es válida. Intente nuevamente.");
                    return;
                }

                if(especialidad_paciente == 1)
                {
                    for(int i = 0; i < Drs_MedicinaG.Length; i++)
                    {
                        Console.WriteLine("Doctores disponibles: " + Drs_MedicinaG[i]);
                        int doctor_elegido = int.Parse(Console.ReadLine()?.Trim());
                    }
                }

                if(especialidad_paciente == 2)
                {
                    for (int i = 0; i < Drs_Pediatria.Length; i++)
                    {
                        Console.WriteLine("Doctores disponibles: " + Drs_Pediatria[i]);
                        doctor_elegido = (Console.ReadLine()?.Trim());
                    }
                }

                if(especialidad_paciente == 3)
                {
                    for (int i = 0; i < Drs_Ginecologia.Length; i++)
                    {
                        Console.WriteLine("Doctores disponibles: " + Drs_Ginecologia[i]);
                        doctor_elegido = Console.ReadLine()?.Trim();
                    }
                }

                if(especialidad_paciente == 4)
                {
                    for (int i = 0; i < Drs_Traumatologia.Length; i++)
                    {
                        Console.WriteLine("Doctores disponibles: " + Drs_Traumatologia[i]);
                        doctor_elegido = (Console.ReadLine()?.Trim());
                    }
                }

                if(especialidad_paciente == 5)
                {
                    for (int i = 0; i < Drs_Cirugia.Length; i++)
                    {
                        Console.WriteLine("Doctores disponibles: " + Drs_Cirugia[i]);
                        doctor_elegido = (Console.ReadLine()?.Trim());
                    }
                }

            }
            while (especialidad_paciente == 0);

            Console.WriteLine("Ingrese la fecha y hora de la cita: [ DD/MM/AÑO ]");
            string fecha_cita = Console.ReadLine()?.Trim();

            if(string.IsNullOrWhiteSpace(fecha_cita))
            {
                Console.WriteLine("La fecha de la cita es necesaria. Intente nuevamente.");
                return;


            }

            Random Hora_Aleatoria = new Random();

            


            Random Numero_Aleatorio_Para_Correo = new Random();

            arreglo_PACIENTES[MAX_PACIENTES] = nombre_paciente_mayus;
            arreglo_DNI[MAX_PACIENTES] = dni_paciente;
            arreglo_NUMTELF[MAX_PACIENTES] = numero_paciente;
            arreglo_GENERO[MAX_PACIENTES] = genero_paciente;
            arreglo_EDAD[MAX_PACIENTES] = edad_paciente;
            arreglo_DOCTOR[MAX_PACIENTES] = doctor_elegido;





            string correo_paciente = $"{partes_nombre_paciente[0].ToLower()}.{partes_nombre_paciente[1].ToLower()}{Numero_Aleatorio_Para_Correo.Next(100, 1000)}@gmail.com";

            arreglo_CORREO_PACIENTES[MAX_PACIENTES] = correo_paciente;

            Console.WriteLine("Se ha registrado exitosamente...");
            Console.WriteLine("Para mantener al paciente en contacto se ha creado un correo electronico para el paciente: " + correo_paciente);
            Console.WriteLine("");
            
            Console.WriteLine("Puede cambiar la direccion del correo electronico a la de su gusto volviendo al menu y eligiendo la opcion: " + " Modificar historia clinca.");


            Console.WriteLine("*****************************");

            Cantidad_Pacientes++;



            Console.ReadKey();
        }


        static public void Buscar_historia_Clinica()
        {

        }

        static public void Mostrar_Pacientes_Registrados()
        {

        }

        static public void Modificar_historia_clinica() 
        {
        
        }

        static public void Guardar_datos_archivo()
        {

        }

        static public void Cargar_Datos_de_Archivo()
        {

        }







        // /-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/

        static void Main(string[] args)
        {


            Cargar_Datos_de_Archivo();

            int opcion = 0;
            while(opcion != 6)
            {
                
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("   CENTRO MATERNO INFANTIL MÉXICO"     );
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Registrar paciente.");
                Console.WriteLine("2. Buscar historia clínica.");
                Console.WriteLine("3. Pacientes registrados.");
                Console.WriteLine("4. Modificar historia clínica.");
                Console.WriteLine("5. Guardar información (archivo).");
                Console.WriteLine("6. Salir.");

                if (!int.TryParse(Console.ReadLine(), out opcion))

                {

                    Console.WriteLine("Ingrese un valor númerico válido");

                    Console.ReadKey();

                    continue;

                }
                switch(opcion)
                {
                    case 1:
                        Registrar_Paciente();
                        break;
                    case 2:
                        Buscar_historia_Clinica();
                        break;
                    case 3:
                        Mostrar_Pacientes_Registrados();
                        break;
                    case 4:
                        Modificar_historia_clinica();
                        break;
                    case 5:
                        Guardar_datos_archivo();
                        break;
                    case 6:
                        Console.WriteLine("Gracias, y hasta pronto!!!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;

                }


            }
        }
    }
}
