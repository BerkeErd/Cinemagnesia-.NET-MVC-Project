using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AppInterfaces
{
    public interface ICastMemberService
    {
        IEnumerable<CastMember> GetAllCastMembers();
        void AddCastMember(CastMember castMember);
        void RemoveCastMember(string id);
        void UpdateCastMember(string id, CastMember castMember);
        CastMember GetById(string id);
    }
}
