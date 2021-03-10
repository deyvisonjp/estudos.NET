using System;

namespace DIO.Series
{
  class Program
  {
    // https://diohermes.s3-sa-east-1.amazonaws.com/contents/video/57d42a23-a5f8-4075-9665-13ba63ac007d.mp4
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();
      while (opcaoUsuario != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarSeries();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;
        }
        opcaoUsuario = ObterOpcaoUsuario();
      }

    }

    private static void VisualizarSerie()
    {
      Console.WriteLine("Visualizar série");
      Console.WriteLine("Qual série (id) deseja visualizar?");
      int indiceSerie = int.Parse(Console.ReadLine());
      var serie = repositorio.RetornaPorId(indiceSerie);
      Console.WriteLine(serie);
    }

    private static void AtualizarSerie()
    {
      Console.WriteLine("Atualizar informação de série");
      Console.WriteLine("Qual série (id) deseja atulizar?");
      int indiceSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.Write("Digite o gênero dentre as opçoes acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o título da série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o ano da série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a descrição da série: ");
      string entradaDescricao = Console.ReadLine();

      Serie atualizaSerie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

      repositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void ExcluirSerie()
    {
      Console.WriteLine("Excluir uma série");
      Console.WriteLine("Qual série deseja excluir?");
      int idExcluir = int.Parse(Console.ReadLine());
      repositorio.Excluir(idExcluir);
    }

    private static void InserirSerie()
    {
      Console.WriteLine("Inserir uma nova série ✔");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.Write("Digite o gênero dentre as opçoes acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o título da série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o ano da série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a descrição da série: ");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

      repositorio.Insere(novaSerie);

    }

    private static void ListarSeries()
    {
      Console.WriteLine("Lista de Séries . . . ");
      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada.");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();
        if(!excluido) {
          Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
          //Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
        }
      }

    }
    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries a seu dispor!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1. Listar séries");
      Console.WriteLine("2. Inserir nova série");
      Console.WriteLine("3. Atualizar série");
      Console.WriteLine("4. Excluir série");
      Console.WriteLine("5. Visualizar série");
      Console.WriteLine("C. Limpar Tela");
      Console.WriteLine("X. Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
