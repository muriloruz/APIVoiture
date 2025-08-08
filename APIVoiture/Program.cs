using APIVoiture.Authorization;
using APIVoiture.Controllers;
using APIVoiture.Data;
using APIVoiture.Models;
using APIVoiture.Profiles;
using APIVoiture.Services;
using AutoMapper;
using DotNetEnv;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Stripe ;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;


var builder = WebApplication.CreateBuilder(args);

Env.Load();


var connectionString = builder.Configuration.GetConnectionString("ConnectionString");



var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new VendedorProfile());
    mc.AddProfile(new EnderecoProfile());
    mc.AddProfile(new UsuarioProfile());
    mc.AddProfile(new VendedorClienteProfile());
    mc.AddProfile(new PagamentoProfile());
    mc.AddProfile(new PecaProfile());
    mc.AddProfile(new FavoritoProfile());
    
});
builder.Services.AddControllers();

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);



builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    );

builder.Services.AddDbContext<UsuarioContext>(opts =>
    opts.UseLazyLoadingProxies()
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<UsuarioContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UsuarioServices>();
builder.Services.AddScoped<TokenServices>();
builder.Services.AddScoped<VendedorServices>();

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("VendedorPolicy", policy => policy.RequireRole("VENDEDOR"));
    opt.AddPolicy("UsuarioPolicy", policy => policy.RequireRole("USUARIO"));

});



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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

 app.UseCors("AllowSpecificOrigin");
 

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "imagens")
    ),
    RequestPath = "/imagens"
});



app.UseRouting();
app.UseAuthorization();
app.MapControllers();


StripeConfiguration.ApiKey =
    Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY") ??
    throw new Exception("Chave Stripe não configurada");


app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
{
    var endpoints = endpointSources
        .SelectMany(es => es.Endpoints)
        .OfType<RouteEndpoint>();

    return Results.Json(endpoints.Select(e => new {
        Method = e.Metadata.GetMetadata<HttpMethodMetadata>()?.HttpMethods?[0],
        Pattern = e.RoutePattern.RawText
    }));
});

app.Run();