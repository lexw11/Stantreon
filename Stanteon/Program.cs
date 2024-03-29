using Microsoft.EntityFrameworkCore;
using StantreonApi.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<StantreonContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection"
        )
    );
    //options.UseInMemoryDatabase("Stantreon");
    //.UseLoggerFactory(LoggerFactory.Create(builder =>
    //{
    //    builder.AddDebug();
    //    builder.AddConsole();
    //}));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var dbContext = services.GetRequiredService<ApplicationDbContext>();
//    dbContext.Database.Migrate();
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
