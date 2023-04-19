using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AppInterfaces
{
    public interface IWatchListService
    {
        IEnumerable<WatchList> GetAllWatchList();
        void AddWatchList(WatchList watchList);
        void RemoveWatchList(string id);
        void UpdateWatchList(string id, WatchList watchList);
        WatchList GetById(string id);
    }
}

