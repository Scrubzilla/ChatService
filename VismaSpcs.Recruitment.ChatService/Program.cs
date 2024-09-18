using VismaSpcs.Recruitment.ChatService.Context;
using Microsoft.EntityFrameworkCore;
using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Repositories;
using VismaSpcs.Recruitment.ChatService.Repositories.Implementation;
using VismaSpcs.Recruitment.ChatService.Repositories.Interface;
using VismaSpcs.Recruitment.ChatService.Services;
using VismaSpcs.Recruitment.ChatService.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ChatServiceDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IConversationService, ConversationService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IConversationRepository, ConversationRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

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
