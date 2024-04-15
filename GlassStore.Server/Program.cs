using GlassStore.Server.Domain;
using GlassStore.Server.Domain.Models;
using GlassStore.Server.Repositories.Implementations;
using GlassStore.Server.Repositories.Interfaces;
//using GlassStore.Service.Services;
using Microsoft.OpenApi.Models;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GlassStore API", Version = "v1" });
});

/*############################# MongoDB ###########################################################*/
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
builder.Services.AddSingleton<ApplicationDbContext>();

/*############################## Repositories ######################################################*/
//builder.Services.AddScoped<iBaseRepository<Glass>, GlassRepository>();
builder.Services.AddScoped(typeof(iBaseRepository<>), typeof(BaseRepository<>));
//builder.Services.AddScoped<DownloadService>();
/*############################## localhost 4200 #############s##########################################*/
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowLocalhost7224",
//        builder =>
//        {
//            builder.WithOrigins("https://localhost:7224")
//                   .AllowAnyMethod()
//                   .AllowAnyHeader();
//        });
//});
/*##################################################################################################*/



var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GlassStore API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
