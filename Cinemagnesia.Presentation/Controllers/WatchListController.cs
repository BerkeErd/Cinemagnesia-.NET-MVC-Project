using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Presentation.Models;
using Domain.Entities.Concrete;
using Domain.Entities.Constants;
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

        [HttpPost]
        public IActionResult UpdateorAddStatus(string userId, string movieId, WatchStatus status)
        {

            if(userId != null && movieId != null) 
            {
                // Check if a WatchList already exists for the user and movie
                WatchList watchList = _watchListService.GetWatchListByUserIdAndMovieId(userId, movieId);

                if (watchList != null)
                {
                    // Update the status of the existing WatchList instance
                    watchList.WatchStatus = status;
                    _watchListService.UpdateWatchList(watchList.Id, watchList);
                }
                else
                {
                    // Create a new WatchList instance for the user and movie
                    WatchList newWatchList = new WatchList
                    {
                        ApplicationUserId = userId,
                        MovieId = movieId,
                        WatchStatus = status
                    };
                    _watchListService.AddWatchList(newWatchList);
                }

                return Ok(); // or return a success or error response as needed
            }
            return BadRequest("userId or movieId is null");
        }
    }
}
