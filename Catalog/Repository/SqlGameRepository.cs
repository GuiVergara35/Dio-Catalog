// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Catalog.Entities;
// using Microsoft.Extensions.Configuration;

// namespace Catalog.Repository
// {
//     public class SqlGameRepository : IGameRepository
//     {
//         private readonly SqlConnection _sqlConnection;

//         public SqlGameRepository(IConfiguration configuration)
//         {
//             _sqlConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
//         }

//         public async Task<List<Game>> Get(int page, int quantity)
//         {
//             var gameList = new List<Game>();
//             var command = $"select* from games order by id offset{((page -1) * quantity)} rows fetch next {quantity} rows only";

//             await _sqlConnection.OpenAsync();
//             SqlCommand sqlCommand = new SqlCommand(command, _sqlConnection);
//             SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

//             while(sqlDataReader.Read()){
//                 gameList.Add(new Game{
//                     Id = (Guid)sqlDataReader["Id"],
//                     Name = (string)sqlDataReader["Name"],
//                     Publisher = (string)sqlDataReader["Publisher"],
//                     Price = (double)sqlDataReader["Price"]
//                 });
//             }

//             await _sqlConnection.CloseAsync();

//             return gameList;
//         }

//         public Task Delete(Guid id)
//         {
//             throw new NotImplementedException();
//         }

//         public void Dispose()
//         {
//             throw new NotImplementedException();
//         }


//         public Task<Game> Get(Guid id)
//         {
//             throw new NotImplementedException();
//         }

//         public Task<List<Game>> Get(string name, string publisher)
//         {
//             throw new NotImplementedException();
//         }

//         public Task Save(Game game)
//         {
//             throw new NotImplementedException();
//         }

//         public Task Update(Game game)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }
