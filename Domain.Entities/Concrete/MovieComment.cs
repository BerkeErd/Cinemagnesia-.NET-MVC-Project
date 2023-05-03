using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class MovieComment : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        
        public string MovieId { get; set; }
        public Movie Movie { get; set; }
        [Required]

        [MaxLength(20000)]
        public string CommentText { get; set; }
        public bool HasSpoiler { get; set; }

        public ApprovalStatus Status { get; set; } = ApprovalStatus.Approved;
        public int LikeCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

    }
}
