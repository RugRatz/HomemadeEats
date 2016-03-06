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
    public class CustomerLoginsController : ApiController
    {
        private HE_DbContext db = new HE_DbContext();

        // GET: api/CustomerLogins
        public IQueryable<CustomerLogin> GetIdentityUserLogins()
        {
            return db.IdentityUserLogins;
        }

        // GET: api/CustomerLogins/5
        [ResponseType(typeof(CustomerLogin))]
        public async Task<IHttpActionResult> GetCustomerLogin(string id)
        {
            CustomerLogin customerLogin = await db.IdentityUserLogins.FindAsync(id);
            if (customerLogin == null)
            {
                return NotFound();
            }

            return Ok(customerLogin);
        }

        // PUT: api/CustomerLogins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerLogin(string id, CustomerLogin customerLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerLogin.LoginProvider)
            {
                return BadRequest();
            }

            db.Entry(customerLogin).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerLoginExists(id))
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

        // POST: api/CustomerLogins
        [ResponseType(typeof(CustomerLogin))]
        public async Task<IHttpActionResult> PostCustomerLogin(CustomerLogin customerLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IdentityUserLogins.Add(customerLogin);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerLoginExists(customerLogin.LoginProvider))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = customerLogin.LoginProvider }, customerLogin);
        }

        // DELETE: api/CustomerLogins/5
        [ResponseType(typeof(CustomerLogin))]
        public async Task<IHttpActionResult> DeleteCustomerLogin(string id)
        {
            CustomerLogin customerLogin = await db.IdentityUserLogins.FindAsync(id);
            if (customerLogin == null)
            {
                return NotFound();
            }

            db.IdentityUserLogins.Remove(customerLogin);
            await db.SaveChangesAsync();

            return Ok(customerLogin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerLoginExists(string id)
        {
            return db.IdentityUserLogins.Count(e => e.LoginProvider == id) > 0;
        }
    }
}