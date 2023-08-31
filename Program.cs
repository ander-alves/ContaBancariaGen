using ContaBancaria.Model;

namespace ContaBancaria
{
    public class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;

        static void Main(string[] args)
        {

            
            Conta c1 = new Conta(1,123,1,"USUARIO",100500.00M);
            
            c1.Visualizar();
            c1.Sacar(12000.0M);
            c1.Visualizar();
            c1.Depositar(5000.0M);
            c1.Visualizar();
           
            int opcao;



            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=====================================================");
                Console.WriteLine("                                                     ");
                LogoBanco();
                Console.WriteLine("                                                     ");
                Console.WriteLine("=====================================================");
                Console.WriteLine("                                                     ");
                Console.WriteLine("            1 - Criar Conta                          ");
                Console.WriteLine("            2 - Listar todas as Contas               ");
                Console.WriteLine("            3 - Buscar Conta por Numero              ");
                Console.WriteLine("            4 - Atualizar Dados da Conta             ");
                Console.WriteLine("            5 - Apagar Conta                         ");
                Console.WriteLine("            6 - Sacar                                ");
                Console.WriteLine("            7 - Depositar                            ");
                Console.WriteLine("            8 - Transferir valores entre Contas      ");
                Console.WriteLine("            9 - Sair                                 ");
                Console.WriteLine("                                                     ");
                Console.WriteLine("=====================================================");
                Console.WriteLine("                                                     ");
                Console.WriteLine("Entre com a opção desejada:                          ");
                Console.WriteLine("                                                     ");
                Console.ResetColor();


                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 9)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nBanco do NoBank's - Bem Melhor que o ROXO ;D");
                    Sobre();
                    Console.ResetColor();
                    System.Environment.Exit(0);
                }

                switch (opcao)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Criar Conta\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Listar todas as Contas\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Consultar dados da Conta - por número\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Atualizar dados da Conta\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;
                    case 5:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Apagar a Conta\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Saque\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Depósito\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Transferência entre Contas\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpção Inválida!\n");
                        Console.ResetColor();

                        KeyPress();
                        break;
                }
            }
        }

        static void Sobre()
        {
            Console.WriteLine("\n*********************************************************");
            Console.WriteLine("Projeto Desenvolvido por: Anderson Alves");
            Console.WriteLine("Email: alves_anderson@outlook.com");
            Console.WriteLine("Generation Brasil - generation@generation.org");
            Console.WriteLine("github.com/ander-alves");
            Console.WriteLine("*********************************************************");

        }

        static void KeyPress()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nPressione Enter para Continuar...");
                consoleKeyInfo = Console.ReadKey();

            } while (consoleKeyInfo.Key != ConsoleKey.Enter);
        }


        static void LogoBanco()
        {
            Console.WriteLine("      _   _      ______             _    _     \r\n" +
                 "     | \\ | |     | ___ \\           | |  ( )    \r\n" +
                 "     |  \\| | ___ | |_/ / __ _ _ __ | | _|/ ___ \r\n" +
                 "     | . ` |/ _ \\| ___ \\/ _` | '_ \\| |/ / / __|\r\n" +
                 "     | |\\  | (_) | |_/ / (_| | | | |   <  \\__ \\\r\n" +
                 "     \\_| \\_/\\___/\\____/ \\__,_|_| |_|_|\\_\\ |___/");

        }
    }
}

