using API_Pedidos.Domain.PedidosContext.Services;
using API_Pedidos.Domain.PedidosContext.Repositories;
using API_Pedidos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using API_Pedidos.Services.PedidosContext;
using API_Pedidos.Infrastructure.Repositories;
using API_Pedidos.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//resolve cors local
var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder => {        
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        //builder.SetIsOriginAllowed(origin => true);
    });
});

//registro do perfil criado para o automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
//use inMemory
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Pedidos"));
//use SQLServer ConnectionString
//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//injestao de dependencia
builder.Services.AddScoped<IPedidosRepository, PedidosRepository>();
builder.Services.AddScoped<IPedidosService, PedidosService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(devCorsPolicy);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
