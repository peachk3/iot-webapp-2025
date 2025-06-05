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
        private readonly ApplicationDbContext _context; // DB ����

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
            // DB���� �����͸� �ҷ��� �� About, Skill ��ü�� ������ ��Ƽ� ��� �Ѱ���
            var skillCount = _context.Skill.Count();
            var skill = await _context.Skill.ToListAsync();

            // FristAsync()�� �����Ͱ� ������ ���� �߻�. FirstOrDefaultAsync �����Ͱ� ������ ������
            var about = await _context.About.FirstOrDefaultAsync(); 

            ViewBag.SkillCount = skillCount;
            ViewBag.colNum = (skillCount / 2) + (skillCount % 2); // 3( 7/2) + !(7%2)

            var model = new AboutModel();
            //model.About =  // ���߿�
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
            if (ModelState.IsValid) // Model�� �� 4���� ���� ����� ������
            {
                try
                {
                    var smtpClient = new SmtpClient("smtp.gmail.com") // Gmail�� ����ϸ�
                    {
                        Port = 586, // ��Ʈ��ȣ
                        Credentials = new NetworkCredential("doo062991@gmail.com", "��й�ȣ"),
                        EnableSsl = true,
                    };

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(model.Email),    // �����ϱ⿡�� �ۼ��� ���� �ּ�
                        Subject = model.Subject ?? "[�������]",
                        Body = $"������� : {model.Name} ({model.Email})\n\n �޽��� : {model.Message}",
                        IsBodyHtml = false, // ���� ������ HTML �±� ��� ����
                    };

                    mailMessage.To.Add("doo0629@naver.com"); // ���� ���� �ּ�

                    await smtpClient.SendMailAsync(mailMessage); // �� ������ ���� ��ü�� ����!
                    ViewBag.Success = true;
                }
                catch(Exception ex)
                {
                    ViewBag.Success = false;
                    ViewBag.Error = $"�������� ����! {ex.Message}";
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
