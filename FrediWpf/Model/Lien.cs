using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrediWpf.Model
{
    class Lien
    {
        public Guid IDLink { get; set; }
        [DisplayName("Numéro de Licence")]
        public string LicenceNumber { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }

        public Lien()
        {

        }
    }
}
