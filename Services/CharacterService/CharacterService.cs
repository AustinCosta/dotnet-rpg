using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        //Instantiate a list of characters
        private static List<Character> characters = new List<Character> 
        {
            new Character(),
            new Character { Id = 1, Name = "Sam" }
        };
        
        private readonly IMapper _mapper;

        //Inject Auto mapper
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            //Create response variable
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            //Map to the character
            characters.Add(_mapper.Map<Character>(newCharacter));

            //Map every character object of the list into a characterDto
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            //Return the mapped character dto
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            return new ServiceResponse<List<GetCharacterDto>> 
            { 
                Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList() 
            };
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            //Instantiate a CharacterDto object
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            //Get the character by id
            var character = characters.FirstOrDefault(c => c.Id == id);

            //Map the character object to the CharacterDto object class
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

            //Return the mapped object
            return serviceResponse;
        }
    }
}