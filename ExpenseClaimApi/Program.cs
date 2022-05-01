using ExpenseClaimApi.Context;
using ExpenseClaimApi.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();
// app.UseMiddleware<JwtMiddleware>();
app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/ExpenseClaim"),
    appBuilder => appBuilder.UseMiddleware<JwtMiddleware>());
app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/ClaimItem"),
    appBuilder => appBuilder.UseMiddleware<JwtMiddleware>());
app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/User/GetUserInformation"),
    appBuilder => appBuilder.UseMiddleware<JwtMiddleware>());

// app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}"
);

app.Run();
