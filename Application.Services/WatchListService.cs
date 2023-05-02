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
            _watchListRepository.CreateAsync(watchList).Wait();
        }

        public IEnumerable<WatchList> GetAllWatchList()
        {
            return _watchListRepository.GetAllAsync().Result;
        }

        public WatchList GetById(string id)
        {
            return _watchListRepository.GetByIdAsync(id).Result;
        }

        public void RemoveWatchList(string id)
        {
            _watchListRepository.DeleteAsync(id).Wait();
        }

        public void UpdateWatchList(string id, WatchList watchList)
        {
            _watchListRepository.Update(id, watchList);
        }

    }
}
