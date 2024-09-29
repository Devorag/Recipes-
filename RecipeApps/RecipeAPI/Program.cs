var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Configuration.AddJsonFile("secret-appsettings.json", true, true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");
app.UseAuthorization();
string settingname = "Settings:liveconn";
#if DEBUG
settingname = "Settings:devconn";
#endif 

string? connstring = builder.Configuration[settingname];

if(connstring == null)
{
    throw new Exception(settingname + " connection string not found");
}
RecipeSystem.DBManager.SetConnectionString(connstring, true);

app.MapControllers();

app.Run();
