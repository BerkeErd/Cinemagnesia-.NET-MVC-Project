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
    public class WatchListService : IWatchListService
    {
        private readonly IWatchListRepository _watchListRepository;

       public WatchListService(IWatchListRepository watchListRepository)
        {
            _watchListRepository = watchListRepository;
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

    }
}
