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

            // 최대파일 용량 제한
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
            // DB 연결 초기화
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
                builder.Configuration.GetConnectionString("SmartHomeConnection"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SmartHomeConnection"))
            ));

            // ASP.NET Core Identity 설정
            // 원본은 IdentityUser -> CustomUser로 변경
            builder.Services.AddIdentity<CustomUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            // 패스워드 정책
            // 변경 전. 최대 6자리 이상, 특수문자 1개 포함, 영어대소문자 포함
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // 이런 암호 간단화는 하지 말아야 함! 보안 취약!!
                options.Password.RequiredLength = 4; // 최소 길이
                options.Password.RequireNonAlphanumeric = false; // 특수문자 필수 X
                options.Password.RequireUppercase = false; // 대문자 필수 X
                options.Password.RequireLowercase = false; // 소문자 필수 X
                options.Password.RequireDigit = false; // 숫자 필수 X
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();  // ASP.NEt Core Identity 계정
            app.UseAuthorization();   // 권한

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
