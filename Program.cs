using System.Net;
using System.Net.Cache;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapGet("/", () => new Person("Tom", 38));

app.Run();

using System.Net;

record Person(string Name, int Age);

using System.Net.Http.Json;

class Program

{
    static HttpClient httpClient = new HttpClient();
    static async Task Main()
    {
        object? data = await httpClient.GetFromJsonAsync("https://localhost:7073/", typeof(Person));
        if (data is Person person)
        {
            Console.WriteLine($"Name: {person.Name} Age: {person.Age}");
        }
    }
}
record Person(string Name, int Age);

using System.Net.Http.Json;
 
class Program
{
    static HttpClient httpClient = new HttpClient();
    static async Task Main()
    {
        Person? person = await httpClient.GetFromJsonAsync<Person>("https://localhost:7073/");
        Console.WriteLine($"Name: {person?.Name} Age: {person?.Age}");
    }
}
record Person(string Name, int Age);

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapGet("/{id?}", (int? id) =>
{
    if (id is null)
        return Results.BadRequest(new { Message = "Некорректные данные в запросе" });
    else if (id != 1)
        return Results.NotFound(new { Message = $"Объект с id={id} не существует" });
    else
        return Results.Json(new Person("Bob", 42));
});

app.Run();
record Person(string Name, int Age);

using System.Net;
using System.Net.Http.Json;
class Program
{
    static HttpClient httpClient = new HttpClient();
    static async Task Main()
    {
        using var response = await httpClient.GetAsync("https://localhost:7073/1");

        if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
        {
            Error? error = await response.Content.ReadFromJsonAsync<Error>();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(error?.Message);
        }
        else
        {
            Person? person = await response.Content.ReadFromJsonAsync<Person>();
            Console.WriteLine($"Name: {person?.Name}   Age: {person?.Age}");
        }
    }
}
record Person(string Name, int Age);
record Error(string Message);