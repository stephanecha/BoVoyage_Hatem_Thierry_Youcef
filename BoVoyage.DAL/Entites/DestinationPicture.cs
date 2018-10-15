using BoVoyage.DAL.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.DAL.Entites
{
    public sealed class DestinationPicture : BaseModel
    {
        [Required]
        [StringLength(150)]
        public string Nom { get; set; }

        [Required]
        [StringLength(150)]
        public string ContentType { get; set; }

        [Required]
        public byte[] Content { get; set; }// on enregistre l'image sous forme de tableau de byte

        [Required]
        public int DestinationID { get; set; }

        [ForeignKey("DestinationID")] //one to many, un tournoi peut avoir plusieurs images, une img € a un seul tournoi
        public Destination Destination { get; set; }
    }
}
