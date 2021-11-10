using System;

namespace DIO.Animes
{
    public class Program
    {
        static AnimeRepositorio Repositorio = new AnimeRepositorio();
        static void Main(string[] args)
        {
            int Opcao = int.Parse(Exibemenu());
            while(Opcao != 6)
            {
                switch (Opcao)
                {
                    case 1:
                        ListarAnimes();
                        break;
                    case 2:
                        AdicionarAnimes();
                        break;
                    case 3:
                        AlterarAnimes();
                        break;
                    case 4:
                        VisualizarAnimes();
                        break;
                    case 5:
                        ExcluirAnimes();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Opcao = int.Parse(Exibemenu());
            }
        }

        //Método que exibe a lista de animes
        private static void ListarAnimes()
        {
            Console.Clear();
            Console.WriteLine("Lista de animes");

            var lista = Repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Sua lista de animes está vazia");
                Console.ReadKey();
                return;
            }

            foreach(var anime in lista)
            {
                var excluido = anime.RetornaExcluido();

                Console.WriteLine("#ID {0}: - {1}", anime.RetornaId(), anime.RetornaTitulo(), (excluido ? "*Excluido*" : ""));
            }

            Console.ReadKey();
        }

        //Método que adiciona novos animes a lista
        private static void AdicionarAnimes()
        {
            Console.Clear();
            Console.WriteLine("Adicionar novo anime");
            Console.WriteLine();
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Escolha um dos gêneros listados acima: ");
            int OpcaoGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();
            
            Console.WriteLine("Insira o titulo do anime desejado: ");
            string EntradaTitulo = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Insira o ano de lançamento do anime desejado: ");
            int EntradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Insira o estúdio de animação responsável pelo anime desejado: ");
            string EntradaStudio = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Insira a descrição do anime desejado: ");
            string EntradaDescricao = Console.ReadLine();
            Console.WriteLine();

            Anime NovoAnime = new Anime(Repositorio.ProximoId(),
                                        genero: (Genero)OpcaoGenero,
                                        titulo: EntradaTitulo,
                                        ano: EntradaAno,
                                        animationstudio: EntradaStudio,
                                        descricao: EntradaDescricao);
            Repositorio.Insere(NovoAnime);
        }

        //Método que altera dados de um anime da lista
        private static void AlterarAnimes()
        {
            Console.WriteLine("Alteração de animes");
            ListarAnimes();
            Console.WriteLine();
            Console.WriteLine("Insira o Id do anime desejado: ");
            int IdAnime = int.Parse(Console.ReadLine());
            Console.Clear();
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Escolha um dos gêneros listados acima: ");
            int OpcaoGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Insira o titulo do anime desejado: ");
            string EntradaTitulo = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Insira o ano de lançamento do anime desejado: ");
            int EntradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Insira o estúdio de animação responsável pelo anime desejado: ");
            string EntradaStudio = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Insira a descrição do anime desejado: ");
            string EntradaDescricao = Console.ReadLine();
            Console.WriteLine();

            Anime AtualizaAnime = new Anime(id: IdAnime,
                                        genero: (Genero)OpcaoGenero,
                                        titulo: EntradaTitulo,
                                        ano: EntradaAno,
                                        animationstudio: EntradaStudio,
                                        descricao: EntradaDescricao);
            Repositorio.Atualiza(IdAnime, AtualizaAnime);

        }

        //Método que exibe os animes da lista de forma detalhada
        private static void VisualizarAnimes()
        {
            ListarAnimes();
            Console.WriteLine();
            Console.Write("Insira o id do anime que deseja visualizar: ");
            int IdAnime = int.Parse(Console.ReadLine());
            Console.Clear();

            var anime = Repositorio.RetornaPorId(IdAnime);

            Console.WriteLine(anime);
            Console.ReadKey();
        }

        //Método que remove o anime desejado da lista
        public static void ExcluirAnimes()
        {
            ListarAnimes();
            Console.WriteLine();
            Console.Write("Insira o id do anime que deseja excluir: ");
            int IdAnime = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Deseja realmente excluir este anime?(1=Sim 2=Não)");
            int Resp = int.Parse(Console.ReadLine());
            if(Resp == 1)
            {
                return;
            }else if(Resp == 2)
            {
                Repositorio.Exclui(IdAnime);
            }else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        //Método que exibe o menu principal
        private static string Exibemenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("BEM-VINDO A DIO ANIMES!!!!");
            Console.WriteLine("------Menu Principal------");
            Console.WriteLine("|1- Listar animes        |");
            Console.WriteLine("|2- Adicionar animes     |");
            Console.WriteLine("|3- Alterar animes       |");
            Console.WriteLine("|4- Visualizar animes    |");
            Console.WriteLine("|5- Excluir animes       |");
            Console.WriteLine("|6- Sair                 |");
            Console.WriteLine("--------------------------");
            Console.WriteLine("");
            Console.WriteLine("Escolha uma das opções acima: ");
            string Opcao = Console.ReadLine();
            return Opcao;
        }
    }
}
