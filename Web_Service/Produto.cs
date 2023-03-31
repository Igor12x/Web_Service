using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Service
{
    public class Produto
    {
        //Atributos - Atralho: prop e apertar Tab 2x
        public int id { get; set; }
        public String nome { get; set; }
        public double preco { get; set; }
        public int quantidade { get; set; }

        //Construtor - Atalho: Ctrl .

        public Produto(int id, string nome, double preco, int quantidade)
        {
            this.id = id;
            this.nome = nome;
            this.preco = preco;
            this.quantidade = quantidade;
        }
        public Produto() { }
    }
}