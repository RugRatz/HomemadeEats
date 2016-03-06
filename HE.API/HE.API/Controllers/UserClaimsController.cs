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
    public class UserClaimsController : ApiController
    {
        private HE_DbContext db = new HE_DbContext();

        // GET: api/UserClaims
        public IQueryable<UserClaim> GetIdentityUserClaims()
        {
            return db.IdentityUserClaims;
        }

        // GET: api/UserClaims/5
        [ResponseType(typeof(UserClaim))]
        public async Task<IHttpActionResult> GetUserClaim(int id)
        {
            UserClaim userClaim = await db.IdentityUserClaims.FindAsync(id);
            if (userClaim == null)
            {
                return NotFound();
            }

            return Ok(userClaim);
        }

        // PUT: api/UserClaims/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserClaim(int id, UserClaim userClaim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userClaim.Id)
            {
                return BadRequest();
            }

            db.Entry(userClaim).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserClaimExists(id))
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

        // POST: api/UserClaims
        [ResponseType(typeof(UserClaim))]
        public async Task<IHttpActionResult> PostUserClaim(UserClaim userClaim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IdentityUserClaims.Add(userClaim);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userClaim.Id }, userClaim);
        }

        // DELETE: api/UserClaims/5
        [ResponseType(typeof(UserClaim))]
        public async Task<IHttpActionResult> DeleteUserClaim(int id)
        {
            UserClaim userClaim = await db.IdentityUserClaims.FindAsync(id);
            if (userClaim == null)
            {
                return NotFound();
            }

            db.IdentityUserClaims.Remove(userClaim);
            await db.SaveChangesAsync();

            return Ok(userClaim);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserClaimExists(int id)
        {
            return db.IdentityUserClaims.Count(e => e.Id == id) > 0;
        }
    }
}