using Globals.Resources;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization();
builder.Services.AddTransient<Messages>();
builder.Services.AddControllers();

var app = builder.Build();

var cultures = new [] {"en-US", "pt-BR", "es-ES"};
var cultureOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(cultures.First())
    .AddSupportedCultures(cultures)
    .AddSupportedUICultures(cultures);

app.UseRequestLocalization(cultureOptions);
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapGet("/", (Messages messages) => {
    var current = Thread.CurrentThread;
    // current.CurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");
    return Results.Ok(new {
        Hello = messages.HelloWorld,
        Welcome = messages.Welcome,
        Ask = messages.Ask
    });
});
app.Run();