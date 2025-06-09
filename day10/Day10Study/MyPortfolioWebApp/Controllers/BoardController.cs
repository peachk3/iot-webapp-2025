using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebApp.Models;

namespace MyPortfolioWebApp.Controllers
{
    public class BoardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Board
        public async Task<IActionResult> Index(int page = 1, string search = "")
        {
            //ViewBag.Search = search; // 검색어
            ViewData["Title"] = "자유 게시판"; // 페이지 제목 설정

            var totalCount = _context.Board.Where(n => EF.Functions.Like(n.Title, $"%{search}%")).Count();
            var countList = 10; // 한 페이지에 나타낼 기본 10개
            var totalPage = totalCount / countList; // 전체 페이지 수
            if (totalCount % countList > 0) totalPage++;
            if (totalPage < page) page = totalPage;

            // 마지막 페이지 구하기
            var countPage = 10; // 페이지를 표시할 최대 페이지 개수, 10개 
            var startPage = ((page - 1) / countPage) * countPage + 1;
            var endPage = startPage + countPage - 1;
            if (totalPage < endPage) endPage = totalPage;
            // 나타낼 페이지 수가 10이 안 되면 페이지 수 조정
            // 마지막 페이지까지 글이 12개이면 1, 2 패지키만 표시

            // 저장 프로시저에 보낼 rowNum값, 시작번호랑 끝번호
            var startCount = ((page - 1) * countPage) + 1; // 2페이지의 경우 11
            var endCount = startCount + countList - 1; // 2페이지의 경우 20

            // View로 넘기는 데이터, 페이징 숫자 컨트롤 사용
            ViewBag.StartPage = startPage; // 시작 페이지
            ViewBag.EndPage = endPage; // 끝 페이지
            ViewBag.Page = page; // 현재 페이지
            ViewBag.TotalPAge = totalPage;
            ViewBag.Search = search; // 검색어

            var boards = await _context.Board.FromSql($"CALL NEW_PagingFreeBoard({startCount}, {endCount}, {search})").ToListAsync();
            return View(boards);
        }

        // GET: Board/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }

            // 조회수 증가 로직
            board.ReadCount += 1; // 조회수 증가
            _context.Board.Update(board);
            await _context.SaveChangesAsync();
            
            return View(board);
        }

        // GET: Board/Create
        public IActionResult Create()
        {
            var board = new Board
            {
                PostDate = DateTime.Now, // 현재 날짜로 설정
                ReadCount = 0 // 조회수 초기화
            };
            return View(board);
        }

        // POST: Board/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Writer,Title,Contents,PostDate,ReadCount")] Board board)
        {
            if (ModelState.IsValid)
            {
                board.PostDate = DateTime.Now; // 현재 날짜로 설정
                board.ReadCount = 0; // 조회수 초기화

                _context.Add(board);
                
                await _context.SaveChangesAsync();
                
                TempData["success"] = "게시판 등록 성공!";

                return RedirectToAction(nameof(Index));
            }
            return View(board);
        }

        // GET: Board/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Board.FindAsync(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        // POST: Board/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Writer,Title,Contents")] Board board)
        {
            if (id != board.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // 방식 2 - 원본을 찾아서 수정해주는 방식
                    var existingBoards = await _context.Board.FindAsync(id);
                    if (existingBoards == null)
                    {
                        return NotFound();
                    }

                    existingBoards.Title = board.Title;
                    existingBoards.Contents = board.Contents;

                    //_context.Update(board);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardExists(board.Id))
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
            return View(board);
        }

        // GET: Board/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        // POST: Board/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var board = await _context.Board.FindAsync(id);
            if (board != null)
            {
                _context.Board.Remove(board);
            }

            await _context.SaveChangesAsync();
            TempData["success"] = "게시판 글 삭제 성공!";
            return RedirectToAction(nameof(Index));
        }

        private bool BoardExists(int id)
        {
            return _context.Board.Any(e => e.Id == id);
        }
    }
}
