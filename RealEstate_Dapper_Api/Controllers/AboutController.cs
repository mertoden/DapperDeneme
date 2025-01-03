using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.AboutDtos;
using RealEstate_Dapper_Api.Repositories.AboutRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutController(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutRepository.GetAllAboutAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            _aboutRepository.CreateAboutAsync(createAboutDto);
            return Ok("About Add Succesfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            _aboutRepository.DeleteAboutAsync(id);
            return Ok("About deleted succesfully.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            _aboutRepository.UpdateAboutAsync(updateAboutDto);
            return Ok("About Updated Succesfully");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _aboutRepository.GetAbout(id);
            return Ok(value);
        }
    }
}
