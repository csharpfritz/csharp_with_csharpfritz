using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCollectionSite.Models;

namespace MyCollectionSite.Controllers
{
	public class CollectionItemsController : Controller
	{
		private readonly CollectionContext _context;
		private readonly IWebHostEnvironment Environment;

		public CollectionItemsController(CollectionContext context
		, IWebHostEnvironment environment)
		{
			_context = context;
			this.Environment = environment;
		}

		// GET: CollectionItems
		public async Task<IActionResult> Index()
		{
			return Redirect("/");
		}

		// GET: CollectionItems/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.CollectionItems == null)
			{
				return NotFound();
			}

			var collectionItem = await _context.CollectionItems
					.FirstOrDefaultAsync(m => m.Id == id);
			if (collectionItem == null)
			{
				return NotFound();
			}

			return View(collectionItem);
		}

		// GET: CollectionItems/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: CollectionItems/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(
		[Bind("Name,Description,Acquired")] 
			CollectionItem collectionItem,
			List<IFormFile> files)
		{
			if (ModelState.IsValid)
			{

				if ((files.FirstOrDefault()?.Length ?? 0) > 0)
				{
					var filePath = Path.Combine(this.Environment.WebRootPath, 
						"collectionImages", 
						collectionItem.Name + ".jpg");

					using (var stream = System.IO.File.Create(filePath))
					{
						await files.First().CopyToAsync(stream);
					}

					collectionItem.ImageURL = $"/collectionImages/{collectionItem.Name}.jpg";

				}

				_context.Add(collectionItem);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(collectionItem);
		}

		// GET: CollectionItems/Edit/5
		[Authorize(policy: "CanEdit")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.CollectionItems == null)
			{
				return NotFound();
			}

			var collectionItem = await _context.CollectionItems.FindAsync(id);
			if (collectionItem == null)
			{
				return NotFound();
			}
			return View(collectionItem);
		}

		// POST: CollectionItems/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageURL,Acquired,Votes")] CollectionItem collectionItem)
		{
			if (id != collectionItem.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(collectionItem);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CollectionItemExists(collectionItem.Id))
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
			return View(collectionItem);
		}

		// GET: CollectionItems/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.CollectionItems == null)
			{
				return NotFound();
			}

			var collectionItem = await _context.CollectionItems
					.FirstOrDefaultAsync(m => m.Id == id);
			if (collectionItem == null)
			{
				return NotFound();
			}

			return View(collectionItem);
		}

		// POST: CollectionItems/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.CollectionItems == null)
			{
				return Problem("Entity set 'CollectionContext.CollectionItems'  is null.");
			}
			var collectionItem = await _context.CollectionItems.FindAsync(id);
			if (collectionItem != null)
			{
				_context.CollectionItems.Remove(collectionItem);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CollectionItemExists(int id)
		{
			return (_context.CollectionItems?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
