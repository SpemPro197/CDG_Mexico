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

        static string meridiano = "";

        static string[] arreglo_DNI = new string[MAX_PACIENTES];
        static string[] arreglo_GENERO = new string[MAX_PACIENTES];
        static string[] arreglo_EDAD = new string[MAX_PACIENTES];
        static string[] arreglo_NOMBRES = new string[MAX_PACIENTES];
        static string [] arreglo_NUMTELF = new string[MAX_PACIENTES];
        static string[] arreglo_CORREO_PACIENTES = new string[MAX_PACIENTES];
        static string[] arreglo_ESPECIALIDADES = new string[MAX_PACIENTES];
        static string[] arreglo_FECHAHORA = new string[MAX_PACIENTES];
        static string[] arreglo_DOCTOR = new string[MAX_PACIENTES];
        static string[] Drs_MedicinaG = new string[] { "Dr.Juan", "Dr.Camilo", "Dr.Ramos", "Dr.Camilo" };
        static string[] Drs_Pediatria = new string[] { "Dr.Cruz", "Dr.Inga", "Dr.Chumpitaz", "Dra.Quispe" };
        static string[] Drs_Ginecologia = new string[] { "Dra.Maria", "Dra.Jimena", "Dra.Luz", "Dra.Paloma" };
        static string[] Drs_Traumatologia = new string[] { "Dra.Abigail", "Dr.Luis", "Dr.Esteban", "Dr.Quispe" };
        static string[] Drs_Cirugia = new string[] { "Dra.Camila", "Dra.Cielo", "Dr.Huaman", "Dr.Calderon" };

        static string[] nombres_de_pacientes = new string[MAX_PACIENTES];

        static string doctor_elegido = "";

        static int especialidad_pacientes = 0;

        static string ruta_archivo = "Registro_Pacientes_Hospital.txt";

       
       

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

            string genero_paciente = "";
            do
            {
                Console.WriteLine("Ingrese el genero del paciente: [ M / F ]");
                genero_paciente = Console.ReadLine().Trim().ToUpper();

                if (genero_paciente != "M" && genero_paciente != "F")
                {
                    Console.WriteLine("Error: Por favor ingrese solo 'M' para Masculino o 'F' para Femenino.");
                }

            } while (genero_paciente != "M" && genero_paciente != "F");


            string dni_paciente_string = "";
            int validador_numeros = 0;

            do
            {
                Console.WriteLine("Ingrese el DNI del paciente: [ 8 digitos. ]");
                dni_paciente_string = Console.ReadLine().Trim();

                if (dni_paciente_string.Length != 8)
                {
                    Console.WriteLine("Error: El DNI debe tener exactamente 8 digitos. Intente nuevamente.");
                }
                else if (int.TryParse(dni_paciente_string, out validador_numeros) == false)
                {
                    Console.WriteLine("Error: El DNI no puede contener letras ni símbolos. Ingrese solo números.");
                }
                else
                {
                    break;
                }

            } while (true);

            string numero_paciente_string = "";
            int numero_paciente = 0;

            do
            {
                Console.WriteLine("Ingrese el numero telefonico del paciente: [ OJO: El numero debe tener 9 digitos ]");
                numero_paciente_string = Console.ReadLine().Trim();

                if (numero_paciente_string.Length != 9)
                {
                    Console.WriteLine("Error: El telefono debe tener exactamente 9 digitos. Intente nuevamente.");
                }
                else if (int.TryParse(numero_paciente_string, out numero_paciente) == false)
                {
                    Console.WriteLine("Error: El telefono no puede contener letras ni símbolos. Ingrese solo números.");
                }
                else
                {
                    break;
                }

            } while (true);


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
                    continue;
                }

                if(especialidad_paciente == 1)
                {
                    for(int i = 0; i < Drs_MedicinaG.Length; i++)
                    {
                        Console.WriteLine("Doctores disponibles: ");
                        Console.WriteLine((i+1) + ". [ " + Drs_MedicinaG[i] + " ]");


                    }
                }

                if(especialidad_paciente == 2)
                {
                    for (int i = 0; i < Drs_Pediatria.Length; i++)
                    {
                        Console.WriteLine("Doctores disponibles: " );
                        Console.WriteLine((i+1) + ". [ " + Drs_Pediatria[i] + " ] ");
              
                    }
                }

                if(especialidad_paciente == 3)
                {
                    for (int i = 0; i < Drs_Ginecologia.Length; i++)
                    {
                        Console.WriteLine("Doctores disponibles: " );
                        Console.WriteLine((i+1) + ". [ " + Drs_Ginecologia[i] + " ] ");

                    }
                }

                if(especialidad_paciente == 4)
                {
                    for (int i = 0; i < Drs_Traumatologia.Length; i++)
                    {
                        Console.WriteLine("Doctores disponibles: " );
                        Console.WriteLine((i+1) + ". [ " + Drs_Traumatologia[i] + " ]");
                    }
                }

                if(especialidad_paciente == 5)
                {
                    for (int i = 0; i < Drs_Cirugia.Length; i++)
                    {
                        Console.WriteLine("Doctores disponibles: ");
                        Console.WriteLine((i+1) + ". [ " + Drs_Cirugia[i] + " ]");

                    }
                }

                Console.ReadKey();
                Console.WriteLine("Ingrese el doctor con el que se va a atender: [ Escriba el nombre por favor. ]");
                doctor_elegido = (Console.ReadLine()?.Trim());

                if(doctor_elegido == null || string.IsNullOrWhiteSpace(doctor_elegido))
                {
                    Console.WriteLine("El doctor elegido no puede estar vacío. Intente nuevamente.");
                    continue;
                }

            }
            while (especialidad_paciente == 0);

            Console.WriteLine("Ingrese la fecha y hora de la cita: [ DD/MM/AÑO ]");
            string fecha_cita = Console.ReadLine()?.Trim();

            string dia_cita = fecha_cita.Split('/')[0];
            string mes_cita = fecha_cita.Split('/')[1];
            string año_cita = fecha_cita.Split('/')[2];

            if (string.IsNullOrWhiteSpace(fecha_cita))
            {
                Console.WriteLine("La fecha de la cita es necesaria. Intente nuevamente.");
                return;


            }

            Random Hora_Aleatoria = new Random();

            Random minuto_aleatorio = new Random();

            int hora_cita = Hora_Aleatoria.Next(6, 21);
            int minuto_cita = minuto_aleatorio.Next(0, 60);

            if (hora_cita < 12)
            {
                meridiano = "AM";
            }
            else
            {
                meridiano = "PM";
            }

            Random Numero_Aleatorio_Para_Correo = new Random();

       

            string correo_paciente = $"{partes_nombre_paciente[0].ToLower()}.{partes_nombre_paciente[1].ToLower()}{Numero_Aleatorio_Para_Correo.Next(100, 1000)}@gmail.com";

            string fecha_y_hora_cita = $"El {doctor_elegido} lo vera el [ {dia_cita}/{mes_cita}/{año_cita} ] a las {hora_cita}:{minuto_cita}.{meridiano}.";


      


            arreglo_NOMBRES[Cantidad_Pacientes] = nombre_paciente_mayus;
            arreglo_PACIENTES[Cantidad_Pacientes] = nombre_paciente_mayus;
            arreglo_DNI[Cantidad_Pacientes] = dni_paciente_string;
            arreglo_NUMTELF[Cantidad_Pacientes] = numero_paciente_string;
            arreglo_GENERO[Cantidad_Pacientes] = genero_paciente;
            arreglo_EDAD[Cantidad_Pacientes] = edad_paciente;
            arreglo_DOCTOR[Cantidad_Pacientes] = doctor_elegido;
            arreglo_FECHAHORA[Cantidad_Pacientes] = fecha_y_hora_cita;
            arreglo_CORREO_PACIENTES[Cantidad_Pacientes] = correo_paciente;





            arreglo_CORREO_PACIENTES[Cantidad_Pacientes] = correo_paciente;

            Console.WriteLine("Se ha registrado exitosamente.");

            Console.WriteLine(" * RESUMEN * ");

       

            Console.WriteLine("Nombre del paciente: " + nombre_paciente_mayus); 

            Console.WriteLine("Para mantener al paciente en contacto se ha creado un correo electronico para el paciente: " + correo_paciente);

            Console.WriteLine(fecha_y_hora_cita);

            
            Console.WriteLine(" *********** ");
            
            
            Console.WriteLine("Puede cambiar la direccion del correo electronico a la de su gusto volviendo al menu y eligiendo la opcion: " + " [ 4. Modificar historia clinca. ]");


            Console.WriteLine("*****************************");

            Cantidad_Pacientes++;



            Console.ReadKey();
        }

        static public void Ordenar_Pacientes_Por_Orden_Alfabetico()
        {
            if(Cantidad_Pacientes <= 1)
            {
                Console.WriteLine("No hay suficientes pacientes para ordenar...");
                return;
            }

            for(int i = 0; i < Cantidad_Pacientes - 1; i++)
            {
                for(int j = 0; j < Cantidad_Pacientes - 1 - i; j++)
                {
                    if (string.Compare(arreglo_PACIENTES[j], arreglo_PACIENTES[j + 1]) > 0)
                    {
                        string nombre_temporal = arreglo_PACIENTES[j];
                        arreglo_PACIENTES[j] = arreglo_PACIENTES[j + 1];
                        arreglo_PACIENTES[j + 1] = nombre_temporal;

                        string dni_temporal = arreglo_DNI[j];
                        arreglo_DNI[j] = arreglo_DNI[j + 1];
                        arreglo_DNI[j + 1] = dni_temporal;

                        string genero_temporal = arreglo_GENERO[j];
                        arreglo_GENERO[j] = arreglo_GENERO[j + 1];
                        arreglo_GENERO[j + 1] = genero_temporal;

                        string edad_temporal = arreglo_EDAD[j];
                        arreglo_EDAD[j] = arreglo_EDAD[j + 1];
                        arreglo_EDAD[j + 1] = edad_temporal;

                        string correo_temporal = arreglo_CORREO_PACIENTES[j];
                        arreglo_CORREO_PACIENTES[j] = arreglo_CORREO_PACIENTES[j + 1];
                        arreglo_CORREO_PACIENTES[j + 1] = correo_temporal;

                        string especialidad_temporal = arreglo_ESPECIALIDADES[j];
                        arreglo_ESPECIALIDADES[j] = arreglo_ESPECIALIDADES[j + 1];
                        arreglo_ESPECIALIDADES[j + 1] = especialidad_temporal;

                        string fecha_hora_temporal = arreglo_FECHAHORA[j];
                        arreglo_FECHAHORA[j] = arreglo_FECHAHORA[j + 1];
                        arreglo_FECHAHORA[j + 1] = fecha_hora_temporal;

                        string doctor_temporal = arreglo_DOCTOR[j];
                        arreglo_DOCTOR[j] = arreglo_DOCTOR[j + 1];
                        arreglo_DOCTOR[j + 1] = doctor_temporal;

                        string numero_temporal = arreglo_NUMTELF[j];
                        arreglo_NUMTELF[j] = arreglo_NUMTELF[j + 1];
                        arreglo_NUMTELF[j + 1] = numero_temporal;

                    }


                }


            }


        }


        static public void Buscar_historia_Clinica()
        {
            Console.WriteLine("Ingrese el DNI del paciente a buscar:");
            string dni_buscar = Console.ReadLine()?.Trim();
            bool encontrado = false;

            for (int i = 0; i < Cantidad_Pacientes; i++)
            {
                if (arreglo_DNI[i] == dni_buscar)
                {
                    Console.WriteLine("\n--- PACIENTE ENCONTRADO ---");
                    Console.WriteLine("Nombre: " + arreglo_PACIENTES[i]);
                    Console.WriteLine("Especialidad: " + arreglo_ESPECIALIDADES[i]);
                    Console.WriteLine("Doctor: " + arreglo_DOCTOR[i]);
                    Console.WriteLine("Teléfono: " + arreglo_NUMTELF[i]);
                    encontrado = true;
                    break;
                }
            }

            if (encontrado == false)
            {
                Console.WriteLine("No se encontró ningún paciente registrado con ese DNI.");
            }
        }

        static public void Mostrar_Pacientes_Registrados()
        {
            for(int i = 0; i < Cantidad_Pacientes; i++)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Paciente: " + (i + 1) + ": " + arreglo_PACIENTES[i]);
                Console.WriteLine("DNI: " + arreglo_DNI[i]);
                Console.WriteLine("Genero: " + arreglo_GENERO[i]);
                Console.WriteLine("Edad: " + arreglo_EDAD[i]);
                Console.WriteLine("Numero de telefono: " + arreglo_NUMTELF[i]);
                Console.WriteLine("Correo electronico: " + arreglo_CORREO_PACIENTES[i]);
                Console.WriteLine("Especialidad: " + arreglo_ESPECIALIDADES[i]);
                Console.WriteLine("Datos de la cita: " + arreglo_FECHAHORA[i]);
                Console.WriteLine("--------------------------------------");
            }



        }

        static public void Modificar_historia_clinica()
        {
            Console.WriteLine("Ingrese el DNI del paciente que desea modificar:");
            string dni_buscar = Console.ReadLine()?.Trim();
            bool encontrado = false;

            for (int i = 0; i < Cantidad_Pacientes; i++)
            {
                if (arreglo_DNI[i] == dni_buscar)
                {
                    Console.WriteLine("\nPaciente encontrado: " + arreglo_PACIENTES[i]);

                    Console.WriteLine("Ingrese el nuevo correo electrónico:");
                    arreglo_CORREO_PACIENTES[i] = Console.ReadLine()?.Trim();

                    Console.WriteLine("Ingrese el nuevo número de teléfono:");
                    arreglo_NUMTELF[i] = Console.ReadLine()?.Trim();

                    Console.WriteLine("¡Datos actualizados en la memoria!");
                    encontrado = true;

                    Guardar_datos_archivo();

                    break;
                }
            }

            if (encontrado == false)
            {
                Console.WriteLine("No se encontró ningún paciente para modificar.");
            }
        }

        static public void Guardar_datos_archivo()
        {
            if(Cantidad_Pacientes == 0)
            {
                Console.WriteLine("No hay pacientes que guardar.");
                return;
            }

            using (StreamWriter escribir = new StreamWriter(ruta_archivo))
            {
                for(int i = 0; i < Cantidad_Pacientes; i++)
                {
                    escribir.WriteLine("--------------------------------------");
                    escribir.WriteLine("Paciente: " + (i + 1) + ": " + arreglo_PACIENTES[i]);
                    escribir.WriteLine("DNI: " + arreglo_DNI[i]);
                    escribir.WriteLine("Genero: " + arreglo_GENERO[i]);
                    escribir.WriteLine("Edad: " + arreglo_EDAD[i]);
                    escribir.WriteLine("Numero de telefono: " + arreglo_NUMTELF[i]);
                    escribir.WriteLine("Correo electronico: " + arreglo_CORREO_PACIENTES[i]);
                    escribir.WriteLine("Especialidad: " + arreglo_ESPECIALIDADES[i]);
                    escribir.WriteLine("Datos de la cita: " + arreglo_FECHAHORA[i]);
                    escribir.WriteLine("--------------------------------------");
                }


            }



        }

        static public void Cargar_Datos_de_Archivo()
        {
            if(!File.Exists(ruta_archivo))
            {
                Console.WriteLine("No se encontró el archivo de datos. Se creará uno nuevo al guardar.");
                return;
            }

            using (StreamReader leer = new StreamReader(ruta_archivo))
            {
                for (int i = 0; i < Cantidad_Pacientes; i++)
                {


                }


            }


        }







        // /-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/

        static void Main(string[] args)
        {
            // P R O G R A M A /-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/

            Cargar_Datos_de_Archivo();

            int opcion = 0;
            while(opcion != 7)
            {
                
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("   CENTRO MATERNO INFANTIL MÉXICO"     );
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Registrar paciente.");
                Console.WriteLine("2. Buscar historia clínica.");
                Console.WriteLine("3. Ver Pacientes registrados.");
                Console.WriteLine("4. Modificar historia clínica.");
                Console.WriteLine("5. Guardar información (archivo).");
                Console.WriteLine("6. Ordenar pacientes por orden alfabético.");
                Console.WriteLine("7. Salir.");

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
                        Ordenar_Pacientes_Por_Orden_Alfabetico();
                        break;
                    case 7:
                        Console.WriteLine("Gracias, y hasta pronto!!!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;

                }


            }

            // /-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/
        }


    }
}
