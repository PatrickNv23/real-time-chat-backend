using real_time_chat_backend.Implementations;
using real_time_chat_backend.Repositories;
using real_time_chat_backend.Repositories.Interfaces;
using real_time_chat_backend.Services;
using real_time_chat_backend.Services.Interfaces;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

// CORS
var corsPolicyName = "CorsPolicy";

// Add services to the container.
builder.Services.AddControllers();

// Add dependency injections
builder.Services.AddRepositoryDependencyInjection();
builder.Services.AddServiceDependencyInjection();


// Add SignalR to the container
builder.Services.AddSignalR();

// Add Supabase to the container
builder.Services.AddSingleton<Supabase.Client>(provider =>
    new Supabase.Client(
        builder.Configuration["SUPABASE_URL"],
        builder.Configuration["SUPABASE_API_KEY"],
        new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        }
    )
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("http://localhost:4200");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS
app.UseCors(corsPolicyName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// link Hub to the route, under MapControllers
app.MapHub<ChatHub>("/chat");

app.Run();