using Dapper;
using DapperSQLServer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CarController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Factory");
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            using var connection = new SqlConnection(_connectionString);
            var cars = await connection.QueryAsync<Car>("select * from Car");

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var car = await connection.QueryFirstAsync<Car>("select * from Car where id = @Id", new { Id = id });
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(Car request)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("insert into Car (name, year, createdAt) values (@name, @year, @createdAt)", new
            {
                Name = request.Name,
                Year = request.Year,
                CreatedAt = DateTime.UtcNow
            });

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(Car request)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("update Car set name = @Name, year = @Year", new
            {
                Name = request.Name,
                Year = request.Year
            });

            return Ok(GetCarById(request.Id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("delete Car where id = @Id", new { Id = id });
            return Ok(GetCars());
        }
    }
}
