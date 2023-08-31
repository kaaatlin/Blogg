using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BLog.API.Contracts;
using BLog.DAL.Models;
using BLog.DAL;
using System.Reflection;
using BLog.BLL.Services.IServices;
using BLog.BLL.Services;
using BLog.DAL.Repositories.IRepositories;
using BLog.DAL.Repositories;

namespace BLog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Blog API",
                });
                var basePath = AppContext.BaseDirectory;

                var xmlPath = Path.Combine(basePath, "Blog.API.xml");
                options.IncludeXmlComments(xmlPath);
            });

            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(new MappingProfile());
            });
            var mapper = mapperConfig.CreateMapper();
            var assembly = Assembly.GetAssembly(typeof(MappingProfile));

            builder.Services.AddAutoMapper(assembly);

            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connection))
                .AddIdentity<User, Role>(opts =>
                {
                    opts.Password.RequiredLength = 5;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<BlogDbContext>();

            // Services AddSingletons,Transient
            builder.Services
                .AddSingleton(mapper)
                .AddTransient<IAccountService, AccountService>()
                .AddTransient<ICommentService, CommentService>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<IPostService, PostService>()
                .AddTransient<IPostRepository, PostRepository>()
                .AddTransient<IRoleService, RoleService>()
                .AddTransient<ITagService, TagService>()
                .AddTransient<ITagRepository, TagRepository>();

            builder.Services.AddAuthentication(optionts => optionts.DefaultScheme = "Cookies")
                .AddCookie("Cookies", options =>
                {
                    options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = redirectContext =>
                            {
                                redirectContext.HttpContext.Response.StatusCode = 401;
                                return Task.CompletedTask;
                            }
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}