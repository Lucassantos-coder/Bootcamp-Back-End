using System;
using System.Collections.Generic;
using DIO.Animes.Interfaces;

namespace DIO.Animes
{
    public class AnimeRepositorio : IRepositorio<Anime>
    {
        private List<Anime> ListaAnimes = new List<Anime>();
        public void Atualiza(int id, Anime entidade)
        {
            ListaAnimes[id] = entidade;
        }

        public void Exclui(int id)
        {
            ListaAnimes[id].Excluir();
        }

        public void Insere(Anime entidade)
        {
            ListaAnimes.Add(entidade);
        }

        public List<Anime> Lista()
        {
            return ListaAnimes;
        }

        public int ProximoId()
        {
            return ListaAnimes.Count;
        }

        public Anime RetornaPorId(int id)
        {
            return ListaAnimes[id];
        }
    }
}
