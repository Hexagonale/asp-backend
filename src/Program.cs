using Api.Services;
using Api.Database;
using Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<UsersRepository, DevelopmentUsersRepository>();
builder.Services.AddScoped<PostsRepository, DevelopmentPostsRepository>();
builder.Services.AddScoped<CommentsRepository, DevelopmentCommentsRepository>();
builder.Services.AddScoped<LikesRepository, DevelopmentLikesRepository>();
builder.Services.AddScoped<UsersService, UsersService>();
builder.Services.AddScoped<PostsService, PostsService>();
builder.Services.AddScoped<CommentsService, CommentsService>();
builder.Services.AddScoped<LikesService, LikesService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<AppDbContext>();

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
app.UseSession(); 

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
