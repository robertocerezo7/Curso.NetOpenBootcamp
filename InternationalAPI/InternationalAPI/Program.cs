var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. LOCALIZATION
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2.SUPPORTED CULTURES
var supportedClutures = new[] { "en-US", "es-ES", "fr-FR" }; // USA English, Spain Spanish, France french

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedClutures[0]) // English by default
    .AddSupportedCultures(supportedClutures) // Add all supported cultures
    .AddSupportedUICultures(supportedClutures); // Add supported cultures to UI


// 3. ADD LOCALIZATION to App
app.UseRequestLocalization(localizationOptions);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
