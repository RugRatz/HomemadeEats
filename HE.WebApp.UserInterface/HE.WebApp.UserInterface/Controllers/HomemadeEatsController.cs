using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HE.API.DbContexts;
using HE.API.Models;
using HE.WebApp.UserInterface.Models;
using System.IO;

namespace HE.WebApp.UserInterface.Controllers
{
    public class HomemadeEatsController : Controller
    {
        public async Task<MealTypesViewList> GetMealTypesList()
        {
            var mealTypesList = new MealTypesViewList();
            mealTypesList.MealTypesItemList = await WebApiService.Instance.GetMealTypesViewModelAsync("api/MealTypes");

            return mealTypesList;
        }

        // GET: HomemadeEats/Welcome
        public async Task<ActionResult> Welcome()
        {
            // In order to send data to the view file (cshtml file), 
            // you must send in the object that contains the data 
            // AND from within the cshtml file, add the statement to include the object you need to access like
            // @model HE.WebApp.UserInterface.Models.MealTypesViewList

            // Pass in the list to the view like so
            return View("Welcome", await GetMealTypesList());
        }

        public ActionResult CreateMealTypeModalDialog()
        {
            return View();
        }

        // GET: HomemadeEats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MealTypesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MealTypesViewModel mealTypesViewModel, HttpPostedFileBase uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {
                    mealTypesViewModel.ImageTitle = User.Identity.Name + "_" + Guid.NewGuid().ToString() + "_" + Path.GetFileName(uploadedFile.FileName);
                    mealTypesViewModel.ImageFilePath = "/Content/Images/Uploads/" + mealTypesViewModel.ImageTitle;
                    uploadedFile.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/Uploads"), mealTypesViewModel.ImageTitle));
                }

                mealTypesViewModel.IsSystemDefault = false;
                mealTypesViewModel.LastUpdatedUTC = DateTime.UtcNow;
                mealTypesViewModel.DateCreatedUTC = DateTime.UtcNow;

                var result = await WebApiService.Instance.PostAsync("api/MealTypes", mealTypesViewModel);

                // If API successfully inserted the new record, display the Welcome screen. 
                // Otherwise send the user back to the Create screen again
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Welcome", "HomemadeEats");
                }
                // return View("Create");   // seems redundant here?
            }
            return View("Create");
        }



        #region GET: MealTypesModels/Details/5
        //// GET: MealTypesModels/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MealTypesModel mealTypesModel = await db.MealTypesModels.FindAsync(id);
        //    if (mealTypesModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mealTypesModel);
        //}
        #endregion

        //// GET: MealTypesModels/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}




        #region GET: MealTypesModels/Edit/5
        //// GET: MealTypesModels/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MealTypesModel mealTypesModel = await db.MealTypesModels.FindAsync(id);
        //    if (mealTypesModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mealTypesModel);
        //}
        #endregion

        #region POST: MealTypesModels/Edit/5
        //// POST: MealTypesModels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "MealTypeID,Name,IsSystemDefault,DateCreatedUTC,LastUpdatedUTC")] MealTypesModel mealTypesModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(mealTypesModel).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(mealTypesModel);
        //}
        #endregion

        #region GET: MealTypesModels/Delete/5
        //// GET: MealTypesModels/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MealTypesModel mealTypesModel = await db.MealTypesModels.FindAsync(id);
        //    if (mealTypesModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mealTypesModel);
        //}
        #endregion

        #region POST: MealTypesModels/Delete/5
        //// POST: MealTypesModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    MealTypesModel mealTypesModel = await db.MealTypesModels.FindAsync(id);
        //    db.MealTypesModels.Remove(mealTypesModel);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
        #endregion

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
