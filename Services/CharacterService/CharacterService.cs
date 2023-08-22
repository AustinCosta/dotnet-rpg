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

            //Get the max id from the list and increase it by one
            //Then add the character to the list
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;

            //Add the character to the list
            characters.Add(character);

            //Map every character object of the list into a characterDto
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            //Return the mapped character dto
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            //Get a characterdto from the service
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                //Get the character whos id is the same as the updatedCharacter we are passing in
                Character character = characters.First(c => c.Id == id);
                characters.Remove(character);
                response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            } 
            catch(Exception ex) 
            {
                //Set success flag to false
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
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

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            //Get a characterdto from the service
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();

            try
            {
                //Get the character whos id is the same as the updatedCharacter we are passing in
                Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

                //Parse the updates into the character object
                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.Strength;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                //edit the response body
                response.Data = _mapper.Map<GetCharacterDto>(character);
            } 
            catch(Exception ex) 
            {
                //Set success flag to false
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }
    }
}