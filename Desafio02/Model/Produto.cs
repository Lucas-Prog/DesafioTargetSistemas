using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio02.Model
{
    internal class Produto
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int Estoque { get; set; }

        public Produto() {

        }
        public Produto(int codProd, string descProd, int qtdEstoque) {
            CodigoProduto = codProd;
            DescricaoProduto = descProd;
            Estoque = qtdEstoque;
        }
    }
}
