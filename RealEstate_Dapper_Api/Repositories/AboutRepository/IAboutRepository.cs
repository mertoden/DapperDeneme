using RealEstate_Dapper_Api.Dtos.AboutDtos;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.AboutRepository
{
    public interface IAboutRepository
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        void CreateAboutAsync(CreateAboutDto createAboutDto);
        void DeleteAboutAsync(int id);
        void UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task<GetByIDAboutDto> GetAbout(int id);
    }
}
