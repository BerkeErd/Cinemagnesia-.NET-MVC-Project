using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Controllers
{

    public class DirectorController : Controller
    {
        private readonly IDirectorService _directorService;
        private readonly IMapper _mapper;

        public DirectorController(IDirectorService directorService, IMapper mapper)
        {
            _mapper = mapper;
            _directorService = directorService;
        }

        [HttpGet]
        public int GetNumOfDirectors()
        {
            return _directorService.GetNumOfDirectors();
        }
    }
}
