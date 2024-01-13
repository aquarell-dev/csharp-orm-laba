using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba3
{
    public class Club
    {
        public Club() { 
            Owners = new HashSet<Owner>();
            Teams = new HashSet<Team>();
        }

        [Key]
        public int clubId { get; set; }

        [MaxLength(64)]
        public string name { get; set; }

        [NotMapped]
        public virtual ICollection<Owner> Owners { get; set; }

        [NotMapped]
        public virtual ICollection<Team> Teams { get; set; }

        public override string ToString()
        {
            return $"Клуб: Id — {clubId}, название - {name}";
        }
    }
}