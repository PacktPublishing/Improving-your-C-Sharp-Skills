using System.ComponentModel.DataAnnotations;
using SpeakerMeet.Repositories.Interfaces;

namespace SpeakerMeet.Models
{
    public class Speaker : IIdentity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }

        public bool IsDeleted { get; set; }
    }
}