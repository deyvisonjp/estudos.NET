using System;

namespace DIO.Bank
{
  public class Conta
  {
    private TipoConta TipoConta { get; set; }
    private double Saldo { get; set; }
    private double Credito { get; set; }
    private string Nome { get; set; }

    public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
    {
      this.TipoConta = tipoConta;
      this.Saldo = saldo;
      this.Credito = credito;
      this.Nome = nome;
    }

    public bool Sacar(double valorSaque)
    {
      // Validação de saldo insuficiente
      if (this.Saldo - valorSaque < (this.Credito * -1))
      {
        Console.WriteLine("Saldo  insuficiente");
        return false;
      }

      this.Saldo -= valorSaque;
      Console.WriteLine("Saldo atual da conta de {0} é {1:N2}", this.Nome, this.Saldo);
      //https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

      return true;
    }

    public void Depositar(double valorDeposito)
    {
      this.Saldo += valorDeposito;
      Console.WriteLine("Saldo atual da conta de {0} é {1:N2}", this.Nome, this.Saldo);
    }

    public void Transferencia(double valorTransferencia, Conta contaDestino)
    {
        if (this.Sacar(valorTransferencia)) {
            contaDestino.Depositar(valorTransferencia);
            Console.WriteLine("Valor transferido com sucesso!");
        }
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "Tipo Conta " + this.TipoConta + " | ";
      retorno += "Nome " + this.Nome + " | ";
      retorno += "Saldo Atual R$ " + this.Saldo.ToString("N2") + " | ";
      retorno += "Crédito R$ " + this.Credito.ToString("N2");
      return retorno;
    }

  }
}