using Repositories.Interface;
using Repositories.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//DI
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShelfRepository, ShelfRepository>();
builder.Services.AddScoped<IImportRepository, ImportRepository>();
builder.Services.AddScoped<IImportDetailRepository, ImportDetailRepository>();
builder.Services.AddScoped<IProductLineRepostiory, ProductLineRepostiory>();
builder.Services.AddScoped<IExportRepository, ExportRepository>();
builder.Services.AddScoped<IExportDetailRepository, ExportDetailRepository>();
builder.Services.AddScoped<ICheckingRequestRepository, CheckingRequestRepository>();
<<<<<<< HEAD
builder.Services.AddScoped<IReportRepository, ReportRepository>();
=======
builder.Services.AddScoped<IBrewingRoomRepository, BrewingRoomRepository>();
>>>>>>> 9c2004ea2fd3bbccf5f75dbc8f7f318b6a4391b0
//Session
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapGet("/", context =>
{
    context.Response.Redirect("/Login");
    return Task.CompletedTask;
});
app.UseSession();

app.Run();
