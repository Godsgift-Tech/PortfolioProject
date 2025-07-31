using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.APP.Mapping;
using Portfolio.APP.ServiceImplementations;
using Portfolio.APP.ServiceInterface;
using Portfolio.Core.DataInterfaces;
using Portfolio.Core.ProfileUser;
using Portfolio.Infra.Data;
using Portfolio.Infra.DataImplementations;
using Portfolio.Infra.Unit_of_Works;

var builder = WebApplication.CreateBuilder(args);

//  Add Database Context
var configuration = builder.Configuration;
Console.WriteLine("🔗 Connection string in use: " + configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddDbContext<PortfolioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Identity Configuration
builder.Services.AddIdentity<AppUser, Role>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<PortfolioContext>()
.AddDefaultTokenProviders();

//  Register Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IWorkExperienceRepository, WorkExperienceRepository>();
builder.Services.AddScoped<IWorkExperienceService, WorkExperienceService>();
builder.Services.AddScoped<IProfessionalStackRepository, ProfessionalStackRepository>();
builder.Services.AddScoped<IProfessionalStackService, ProfessionalStackService>();
builder.Services.AddScoped<IUnitOFWork, UnitOFWork>();
builder.Services.AddMemoryCache();

//  AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//  Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
