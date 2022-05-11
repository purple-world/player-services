using System.Xml;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlayerService.Data;
using PlayerService.Dtos;
using PlayerService.Models;

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
            var playerAll = _repository.GetAllPlayers();
            if(playerAll != null) {
                return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(playerAll));
            }
            return NotFound();
        }

        [HttpGet("{userLicense}", Name = "GetPlayersFromLicense")]
        public ActionResult<IEnumerable<PlayerReadDto>> GetPlayersFromLicense(string userLicense)
        {
            Guid licenseGUID = new Guid(userLicense);
            var playerOwn = _repository.GetPlayersByLicense(licenseGUID);
            if (playerOwn != null) {
                return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(playerOwn));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<PlayerReadDto> CreatePlayer(PlayerCreateDto playerCreateDto)
        {
            var playerModel = _mapper.Map<Player>(playerCreateDto);
            _repository.CreatePlayer(playerModel);
            _repository.SaveChanges();
            var PlayerReadDto = _mapper.Map<PlayerReadDto>(playerModel);

            return CreatedAtRoute(nameof(GetPlayersFromLicense), new {userLicense = PlayerReadDto.UserLicense}, PlayerReadDto);

        }
    }
}
