using LinkShortener.EFCore.DatabaseContext;
using LinkShortener.InversionOfControl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//DATABASE CONFIGURATION
string DbDataBase = builder.Configuration.GetValue<string>("ConnectionStrings:Database");
string DbServer = builder.Configuration.GetValue<string>("ConnectionStrings:Server");
string DbUser = builder.Configuration.GetValue<string>("ConnectionStrings:User");
string DbPassword = builder.Configuration.GetValue<string>("ConnectionStrings:Password");
int DbTimeout = builder.Configuration.GetValue<int>("ConnectionStrings:Timeout");

string connectionString = Connection.SetConnectionString(DbServer, DbDataBase, DbUser, DbPassword);

builder.Services.AddDependencies(connectionString);

builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

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
