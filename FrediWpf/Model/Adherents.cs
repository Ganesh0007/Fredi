using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrediWpf.Model
{
    class Adherents
    {
        public Guid IDAdherents { get; set; }
        [DisplayName("Numéro de Licence")]
        public virtual Lien LicenceNumber { get; set; }
        [DisplayName("Nom")]
        public string FamilyName { get; set; }
        [DisplayName("Prénom")]
        public string Name { get; set; }
        [DisplayName("Mail")]
        public string Email { get; set; }
        [DisplayName("Mot de passe")]
        public string Password { get; set; }
        [DisplayName("Numéro de Ligue")]
        public virtual Ligues LeaguesNumber { get; set; }

        public Adherents()
        {

        }

    }
}
