//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mmm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;

    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            this.Titres = new HashSet<Titre>();
        }
        [Required(ErrorMessage ="l'identifiant est obligatoire")]
        public int clientid { get; set; }
        [Required(ErrorMessage = "le nom est obligatoire")]
        public string clientnom { get; set; }
        [Required(ErrorMessage = "Le prix total est obligatoire.")]
        [Range(1, 1000, ErrorMessage = "Le prix doit être compris entre 1 et 1000.")]
        public Nullable<int> clientprix { get; set; }
        [Required(ErrorMessage = "Le nombre de titres est obligatoire.")]
        [Range(1,5, ErrorMessage = "Le nombre doit être compris entre 1 et 5.")]
        public Nullable<int> clientnbrtitre { get; set; }
        public Nullable<int> Idtitre { get; set; }
    
        public virtual Titre Titre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Titre> Titres { get; set; }
    }
}
