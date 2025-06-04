using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebApp.Models;
using System.Diagnostics;

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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
