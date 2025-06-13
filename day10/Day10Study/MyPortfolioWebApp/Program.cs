using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebApp.Models;

namespace MyPortfolioWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // �ִ����� �뷮 ����
            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 200 * 1024 * 1024;
            });

            builder.WebHost.ConfigureKestrel(options =>
            {
                // 1024(MB) , 1024(KB)
                options.Limits.MaxRequestBodySize = 200 * 1024 * 1024;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // DB ���� �ʱ�ȭ
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
                builder.Configuration.GetConnectionString("SmartHomeConnection"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SmartHomeConnection"))
            ));

            // ASP.NET Core Identity ����
            // ������ IdentityUser -> CustomUser�� ����
            builder.Services.AddIdentity<CustomUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            // �н����� ��å
            // ���� ��. �ִ� 6�ڸ� �̻�, Ư������ 1�� ����, �����ҹ��� ����
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // �̷� ��ȣ ����ȭ�� ���� ���ƾ� ��! ���� ���!!
                options.Password.RequiredLength = 4; // �ּ� ����
                options.Password.RequireNonAlphanumeric = false; // Ư������ �ʼ� X
                options.Password.RequireUppercase = false; // �빮�� �ʼ� X
                options.Password.RequireLowercase = false; // �ҹ��� �ʼ� X
                options.Password.RequireDigit = false; // ���� �ʼ� X
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();  // ASP.NEt Core Identity ����
            app.UseAuthorization();   // ����

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
