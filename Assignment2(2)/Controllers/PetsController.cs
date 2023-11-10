using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2_2_.Data;
using Assignment2_2_.Models;
using Assignment2_2_.ViewModels;
using PagedList;

namespace Assignment2_2_.Controllers
{
    public class PetsController : Controller
    {
        private Assignment2_2_Context db = new Assignment2_2_Context();

        // GET: Pets
        public ActionResult Index(string category, string search,int? page)
        {
            PetIndexViewModel viewModel = new PetIndexViewModel();
            var pets = db.Pets.Include(p => p.Category);
            if (!String.IsNullOrEmpty(search))
            {
                pets = pets.Where(p => p.Name.Contains(search) ||
                p.Lifetime.Contains(search) ||
                p.Price.Contains(search) ||
                p.Category.Name.Contains(search));
                viewModel.Search = search;
            }
            viewModel.CatsWithCount = from matchingPets in pets
                                      where
                                      matchingPets.CategoryID != null
                                      group matchingPets by
                                      matchingPets.Category.Name into
                                      catGroup
                                      select new CategoryWithCount()
                                      {
                                          CategoryName = catGroup.Key,
                                          PetCount = catGroup.Count()
                                      };
            if (!String.IsNullOrEmpty(category))
            {
                pets = pets.Where(p => p.Category.Name == category);
                viewModel.Category = category;
            }
            pets = pets.OrderBy(p => p.Name);
            const int PageItems = 4;
            int currentPage = (page ?? 1);
            viewModel.Pets = pets.ToPagedList(currentPage, PageItems);
            return View(viewModel);
        }

        // GET: Pets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Pets/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,Lifetime,CategoryID")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", pet.CategoryID);
            return View(pet);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", pet.CategoryID);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,Lifetime,CategoryID")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", pet.CategoryID);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
