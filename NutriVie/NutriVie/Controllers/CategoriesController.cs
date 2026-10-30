
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using NutriVie.Models;
using NutriVie.Models.Data;

public class CategoriesController : Controller
{
    private readonly NutriVieDbContext _context;

    public CategoriesController(NutriVieDbContext context)
    {
        _context = context;
    }

    // GET: CATEGORIES
    public async Task<IActionResult> Index()    
    {

        //return View(await _context.Categorie.OrderByDescending(c => c.Nom).ToListAsync());
        var categories = await _context.Categorie
       .OrderByDescending(c => c.Nom)
       .Include(c => c.Recettes.OrderBy(r => r.Nom))
       .ToListAsync();

        return View(categories);


    }

    // GET: CATEGORIES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categorie = await _context.Categorie
            .FirstOrDefaultAsync(m => m.Id == id);
        if (categorie == null)
        {
            return NotFound();
        }

        return View(categorie);
    }

    // GET: CATEGORIES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CATEGORIES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nom,Recettes")] Categorie categorie)
    {
       
        if (ModelState.IsValid)
        {
            // 1. Vérifier si une catégorie avec le même nom existe déjà (sans tenir compte de la casse)
            bool categorieExite = await _context.Categorie
            .AnyAsync(c => c.Nom.ToLower() == categorie.Nom.ToLower());

            if (categorieExite)
            {
                // 2. Ajouter le message d'erreur ciblé sur le champ "Nom"
                ModelState.AddModelError("Nom", "Cette catégorie exite déjà.");

                // Retourner la vue avec le modèle pour afficher l'erreur
                return View(categorie);
            }

            // 3. Si elle n'existe pas, procéder à l'ajout
            _context.Add(categorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(categorie);
    }

    // GET: CATEGORIES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categorie = await _context.Categorie.FindAsync(id);
        if (categorie == null)
        {
            return NotFound();
        }
        return View(categorie);
    }

    // POST: CATEGORIES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nom,Recettes")] Categorie categorie)
    {
        if (id != categorie.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(categorie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(categorie.Id))
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
        return View(categorie);
    }

    // GET: CATEGORIES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categorie = await _context.Categorie
            .FirstOrDefaultAsync(m => m.Id == id);
        if (categorie == null)
        {
            return NotFound();
        }

        return View(categorie);
    }

    // POST: CATEGORIES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        // 1. Récupérer la catégorie avec ses recettes incluses
        var categorie = await _context.Categorie
            .Include(c => c.Recettes)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (categorie != null && categorie.Recettes.Any())
        {
            ModelState.AddModelError(string.Empty, "Vous ne pouvez supprimer cette catégorie parce qu'elle contient des recettes");
            return View(categorie);
            
        }

        _context.Categorie.Remove(categorie);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CategorieExists(int? id)
    {
        return _context.Categorie.Any(e => e.Id == id);
    }
}
