using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrediWpf.Model
{
    class Motif
    {
        public int ReasonID { get; set; }
        [DisplayName("Motif")]
        public string Reason { get; set; }

        public Motif()
        {

        }
    }
}
