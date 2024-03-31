using System;
using System.Collections.Generic;

namespace Fretefy.Test.WebApi.DTOs
{
    public class RegiaoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; }
        public List<CidadeDTO> Cidades { get; set; }
    }
}
