using contact_book_api._1___Presentation.Mapping;
using contact_book_api._2___Domain.Services;
using contact_book_api.Data;
using contact_book_api.Interfaces.IService;
using contact_book_api.IRepository;
using contact_book_api.Repository;
using Microsoft.EntityFrameworkCore;

const string CorsPolicy = "AllowSwagger";

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicy, p =>
            p.WithOrigins(
                    "http://localhost:5000",  // Swagger UI no host
                    "https://localhost:5001"  // se você usar https local
                    // adicione outras origens se necessário, ex. http://localhost:5173
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
        // .AllowCredentials() // só se usar cookies/autenticação baseada em cookie
    );
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("Default")
           ?? throw new InvalidOperationException("Connection string 'Default' não configurada");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(conn);
});



builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();

builder.Services.AddScoped<IAgendaService, AgendaService>(); 


builder.Services.AddSingleton<AgendaMap>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agenda de contatos");
        c.RoutePrefix = "swagger";
    });
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(CorsPolicy);

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.Run();
