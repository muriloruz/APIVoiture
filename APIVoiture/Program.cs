using APIVoiture.Authorization;
using APIVoiture.Controllers;
using APIVoiture.Data;
using APIVoiture.Models;
using APIVoiture.Profiles;
using APIVoiture.Services;
using AutoMapper;
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
builder.Services.AddTransient<VendedorClienteController>();
builder.Services.AddTransient<EnderecoController>();
builder.Services.AddTransient<MCController>();
builder.Services.AddTransient<UsuarioController>();
builder.Services.AddTransient<VendedorController>();
builder.Services.AddTransient<PagamentoController>();
builder.Services.AddTransient<PecaController>();
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Add services to the container.

builder.Services.AddDbContext<UsuarioContext>(opts =>
    opts.UseLazyLoadingProxies()
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<UsuarioContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UsuarioServices>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("IdadeMinima", policy => policy.AddRequirements(new IdadeMinima(18)));
});

/*builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());*/

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5173")
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
