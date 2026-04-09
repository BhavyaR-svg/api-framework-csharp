using System.Net.Http.Headers;

public class BaseService
{
    protected HttpClient client;

    public BaseService()
    {
        client = new HttpClient();
        client.BaseAddress = new Uri(ConfigReader.BaseUrl);

        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

   
}