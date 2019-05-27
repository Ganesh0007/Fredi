using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrediWpf.Model
{
    class LignesDeFrais
    {
        public Guid IDLignesDeFrais { get; set; }
        [DisplayName("Votre Mail")]
        public virtual Lien Email { get; set; }
        [DisplayName("Date du déplacement")]
        public DateTime Date { get; set; }
        // Choix multiple du motif
        [DisplayName("Motif du délacement")]
        public int? ReasonID { get; set; }
        public virtual Motif Reason { get; set; }
        [DisplayName("Description du trajet")]
        public string Journey { get; set; }
        [DisplayName("Kilométrage Total")]
        public float TotalKm { get; set; }
        [DisplayName("Montant du péages")]
        public float CostToll { get; set; }
        [DisplayName("Montant du péages")]
        public float CostLunches { get; set; }
        [DisplayName("Montant de l'hébergement")]
        public float CostAccommodation { get; set; }

        public LignesDeFrais()
        {

        }
    }
}
