using APIVoiture.Authorization;
using APIVoiture.Controllers;
using APIVoiture.Data;
using APIVoiture.Models;
using APIVoiture.Profiles;
using APIVoiture.Services;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using static APIVoiture.Controllers.MCController;

var builder = WebApplication.CreateBuilder(args);
//var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
//builder.WebHost.UseUrls($"http://*:{port}");




var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

// Configurar AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new VendedorProfile());
    mc.AddProfile(new EnderecoProfile());
    mc.AddProfile(new MCProfile());
    mc.AddProfile(new UsuarioProfile());
    mc.AddProfile(new VendedorClienteProfile());
    mc.AddProfile(new PagamentoProfile());
    mc.AddProfile(new PecaProfile());
    // Adicione outras profiles conforme necessário
});
builder.Services.AddControllers();

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Add services to the container.

builder.Services.AddDbContext<UsuarioContext>(opts =>
    opts.UseLazyLoadingProxies()
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<UsuarioContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UsuarioServices>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<VendedorServices>();

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("VendedorPolicy", policy => policy.RequireRole("VENDEDOR"));
    opt.AddPolicy("UsuarioPolicy", policy => policy.RequireRole("USUARIO"));

});

/*builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());*/

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5000")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});




var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = new[] { "USUARIO", "VENDEDOR", "ADMIN" };
    foreach (var roleName in roles)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



//app.UseHttpsRedirection();

// Usar CORS
app.UseCors("AllowSpecificOrigin");

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    await next();
});







app.UseAuthorization();

app.MapControllers();



app.Run();
