using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio01.Models
{
    internal class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Comissao { get; set; }

        public Vendedor(int id, string nome) {
            Id = id;
            Nome = nome;
        }
    }
}
