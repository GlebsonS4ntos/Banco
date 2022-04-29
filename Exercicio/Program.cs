using System;

namespace Exercicio
{
    class ContaBancaria
    {
        public int Numero { get; private set; }
        public char Tipo { get; private set; }
        public string Proprietario { get; set; }
        public double Saldo { get; protected set; }

        public ContaBancaria(int numero, char tipo, string propriedade, double saldo)
        {
            this.Numero = numero;
            this.Tipo = tipo;
            this.Proprietario = propriedade;
            this.Saldo = saldo;
        }
        public void Depositar(double valor)
        {
            Saldo += valor;
        }
        public virtual void Sacar(double valor)
        {
            double taxa = 5.0;
            if (valor + taxa <= Saldo )
                Saldo = (Saldo - valor) - taxa;
            else
                Console.WriteLine("Infelizmente você n pode realizar o saque, pois a soma do valor + taxa de saque supera o seu Saldo !");
        }

        public override string ToString()
        {
            return "Numero da Conta: " +
                Numero + ", Tipo: " + Tipo + ", Proprietario: "
                + Proprietario + ", Saldo: " + Saldo;
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------

    class Poupança : ContaBancaria
    {
        public Poupança(int numero, char tipo, string propriedade, double saldo) : base(numero, tipo, propriedade, saldo)
        {
        }

        public double ValorRendido(int meses)
        {
            double rendimento = 0.04;
            double valorComJuros = Saldo * (Math.Pow(1 + rendimento, meses));
            return valorComJuros;
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------

    class Corrente : ContaBancaria
    {
        public Corrente(int numero, char tipo, string propriedade, double saldo) : base(numero, tipo, propriedade, saldo)
        {
        }

        public override void Sacar(double valor)
        {
            double taxa = 5.0;
            if(valor + taxa > Saldo)
            {
                Console.WriteLine("Infelizmente você n tem valor suficiente, deseja pedir um cheque especial de Até 2.000 ? (s/ n) ");
                char resposta = char.Parse(Console.ReadLine());
                Console.WriteLine();
                if (resposta == 's')
                {
                    Console.WriteLine();
                    Console.Write("Quanto gostaria de contratar ?");
                    double valorContratado = double.Parse(Console.ReadLine());
                    if(valorContratado > 0 && valorContratado <= 200)
                    {
                        taxa = 20;
                        ChequeEspecial(valorContratado, taxa);
                    }
                    else if (valorContratado > 200 && valorContratado <= 500)
                    {
                        taxa = 50;
                        ChequeEspecial(valorContratado, taxa);
                    }
                    else if (valorContratado > 500 && valorContratado <= 1000)
                    {
                        taxa = 70;
                        ChequeEspecial(valorContratado, taxa);
                    }
                    else if (valorContratado > 1000 && valorContratado <= 2000)
                    {
                        taxa = 100;
                        ChequeEspecial(valorContratado, taxa);
                    }
                    else
                    {
                        Console.WriteLine("O valor não é aceito !! Então segue os dados bancarios e até a proxima");
                    }

                }
                else
                {
                    Console.WriteLine("Como vc opitou em não contratar o Cheque especial, segue os dados da sua conta e até a proxima !!");
                }
            }
            else
            {
                Saldo = (Saldo - valor) - taxa;
            }
        }
        //private para evitar que a contratação seja feita sem ser pelo metodo saque 
        private void ChequeEspecial(double valor, double taxa)
        {
            Saldo = (Saldo - valor) - taxa;
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------

    internal class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria conta1;
            double saldo;

            Console.Write("Entre com o numero da Conta: ");
            int numeroDaConta = int.Parse(Console.ReadLine());
            Console.Write("O tipo da conta é (C/P): ");
            char tipoConta = char.Parse(Console.ReadLine());
            Console.Write("Entre com o nome do proprietario: ");
            string proprietario = Console.ReadLine();
            Console.Write("Deposito inicial (s/n) ? ");
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

            if (tipoConta == 'C')
            {
                conta1 = new Corrente(numeroDaConta, tipoConta, proprietario, saldo);
            }
            else
            {
                conta1 = new Poupança(numeroDaConta, tipoConta, proprietario, saldo);
            } //to levando em consideração que o usuario vai digitar apenas C ou P.

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
            Console.WriteLine();

        }
    }
}
