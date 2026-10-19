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
        static string[] arreglo_NUMTELF = new string[MAX_PACIENTES];
        static string[] arreglo_CORREO_PACIENTES = new string[MAX_PACIENTES];
        static string[] arreglo_ESPECIALIDADES = new string[MAX_PACIENTES];
        static string[] arreglo_FECHAHORA = new string[MAX_PACIENTES];
        static string[] arreglo_DOCTOR = new string[MAX_PACIENTES];

        static string[] Drs_MedicinaG = new string[] { "Dr.Juan", "Dr.Camilo", "Dr.Ramos", "Dr.Camilo" };
        static string[] Drs_Pediatria = new string[] { "Dr.Cruz", "Dr.Inga", "Dr.Chumpitaz", "Dra.Quispe" };
        static string[] Drs_Ginecologia = new string[] { "Dra.Maria", "Dra.Jimena", "Dra.Luz", "Dra.Paloma" };
        static string[] Drs_Traumatologia = new string[] { "Dra.Abigail", "Dr.Luis", "Dr.Esteban", "Dr.Quispe" };
        static string[] Drs_Cirugia = new string[] { "Dra.Camila", "Dra.Cielo", "Dr.Huaman", "Dr.Calderon" };

        static string doctor_elegido = "";
        static string ruta_archivo = "Registro_Pacientes_Hospital.txt";

        // /-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/

        // F U N C I O N E S /-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/

        static public void Registrar_Paciente()
        {
            if (Cantidad_Pacientes >= MAX_PACIENTES)
            {
                Console.WriteLine("No se pueden registrar mas pacientes, se ha llegado al maximo soportado.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("***** REGISTRAR PACIENTE ****");

            Console.WriteLine("Ingrese el nombre del paciente: ");
            string nombre_paciente = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(nombre_paciente))
            {
                Console.WriteLine("El nombre del paciente no puede estar vacío. Intente nuevamente.");
                return;
            }
            string nombre_paciente_mayus = nombre_paciente.ToUpper();
            string[] partes_nombre_paciente = nombre_paciente_mayus.Split(' ');

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
                genero_paciente = Console.ReadLine()?.Trim().ToUpper();
                if (genero_paciente != "M" && genero_paciente != "F")
                {
                    Console.WriteLine("Error: El genero debe ser solo 'M' o 'F'. Intente nuevamente.");
                }
            } while (genero_paciente != "M" && genero_paciente != "F");

            string dni_paciente_string = "";
            int validador_numeros = 0;
            do
            {
                Console.WriteLine("Ingrese el DNI del paciente: [ 8 digitos. ]");
                dni_paciente_string = Console.ReadLine()?.Trim();

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
            do
            {
                Console.WriteLine("Ingrese el numero telefonico del paciente: [ OJO: 9 digitos, sin espacios ]");
                numero_paciente_string = Console.ReadLine()?.Trim();

                if (numero_paciente_string.Length != 9)
                {
                    Console.WriteLine("Error: El numero telefonico debe tener exactamente 9 digitos.");
                }
                else if (int.TryParse(numero_paciente_string, out validador_numeros) == false)
                {
                    Console.WriteLine("Error: El telefono debe contener solo números.");
                }
                else
                {
                    break;
                }
            } while (true);

            int especialidad_paciente = 0;
            string nombre_especialidad = "";
            do
            {
                Console.WriteLine("Ingrese la especialidad con la que se quiere reservar una cita: ");
                Console.WriteLine("1. Medicina General");
                Console.WriteLine("2. Pediatria");
                Console.WriteLine("3. Ginecologia");
                Console.WriteLine("4. Traumatologia");
                Console.WriteLine("5. Cirugia");

                string input_esp = Console.ReadLine()?.Trim();

                if (int.TryParse(input_esp, out especialidad_paciente) == false || especialidad_paciente < 1 || especialidad_paciente > 5)
                {
                    Console.WriteLine("Error: La especialidad ingresada no es válida. Elija un número del 1 al 5.");
                }
                else
                {
                    break;
                }
            } while (true);

            if (especialidad_paciente == 1)
            {
                nombre_especialidad = "Medicina General";
                for (int i = 0; i < Drs_MedicinaG.Length; i++) Console.WriteLine((i + 1) + ". [ " + Drs_MedicinaG[i] + " ]");
            }
            else if (especialidad_paciente == 2)
            {
                nombre_especialidad = "Pediatria";
                for (int i = 0; i < Drs_Pediatria.Length; i++) Console.WriteLine((i + 1) + ". [ " + Drs_Pediatria[i] + " ] ");
            }
            else if (especialidad_paciente == 3)
            {
                nombre_especialidad = "Ginecologia";
                for (int i = 0; i < Drs_Ginecologia.Length; i++) Console.WriteLine((i + 1) + ". [ " + Drs_Ginecologia[i] + " ] ");
            }
            else if (especialidad_paciente == 4)
            {
                nombre_especialidad = "Traumatologia";
                for (int i = 0; i < Drs_Traumatologia.Length; i++) Console.WriteLine((i + 1) + ". [ " + Drs_Traumatologia[i] + " ]");
            }
            else if (especialidad_paciente == 5)
            {
                nombre_especialidad = "Cirugia";
                for (int i = 0; i < Drs_Cirugia.Length; i++) Console.WriteLine((i + 1) + ". [ " + Drs_Cirugia[i] + " ]");
            }

            Console.WriteLine("Ingrese el doctor con el que se va a atender: [ Escriba el nombre por favor. ]");
            doctor_elegido = Console.ReadLine()?.Trim();

            Console.WriteLine("Ingrese la fecha y hora de la cita: [ DD/MM/AÑO ]");
            string fecha_cita = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(fecha_cita) || !fecha_cita.Contains("/"))
            {
                Console.WriteLine("La fecha de la cita no es válida. Registro cancelado.");
                return;
            }

            string dia_cita = fecha_cita.Split('/')[0];
            string mes_cita = fecha_cita.Split('/')[1];
            string año_cita = fecha_cita.Split('/')[2];

            Random Hora_Aleatoria = new Random();
            Random minuto_aleatorio = new Random();
            int hora_cita = Hora_Aleatoria.Next(6, 21);
            int minuto_cita = minuto_aleatorio.Next(0, 60);

            if (hora_cita < 12) meridiano = "AM";
            else meridiano = "PM";

            Random Numero_Aleatorio_Para_Correo = new Random();
            string apellido_correo = partes_nombre_paciente.Length > 1 ? partes_nombre_paciente[1].ToLower() : "paciente";
            string correo_paciente = $"{partes_nombre_paciente[0].ToLower()}.{apellido_correo}{Numero_Aleatorio_Para_Correo.Next(100, 1000)}@gmail.com";

            string fecha_y_hora_cita = $"El {doctor_elegido} lo vera el [ {dia_cita}/{mes_cita}/{año_cita} ] a las {hora_cita}:{minuto_cita} {meridiano}.";

            // GUARDANDO EN LA MEMORIA
            arreglo_NOMBRES[Cantidad_Pacientes] = nombre_paciente_mayus;
            arreglo_PACIENTES[Cantidad_Pacientes] = nombre_paciente_mayus;
            arreglo_DNI[Cantidad_Pacientes] = dni_paciente_string;
            arreglo_NUMTELF[Cantidad_Pacientes] = numero_paciente_string;
            arreglo_GENERO[Cantidad_Pacientes] = genero_paciente;
            arreglo_EDAD[Cantidad_Pacientes] = edad_paciente;
            arreglo_DOCTOR[Cantidad_Pacientes] = doctor_elegido;
            arreglo_ESPECIALIDADES[Cantidad_Pacientes] = nombre_especialidad;
            arreglo_FECHAHORA[Cantidad_Pacientes] = fecha_y_hora_cita;
            arreglo_CORREO_PACIENTES[Cantidad_Pacientes] = correo_paciente;

            Console.WriteLine("\nSe ha registrado exitosamente.");
            Console.WriteLine(" * RESUMEN * ");
            Console.WriteLine("Nombre del paciente: " + nombre_paciente_mayus);
            Console.WriteLine("Correo electronico asignado: " + correo_paciente);
            Console.WriteLine(fecha_y_hora_cita);
            Console.WriteLine(" *********** ");

            Cantidad_Pacientes++;
            

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static public void Ordenar_Pacientes_Por_Orden_Alfabetico()
        {
            if (Cantidad_Pacientes <= 1)
            {
                Console.WriteLine("No hay suficientes pacientes para ordenar...");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < Cantidad_Pacientes - 1; i++)
            {
                for (int j = 0; j < Cantidad_Pacientes - 1 - i; j++)
                {
                    if (string.Compare(arreglo_PACIENTES[j], arreglo_PACIENTES[j + 1]) > 0)
                    {
                        string temp;
                        temp = arreglo_PACIENTES[j]; arreglo_PACIENTES[j] = arreglo_PACIENTES[j + 1]; arreglo_PACIENTES[j + 1] = temp;
                        temp = arreglo_DNI[j]; arreglo_DNI[j] = arreglo_DNI[j + 1]; arreglo_DNI[j + 1] = temp;
                        temp = arreglo_GENERO[j]; arreglo_GENERO[j] = arreglo_GENERO[j + 1]; arreglo_GENERO[j + 1] = temp;
                        temp = arreglo_EDAD[j]; arreglo_EDAD[j] = arreglo_EDAD[j + 1]; arreglo_EDAD[j + 1] = temp;
                        temp = arreglo_CORREO_PACIENTES[j]; arreglo_CORREO_PACIENTES[j] = arreglo_CORREO_PACIENTES[j + 1]; arreglo_CORREO_PACIENTES[j + 1] = temp;
                        temp = arreglo_ESPECIALIDADES[j]; arreglo_ESPECIALIDADES[j] = arreglo_ESPECIALIDADES[j + 1]; arreglo_ESPECIALIDADES[j + 1] = temp;
                        temp = arreglo_FECHAHORA[j]; arreglo_FECHAHORA[j] = arreglo_FECHAHORA[j + 1]; arreglo_FECHAHORA[j + 1] = temp;
                        temp = arreglo_DOCTOR[j]; arreglo_DOCTOR[j] = arreglo_DOCTOR[j + 1]; arreglo_DOCTOR[j + 1] = temp;
                        temp = arreglo_NUMTELF[j]; arreglo_NUMTELF[j] = arreglo_NUMTELF[j + 1]; arreglo_NUMTELF[j + 1] = temp;
                    }
                }
            }

            Console.Clear(); // Limpiamos la pantalla para que la lista se vea ordenada desde arriba
            Console.WriteLine("¡Los pacientes han sido ordenados alfabéticamente con éxito!\n");

            // LLAMAMOS A LA FUNCIÓN QUE MUESTRA LOS DATOS AUTOMÁTICAMENTE
            Mostrar_Pacientes_Registrados();
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

            if (!encontrado) Console.WriteLine("No se encontró ningún paciente registrado con ese DNI.");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static public void Mostrar_Pacientes_Registrados()
        {
            if (Cantidad_Pacientes == 0)
            {
                Console.WriteLine("No hay pacientes registrados aún.");
            }
            for (int i = 0; i < Cantidad_Pacientes; i++)
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
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
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

                    Console.WriteLine("\n¡Datos actualizados en la memoria exitosamente!");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado) Console.WriteLine("No se encontró ningún paciente para modificar.");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static public void Guardar_datos_archivo()
        {
            if (Cantidad_Pacientes == 0)
            {
                Console.WriteLine("No hay pacientes que guardar.");
                return;
            }

            using (StreamWriter escribir = new StreamWriter(ruta_archivo))
            {
                for (int i = 0; i < Cantidad_Pacientes; i++)
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
            // Agregamos este mensaje para que el profesor sepa que la Opción 5 sí funcionó
            Console.WriteLine(">> Los datos han sido guardados correctamente en el archivo de texto.");
        }

        static public void Cargar_Datos_de_Archivo()
        {
            if (!File.Exists(ruta_archivo))
            {
                Console.WriteLine("No se encontró archivo previo. Iniciando base de datos limpia...");
                return;
            }

            try
            {
                using (StreamReader leer = new StreamReader(ruta_archivo))
                {
                    string linea;
                    while ((linea = leer.ReadLine()) != null)
                    {
                        if (linea.StartsWith("Paciente: "))
                        {
                            string[] partesPaciente = linea.Split(new string[] { ": " }, 3, StringSplitOptions.None);
                            if (partesPaciente.Length >= 3)
                            {
                                arreglo_PACIENTES[Cantidad_Pacientes] = partesPaciente[2];
                                arreglo_NOMBRES[Cantidad_Pacientes] = partesPaciente[2];
                            }

                            string lineaDni = leer.ReadLine();
                            if (lineaDni != null && lineaDni.StartsWith("DNI: ")) arreglo_DNI[Cantidad_Pacientes] = lineaDni.Substring(5).Trim();

                            string lineaGenero = leer.ReadLine();
                            if (lineaGenero != null && lineaGenero.StartsWith("Genero: ")) arreglo_GENERO[Cantidad_Pacientes] = lineaGenero.Substring(8).Trim();

                            string lineaEdad = leer.ReadLine();
                            if (lineaEdad != null && lineaEdad.StartsWith("Edad: ")) arreglo_EDAD[Cantidad_Pacientes] = lineaEdad.Substring(6).Trim();

                            string lineaTelefono = leer.ReadLine();
                            if (lineaTelefono != null && lineaTelefono.StartsWith("Numero de telefono: ")) arreglo_NUMTELF[Cantidad_Pacientes] = lineaTelefono.Substring(20).Trim();

                            string lineaCorreo = leer.ReadLine();
                            if (lineaCorreo != null && lineaCorreo.StartsWith("Correo electronico: ")) arreglo_CORREO_PACIENTES[Cantidad_Pacientes] = lineaCorreo.Substring(20).Trim();

                            string lineaEspecialidad = leer.ReadLine();
                            if (lineaEspecialidad != null && lineaEspecialidad.StartsWith("Especialidad: ")) arreglo_ESPECIALIDADES[Cantidad_Pacientes] = lineaEspecialidad.Substring(14).Trim();

                            string lineaCita = leer.ReadLine();
                            if (lineaCita != null && lineaCita.StartsWith("Datos de la cita: ")) arreglo_FECHAHORA[Cantidad_Pacientes] = lineaCita.Substring(18).Trim();

                            Cantidad_Pacientes++;
                        }
                    }
                }
                Console.WriteLine(">> Archivo de pacientes cargado con éxito.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error al intentar leer el archivo de registros.");
            }
        }

        // /-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/

        static void Main(string[] args)
        {
            // P R O G R A M A /-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/

            Cargar_Datos_de_Archivo();
            Console.WriteLine("Presione cualquier tecla para entrar al sistema...");
            Console.ReadKey();

            int opcion = 0;
            while (opcion != 7)
            {
                Console.Clear(); 
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("   CENTRO MATERNO INFANTIL MÉXICO     ");
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

                switch (opcion)
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
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 6:
                        Ordenar_Pacientes_Por_Orden_Alfabetico();
                        break;
                    case 7:
                        Console.WriteLine("Gracias, y hasta pronto!!!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}