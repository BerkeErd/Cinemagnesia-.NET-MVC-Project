using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Infrastructure.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WatchListService : IWatchListService
    {
        private readonly IWatchListRepository _watchListRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
       public WatchListService(IWatchListRepository watchListRepository, IMapper mapper, IRatingRepository ratingRepository)
        {
            _mapper = mapper;
            _watchListRepository = watchListRepository;
            _ratingRepository = ratingRepository;
        }

        public void AddWatchList(WatchList watchList)
        {
            if(watchList != null)
            {
                _watchListRepository.CreateAsync(watchList).Wait();
            }
           
        }

        public IEnumerable<WatchList> GetAllWatchList()
        {
            return _watchListRepository.GetAllAsync().Result;
        }

        public WatchList GetById(string id)
        {
            if(id  == null)
            {
                return null;
            }
            return _watchListRepository.GetByIdAsync(id).Result;
        }

        public void RemoveWatchList(string id)
        {
            if (id != null)
            {
                _watchListRepository.DeleteAsync(id).Wait();
            }
            
        }

        public void UpdateWatchList(string id, WatchList watchList)
        {
            if (id != null && watchList != null)
            {
                _watchListRepository.Update(id, watchList);
            }
            
        }
        public List<WatchListDto> GetWatchListByUserId(string userId)
        {
            var watchLists =  _watchListRepository.GetByUserIdAsync(userId).Result;
            var watchListDtos = _mapper.Map<List<WatchListDto>>(watchLists);

            foreach (var watchListDto in watchListDtos)
            {
                var rating = _ratingRepository.GetRateoftheUser(userId, watchListDto.MovieId);
                watchListDto.Rating = rating;
            }

            return watchListDtos;
        }

    }
}
