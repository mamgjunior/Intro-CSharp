using System;
using dio.bakn.Enum;
using dio.bakn.Classes;
using System.Collections.Generic;

namespace dio.bakn
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        
        static void Main(string[] args)
        {
            const string sair = "X";

            string opcao = menuOpcoes();
            while (opcao.ToUpper() != sair)
            {
                switch (opcao)
                {
                    case "1":
                        listarContas();
                        break;
                    case "2":
                        inserirConta();
                        break;
                    case "3":
                        transferir();
                        break;
                    case "4":
                        sacar();
                        break;
                    case "5":
                        depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = menuOpcoes();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
        }

        private static void transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int origem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int destino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor da transferencia: ");
            double valor = double.Parse(Console.ReadLine());

            listaContas[origem].transferencia(listaContas[destino], valor);
        }

        private static void depositar()
        {
            Console.Write("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor que deseja sacar: ");
            double valor = double.Parse(Console.ReadLine());

            listaContas[numero].depositar(valor);
        }

        private static void sacar()
        {
            Console.Write("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor que deseja sacar: ");
            double valor = double.Parse(Console.ReadLine());

            listaContas[numero].sacar(valor);
        }

        private static void listarContas()
        {
            Console.WriteLine("Listando todas as contas...");
            if (listaContas.Count == 0)
                Console.WriteLine("Nenhuma conta foi cadastrada!");
            else
                for (int contador = 0; contador < listaContas.Count; contador++)
                    Console.WriteLine("#{0} - {1}", contador, listaContas[contador]);                         
                
            Console.ReadLine();
        }

        private static void inserirConta()
        {
            Console.WriteLine("*** Inserir uma nova conta ***");
            Console.Write("Digite 1 para pessoa fisica ou 2 para pessoa juridica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o valor do saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o valor do credito inicial: ");
            double credito = double.Parse(Console.ReadLine());

            Conta conta = new Conta(tipoConta: (TipoConta)tipoConta, saldo: saldo, credito: credito, nome: nome);
            listaContas.Add(conta);
        }

        private static string menuOpcoes()
        {
            Console.WriteLine("\nDio banck a seu dispor!\nInforme a opção desejada:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            return Console.ReadLine().ToUpper();
        }
    }
}
