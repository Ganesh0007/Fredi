using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrediWpf.Model
{
    class Demandeurs
    {
        public Guid IDDemandeurs { get; set; }
        [DisplayName("Email")]
        public virtual Lien Email { get; set; }
        [DisplayName("Nom")]
        public string FamilyName { get; set; }
        [DisplayName("Prénom")]
        public string Name { get; set; }
        [DisplayName("Date de naissance")]
        public DateTime DateOfBirthday { get; set; }
        [DisplayName("Adresse")]
        public string Address { get; set; }
        [DisplayName("Code Postal")]
        public int PostalCode { get; set; }
        [DisplayName("Ville")]
        public string City { get; set; }
        [DisplayName("Numéro de Reçu")]
        public string ReceiptNumber { get; set; }

        public Demandeurs()
        {

        }
    }
}
