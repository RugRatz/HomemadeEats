using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HE.Domain;
using HE.API.DbContexts;

namespace HE.API.Controllers
{
    public class GroceriesController : ApiController
    {
        private HE_IdentityDbContext db = new HE_IdentityDbContext();

        // GET: api/Groceries
        public IQueryable<Grocery> GetGroceries()
        {
            return db.Groceries;
        }

        // GET: api/Groceries/5
        [ResponseType(typeof(Grocery))]
        public async Task<IHttpActionResult> GetGrocery(int id)
        {
            Grocery grocery = await db.Groceries.FindAsync(id);
            if (grocery == null)
            {
                return NotFound();
            }

            return Ok(grocery);
        }

        // PUT: api/Groceries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGrocery(int id, Grocery grocery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grocery.GroceryID)
            {
                return BadRequest();
            }

            db.Entry(grocery).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryExists(id))
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

        // POST: api/Groceries
        [ResponseType(typeof(Grocery))]
        public async Task<IHttpActionResult> PostGrocery(Grocery grocery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Groceries.Add(grocery);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = grocery.GroceryID }, grocery);
        }

        // DELETE: api/Groceries/5
        [ResponseType(typeof(Grocery))]
        public async Task<IHttpActionResult> DeleteGrocery(int id)
        {
            Grocery grocery = await db.Groceries.FindAsync(id);
            if (grocery == null)
            {
                return NotFound();
            }

            db.Groceries.Remove(grocery);
            await db.SaveChangesAsync();

            return Ok(grocery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroceryExists(int id)
        {
            return db.Groceries.Count(e => e.GroceryID == id) > 0;
        }
    }
}