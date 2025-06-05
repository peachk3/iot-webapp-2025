using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebApp.Models;
using System.Reflection.Metadata.Ecma335;

namespace MyPortfolioWebApp.Controllers
{
    public class AccountController : Controller
    {
        // ASP.NET Core Identity 필요한 변수
        private readonly UserManager<CustomUser> userManager;
        private readonly SignInManager<CustomUser> signInManager;

        // 생성자
        public AccountController(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            // userManage나 signInManager가 null값이 들어오면 안됨
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        // NewsController GET Create(), POST Create()와 동일하게 생각
        [HttpGet] // [HttpGet]가 default. 생략 가능
        public IActionResult Register()
        {
            return View(); // Register.cshtml을 렌더링
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Id를 이메일로 사용하겠다
                var user = new CustomUser { 
                    UserName = model.Email, 
                    Email = model.Email, 
                    City = model.City, 
                    Mobile =  model.Mobile, 
                    Hobby = model.Hobby, 
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // 위의 저장한 유저로 로그인, isPersistent 로그인 상태 유지. false하면 20~30분 동안 사용 안하면 로그아웃
                    await signInManager.SignInAsync(user, isPersistent: false); // 로그인
                    return RedirectToAction("Index", "Home"); // 첫 화면으로 이동
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description); // 에러 메시지 추가
                }

            }
            return View(model); // 회원가입 오류 시 다시 회원가입 페이지로 이동
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Login.cshtml을 렌더링
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); // 로그인 성공 시 첫 화면으로 이동
                }
                ModelState.AddModelError("", "로그인 실패. 이메일이나 비밀번호를 확인하세요.");
            }
            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync(); // 로그아웃
            return RedirectToAction("Index", "Home"); // 첫 화면으로 이동
        }
    }
}