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
    public class GroceryGroupIngredientsController : ApiController
    {
        private HE_DbContext db = new HE_DbContext();

        // GET: api/GroceryGroupIngredients
        public IQueryable<GroceryGroupIngredient> GetGroceryGroupIngredients()
        {
            return db.GroceryGroupIngredients;
        }

        // GET: api/GroceryGroupIngredients/5
        [ResponseType(typeof(GroceryGroupIngredient))]
        public async Task<IHttpActionResult> GetGroceryGroupIngredient(int id)
        {
            GroceryGroupIngredient groceryGroupIngredient = await db.GroceryGroupIngredients.FindAsync(id);
            if (groceryGroupIngredient == null)
            {
                return NotFound();
            }

            return Ok(groceryGroupIngredient);
        }

        // PUT: api/GroceryGroupIngredients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGroceryGroupIngredient(int id, GroceryGroupIngredient groceryGroupIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groceryGroupIngredient.GroceryGroupIngredientID)
            {
                return BadRequest();
            }

            db.Entry(groceryGroupIngredient).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryGroupIngredientExists(id))
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

        // POST: api/GroceryGroupIngredients
        [ResponseType(typeof(GroceryGroupIngredient))]
        public async Task<IHttpActionResult> PostGroceryGroupIngredient(GroceryGroupIngredient groceryGroupIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroceryGroupIngredients.Add(groceryGroupIngredient);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = groceryGroupIngredient.GroceryGroupIngredientID }, groceryGroupIngredient);
        }

        // DELETE: api/GroceryGroupIngredients/5
        [ResponseType(typeof(GroceryGroupIngredient))]
        public async Task<IHttpActionResult> DeleteGroceryGroupIngredient(int id)
        {
            GroceryGroupIngredient groceryGroupIngredient = await db.GroceryGroupIngredients.FindAsync(id);
            if (groceryGroupIngredient == null)
            {
                return NotFound();
            }

            db.GroceryGroupIngredients.Remove(groceryGroupIngredient);
            await db.SaveChangesAsync();

            return Ok(groceryGroupIngredient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroceryGroupIngredientExists(int id)
        {
            return db.GroceryGroupIngredients.Count(e => e.GroceryGroupIngredientID == id) > 0;
        }
    }
}