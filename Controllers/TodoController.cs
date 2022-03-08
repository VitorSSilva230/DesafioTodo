#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioTodo.Models;

namespace DesafioTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Todo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Todo.ToListAsync());
        }

        // GET: Todo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // GET: Todo/Create
        public IActionResult CreateOrUpdate(int Id = 0)
        {
            if (Id == 0)
            
                return View(new Todo());
            
            else
            
                return View(_context.Todo.Find(Id));
            
            
        }

        // POST: Todo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate([Bind("Id,Tasks,Done,CreateTask")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                if (todo.Id == 0)
                
                     _context.Add(todo);
                
                else
                
                _context.Update(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                 
            }
            return View(todo);
        }

    

        
        // GET: Todo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var todo = await _context.Todo.FindAsync(id);
            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
