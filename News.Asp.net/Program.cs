using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Map;
using DataAccess.MyContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext
builder.Services.AddDbContext<AppDbContext>(opt=>
opt.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));

//Mapper
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MyMapper());
});
builder.Services.AddSingleton(mappingConfig.CreateMapper());

//Services
builder.Services.AddScoped<IAbout, AboutService>();
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IComment, CommentService>();
builder.Services.AddScoped<IContact, ContactService>();
builder.Services.AddScoped<IMessage, MessageService>();
builder.Services.AddScoped<IPost, PostService>();
builder.Services.AddScoped<IPrivacy, PrivacyService>();
builder.Services.AddScoped<ISiteAbout, SiteAboutService>();
builder.Services.AddScoped<ISocialMedia, SocialMediaService>();


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
