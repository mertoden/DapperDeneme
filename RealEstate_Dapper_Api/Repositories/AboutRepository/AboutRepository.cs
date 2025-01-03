using Dapper;
using RealEstate_Dapper_Api.Dtos.AboutDtos;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AboutRepository
{
    public class AboutRepository : IAboutRepository
    {
        private readonly Context _context;

        public AboutRepository(Context context)
        {
            _context = context;
        }

        public async void CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            string query = "insert into About (Title,Subtitle,Description1,Description2) values (@title,@subtitle,@description1,@description2)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@title", createAboutDto.Title);
            paramaters.Add("@subtitle", createAboutDto.Subtitle);
            paramaters.Add("@description1", createAboutDto.Description1);
            paramaters.Add("@description2", createAboutDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async void DeleteAboutAsync(int id)
        {
            string query = "Delete From About Where WhoWeAreDetailID=@whoWeAreDetailID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<GetByIDAboutDto> GetAbout(int id)
        {
            string query = "Select * From About Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDAboutDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            string query = "Select * From About";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAboutDto>(query);
                return values.ToList();
            }
        }

        public async void UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            string query = "Update About Set Title=@title,SubTitle=@subTitle, Description1=@description1, Description2=@description2 where WhoWeAreDetailID=@whoWeAreDetailID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@title", updateAboutDto.Title);
            paramaters.Add("@subtitle", updateAboutDto.Subtitle);
            paramaters.Add("@description1", updateAboutDto.Description1);
            paramaters.Add("@description2", updateAboutDto.Description2);
            paramaters.Add("@whoWeAreDetailID", updateAboutDto.WhoWeAreDetailID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
