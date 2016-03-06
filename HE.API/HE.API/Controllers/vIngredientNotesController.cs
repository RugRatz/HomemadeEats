using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HE.DataAccess;

namespace HE.API.Controllers
{
    public class vIngredientNotesController : ApiController
    {
        private HE_DbContext db = new HE_DbContext();

        // GET: api/vIngredientNotes
        public IQueryable<vIngredientNote> GetvIngredientNotes()
        {
            return db.vIngredientNotes;
        }

        // GET: api/vIngredientNotes/5
        [ResponseType(typeof(vIngredientNote))]
        public async Task<IHttpActionResult> GetvIngredientNote(int id)
        {
            vIngredientNote vIngredientNote = await db.vIngredientNotes.FindAsync(id);
            if (vIngredientNote == null)
            {
                return NotFound();
            }

            return Ok(vIngredientNote);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vIngredientNoteExists(int id)
        {
            return db.vIngredientNotes.Count(e => e.IngredientNoteID == id) > 0;
        }
    }
}