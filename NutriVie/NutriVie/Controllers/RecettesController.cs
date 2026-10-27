
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriVie.Models;
using NutriVie.Models.Data;

public class RecettesController : Controller
{
    private readonly NutriVieDbContext _context;

    public RecettesController(NutriVieDbContext context)
    {
        _context = context;
    }

    // GET: RECETTESS
    public async Task<IActionResult> Index()    
    {
        // Ajouter .Include(=> r.categorie).ToListAsync()) pour afficher le nom de la catégorie
        return View(await _context.Recettes.Include(r => r.Categorie).ToListAsync());
    }

    // GET: RECETTESS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var recettes = await _context.Recettes.Include(c => c.Categorie)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (recettes == null)
        {
            return NotFound();
        }

        return View(recettes);
    }

    // GET: RECETTESS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RECETTESS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nom,Description,TempsPreparation,TempsCuisson,Image,CategorieId,Categorie")] Recettes recettes)
    {
        if (ModelState.IsValid)
        {
            _context.Add(recettes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(recettes);
    }

    // GET: RECETTESS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var recettes = await _context.Recettes.FindAsync(id);
        if (recettes == null)
        {
            return NotFound();
        }
        return View(recettes);
    }

    // POST: RECETTESS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nom,Description,TempsPreparation,TempsCuisson,Image,CategorieId,Categorie")] Recettes recettes)
    {
        if (id != recettes.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(recettes);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecettesExists(recettes.Id))
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
        return View(recettes);
    }

    // GET: RECETTESS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var recettes = await _context.Recettes.Include(s => s.Categorie)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (recettes == null)
        {
            return NotFound();
        }

        return View(recettes);
    }

    // POST: RECETTESS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var recettes = await _context.Recettes.FindAsync(id);
        if (recettes != null)
        {
            _context.Recettes.Remove(recettes);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RecettesExists(int? id)
    {
        return _context.Recettes.Any(e => e.Id == id);
    }
}
