using IntegracionGemini.Interfaces;
using IntegracionGemini.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<GeminiRepository>();
builder.Services.AddScoped<OpenAIRepository>();

// Register a factory delegate that returns the right service
builder.Services.AddScoped<Func<string, iChatbotService>>(serviceProvider => key =>
{
    return key switch
    {
        "Gemini" => serviceProvider.GetRequiredService<GeminiRepository>(),
        "OpenAI" => serviceProvider.GetRequiredService<OpenAIRepository>(),
        _ => throw new ArgumentException("Invalid chatbot provider", nameof(key))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
