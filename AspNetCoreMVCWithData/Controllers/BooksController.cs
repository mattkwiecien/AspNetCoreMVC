using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMVCWithData.Data;
using AspNetCoreMVCWithData.Models;

namespace AspNetCoreMVCWithData.Controllers {
	public class BooksController : Controller {

		private readonly AspNetCoreMVCWithDataContext _context;

		public BooksController(AspNetCoreMVCWithDataContext context) {
			_context = context;
		}

		// GET: Books
		public async Task<IActionResult> Index() {
			return View(await _context.Book.ToListAsync());
		}

		// GET: Books/Details/5
		public async Task<IActionResult> Details(int? id) {
			if (id == null) {
				return NotFound();
			}

			var book = await _context.Book
				.FirstOrDefaultAsync(m => m.Id == id);
			if (book == null) {
				return NotFound();
			}

			return View(book);
		}

		// GET: Books/Edit/5
		public async Task<IActionResult> Edit(int? id) {
			if (id == null) {
				return NotFound();
			}

			var book = await _context.Book.FindAsync(id);
			if (book == null) {
				return NotFound();
			}
			return View(book);
		}

		// POST: Books/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Price,PublishDate")] Book book) {
			if (id != book.Id) {
				return NotFound();
			}

			if (ModelState.IsValid) {
				try {
					_context.Update(book);
					await _context.SaveChangesAsync();
				} catch (DbUpdateConcurrencyException) {
					if (!BookExists(book.Id)) {
						return NotFound();
					} else {
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(book);
		}

		private bool BookExists(int id) {
			return _context.Book.Any(e => e.Id == id);
		}
	}
}
