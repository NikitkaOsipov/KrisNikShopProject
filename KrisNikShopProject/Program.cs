using KrisNikShopProject.Components;
using KrisNikShopProject.Components.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();  
builder.Services.AddSingleton<UserRegistrationService>(); //https://www.youtube.com/watch?v=roWkfJoDf3w&list=PLfbOp004UaYX7DQVLu4pheJWY8t-a3X60&index=5&ab_channel=GeraldVersluis
builder.Services.AddSingleton<ProductStorageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
