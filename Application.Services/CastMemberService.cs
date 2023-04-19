using Application.Interfaces.AppInterfaces;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CastMemberService : ICastMemberService
    {
        private readonly ICastMemberRepository _castMemberRepository;

        public CastMemberService(ICastMemberRepository castMemberRepository)
        {
            _castMemberRepository= castMemberRepository;
        }
        public void AddCastMember(CastMember castMember)
        {
            _castMemberRepository.CreateAsync(castMember).Wait();
        }

        public IEnumerable<CastMember> GetAllCastMembers()
        {
            return _castMemberRepository.GetAllAsync().Result;
        }

        public CastMember GetById(string id)
        {
            return _castMemberRepository.GetByIdAsync(id).Result;
        }

        public void RemoveCastMember(string id)
        {
            _castMemberRepository.DeleteAsync(id).Wait();
        }

        public void UpdateCastMember(string id, CastMember castMember)
        {
            _castMemberRepository.UpdateAsync(id, castMember).Wait();
        }
    }
}
