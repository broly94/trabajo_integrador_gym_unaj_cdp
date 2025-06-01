namespace trabajo_integrador_gym_unaj_cdp
{
    internal class Program
    {
        static object[][] ContainerUser = new object[40][];
        static string[] Keys = { "Nombre", "Apellido", "DNI", "Número de socio",
                          "Email", "Edad", "Peso actual", "Altura", "Nivel de actividad" };

        static void Main(string[] args)
        {
            Welcome();
            Menu();
        }
        public static String Welcome()
        {
            return "Bienvenidos...\nSe podrá registrar como maximo 40 personas.\nSeleccione alguna de las siguientes opciones.\n\n";
        }

        public static void Menu()
        {

            int option = 0;

            while (option != 9)
            {
                //Recorre el bucle hasta que exit sea lo contrario a su valor
                //En este caso exit es falso, entonces cuando exit sea verdadero, sale del bucle

                Console.WriteLine("===== Menú =====");
                Console.WriteLine("1. Cargar datos del cliente.");
                Console.WriteLine("2. Calcular IMC de todos los clientes.");
                Console.WriteLine("3. Mostrar clientes según su nivel de actividad.");
                Console.WriteLine("4. Mostrar clientes fuera del rango saludable (IMC).");
                Console.WriteLine("5. Buscar cliente por numero de socio.");
                Console.WriteLine("6. Promedio de edad de los clientes.");
                Console.WriteLine("7. Mostrar todos los usuarios");
                Console.WriteLine("8. Cargar usuarios ficticios");
                Console.WriteLine("9. Salir");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out option))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un numero que este en el menú.");
                    Console.ResetColor();
                    continue;
                }
                else
                {
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            CreateUsers();
                            break;
                        case 2:
                            Console.Clear();
                            CalculateAllIMC();
                            break;
                        case 3:
                            Console.Clear();
                            GetClientByActivity();
                            break;
                        case 4:
                            Console.Clear();
                            GetImcByRangeForHealthy();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Ingrese el numero de socio: ");
                            int NumberMemberShip = int.Parse(Console.ReadLine());
                            ShowClientByMemberShip(NumberMemberShip);
                            break;
                        case 6:
                            Console.Clear();
                            ShowAgeAverageClient();
                            break;
                        case 7:
                            ShowAllUsers();
                            break;
                        case 8:
                            Console.Clear();
                            CastingUsers();
                            break;
                        case 9:
                            Console.WriteLine("Bye...");
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ingrese un numero que este en el menú.");
                            Console.ResetColor();
                            break;

                    }
                    Console.ResetColor();
                }
            }
        }

        //Ordenado por numero de opcion del menu
        public static void CreateUsers()
        {

            for (int i = 0; i < ContainerUser.Length; i++)
            {
                // Se verifica que el lugar donde se va agregar el nuevo usuario sea null
                // Asi no se superpone la información
                if (ContainerUser[i] == null)
                {
                    Console.WriteLine($"\n--- Ingresar datos del usuario #{i + 1} ---");

                    Console.Write("Nombre: ");
                    string Name = Console.ReadLine();

                    Console.Write("Apellido: ");
                    string LastName = Console.ReadLine();

                    Console.Write("DNI: ");
                    int Dni = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Número de socio: ");
                    int NumberMembership = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Email: ");
                    string Email = Console.ReadLine();

                    Console.Write("Edad: ");
                    int Age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Peso actual (En KG): ");
                    double Weight = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Altura (En CM sin puntos ni comas): ");
                    double Height = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Nivel de actividad (Bajo, Medio, Alto): ");
                    string LevelActivity = Console.ReadLine();

                    object[] User = new object[9];
                    User[0] = Name;
                    User[1] = LastName;
                    User[2] = Dni;
                    User[3] = NumberMembership;
                    User[4] = Email;
                    User[5] = Age;
                    User[6] = Weight;
                    User[7] = Height;
                    User[8] = LevelActivity;

                    ContainerUser[i] = User;

                    Console.WriteLine("Usuario cargado correctamente.\n");

                    Console.WriteLine("¿Desea continuar agregando usuarios?\n");

                    Console.WriteLine("Ingrese la letra s (Si) o n (No): ");
                    string OptionNextCreateUser = Console.ReadLine();

                    if (OptionNextCreateUser == "s")
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
                }
            }
        }

        public static void CalculateAllIMC()
        {
            double IMC = 0.0;
            string Name = "";
            double Weight = 0.0;
            double Height = 0.0;

            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < ContainerUser.Length; i++)
            {
                if (ContainerUser[i] != null)
                {
                    Name = Convert.ToString(ContainerUser[i][0]);
                    Weight = Convert.ToInt64(ContainerUser[i][6]);
                    Height = Convert.ToDouble(ContainerUser[i][7]) * Convert.ToDouble(ContainerUser[i][7]);
                    IMC = Math.Round((Weight / Height) * 10000, 2);
                    Console.WriteLine($"El/La cliente/a {Name} tiene un IMC de: {IMC}");
                }
            }

            Console.WriteLine("\n");
            Console.ResetColor();

        }

        public static void GetClientByActivity()
        {
            string LevelActivity = "";
            string Client = "";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ingrese que nivel de actividad quiere visualizar...");
            Console.WriteLine("b = (Bajo), m = (Medio), a = (Alto)");
            Console.ResetColor();

            char Letter = char.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < ContainerUser.Length; i++)
            {
                if (ContainerUser[i] != null)
                {

                    if (Letter == Convert.ToChar(ContainerUser[i][8].ToString().ToLower()[0]))
                    {
                        LevelActivity = ContainerUser[i][8].ToString();
                        Client = ContainerUser[i][0].ToString();
                        Console.WriteLine($"El/La cliente/a {Client} tiene un nivel de actividad {ContainerUser[i][8]}");
                    }


                }
            }
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        public static void GetImcByRangeForHealthy()
        {

            double IMC = 0.0;
            string Name = "";
            double Weight = 0.0;
            double Height = 0.0;

            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < ContainerUser.Length; i++)
            {
                if (ContainerUser[i] != null)
                {
                    Name = Convert.ToString(ContainerUser[i][0]);
                    Weight = Convert.ToInt64(ContainerUser[i][6]);
                    Height = Convert.ToDouble(ContainerUser[i][7]) * Convert.ToDouble(ContainerUser[i][7]);
                    IMC = Math.Round((Weight / Height) * 10000, 2);
                    if (IMC < 18.5 || IMC > 24.9)
                    {
                        Console.WriteLine($"El/La cliente/a {Name} esta fuera del rango saludable -> IMC: {IMC}");
                    }
                }

            }
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        public static void ShowClientByMemberShip(int NumberMembership)
        {

            for (int i = 0; i < ContainerUser.Length; i++)
            {
                if (ContainerUser[i] != null)
                {

                    if (int.Parse(ContainerUser[i][3].ToString()) == NumberMembership)
                    {

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"=== Cliente Número: {ContainerUser[i][3]} ===");
                        Console.WriteLine($"Nombre: {ContainerUser[i][0]}");
                        Console.WriteLine($"Apellido: {ContainerUser[i][1]}");
                        Console.WriteLine($"Dni: {ContainerUser[i][2]}");
                        Console.WriteLine($"Email: {ContainerUser[i][4]}");
                        Console.WriteLine($"Edad: {ContainerUser[i][5]}");
                        Console.WriteLine($"Peso Actual (En KG): {ContainerUser[i][6]}");
                        Console.WriteLine($"Altura (en CM): {ContainerUser[i][7]}");
                        Console.WriteLine($"Nivel de actividad: {ContainerUser[i][8]}");
                        Console.WriteLine("==================================");
                        Console.ResetColor();
                        Console.WriteLine("\n");

                    }
                }
            }
        }

        public static void ShowAgeAverageClient()
        {

            int SumAge = 0;
            int CounterAge = 0;

            for (int i = 0; i < ContainerUser.Length; i++)
            {

                if (ContainerUser[i] != null)
                {

                    SumAge += Convert.ToInt32(ContainerUser[i][5]);

                    CounterAge++;

                }
            }

            if (CounterAge > 0)
            {
                double Average = Convert.ToInt32(SumAge / CounterAge);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"El primedio de edad es: {Average}");
                Console.ResetColor();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay clientes registrados");
                Console.ResetColor();
            }

        }

        public static void ShowAllUsers()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < ContainerUser.Length; i++)
            {
                if (ContainerUser[i] != null)
                {
                    Console.WriteLine($"###Cliente numero: {i + 1}####");

                    Console.WriteLine($"{Keys[0]} : {ContainerUser[i][0]}");
                    Console.WriteLine($"{Keys[1]} : {ContainerUser[i][1]}");
                    Console.WriteLine($"{Keys[2]} : {ContainerUser[i][2]}");
                    Console.WriteLine($"{Keys[3]} : {ContainerUser[i][3]}");
                    Console.WriteLine($"{Keys[4]} : {ContainerUser[i][4]}");
                    Console.WriteLine($"{Keys[5]} : {ContainerUser[i][5]}");
                    Console.WriteLine($"{Keys[6]} : {ContainerUser[i][6]}");
                    Console.WriteLine($"{Keys[7]} : {ContainerUser[i][7]}");
                    Console.WriteLine($"{Keys[8]} : {ContainerUser[i][8]}");

                    Console.WriteLine($"=================================\n");
                }
            }

            Console.ResetColor();
        }

        public static void CastingUsers()
        {
            for (int i = 0; i < UsersCast().Length; i++)
            {

                if (ContainerUser[i] == null)
                {
                    ContainerUser[i] = UsersCast()[i];
                }

            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usuarios Creados");
            Console.ResetColor();
        }

        public static object[][] UsersCast()
        {
            return [
                [ "Juan", "Pérez", 12345678, 1, "juan.perez@example.com", 25, 70.5, 175, "Medio" ],
                [ "María", "Gómez", 23456789, 2, "maria.gomez@example.com", 32, 60.2, 160, "Alto" ],
                [ "Luis", "Martínez", 34567890, 3, "luis.martinez@example.com", 40, 80.0, 180, "Bajo" ],
                [ "Ana", "López", 45678901, 4, "ana.lopez@example.com", 28, 55.0, 165, "Medio" ],
                [ "Carlos", "Rodríguez", 56789012, 5, "carlos.rodriguez@example.com", 35, 90.3, 185, "Alto" ],
                [ "Lucía", "Fernández", 67890123, 6, "lucia.fernandez@example.com", 22, 50.8, 158, "Medio" ],
                [ "Pedro", "González", 78901234, 7, "pedro.gonzalez@example.com", 30, 75.0, 178, "Bajo" ],
                [ "Sofía", "Ramírez", 89012345, 8, "sofia.ramirez@example.com", 27, 62.4, 162, "Alto" ],
                [ "Diego", "Torres", 90123456, 9, "diego.torres@example.com", 45, 85.6, 172, "Medio" ],
                [ "Valentina", "Sánchez", 11223344, 10, "valentina.sanchez@example.com", 19, 54.3, 167, "Alto" ]
            ];
        }

    }
}
