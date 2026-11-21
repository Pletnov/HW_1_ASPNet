var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (HttpContext context) =>
{
    var expiriences = new[] {
        "Web development",
        "C# Development",
        "C++ Development",
        "Node js, Html, JS developer"
    };
    var expiriencesList = string.Join("", expiriences.Select(e => $"<li>{e}</li>"));

    var birthday = DateTime.Parse("2011-07-18");
    var today = DateTime.Today;
    int age = today.Year - birthday.Year;

    var htmlContent = $@"
        <html>
            <head>
                <title>My Web</title>
                <link rel='stylesheet' href='/style.css'>
            </head>
            <body>
                <h1>Welcome to my page, my name is Denys Pletnov!</h1>

                <h2>My expiriences:<h2>
                <ul>
                    {expiriencesList}
                </ul>
                <h3>My birthday: {birthday.ToLongDateString()}</h3>
                <h3>My Age: {age}</h3>
            </body>
        </html>
    ";
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(htmlContent);

});


app.MapGet("/style.css", async (HttpContext context) =>
{
    context.Response.ContentType = "text/css; charset=utf-8";
    await context.Response.WriteAsync(GetStyle());
});

app.Run();



static string GetStyle()
{
    return @"
                body {
                    background-color: #1e1e2e;
                    color: white;
                    font-family: Arial, sans-serif;
                    text-align: center;
                    padding: 30px;
                }
                h1 {
                    color: #89b4fa;
                    font-size: 36px;
                }
                h2 {
                    color: #a6e3a1;
                }
                ul {
                    list-style: none;
                    padding: 0;
                }
                li {
                     background-color: #313244;
                     margin: 10px auto;
                     padding: 15px;
                     border-radius: 10px;
                     max-width: 400px;
                }
                h3 {
                     color: #f9e2af;
                }
    ";
}