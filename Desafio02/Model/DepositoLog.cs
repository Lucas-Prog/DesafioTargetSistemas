using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio02.Model
{
    internal class DepositoLog
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public TipoMovimentacao TipoMoviementacao { get; set; }
        public int QuantidadeEstoqueAntes { get; set; }
        public int QuantidadeEstoqueDepois { get; set; }
    }
}
