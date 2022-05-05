using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlayerService.Data;
using PlayerService.Dtos;

namespace PlayerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepo _repository;
        private readonly IMapper _mapper;
        public PlayerController(IPlayerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlayerReadDto>> GetPlayers()
        {
            Console.WriteLine("Get Players");
            var playerItem = _repository.GetAllPlayers();
            return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(playerItem));
        }
    }
}
