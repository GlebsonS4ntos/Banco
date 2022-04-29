using System;

namespace BancoAlterações
{
    class ContaBancaria
    {
        public int Numero { get; private set; }
        public string Proprietario { get; set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numero, string propriedade, double saldo)
        {
            this.Numero = numero;
            this.Proprietario = propriedade;
            this.Saldo = saldo;
        }
        public void Depositar(double valor)
        {
            Saldo += valor;
        }
        public void Sacar(double valor)
        {
            double taxa = 5.0;
            Saldo = (Saldo - valor) - taxa;
        }

        public override string ToString()
        {
            return "Numero da Conta: " +
                Numero + ", Proprietario: "
                + Proprietario + ", Saldo: " + Saldo;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria conta1;
            double saldo;

            Console.Write("Entre com o numero da Conta: ");
            int numeroDaConta = int.Parse(Console.ReadLine());
            Console.Write("Entre com o nome do proprietario: ");
            string proprietario = Console.ReadLine();
            Console.Write("Tera deposito inicial (s/n) ? ");
            char escolha = char.Parse(Console.ReadLine());

            if (escolha == 's')
            {
                Console.Write("Digite o valor do Deposito: ");
                saldo = double.Parse(Console.ReadLine());
            }
            else
            {
                saldo = 0;
            }

            conta1 = new ContaBancaria(numeroDaConta, proprietario, saldo);

            Console.WriteLine();
            Console.WriteLine(conta1.ToString());
            Console.WriteLine();

            Console.Write("Quanto você gostaria de Depositar ? ");
            double valor = double.Parse(Console.ReadLine());

            conta1.Depositar(valor);
            Console.WriteLine(conta1.ToString());

            Console.WriteLine();

            Console.Write("Quanto você gostaria de Sacar ? ");
            double saque = double.Parse(Console.ReadLine());

            conta1.Sacar(saque);
            Console.WriteLine(conta1.ToString());

        }
    }
}
