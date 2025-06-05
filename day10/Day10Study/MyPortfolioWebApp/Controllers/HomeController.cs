using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using MyPortfolioWebApp.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace MyPortfolioWebApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context; // DB 연동

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            // DB에서 데이터를 불러온 뒤 About, Skill 객체에 데이터 담아서 뷰로 넘겨줌
            var skillCount = _context.Skill.Count();
            var skill = await _context.Skill.ToListAsync();

            // FristAsync()는 데이터가 없으면 예외 발생. FirstOrDefaultAsync 데이터가 없으면 ㄴ러값
            var about = await _context.About.FirstOrDefaultAsync(); 

            ViewBag.SkillCount = skillCount;
            ViewBag.colNum = (skillCount / 2) + (skillCount % 2); // 3( 7/2) + !(7%2)

            var model = new AboutModel();
            //model.About =  // 나중에
            model.About = about;
            model.Skill = skill;

            return View(model);
        }
        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Contact(ContactModel model)
        {
            if (ModelState.IsValid) // Model에 들어간 4개의 값이 제대로 들어갔으면
            {
                try
                {
                    var smtpClient = new SmtpClient("smtp.gmail.com") // Gmail을 사용하면
                    {
                        Port = 586, // 포트번호
                        Credentials = new NetworkCredential("doo062991@gmail.com", "비밀번호"),
                        EnableSsl = true,
                    };

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(model.Email),    // 문의하기에서 작성한 메일 주소
                        Subject = model.Subject ?? "[제목없음]",
                        Body = $"보낸사람 : {model.Name} ({model.Email})\n\n 메시지 : {model.Message}",
                        IsBodyHtml = false, // 메일 본문에 HTML 태그 사용 여부
                    };

                    mailMessage.To.Add("doo0629@naver.com"); // 받을 메일 주소

                    await smtpClient.SendMailAsync(mailMessage); // 위 생성된 메일 객체를 전송!
                    ViewBag.Success = true;
                }
                catch(Exception ex)
                {
                    ViewBag.Success = false;
                    ViewBag.Error = $"메일전송 실패! {ex.Message}";
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
