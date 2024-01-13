using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba3
{
    public class Team
    {
        public Team() { }

        [Key]
        public int teamId { get; set; }

        [MaxLength(64)]
        public string name { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Clubs")]
        public int clubId { get; set; }

        [NotMapped]
        public virtual Club Clubs { get; set; }

        public override string ToString()
        {
            return $"Team: id - {teamId}; name - {name}";
        }
    }
}