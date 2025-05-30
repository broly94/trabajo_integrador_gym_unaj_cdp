namespace trabajo_integrador_gym_unaj_cdp
{
    internal class Program
    {
        static object[][] ContainerUser = new object[40][];
        static string[] Keys = { "Nombre", "Apellido", "DNI", "Número de socio",
                          "Email", "Edad", "Peso actual", "Altura", "Nivel de actividad" };

        static void Main(string[] args)
        {
            Menu();
        }
        public static String Welcome()
        {
            return "Bienvenidos...\nSe podrá registrar como maximo 40 personas.\nSeleccione alguna de las siguientes opciones.\n\n";
        }

        public static void Menu()
        {

            Welcome();

            bool exit = false;

            int option;

            while (!exit)
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
                Console.WriteLine("7. Salir");
                Console.WriteLine("8. Mostrar todos los usuarios");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out option))
                {
                    Console.WriteLine("Ingrese un numero que este en el menú.");
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
                            exit = Exit();
                            Console.WriteLine("Bye...");
                            break;
                        case 8:
                            ShowAllUsers();
                            break;
                        default:
                            Console.WriteLine("Opcion no reconocida...");
                            break;

                    }
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

            for (int i = 0; i < ContainerUser.Length; i++)
            {
                if (ContainerUser[i] != null)
                {
                    object[] User = (object[])ContainerUser[i];

                    Name = Convert.ToString(User[0]);
                    Weight = Convert.ToInt64(User[6]);
                    Height = Convert.ToDouble(User[7]) * Convert.ToDouble(User[7]);
                    IMC = Math.Round((Weight / Height) * 10000, 2);
                    Console.WriteLine($"El/La cliente/a {Name} tiene un IMC de: {IMC}");
                }
            }

        }

        public static void GetClientByActivity()
        {
            string LevelActivity = "";
            string Client = "";

            Console.WriteLine("Ingrese que nivel de actividad quiere visualizar...");
            Console.WriteLine("b = (Bajo), m = (Medio), a = (Alto)");
            char Letter = char.Parse(Console.ReadLine());

            for (int i = 0; i < ContainerUser.Length; i++)
            {
                if (ContainerUser[i] != null)
                {
                    object[] User = (object[])ContainerUser[i];

                    if (Letter == Convert.ToChar(User[8].ToString().ToLower()[0]))
                    {
                        LevelActivity = User[8].ToString();
                        Client = User[0].ToString();
                        Console.WriteLine($"El/La cliente/a {Client} tiene un nivel de actividad {User[8]}");
                        break;
                    }
                   
                }
            }
        }

        public static void GetImcByRangeForHealthy()
        {

            double IMC = 0.0;
            string Name = "";
            double Weight = 0.0;
            double Height = 0.0;

            for (int i = 0; i < ContainerUser.Length; i++)
            {
                if (ContainerUser[i] != null)
                {
                    object[] User = (object[])ContainerUser[i];

                    for (int j = 0; j < User.Length; j++)
                    {
                        Name = Convert.ToString(User[0]);
                        Weight = Convert.ToInt64(User[6]);
                        Height = Convert.ToDouble(User[7]) * Convert.ToDouble(User[7]);
                        IMC = Math.Round((Weight / Height) * 10000, 2);
                    }
                    if (IMC < 18.5 || IMC > 24.9)
                    {
                        Console.WriteLine($"El/La cliente/a {Name} esta fuera del rango saludable -> IMC: {IMC}");
                    }
                }

            }
        }

        public static void ShowClientByMemberShip(int NumberMembership)
        {

            for (int i = 0; i < ContainerUser.Length; i++)
            {
                if (ContainerUser[i] != null)
                {

                    object[] User = (object[])ContainerUser[i];

                    if (int.Parse(User[3].ToString()) == NumberMembership)
                    {

                        Console.Clear();
                        Console.WriteLine($"=== Cliente Número: {User[3]} ===");
                        Console.WriteLine($"Nombre: {User[0]}");
                        Console.WriteLine($"Apellido: {User[1]}");
                        Console.WriteLine($"Dni: {User[2]}");
                        Console.WriteLine($"Email: {User[4]}");
                        Console.WriteLine($"Edad: {User[5]}");
                        Console.WriteLine($"Peso Actual (En KG): {User[6]}");
                        Console.WriteLine($"Altura (en CM): {User[7]}");
                        Console.WriteLine($"Nivel de actividad: {User[8]}");
                        Console.WriteLine("==========");
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

                    object[] User = (object[])ContainerUser[i];

                    SumAge += Convert.ToInt32(User[5]);

                    CounterAge++;

                }
            }

            if (CounterAge > 0)
            {
                double Average = Convert.ToInt32(SumAge / CounterAge);
                Console.Clear();
                Console.WriteLine($"El primedio de edad es: {Average}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No hay clientes registrados");
            }

        }

        public static bool Exit()
        {
            return true;
        }

        public static void ShowAllUsers()
        {
            Console.Clear();

            for (int i = 0; i < ContainerUser.Length; i++)
            {
                if (ContainerUser[i] != null)
                {
                    Console.WriteLine($"###Cliente numero: {i + 1}####");

                    object[] User = (object[])ContainerUser[i];

                    for (int j = 0; j < User.Length; j++)
                    {
                        Console.WriteLine($"{Keys[j]} : {User[j]}");

                    }
                    Console.WriteLine($"=================================\n");
                }
            }
        }





    }
}
