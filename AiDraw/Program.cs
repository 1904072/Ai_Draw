var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/AiDraw/Error"); // Update if you want custom error handling
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Set the default route to point to AiDrawController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AiDraw}/{action=Index}/{id?}"); // Changed default controller to AiDraw

app.Run();



