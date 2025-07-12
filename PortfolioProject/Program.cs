using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.APP.Mapping;
using Portfolio.Core.DataInterfaces;
using Portfolio.Core.ProfileUser;
using Portfolio.Infra.Data;
using Portfolio.Infra.DataImplementations;
using Portfolio.Infra.Unit_of_Works;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// registering other services
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IUnitOFWork, UnitOFWork>();
builder.Services.AddMemoryCache();


// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));




builder.Services.AddIdentity<AppUser, Role>(options =>
{
    // Optional: password or lockout settings
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<PortfolioContext>() // your DbContext
.AddDefaultTokenProviders(); // needed for email confirmation, password reset, etc.
builder.Services.AddDbContext<PortfolioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<Role>>();

    await IdentitySeeder.SeedAsync(userManager, roleManager);
}
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
