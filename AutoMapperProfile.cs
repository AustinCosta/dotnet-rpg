using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Map from a Character to a CharacterDto
            CreateMap<Character, GetCharacterDto>();

            //Map from AddCharacterDto to Character object
            CreateMap<AddCharacterDto, Character>();

            //Map from updated character fields
            CreateMap<UpdateCharacterDto, Character>();
        }
    }
}