using System;

namespace Revisao
{
  class Program
  {
    static void Main(string[] args)
    {

      Aluno[] alunos = new Aluno[4];
      var indiceAluno = 0;
      string opcaoUsuario = Menu();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            //TODO: adicionar aluno
            Console.WriteLine("Informe o nome do aluno:");
            Aluno aluno = new Aluno();
            aluno.Nome = Console.ReadLine();

            Console.WriteLine("Informe a nota do aluno:");

            /*
            //var infere o tipo conforme o recebe
            var nota = decimal.Parse(Console.ReadLine()); 
            aluno.Nota = nota;
            */ // Posso obter da sequinte forma . . .

            if (decimal.TryParse(Console.ReadLine(), out decimal nota))
            {
              aluno.Nota = nota;
            }
            else
            {
              throw new ArgumentException("Valor da nota deve ser decimal");
            }

            alunos[indiceAluno] = aluno;
            indiceAluno++;

            break;
          case "2":
            //TODO: listar alunos
            foreach (var aln in alunos)
            {
              if (aln != null)
              {
                Console.WriteLine($"Aluno: {aln.Nome} - Nota: {aln.Nota}");
              }
            }
            break;
          case "3":
            //TODO: calcular média geral
            decimal notaTotal = 0;
            var quantidadeAlunos = 0;

            for(int i = 0; i < alunos.Length; i++) {
                if (alunos[i] != null ) {
                    notaTotal += alunos[i].Nota;
                    quantidadeAlunos++;
                }
            }
            decimal media = notaTotal / quantidadeAlunos;
            Console.WriteLine($"A média geral é: {media}");

            break;
          default:
            throw new ArgumentOutOfRangeException("opção Inválida!");
        }

        opcaoUsuario = Menu();
      }

    }

    private static string Menu()
    {
      Console.WriteLine();
      Console.WriteLine("--------- Menu ---------");
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine("1 - Inserir novo aluno");
      Console.WriteLine("2 - Listar alunos");
      Console.WriteLine("3 - Calcular média geral");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine();
      return opcaoUsuario;
    }

  }
}
