using System;
using System.Collections.Generic;
using System.Text;

namespace Fretefy.Test.Domain.Entities
{
    public class Regiao
    {
        public Regiao()
        {
            RegiaoCidades = new HashSet<RegiaoCidade>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; } = true;
        public ICollection<RegiaoCidade> RegiaoCidades { get; set; }
    }
}
