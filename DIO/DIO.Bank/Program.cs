using System.Collections.Generic;
using System;

namespace DIO.Bank
{
  class Program
  {
    static List<Conta> listContas = new List<Conta>();
    static void Main(string[] args)
    {

      Conta[] contas;
      string escolhaDoUsuario = MenuBancario();

      while (escolhaDoUsuario != "X")
      {
        switch (escolhaDoUsuario)
        {
          case "1":
            {
              ListarConstas();
              break;
            }
          case "2":
            {
              InserirConta();
              break;
            }
          case "3":
            {
              TransferirSaldos();
              break;
            }
          case "4":
            {
              SaqueConta();
              break;
            }
          case "5":
            {
              DepositarConta();
              break;
            }
          case "C":
            {
              Console.Clear();
              break;
            }
        }
        escolhaDoUsuario = MenuBancario();
      }

      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.ReadLine();

    }

    private static void TransferirSaldos()
    {
      Console.Write("Digite o numero da conta origem (indice): ");
      int indiceDaContaDebita = int.Parse(Console.ReadLine());

      Console.Write("Digite o numero da conta destino (indice)  ");
      int indiceDaContaCredita = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser transferido: ");
      double valorTransferencia = double.Parse(Console.ReadLine());

      listContas[indiceDaContaDebita].Transferencia(valorTransferencia, listContas[indiceDaContaCredita]);
    }

    private static void DepositarConta()
    {
      Console.Write("Digite o numero da sua conta (indice): ");
      int indiceDaConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser depositado: ");
      double valorDeposito = double.Parse(Console.ReadLine());

      listContas[indiceDaConta].Depositar(valorDeposito);

    }

    private static void SaqueConta()
    {
      Console.Write("Digite o numero da sua conta (indice): ");
      int indiceDaConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser sacado: ");
      double valorSaque = double.Parse(Console.ReadLine());

      listContas[indiceDaConta].Sacar(valorSaque);
    }

    // Listar Contas Criadas
    private static void ListarConstas()
    {
      Console.WriteLine("Listar contas . . . ");

      if (listContas.Count == 0)
      {
        Console.WriteLine("nenhuma conta cadastrada.");
        return;
      }

      for (int i = 0; i < listContas.Count; i++)
      {
        Conta conta = listContas[i];
        Console.Write("Conta #{0} - ", i);
        Console.WriteLine(conta);
      }

    }

    //Criar nova conta
    private static void InserirConta()
    {
      Console.WriteLine("Inserir nova conta");

      int inputTipoConta = 0;
      do
      {
        Console.WriteLine("Digite [1] para Conta Física ou [2] para Juridica:");
        inputTipoConta = int.Parse(Console.ReadLine());
      } while (inputTipoConta != 1 && inputTipoConta != 2);

      Console.WriteLine("Digite o nome do cliente:");
      string inputNome = Console.ReadLine();

      Console.WriteLine("Digite o saldo inicial:");
      double inputSaldo = double.Parse(Console.ReadLine());

      Console.WriteLine("Digite o crédito:");
      double inputCredito = double.Parse(Console.ReadLine());

      Conta novaConta = new Conta(tipoConta: (TipoConta)inputTipoConta,
                                    saldo: inputSaldo,
                                    credito: inputCredito,
                                    nome: inputNome
        );

      listContas.Add(novaConta);

      Console.WriteLine("Cliente criado com sucesso!");
    }

    private static string MenuBancario()
    {
      Console.WriteLine();
      Console.WriteLine("---- DIO Bank - MenuBancario ----");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1. Listar contas");
      Console.WriteLine("2. Inserir nova conta");
      Console.WriteLine("3. Transferir");
      Console.WriteLine("4. Sacar");
      Console.WriteLine("5. Depositar");
      Console.WriteLine("C. Limpar Tela");
      Console.WriteLine("X. Sair");

      string escolhaUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return escolhaUsuario;
    }

  }
}
