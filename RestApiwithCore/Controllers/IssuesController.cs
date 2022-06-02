using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiwithCore.Data;
using RestApiwithCore.Models;

namespace RestApiwithCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly Issuedbcontext _Context;
        public IssuesController(Issuedbcontext issuedbContext)
        {
            _Context = issuedbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Issue>> GetIssues()
        
           => await _Context.issues.ToListAsync();
        
        [HttpGet("ID")]
        [ProducesResponseType(typeof(Issue),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Issue),StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIssueById(int id)
        {
            var issue = await _Context.issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(issue);
            }

        }

        [HttpPost]
        [ProducesResponseType(typeof(Issue),StatusCodes.Status201Created)]
        public async Task<IActionResult> PostIssue(Issue issue)
        {
            await _Context.issues.AddAsync(issue);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetIssueById),new { id=issue.ID}, issue);
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateIssue(int id,Issue issue)
        {
            if(id!=issue.ID)
            {
                return BadRequest();
            }
            _Context.Entry(issue).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return NoContent();
            

        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            var Issue = await _Context.issues.FindAsync(id);
            if(Issue==null)
            {
                return NotFound();
            }
            _Context.issues.Remove(Issue);
            await _Context.SaveChangesAsync();
            return Ok();
        }
           
    }
}
