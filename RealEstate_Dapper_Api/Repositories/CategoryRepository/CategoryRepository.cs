using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryName", categoryDto.CategoryName);
            paramaters.Add("@categoryStatus", true);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async void DeleteCategoryAsync(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category Where CategoryID=@CategoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", id);
            using(var connection = _context.CreateConnection())
            {
              var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query,parameters);
                return values;
            }
        }

        public async void UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryName", categoryDto.CategoryName);
            paramaters.Add("@categoryStatus", categoryDto.CategoryStatus);
            paramaters.Add("@categoryID", categoryDto.CategoryID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
