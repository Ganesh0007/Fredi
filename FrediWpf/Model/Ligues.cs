using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrediWpf.Model
{
    class Ligues
    {
        [DisplayName("Numéro de Ligue")]
        public Guid IDLeagues { get; set; }
        [DisplayName("Nom De La Ligue")]
        public string LName { get; set; }
        [DisplayName("Sigle De La Ligue")]
        public string Sigle { get; set; }
        [DisplayName("Nom Du Président De La Ligue")]
        public string PName { get; set; }

        public Ligues()
        {

        }
    }
}
