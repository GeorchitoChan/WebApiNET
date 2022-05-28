using webapinet;
using webapinet.Middlewares;
using webapinet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TareasDb;Data Source=192.168.0.10\\SQLSERVER2019");
// builder.Services.AddScoped<IHelloWorldService, HelloWorldService>(); // Dependency injection with an interface
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService()); // Dependency injection with a class
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseWelcomePage(); // Middlewares

app.MapControllers();

app.Run();
