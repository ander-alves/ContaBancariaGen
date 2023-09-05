using ContaBancaria.Controller;
using ContaBancaria.Model;

namespace ContaBancaria
{
    public class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;

        static void Main(string[] args)
        {
            //instancia da classe contaController
            ContaController contas = new();
              // Teste da Classe Conta Corrente
              ContaCorrente cc1 = new(1, 123, 1, "Mariana", 15000.0M, 1000.0M);
              contas.Cadastrar(cc1);
              /*cc1.Visualizar();
              cc1.Sacar(17000.0M);
              cc1.Visualizar();
              cc1.Depositar(5000.0M);
              cc1.Visualizar();*/

              //Teste da Classe Conta Poupança
              ContaPoupanca cp1 = new(2, 123, 2, "Victor", 100000.0M, 15);
            contas.Cadastrar(cp1);  
            /*cp1.Visualizar();
              cp1.Sacar(1000.0M);
              cp1.Visualizar();
              cp1.Depositar(5000.0M);
              cp1.Visualizar();
            */
            int opcao, agencia, tipo, aniversario,numero;
            string? titular;
            decimal saldo, limite;

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

                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDigite valores inteiros!");
                    opcao = 0;
                    Console.ResetColor();
                }

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
                        Console.WriteLine("Digite o Numero da Agencias: ");
                        agencia = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o Nome do Titular: ");
                        titular = Console.ReadLine();

                        titular ??= string.Empty;

                        do
                        {
                            Console.WriteLine("Digite o tipo da Conta (1 - CC ou 2 - CP)");
                            tipo = Convert.ToInt32(Console.ReadLine());
                        } while (tipo != 1 && tipo != 2);

                        Console.WriteLine("Digite o Saldo da Conta (R$): ");
                        saldo = Convert.ToDecimal(Console.ReadLine());

                        switch (tipo)
                        {
                            case 1:
                                Console.WriteLine("Digite o limite de Credito (R$): ");
                                limite = Convert.ToDecimal(Console.ReadLine());
                                contas.Cadastrar(new ContaCorrente(contas.GerarNumero(), agencia, tipo, titular, saldo, limite));
                                break;

                            case 2:
                                Console.WriteLine("Digite o dia do Aniversario da Conta ");
                                aniversario = Convert.ToInt32(Console.ReadLine());
                                contas.Cadastrar(new ContaPoupanca(contas.GerarNumero(), agencia, tipo, titular, saldo, aniversario));
                                break;
                        }

                        KeyPress();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Listar todas as Contas\n\n");
                        Console.ResetColor();

                        contas.ListarTodas();

                        KeyPress();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Consultar dados da Conta - por número\n\n");
                        Console.ResetColor();
                        
                        Console.WriteLine("Digite o Numero da Conta: ");
                        
                        numero = Convert.ToInt32(Console.ReadLine());
                        contas.ProcurarPorNumero(numero);

                        KeyPress();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Atualizar dados da Conta\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        var conta = contas.BuscarNaCollection(numero);

                        if (conta is not null)
                        {
                            Console.WriteLine("Digite o Número da Agência: ");
                            agencia = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Digite o Nome do Titular: ");
                            titular = Console.ReadLine();

                            titular ??= string.Empty;

                            Console.WriteLine("Digite o Saldo da Conta: ");
                            saldo = Convert.ToDecimal(Console.ReadLine());

                            tipo = conta.GetTipo();

                            switch (tipo)
                            {
                                case 1:
                                    Console.WriteLine("Digite o Limite da Conta: ");
                                    limite = Convert.ToDecimal(Console.ReadLine());

                                    contas.Atualizar(new ContaCorrente(numero, agencia, tipo, titular, saldo, limite));
                                    break;
                                case 2:
                                    Console.WriteLine("Digite o dia do Aniversário da Conta: ");
                                    aniversario = Convert.ToInt32(Console.ReadLine());

                                    contas.Atualizar(new ContaPoupanca(numero, agencia, tipo, titular, saldo, aniversario));
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                            Console.ResetColor();
                        }

                        KeyPress();
                        break;
                    case 5:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Apagar a Conta\n\n");
                        Console.ResetColor();
                        Console.WriteLine("Digite o Numero da Conta: ");

                        numero = Convert.ToInt32(Console.ReadLine());
                        contas.Deletar(numero);

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

