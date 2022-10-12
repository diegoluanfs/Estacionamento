using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento
{
    public class Estacionamento
    {
        public int? idEstacionamento { get; set; }
        public IList<Veiculo> Veiculos { get; set; }
    }
}
