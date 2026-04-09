using ApiFramework.Helpers;
using ApiFramework.Models;
using ApiFramework.Models.Response;
using ApiFramework.Utilities;
using NUnit.Framework;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;

[TestFixture]
public class UserTests
{
    private ApiClient _api=null!;
   // private AuthService _auth=null!;

    [SetUp]
    public void Setup()
    {
        _api = new ApiClient();
       // _auth = new AuthService();
    }
    [OneTimeSetUp]
    public void Init()
    {
        Logger.Setup();
        ReportManager.Init();
    }
   
    //[Test]
    //public async Task CreateUser_WithToken()
    //{
    //   
    //    var loginRequest = new LoginRequest
    //    {
    //        email = "eve.holt@reqres.in",
    //        password = "cityslicka"
    //    };

    //    var token = await _auth.GetToken(loginRequest);


    //    _api.SetToken(token);


    //    var request = new UserRequest
    //    {
    //        name = "Bhavya",
    //        job = "QA Engineer"
    //    };

    //    var response = await _api.Post("/users", request);

    //    var json = await response.Content.ReadAsStringAsync();
    //    var user = JsonHelper.Deserialize<UserResponse>(json);

    //    Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
    //    Assert.That(user.name, Is.EqualTo("Bhavya"));
    //}

    [Test]
    public async Task CreatePostTest()
    {
        var request = new PostResponse
        {
          title= "test",
          body= "demo",
          userId= 1,

        };
        Log.Information("Sending POST request");
        ReportManager.test = ReportManager.extent.CreateTest("Create Post Test");
        ReportManager.test.Info("Request Created");
        var response = await _api.Post("/posts", request);
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonHelper.Deserialize<PostResponse>(json);
        Log.Information($"Response Status: {response.StatusCode}");
        ReportManager.test.Info($"Response Status: {response.StatusCode}");

        if (!response.IsSuccessStatusCode)
        {
            Log.Error("Request failed");
            ReportManager.test.Fail("Fail");
        }
        else
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
            Assert.That(data.title, Is.EqualTo("test"));
            ReportManager.test.Pass("Pass");
            Log.Information("Pass");
        }
    }
    [Test]
    public async Task GetPostTest()
    {
        var response = await _api.Get("/posts/1");
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonHelper.Deserialize<PostResponse>(json);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        Assert.That(data.id, Is.EqualTo(1));

    }
    [Test]
    public async Task GetAllPostsTest()
    {
        var response = await _api.Get("/posts"); // get list
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonHelper.Deserialize<List<PostResponse>>(json);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        Assert.That(data.Count, Is.GreaterThan(0));
        Assert.That(data[0].id, Is.EqualTo(1));

    }
    [Test]
    public async Task UpdatePostTest()
    {
        var request = new PostResponse
        {
            id = 1,
            title = "updated",
            body = "new data",
            userId = 1
        };

        var response = await _api.Put("/posts/1", request);
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonHelper.Deserialize<PostResponse>(json);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        Assert.That(data.title, Is.EqualTo("updated"));

    }
    [Test]
    public async Task DeletePostTest()
    {
        var response = await _api.Delete("/posts/1");
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonHelper.Deserialize<PostResponse>(json);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
       
    }
    [OneTimeTearDown]
    public void TearDown()
    {
        ReportManager.Flush();
    }

    //[Test]

    //public async Task Test()
    //{
    //    var client = new HttpClient();
    //    var Request = new
    //    {
    //            title = "test",
    //            body = "demo",
    //            userId = 1,
    //     };

    //    var json = JsonSerializer.Serialize(Request);
    //    var content = new StringContent(json,Encoding.UTF8,"application/json");

    //    var response =await client.PostAsync("https://jsonplaceholder.typicode.com/posts", content);

    //    var responseBody=   await response.Content.ReadAsStringAsync();
    //    var data = JsonSerializer.Deserialize<PostResponse>(responseBody);
    //    Assert.That(data!.userId,Is.EqualTo(1));
    //    Console.WriteLine(responseBody);
    //    Assert.That(response.StatusCode,Is.EqualTo(HttpStatusCode.Created));

    //}

    //[Test]
    //public async Task CreateGetmethod()
    //{

    //    var client = new HttpClient();

    //    var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1");

    //    var responseBody = await response.Content.ReadAsStringAsync();

    //    var data = JsonSerializer.Deserialize<PostResponse>(responseBody);

    //}

    //[Test]
    //public async Task GetMethodList()
    //{
    //    var client = new HttpClient();
    //    var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
    //    var content = await response.Content.ReadAsStringAsync();
    //    var responseBody = JsonSerializer.Deserialize<List<PostResponse>>(content);

    //}

    //[Test]
    //public async Task PutMethodList()
    //{
    //    var client = new HttpClient();
    //    var Request = new
    //    {
    //        title = "test1",
    //        body = "demo1",
    //        userId = 1,
    //    };

    //    var json = JsonSerializer.Serialize(Request);
    //    var content = new StringContent(json,Encoding.UTF8,"application/json");
    //    var response = await client.PutAsync("https://jsonplaceholder.typicode.com/posts/1", content);
    //    var responsebody = await response.Content.ReadAsStringAsync();
    //    var data = JsonSerializer.Deserialize<PostResponse>(responsebody);



    //}


}