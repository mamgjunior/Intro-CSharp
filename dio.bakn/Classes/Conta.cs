using System;
using dio.bakn.Enum;

namespace dio.bakn.Classes
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        private bool existeSaldoSuficiente(double pValor)
        {
            return ((this.Saldo - pValor) > (this.Credito * -1));
        }

        public void sacar(double pValor)
        {
            if (existeSaldoSuficiente(pValor))
            {
                this.Saldo -= pValor;
                Console.WriteLine("Saldo atual da conta do Sr(a) {0} é de {1}", this.Nome, this.Saldo.ToString("N2"));
            } else
                Console.WriteLine("Saldo insuficiênte!");
        }

        public void depositar(double pValor)
        {
            this.Saldo += pValor;
            Console.WriteLine("Saldo atual da conta do Sr(a) {0} é de {1}", this.Nome, this.Saldo.ToString("N2"));
        }

        public void transferencia(Conta pConta, double pValor)
        {
            if (this.existeSaldoSuficiente(pValor))
            {
                this.sacar(pValor);
                pConta.depositar(pValor);
            } else
                Console.WriteLine("Saldo insuficiênte!");
        }

        public override string ToString()
        {
            return "Tipo de conta: "+ this.TipoConta +" | Nome: "+ this.Nome +" | Saldo: "+ this.Saldo.ToString("N2") +" | Credito: "+ this.Credito.ToString("N2");
        }
    }
}