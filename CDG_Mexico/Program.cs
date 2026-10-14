using System;
using System.Diagnostics;
using System.IO;
namespace CDG_Mexico
{
    // TRABAJO HECHO POR: WILLIAM ADRIAN OCHOA DE SOUZA FERREYRA(N00549692), SANTIAGO GABRIEL RIVAS RAMOS (N00544024), DANIELA NORELIS ZUÑIGA TORRES (N00542769), FABRICIO ALDAIR CARRANZA MESA (N00538080).


    internal class Program
    {
        static int MAX_PACIENTES = 500;
        static string[] arreglo_DNI = new string[MAX_PACIENTES];
        static string[] arreglo_GENERO = new string[MAX_PACIENTES];
        static int[] arreglo_EDAD = new int[MAX_PACIENTES];
        static string[] arreglo_NOMBRES = new string[MAX_PACIENTES];
        static int [] arreglo_NUMTELF = new int[MAX_PACIENTES];
        static string[] arreglo_CORREO_PACIENTES = new string[MAX_PACIENTES];
        static string[] arreglo_ESPECIALIDADES = new string[MAX_PACIENTES];
        static string[] arreglo_FECHAHORA = new string[MAX_PACIENTES];
        static string[] arreglo_DOCTOR = new string[MAX_PACIENTES];
        string[] Drs_MedicinaG = new string[] { "Dr. Juan", "Dr. Camilo", "Dr. Ramos", "Dr. Camilo" };
        string[] Drs_Pediatria = new string[] { "Dr. Cruz", "Dr. Inga", "Dr. Chumpitaz", "Dra. Quispe" };
        string[] Drs_Ginecologia = new string[] { "Dra. Maria", "Dra. Jimena", "Dra. Luz", "Dra. Paloma" };
        string[] Drs_Traumatologia = new string[] { "Dra. Abigail", "Dr. Luis", "Dr. Esteban", "Dr. Quispe" };
        string[] Drs_Cirugia = new string[] { "Dra. Camila", "Dra. Cielo", "Dr. Huaman", "Dr. Calderon" }; 
        static string ruta_archivo = "pacientes.txt"; 
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
                Console.WriteLine("5.Guardar información (archivo).");
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

                }


            }
        }
    }
}
