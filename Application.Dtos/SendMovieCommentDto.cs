using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Domain.Entities.Concrete;
using Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class SendMovieCommentDto
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public string MovieId { get; set; }
        public Movie Movie { get; set; }
        public string CommentText { get; set; }
        public bool HasSpoiler { get; set; } = false;
        public ApprovalStatus Status { get; set; } = ApprovalStatus.Approved;
        public int LikeCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
    }
}
