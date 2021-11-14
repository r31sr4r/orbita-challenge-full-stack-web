using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkPaginateCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using orbita_challenge_full_stack_web.Models;
using orbita_challenge_full_stack_web.Service;

namespace orbita_challenge_full_stack_web.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private const int PAGE_SIZE = 3;
        private readonly DB_Context _context;

        public StudentController(DB_Context context)
        {
            _context = context;
        }

        // GET: student
        [HttpGet]
        [Route("/Student")]
        public async Task<IActionResult> Index(int page = 1)
        {
            return StatusCode(200, await _context.Students
                .OrderBy(a => a.Id)
                .PaginateAsync(page, PAGE_SIZE));
            //return View(await _context.Students.ToListAsync());
        }

        // GET: student/details/5
        [HttpGet]
        [Route("/Student/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return StatusCode(200, student);
        }

        // POST: /student
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("/student")]
        public async Task<IActionResult> Create([Bind("Id,Name,CPF,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return StatusCode(201, student);
            }
            return StatusCode(201, student);
        }

        // PUT: student/5        
        [HttpPut]
        [Route("/student/{id}")]        
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CPF,Email")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, student);
            }
            return StatusCode(200, student);
        }


        // DELETE: student/5
        [HttpDelete]
        [Route("/student/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
