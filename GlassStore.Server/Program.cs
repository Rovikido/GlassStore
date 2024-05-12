using GlassStore.Server.DAL.Implementations;
using GlassStore.Server.DAL.Interfaces;
using GlassStore.Server.Domain;
using GlassStore.Server.Domain.Models;
using GlassStore.Server.Domain.Models.Auth;
using GlassStore.Server.Repositories.Implementations;
using GlassStore.Server.Repositories.Interfaces;
using GlassStore.Server.Servise.Auth;
using GlassStore.Server.Servise.Helpers;
using GlassStore.Server.Servise.User;
using GlassStore.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
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
//builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<iUserRepository, UserRepository>();

/*############################## Services ######################################################*/
//builder.Services.AddScoped<DownloadService>();
builder.Services.AddScoped<AuthServise>();
builder.Services.AddScoped<UserServise>();
builder.Services.AddTransient<HttpService>();
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

builder.Services.AddHttpContextAccessor();

/*############################## AddAutoMapper ######################################################*/
builder.Services.AddAutoMapper(typeof(Program));

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

app.UseCors(); // ��� �������� ������ 

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
