using Repository.ITaskManagment;
using DataLayer.TaskManagment;

var builder = WebApplication.CreateBuilder(args);

//  Add MVC services
builder.Services.AddControllersWithViews();

//  Dependency Injection
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

//  DB Connection
ConnectionFactory.Configure(builder.Configuration);

var app = builder.Build();

//  Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
