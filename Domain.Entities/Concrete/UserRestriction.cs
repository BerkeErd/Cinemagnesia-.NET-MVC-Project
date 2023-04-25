using Cinemagnesia.Domain.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class UserRestriction
    {
        public bool IsMuted;
        public DateTime MuteStartDate;
        public DateTime MuteEndDate;

        public bool IsBanned;
        public DateTime BannedStartDate;
        public DateTime BannedEndDate;

        public string UserId;
        public string bannedbyAdminUserId;

    }
}
