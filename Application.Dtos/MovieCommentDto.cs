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
    public class MovieCommentDto
    {
        public string Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public string MovieId { get; set; }
        public Movie Movie { get; set; }
        public string CommentText { get; set; }
        public bool HasSpoiler { get; set; }
        public ApprovalStatus Status { get; set; } = ApprovalStatus.Approved;
        public int LikeCount { get; set; }
    }
}
