var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(typeof(employee_webapi_EF_.Models.EF.EmployeeManagementApiDbContext));
var app = builder.Build();


builder.Services.AddCors(policy =>
{
    policy.AddDefaultPolicy(bydefault =>
    {
        bydefault.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
