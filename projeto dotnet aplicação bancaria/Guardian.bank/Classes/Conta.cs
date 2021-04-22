using System;

namespace Guardian.bank
{
    public class Conta
    {
        //Atributos da conta
        private Tipo_Conta Tipo_Conta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set;}

        //Metodos 
        public Conta(Tipo_Conta tipo_Conta, double Saldo, double Credito, string Nome)
        {
            this.Tipo_Conta = tipo_Conta;
            this.Saldo = Saldo;
            this.Credito = Credito;
            this.Nome = Nome;
        }

        public bool Sacar(double valorSaque)
        {
            // Verefica se tem saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Seu Saldo é insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            //this.Saldo = this.Saldo -= valorSaque; "esses tambem faz a mesma coisa que a referencia a cima"

            Console.WriteLine("O Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

            return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;
            //this.Saldo = this.Saldo + valorDeposito;   "esses tambem faz a mesma coisa que a referencia a cima"
            Console.WriteLine("O Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Tipo_Conta " + this.Tipo_Conta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
			return retorno;
		}
	}
}