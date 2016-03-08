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
    public class IngredientNotesController : ApiController
    {
        private HE_IdentityDbContext db = new HE_IdentityDbContext();

        // GET: api/IngredientNotes
        public IQueryable<IngredientNote> GetIngredientNotes()
        {
            return db.IngredientNotes;
        }

        // GET: api/IngredientNotes/5
        [ResponseType(typeof(IngredientNote))]
        public async Task<IHttpActionResult> GetIngredientNote(int id)
        {
            IngredientNote ingredientNote = await db.IngredientNotes.FindAsync(id);
            if (ingredientNote == null)
            {
                return NotFound();
            }

            return Ok(ingredientNote);
        }

        // PUT: api/IngredientNotes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIngredientNote(int id, IngredientNote ingredientNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredientNote.IngredientNoteID)
            {
                return BadRequest();
            }

            db.Entry(ingredientNote).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientNoteExists(id))
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

        // POST: api/IngredientNotes
        [ResponseType(typeof(IngredientNote))]
        public async Task<IHttpActionResult> PostIngredientNote(IngredientNote ingredientNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IngredientNotes.Add(ingredientNote);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ingredientNote.IngredientNoteID }, ingredientNote);
        }

        // DELETE: api/IngredientNotes/5
        [ResponseType(typeof(IngredientNote))]
        public async Task<IHttpActionResult> DeleteIngredientNote(int id)
        {
            IngredientNote ingredientNote = await db.IngredientNotes.FindAsync(id);
            if (ingredientNote == null)
            {
                return NotFound();
            }

            db.IngredientNotes.Remove(ingredientNote);
            await db.SaveChangesAsync();

            return Ok(ingredientNote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredientNoteExists(int id)
        {
            return db.IngredientNotes.Count(e => e.IngredientNoteID == id) > 0;
        }
    }
}