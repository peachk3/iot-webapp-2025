using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebApp.Models;

namespace MyPortfolioWebApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            // 뷰 쪽에 보내고 싶은 데이터
            //ViewData["Key"]
            //ViewBag.Title =
            //TempData["Key"]
            ViewData["Title"] = "타이틀 변경!!";
            // _context News SELECT * FROM News;
            return View(await _context.News.OrderByDescending(o => o.PostDate).ToListAsync()); // -
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // SELECT * FROM News WHERE Id = id;
            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            // 조회수 증가 로직
            news.ReadCount += 1; // 조회수 증가
            _context.News.Update(news);
            await _context.SaveChangesAsync();

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            var news = new News
            {
                Writer = "관리자",
                PostDate = DateTime.Now,
                ReadCount = 0
            };
            return View(news);
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] News news)
        {
            if (ModelState.IsValid)
            {
                news.Writer = "관리자"; // 작성자는 자동으로 관리자
                news.PostDate = DateTime.Now; // 게시일자는 현재
                news.ReadCount = 0;

                // INSERT INTO...
                _context.Add(news);
                // COMMIT
                await _context.SaveChangesAsync();

                TempData["success"] = "뉴스 등록 성공!";

                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // 방식 2 - 원본을 찾아서 수정해주는 방식
                    var existingNews = await _context.News.FindAsync(id);
                    if (existingNews == null)
                    {
                        return NotFound();
                    }

                    existingNews.Title = news.Title;
                    existingNews.Description = news.Description;  

                    // UPDATE News SET ...
                    //_context.Update(news); // 방식 1 - ID가 같은 새 글을 update하면 수정
                    // COMMIT
                    await _context.SaveChangesAsync();
                    TempData["success"] = "뉴스 수정 성공!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                // DELETE FROM News WHERE Id = @id;
                _context.News.Remove(news);
            }
            // COMMIT
            await _context.SaveChangesAsync();
            TempData["success"] = "뉴스 삭제 성공!";
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
