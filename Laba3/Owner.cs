using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba3
{
    public class Owner
    {
        public Owner()
        {
            Clubs = new HashSet<Club>();
        }

        [Key]
        public int ownerId { get; set; }

        [MaxLength(20)]
        public string fullName { get; set; }

        [NotMapped]
        public virtual ICollection<Club> Clubs { get; set; }

        public override string ToString()
        {
            return $"Владелец: Id — {ownerId}, Имя — {fullName}";
        }
    }
}