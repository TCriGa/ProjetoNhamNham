using System;
using System.Collections.Generic;
using System.Text;
using Receitas.NhamNham;

namespace Receitas.NhamNham
{
    public class Receitas : EntidadeBase
    {
        
        private Categoria Categoria { get; set; }
        private string Nome { get; set; }
        private string Descricao { get; set; }
        private int Tempo { get; set; }

        private bool Excluido { get; set; }
        

        public Receitas(int id, Categoria categoria, string nome, string descricao, int tempo)
        {
            this.Id = id;
            this.Categoria = categoria;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Tempo = tempo;

            this.Excluido = false;
        }

        
        public override string ToString()
        {
           
            string retorno = "";
            retorno += "Categoria: " + this.Categoria + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Tempo de Preparação: " + this.Tempo + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;

            return retorno;
        }
        public string retornaNome()
        {
            return this.Nome;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}
