using CommunityWebApplicationPractice.Data;
using CommunityWebApplicationPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebApplicationPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private readonly CommunityAPIDbContext dbContext;

        public CommunityController(CommunityAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommunityMembers() {
            return Ok(await dbContext.CommunityTable.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCommunityMember([FromRoute] Guid id)
        {
            var communityMember = await dbContext.CommunityTable.FindAsync(id);
            
            if (communityMember == null)
            {
                return NotFound();
            }
            return Ok(communityMember);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCommunityMember([FromRoute] Guid id, UpdateSelectedMemberNameRequest updateSelectedMemberNameRequest)
        {
            var communityMember = await dbContext.CommunityTable.FindAsync(id);

            if (communityMember == null)
            {
                return NotFound();
            }

            communityMember.FullName = updateSelectedMemberNameRequest.FullName;

            await dbContext.SaveChangesAsync();

            return Ok(communityMember);
        }

    }
}
