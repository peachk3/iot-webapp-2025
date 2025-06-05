using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;

namespace MyPortfolioWebApp.Models
{
    // IdentityUser는 Asp.NetCore.Identity에 위치하는 클래스
    // 회원가입시 추가로 받고 싶은 정보를 구성
    public class CustomUser : IdentityUser
    {
        public string? Mobile { get; set; } // 휴대폰 번호
        public string? City { get; set; } // 도시

        public string? Hobby { get; set; } // 취미
    }
}
