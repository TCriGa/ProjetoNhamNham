using System;
using System.Collections.Generic;
using Receitas.NhamNham.Classes;
using Receitas.NhamNham.Interfaces;



namespace Receitas.NhamNham.Classes
{

    public class ReceitasRepositorio : IRepositorio<Receitas>
    {
        private List<Receitas> listaReceita = new List<Receitas>();
        public void Atualiza(int id, Receitas objeto)
        {
            listaReceita[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaReceita[id].Excluir();
        }

        public void Insere(Receitas objeto)
        {
            listaReceita.Add(objeto);
        }

        public List<Receitas> Lista()
        {
            return listaReceita;
        }

        public int ProximoId()
        {
            return listaReceita.Count;
        }

        public Receitas RetornaPorId(int id)
        {
            return listaReceita[id];
        }

    }
}
