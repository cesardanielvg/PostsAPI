namespace PostsApi.Services;

public interface IDbService
{
    Task<T> GetAsync<T>(string command, object parms); 
    Task<List<T>> GetAll<T>(string command, object parms );
    Task<int> EditDataAsync(string command, object parms);

}
