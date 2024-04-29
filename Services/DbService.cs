using System.Data;
using Dapper;
using Npgsql;

namespace PostsApi.Services;

public class DbService(IConfiguration configuration) : IDbService
{
    private readonly IDbConnection _db = new NpgsqlConnection(configuration.GetConnectionString("PostsDb"));

    public async Task<T> GetAsync<T>(string command, object parms)
    {
        T result;

        result = (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();

        return result;

    }

    public async Task<List<T>> GetAll<T>(string command, object parms)
    {

        List<T> result = [];

        result = (await _db.QueryAsync<T>(command, parms)).ToList();

        return result;
    }

    public async Task<int> EditData(string command, object parms)
    {
        int result;

        result = await _db.ExecuteAsync(command, parms);

        return result;
    }
}