namespace trabajo_integrador_gym_unaj_cdp
{
    internal class Program
    {


        static object[][] ContainerUser = new object[40][];

        static void Main(string[] args)
        {
            Menu();
        }

        public static void ShowUsers()
        {
            string[] Keys = {
                                "Nombre", "Apellido", "DNI", "Número de socio",
                                "Email", "Edad", "Peso actual", "Altura", "Nivel de actividad"
};

            for (int i = 0; i < ContainerUser.Length; i++)
            {
                if (ContainerUser[i] != null)
                {
                    object[] User = (object[])ContainerUser[i];

                    for (int j = 0; j < User.Length; j++)
                    {
                        Console.WriteLine($"{Keys[j]} : {User[j]}");
                    }


                }

            }
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
                Console.WriteLine("3. Mostrar cliente según su nivel de actividad.");
                Console.WriteLine("4. Mostrar cliente fuera del rango saludable (IMC).");
                Console.WriteLine("5. Buscar cliente por numero de socio.");
                Console.WriteLine("6. Promedio de edad de los clientes.");
                Console.WriteLine("7. Salir");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out option))
                {
                    Console.WriteLine("Ingrese un numero que este en el menú.");
                } else
                {
                    switch (option)
                    {
                        case 1:
                            CreateUsers();
                            break;
                        case 2:
                            ShowUsers();
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            exit = true;
                            Console.WriteLine("Bye...");
                            break;
                        default:
                            exit = false;
                            break;

                    }
                }

               
            }
        }

        public static String Welcome()
        {
            return "Bienvenidos...\nSe podrá registrar como maximo 40 personas.\nSeleccione alguna de las siguientes opciones.\n\n";
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
                    string name = Console.ReadLine();

                    Console.Write("Apellido: ");
                    string lastName = Console.ReadLine();

                    Console.Write("DNI: ");
                    int dni = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Número de socio: ");
                    int membershipNumber = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Console.Write("Edad: ");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Peso actual: ");
                    double weight = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Altura: ");
                    double height = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Nivel de actividad (Bajo, Medio, Alto): ");
                    string levelActivity = Console.ReadLine();

                    object[] user = new object[9];
                    user[0] = name;
                    user[1] = lastName;
                    user[2] = dni;
                    user[3] = membershipNumber;
                    user[4] = email;
                    user[5] = age;
                    user[6] = weight;
                    user[7] = height;
                    user[8] = levelActivity;

                    ContainerUser[i] = user;

                    Console.WriteLine("Usuario cargado correctamente.\n");

                    Console.WriteLine("¿Desea continuar agregando usuarios?\n");

                    Console.WriteLine("Ingrese la letra s (Si) o n (No): ");
                    string OptionNextCreateUser = Console.ReadLine();

                    if (OptionNextCreateUser == "s")
                    
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

            }

        }

    }
}
