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
                            ShowClientById(NumberMemberShip);
                            break;
                        case 6:
                            Console.Clear();
                            break;
                        case 7:
                            exit = true;
                            Console.WriteLine("Bye...");
                            break;
                        case 8:
                            ShowAllUsers();
                            break;
                        default:
                            exit = false;
                            break;

                    }
                }


            }
        }

        public static void ShowAllUsers()
        {

            object[][] Users = GetAllUsers();

            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i] != null)
                {

                    object[] User = (object[])Users[i];

                    for (int j = 0; j < User.Length; j++)
                    {
                        Console.WriteLine($"{Keys[j]} : {User[j]}");
                    }
                }
            }
        }

        public static void ShowClientById(int NumberMembership)
        {
            object[][] Users = GetAllUsers();

            object[] UserSelected = new object[9];

            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i] != null)
                {

                    object[] User = (object[])Users[i];

                    for (int j = 0; j < User.Length; j++)
                    {
                        if (int.Parse(User[3].ToString()) == NumberMembership)
                        {
                           
                            UserSelected[j] = User[j];
                       
                        }
                    }
                }
            }

           for(int i = 0; i < UserSelected.Length; i++)
            {
                Console.Clear();
                Console.WriteLine($"=== Cliente Número: {UserSelected[3]} ===");
                Console.WriteLine($"Nombre: {UserSelected[0]}");
                Console.WriteLine($"Apellido: {UserSelected[1]}");
                Console.WriteLine($"Dni: {UserSelected[2]}");
                Console.WriteLine($"Email: {UserSelected[4]}");
                Console.WriteLine($"Edad: {UserSelected[5]}");
                Console.WriteLine($"Peso Actual (En KG): {UserSelected[6]}");
                Console.WriteLine($"Altura (en CM): {UserSelected[7]}");
                Console.WriteLine($"Nivel de actividad: {UserSelected[8]}");
                Console.WriteLine("==========");
                Console.WriteLine("\n");
            }
        }

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

        public static object[][] GetAllUsers()
        {
            //Se crea por fuera y se seteea el indice no nulo de container.
            //Esto para verificar que no devuelva los lugares vacios dentro del array
            //Y en la variable count se guarda dicha cantidad de indices llenos.
            int count = 0;

            for (int i = 0; i < ContainerUser.Length; i++)
            {

                if (ContainerUser[i] != null)

                {
                    count++;
                }

            }

            //Se crea un vector nuevo con dimension = a la cantidad de los datos que existen dentro del ContainerUser que sean != null
            object[][] result = new object[count][];

            for (int i = 0; i < ContainerUser.Length; i++)
            {
                if (ContainerUser[i] != null)
                {
                    result[i] = ContainerUser[i];
                }
            }

            return result;

        }

        public static void CalculateAllIMC()
        {
            object[][] Users = GetAllUsers();

            double IMC = 0.0;
            string Name = "";
            double Weight = 0.0;
            double Height = 0.0;

            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i] != null)
                {
                    object[] User = (object[])Users[i];

                    for (int j = 0; j < User.Length; j++)
                    {
                        Name = Convert.ToString(User[0]);
                        Weight = Convert.ToInt64(User[6]);
                        Height = Convert.ToDouble(User[7]) * Convert.ToDouble(User[7]);
                        IMC = Math.Round((Weight / Height) * 10000, 2);
                    }
                }
                Console.WriteLine($"El/La cliente/a {Name} tiene un IMC de: {IMC}");
            }

        }


        public static void GetClientByActivity()
        {

            object[][] Users = GetAllUsers();

            string LevelActivity = "";
            string Client = "";

            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i] != null)
                {
                    object[] User = (object[])Users[i];

                    for (int j = 0; j < User.Length; j++)
                    {
                        if (User[8].ToString() == "bajo")
                        {
                            LevelActivity = User[8].ToString();
                            Client = User[0].ToString();


                        }
                        else if (User[8].ToString() == "medio")
                        {
                            LevelActivity = User[8].ToString();
                            Client = User[0].ToString();


                        }
                        else if (User[8].ToString() == "alto")
                        {
                            LevelActivity = User[8].ToString();
                            Client = User[0].ToString();

                        }
                    }

                    Console.WriteLine($"El/La cliente/a {Client} tiene un nivel de actividad {User[8]}");
                }
            }
        }

        //Terminar
        public static void GetImcByRangeForHealthy()
        {
            object[][] Users = GetAllUsers();

            double IMC = 0.0;
            string Name = "";
            double Weight = 0.0;
            double Height = 0.0;

            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i] != null)
                {
                    object[] User = (object[])Users[i];

                    for (int j = 0; j < User.Length; j++)
                    {
                        Name = Convert.ToString(User[0]);
                        Weight = Convert.ToInt64(User[6]);
                        Height = Convert.ToDouble(User[7]) * Convert.ToDouble(User[7]);
                        IMC = Math.Round((Weight / Height) * 10000, 2);
                    }
                }
                Console.WriteLine($"El/La cliente/a {Name} tiene un IMC de: {IMC}");
            }
        }


    }
}
