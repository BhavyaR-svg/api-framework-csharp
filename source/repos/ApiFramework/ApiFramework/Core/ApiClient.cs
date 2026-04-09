using System.Text;
using System.Text.Json;

public class ApiClient : BaseService
{
    public async Task<HttpResponseMessage> Get(string endpoint)
    {
        return await client.GetAsync(endpoint);
    }

    public async Task<HttpResponseMessage> Post(string endpoint, object body)
    {
        var json = JsonSerializer.Serialize(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await client.PostAsync(endpoint, content);
    }

    public async Task<HttpResponseMessage> Put(string endpoint, object body)
    {
        var json = JsonSerializer.Serialize(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await client.PutAsync(endpoint, content);
    }

    public async Task<HttpResponseMessage> Delete(string endpoint)
    {

        return await client.DeleteAsync(endpoint);
    }

}