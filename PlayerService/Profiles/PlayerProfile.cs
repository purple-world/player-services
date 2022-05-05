using AutoMapper;
using PlayerService.Dtos;
using PlayerService.Models;

namespace PlayerService.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerReadDto>();
            CreateMap<PlayerCreateDto, Player>();
        }
    }
}
