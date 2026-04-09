using System.Text.Json;

public static class ConfigReader
{
    public static string BaseUrl { get; private set; } = null!;

    static ConfigReader()
    {
        var json = File.ReadAllText("Config/appsettings.json");
        var data = JsonSerializer.Deserialize<Dictionary<string, string>>(json)!;

        BaseUrl = data["baseUrl"];
    }
}