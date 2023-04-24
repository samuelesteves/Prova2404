using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova2404.Data;
using Prova2404.Models;

namespace Prova2404.Controllers
{
    [Authorize]
    public class AlunoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlunoController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool AlunoExits(int id)
        {
            return _context.alunos.Any(e => e.IdAluno == id);
        } 

        public async Task<IActionResult> Index()
        {
            return View(await _context.alunos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.alunos == null)
            {
                return NotFound();
            }
            var aluno = await _context.alunos
                .FirstOrDefaultAsync(m => m.IdAluno == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            if(ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.alunos == null)
            {
                return NotFound();
            }
            var aluno = await _context.alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Aluno aluno)
        {
            if(id != aluno.IdAluno)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!AlunoExits(aluno.IdAluno))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                    
                }
                return RedirectToAction("Index");
                
            }
            return View(aluno);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.alunos == null)
            {
                return NotFound();
            }
            var aluno = await _context.alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_context.alunos == null)
            {
                return Problem("'ApplicationDbContext.alunos' não encontrado");
            }
            var aluno = await _context.alunos.FindAsync(id);

            if (aluno != null)
            {
                _context.alunos.Remove(aluno);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
