using System;

namespace DIO.Animes
{
    public class Anime : EntidadeBase
    {
        //Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private string AnimationStudio { get; set; }
        private int Ano { get; set; }
        public bool Excluido { get; set; }

        //Métodos
        public Anime(int id, Genero genero, string titulo, string descricao, string animationstudio, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.AnimationStudio = animationstudio;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string Retorno = "";
            Retorno += "Título: " + this.Titulo + Environment.NewLine;
            Retorno += "Gênero: " + this.Genero + Environment.NewLine;
            Retorno += "Ano de lançamento: " + this.Ano + Environment.NewLine;
            Retorno += "Estúdio de animação: " + this.AnimationStudio + Environment.NewLine;
            Retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            Retorno += "Excluído: " + this.Excluido;
            return Retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}
