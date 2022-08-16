using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using TvojFilm.Model.Requests;
using TvojFilm;
using TvojFilm.Services;
using TvojFilm.Services.Database;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
            },
            new string[]{}
        }
    });
});

builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<ICRUDService<TvojFilm.Model.Uloge, UlogeSearchRequest, UlogeInsertRequest, UlogeInsertRequest>, UlogeService>();
builder.Services.AddTransient<ICRUDService<TvojFilm.Model.Filmovi, FilmoviSearchRequest, FilmoviInsertRequest, FilmoviInsertRequest>, FilmoviService>();
builder.Services.AddTransient<ICRUDService<TvojFilm.Model.Zanrovi, ZanroviSearchRequest, ZanroviInsertRequest, ZanroviInsertRequest>, ZanroviService>();
builder.Services.AddTransient<ICRUDService<TvojFilm.Model.Drzave, DrzaveSearchRequest, DrzaveInsertRequest, DrzaveInsertRequest>, DrzaveService>();
builder.Services.AddTransient<ICRUDService<TvojFilm.Model.Gradovi, GradoviSearchRequest, GradoviInsertRequest, GradoviInsertRequest>, GradoviService>();
builder.Services.AddTransient<ICRUDService<TvojFilm.Model.FilmoviKomentari, FilmoviKomentariSearchRequest, FilmoviKomentariInsertRequest, FilmoviKomentariInsertRequest>, FilmoviKomentariService>();
builder.Services.AddTransient<ICRUDService<TvojFilm.Model.FilmoviOcjene, FilmoviOcjeneSearchRequest, FilmoviOcjeneInsertRequest, FilmoviOcjeneInsertRequest>, FilmoviOcjeneService>();
builder.Services.AddTransient<ICRUDService<TvojFilm.Model.Redatelji, RedateljiSearchRequest, RedateljiInsertRequest, RedateljiInsertRequest>, RedateljiService>();
builder.Services.AddTransient<ICRUDService<TvojFilm.Model.Glumci, GlumciSearchRequest, GlumciInsertRequest, GlumciInsertRequest>, GlumciService>();
builder.Services.AddTransient<ICRUDService<TvojFilm.Model.PrijedloziFilmova, PrijedloziFilmovaSearchRequest, PrijedloziFilmovaInsertRequest, PrijedloziFilmovaInsertRequest>, PrijedloziFilmovaService>();
builder.Services.AddTransient<ICRUDService<TvojFilm.Model.KupnjaFilmova, KupnjaFilmovaSearchRequest, KupnjaFilmovaInsertRequest, KupnjaFilmovaInsertRequest>, KupnjaFilmovaService>();
builder.Services.AddTransient<IRecommendedService, RecomendedService>();

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddAutoMapper(typeof(IFilmoviService));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TvojFilmContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<TvojFilmContext>();
    dataContext.Database.Migrate();
}

app.Run();
