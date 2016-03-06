using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HE.DataAccess;

namespace HE.API.Controllers
{
    public class IngredientCategoriesController : ApiController
    {
        private HE_DbContext db = new HE_DbContext();

        // GET: api/IngredientCategories
        public IQueryable<IngredientCategory> GetIngredientCategories()
        {
            return db.IngredientCategories;
        }

        // GET: api/IngredientCategories/5
        [ResponseType(typeof(IngredientCategory))]
        public async Task<IHttpActionResult> GetIngredientCategory(int id)
        {
            IngredientCategory ingredientCategory = await db.IngredientCategories.FindAsync(id);
            if (ingredientCategory == null)
            {
                return NotFound();
            }

            return Ok(ingredientCategory);
        }

        // PUT: api/IngredientCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIngredientCategory(int id, IngredientCategory ingredientCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredientCategory.IngredientCategoryID)
            {
                return BadRequest();
            }

            db.Entry(ingredientCategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/IngredientCategories
        [ResponseType(typeof(IngredientCategory))]
        public async Task<IHttpActionResult> PostIngredientCategory(IngredientCategory ingredientCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IngredientCategories.Add(ingredientCategory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ingredientCategory.IngredientCategoryID }, ingredientCategory);
        }

        // DELETE: api/IngredientCategories/5
        [ResponseType(typeof(IngredientCategory))]
        public async Task<IHttpActionResult> DeleteIngredientCategory(int id)
        {
            IngredientCategory ingredientCategory = await db.IngredientCategories.FindAsync(id);
            if (ingredientCategory == null)
            {
                return NotFound();
            }

            db.IngredientCategories.Remove(ingredientCategory);
            await db.SaveChangesAsync();

            return Ok(ingredientCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredientCategoryExists(int id)
        {
            return db.IngredientCategories.Count(e => e.IngredientCategoryID == id) > 0;
        }
    }
}