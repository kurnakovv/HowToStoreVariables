using HowToStoreVariables.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddSingleton(builder.Configuration.GetSection("Variables").Get<Variables>());
builder.Services.AddSingleton(builder.Configuration.Get<Root>());

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.MapHealthChecks("/ping");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
