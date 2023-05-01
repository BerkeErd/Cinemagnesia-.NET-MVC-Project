using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class CastMember : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Movie> Movies { get; set; }

    }
}
