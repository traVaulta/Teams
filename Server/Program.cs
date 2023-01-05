using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Teams.Core.Conversation;
using Teams.Core.Conversation.DAL;
using Teams.Core.Message;
using Teams.Core.Message.DAL;
using Teams.Core.Person;
using Teams.Core.Person.DAL;
using Teams.Infrastructure;
using Teams.Infrastructure.Conversation.DAL;
using Teams.Infrastructure.Message.DAL;
using Teams.Infrastructure.Migrations;
using Teams.Infrastructure.Person.DAL;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<TeamsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IConversationRepository, ConversationRepository>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<ConversationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TeamsDbContext>();
    context.Database.ExecuteSqlRaw(InitialCreate.Up());
    context.Database.ExecuteSqlRaw(InitialSeed.Up());
}

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
