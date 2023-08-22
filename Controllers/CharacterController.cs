using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;


namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        //Initialize readonly characterService for dependency injection
        private readonly ICharacterService _characterService;

        //Constructor for the controller, inject the characterService here
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        //Create a method to get list of characters
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        //Create a method to get a single character
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpDelete("{id}")]
        //Create a method to get a single character
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Delete(int id)
        {
            //Get the service response
            var response = await _characterService.DeleteCharacter(id);
            
            if(response.Data == null)
            {
                return NotFound(response);
            }
            //Return the updated character
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            //Return the list of characters
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            //Get the service response
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            
            if(response.Data == null)
            {
                return NotFound(response);
            }
            //Return the updated character
            return Ok(response);
        }

    }
    
}