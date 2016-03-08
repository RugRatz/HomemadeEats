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
    public class HomemadeItemsController : ApiController
    {
        private HE_IdentityDbContext db = new HE_IdentityDbContext();

        // GET: api/HomemadeItems
        public IQueryable<HomemadeItem> GetHomemadeItems()
        {
            return db.HomemadeItems;
        }

        // GET: api/HomemadeItems/5
        [ResponseType(typeof(HomemadeItem))]
        public async Task<IHttpActionResult> GetHomemadeItem(int id)
        {
            HomemadeItem homemadeItem = await db.HomemadeItems.FindAsync(id);
            if (homemadeItem == null)
            {
                return NotFound();
            }

            return Ok(homemadeItem);
        }

        // PUT: api/HomemadeItems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHomemadeItem(int id, HomemadeItem homemadeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != homemadeItem.HomemadeItemID)
            {
                return BadRequest();
            }

            db.Entry(homemadeItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomemadeItemExists(id))
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

        // POST: api/HomemadeItems
        [ResponseType(typeof(HomemadeItem))]
        public async Task<IHttpActionResult> PostHomemadeItem(HomemadeItem homemadeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HomemadeItems.Add(homemadeItem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = homemadeItem.HomemadeItemID }, homemadeItem);
        }

        // DELETE: api/HomemadeItems/5
        [ResponseType(typeof(HomemadeItem))]
        public async Task<IHttpActionResult> DeleteHomemadeItem(int id)
        {
            HomemadeItem homemadeItem = await db.HomemadeItems.FindAsync(id);
            if (homemadeItem == null)
            {
                return NotFound();
            }

            db.HomemadeItems.Remove(homemadeItem);
            await db.SaveChangesAsync();

            return Ok(homemadeItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HomemadeItemExists(int id)
        {
            return db.HomemadeItems.Count(e => e.HomemadeItemID == id) > 0;
        }
    }
}