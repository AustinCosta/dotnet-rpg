using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(GetCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            //Add the new character to the list
            characters.Add(newCharacter);
            serviceResponse.Data = characters;

            //Return the list of characters
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            return new ServiceResponse<List<GetCharacterDto>> { Data = characters };
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = character;
            return serviceResponse;
        }
    }
}