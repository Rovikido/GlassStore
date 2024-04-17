using GlassStore.Server.DAL.Implementations;
using GlassStore.Server.Domain;
using GlassStore.Server.Domain.Models;
using GlassStore.Server.Domain.Models.Auth;
using GlassStore.Server.Repositories.Implementations;
using GlassStore.Server.Repositories.Interfaces;
using GlassStore.Server.Servise.Auth;
using GlassStore.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


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

//builder.Services.AddScoped<BaseRepository<Accounts>,AuthRepository>();
builder.Services.AddScoped<AuthRepository>();

/*############################## Services ######################################################*/
//builder.Services.AddScoped<DownloadService>();
builder.Services.AddScoped<AuthServise>();

/*################################### Auth ##################################################*/
builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection("Auth"));

var authOptions = builder.Configuration.GetSection("Auth").Get<AuthOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = authOptions.Issuer,

            ValidateAudience = true,
            ValidAudience = authOptions.Audience,

            ValidateLifetime = true,

            IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

/*############################## localhost 4200 ######################################################*/
//builder.Services.AddCors(options => { 
//    options.AddDefaultPolicy(
//        builder =>
//        {
//            builder.AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader();
//        });
//    });
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

app.UseCors(); // для создания токина 

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
