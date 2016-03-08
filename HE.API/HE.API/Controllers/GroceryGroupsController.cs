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
    public class GroceryGroupsController : ApiController
    {
        private HE_DbContext db = new HE_DbContext();

        // GET: api/GroceryGroups
        public IQueryable<GroceryGroup> GetGroceryGroups()
        {
            return db.GroceryGroups;
        }

        // GET: api/GroceryGroups/5
        [ResponseType(typeof(GroceryGroup))]
        public async Task<IHttpActionResult> GetGroceryGroup(int id)
        {
            GroceryGroup groceryGroup = await db.GroceryGroups.FindAsync(id);
            if (groceryGroup == null)
            {
                return NotFound();
            }

            return Ok(groceryGroup);
        }

        // PUT: api/GroceryGroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGroceryGroup(int id, GroceryGroup groceryGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groceryGroup.GroceryGroupID)
            {
                return BadRequest();
            }

            db.Entry(groceryGroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryGroupExists(id))
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

        // POST: api/GroceryGroups
        [ResponseType(typeof(GroceryGroup))]
        public async Task<IHttpActionResult> PostGroceryGroup(GroceryGroup groceryGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroceryGroups.Add(groceryGroup);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = groceryGroup.GroceryGroupID }, groceryGroup);
        }

        // DELETE: api/GroceryGroups/5
        [ResponseType(typeof(GroceryGroup))]
        public async Task<IHttpActionResult> DeleteGroceryGroup(int id)
        {
            GroceryGroup groceryGroup = await db.GroceryGroups.FindAsync(id);
            if (groceryGroup == null)
            {
                return NotFound();
            }

            db.GroceryGroups.Remove(groceryGroup);
            await db.SaveChangesAsync();

            return Ok(groceryGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroceryGroupExists(int id)
        {
            return db.GroceryGroups.Count(e => e.GroceryGroupID == id) > 0;
        }
    }
}