using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cinemagnesia.Presentation.Controllers
{
    public class WatchListController : Controller
    {
        private readonly IWatchListService _watchListService;
        private readonly IMapper _mapper;

        public WatchListController(IWatchListService watchListService, IMapper mapper)
        {
            _watchListService = watchListService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult WatchListView()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var watchListDtos = _watchListService.GetWatchListByUserId(userId);
            var watchListViewModels = _mapper.Map<List<WatchListViewModel>>(watchListDtos);
            return View(watchListViewModels);
            
        }
        
        public IActionResult ProfileView()
        {
            return View();
        }

        public IActionResult FavoriteMoviesView()
        {
            return View();
        }
    }
}
