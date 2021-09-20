using Receitas.NhamNham.Classes;
using Receitas.NhamNham;
using System;

namespace Receitas.NhamNham
{
    class Program
    {
		static Classes.ReceitasRepositorio repositorio = new ReceitasRepositorio();
      
		static void Main(string[] args)
        {		
			
			{
				string opcaoUsuario = ObterOpcaoUsuario();

				while (opcaoUsuario.ToUpper() != "X")
				{
					switch (opcaoUsuario)
					{
						case "1":
							ListarReceitas();
							break;
						case "2":
							InserirReceita();
							break;
						case "3":
							AtualizarReceita();
							break;
						case "4":
							ExcluirReceita();
							break;
						case "5":
                            VisualizarReceita();
							break;
						case "C":
							Console.Clear();
							break;

						default:
							throw new ArgumentOutOfRangeException();
					}

					opcaoUsuario = ObterOpcaoUsuario();
				}

				Console.WriteLine("Grata por utilizar nossos serviços.");
				Console.ReadLine();
			}

             static void ExcluirReceita()
			{
				Console.Write("Digite o id da Receita: ");
				int indiceReceita = int.Parse(Console.ReadLine());

				repositorio.Exclui(indiceReceita);
			}
             static void VisualizarReceita()
            {
				Console.Write("Digite o id da Receita: ");
				int indiceReceita = int.Parse(Console.ReadLine());

				var receita = repositorio.RetornaPorId(indiceReceita);

				Console.WriteLine(receita);
			}

			 static void AtualizarReceita()
			{
				Console.Write("Digite o id da Receita: ");
				int indiceReceita = int.Parse(Console.ReadLine());

				foreach (int i in Enum.GetValues(typeof(Categoria)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categoria), i));
				}
				Console.Write("Digite a Categoria entre as opções acima: ");
				int entradaGenero = int.Parse(Console.ReadLine());

				Console.Write("Digite o Nome da Receita: ");
				string entradaNome = Console.ReadLine();

				Console.Write("Digite o Tempo de Preparo da Receita: ");
				int entradaTempo = int.Parse(Console.ReadLine());

				Console.Write("Digite a Descrição da Receita: ");
				string entradaDescricao = Console.ReadLine();

				Receitas atualizaReceita = new Receitas(id: indiceReceita,
											categoria: (Categoria)entradaGenero,
											nome: entradaNome,
											tempo: entradaTempo,
											descricao: entradaDescricao);

				repositorio.Atualiza(indiceReceita, atualizaReceita);
			}
			 static void ListarReceitas()
			{
				Console.WriteLine("Listar receitas");

				var lista = repositorio.Lista();

				if (lista.Count == 0)
				{
					Console.WriteLine("Nenhuma receita cadastrada.");
					return;
				}

				foreach (var receitas in lista)
				{
					var excluido = receitas.retornaExcluido();

					Console.WriteLine("#ID {0}: - {1} {2}", receitas.retornaId(), receitas.retornaNome(), (excluido ? "*Excluído*" : ""));
				}
			}

			static void InserirReceita()
			{
				Console.WriteLine("Inserir nova receita");

				
				foreach (int i in Enum.GetValues(typeof(Categoria)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categoria), i));
				}
				Console.Write("Digite a categoria entre as opções acima: ");
				int entradaCategoria = int.Parse(Console.ReadLine());

				Console.Write("Digite o Nome da Receita: ");
				string entradaNome = Console.ReadLine();

				Console.Write("Digite o tempo de Preparação: ");
				int entradaTempo = int.Parse(Console.ReadLine());

				Console.Write("Digite a Descrição da Receita: ");
				string entradaDescricao = Console.ReadLine();

				Receitas novaReceitas = new Receitas(id: repositorio.ProximoId(),
											categoria: (Categoria)entradaCategoria,
											nome: entradaNome,
											tempo: entradaTempo,
											descricao: entradaDescricao);

				repositorio.Insere(novaReceitas);
			}

			static string ObterOpcaoUsuario()
			{
				Console.WriteLine();
				Console.WriteLine("NhamNham Receitas, Tornando o seu dia mais Saboroso!!!");
				Console.WriteLine("Informe a opção desejada:");

				Console.WriteLine("1- Listar Receitas");
				Console.WriteLine("2- Inserir nova receita");
				Console.WriteLine("3- Atualizar receita");
				Console.WriteLine("4- Excluir receita");
				Console.WriteLine("5- Visualizar receita");
				Console.WriteLine("C- Limpar Tela");
				Console.WriteLine("X- Sair");
				Console.WriteLine();

				string opcaoUsuario = Console.ReadLine().ToUpper();
				Console.WriteLine();
				return opcaoUsuario;
			}
		}

	}
}