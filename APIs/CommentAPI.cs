using Microsoft.AspNetCore.Mvc;
using OfficialProject3.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficialProject3.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CommentAPI(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CommentAPI>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CommentAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommentAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CommentAPI>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value, ApplicationDbContext _context)
        {
            var comment = _context.Comment.Where(c => c.Id == id.ToString()).FirstOrDefault();
            if (comment == null)
            {
                return;
            }
            if (value == "upvote") comment.Upvote++;
            if (value == "downvote") comment.Downvote++;
        }

        // PATCH api/<CommentAPI>/5
        [HttpPatch("{id}")]
        public void Patch(Guid id, [FromBody] string value)
        {
            var comment = _context.Comment.Where(c => c.Id == id.ToString()).FirstOrDefault();
            if (comment == null)
            {
                return;
            }
            if (value == "upvote") comment.Upvote++;
            if (value == "downvote") comment.Downvote++;
        }

        // DELETE api/<CommentAPI>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var comment = _context.Comment.Where(c => c.Id == id.ToString()).FirstOrDefault();
            if (comment == null) return;
            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
