using System.Linq;
using System.Web.Http;
using HE.DataAccess;

namespace HE.API.Controllers
{
    public class CustomerProfilesController : ApiController
    {
        private HE_DbContext db = new HE_DbContext();

        // GET: api/CustomerProfiles
        public IQueryable<CustomerProfile> GetCustomerProfiles()
        {
            return db.Users;
                //db.CustomerProfiles;
        }

        // GET: api/CustomerProfiles/5
        //[ResponseType(typeof(CustomerProfile))]
        //public async Task<IHttpActionResult> GetCustomerProfile(string id)
        //{
        //    //Need to figure out how to implement the FindAsync method for IdentityUser
        //    //db.
        //    //CustomerProfile customerProfile = await db.Users.FindAsync(id);
        //    //CustomerProfile customerProfile = db.Users.f
        //    if (customerProfile == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(customerProfile);
        //}
        
        // PUT: api/CustomerProfiles/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutCustomerProfile(string id, CustomerProfile customerProfile)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != customerProfile.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(customerProfile).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerProfileExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/CustomerProfiles
        //[ResponseType(typeof(CustomerProfile))]
        //public async Task<IHttpActionResult> PostCustomerProfile(CustomerProfile customerProfile)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Users.Add(customerProfile);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (CustomerProfileExists(customerProfile.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = customerProfile.Id }, customerProfile);
        //}

        // DELETE: api/CustomerProfiles/5
        //[ResponseType(typeof(CustomerProfile))]
        //public async Task<IHttpActionResult> DeleteCustomerProfile(string id)
        //{
        //    CustomerProfile customerProfile = await db.Users.FindAsync(id);
        //    if (customerProfile == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(customerProfile);
        //    await db.SaveChangesAsync();

        //    return Ok(customerProfile);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerProfileExists(string id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}