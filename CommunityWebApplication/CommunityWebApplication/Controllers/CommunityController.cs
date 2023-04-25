using CommunityWebApplication.Data;
using CommunityWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebApplication.Controllers
{
    [ApiController]
    [Route("api/community")]
    //[Route("api/[controller]")]
    public class CommunityController : Controller
    {

        private readonly CommunityAPIDbContext dbContext;

        public CommunityController(CommunityAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetCommunityMembers()
        {
            return Ok(await dbContext.CommunityTable.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetCommunityMember([FromRoute] Guid id)
        {
            var communityMember = await dbContext.CommunityTable.FindAsync(id);

            if (communityMember != null)
            {
                return Ok(communityMember);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostCommunityMembers(AddCommunityMemberRequest addCommunityMemberRequest)
        {
            var communityMember = new Community()
            {
                Id = Guid.NewGuid(),
                FullName = addCommunityMemberRequest.FullName,
                Email = addCommunityMemberRequest.Email,
                Phone = addCommunityMemberRequest.Phone,
                Address = addCommunityMemberRequest.Address,
            };

            await dbContext.CommunityTable.AddAsync(communityMember);
            await dbContext.SaveChangesAsync();

            return Ok(communityMember);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCommunityMember([FromRoute] Guid id, UpdateCommunityMemberRequest updateCommunityMemberRequest)
        {
            var communityMember = await dbContext.CommunityTable.FindAsync(id);

            if (communityMember  == null)
            {
                return NotFound();
            }

            communityMember.FullName = updateCommunityMemberRequest.FullName;
            communityMember.Email = updateCommunityMemberRequest.Email;
            communityMember.Phone = updateCommunityMemberRequest.Phone;
            communityMember.Address = updateCommunityMemberRequest.Address;

            await dbContext.SaveChangesAsync();
            return Ok(communityMember);
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DelteCommunityMember([FromRoute] Guid id)
        {
            var communityMember = await dbContext.CommunityTable.FindAsync(id);

            if (communityMember != null)
            {
                dbContext.CommunityTable.Remove(communityMember);
                await dbContext.SaveChangesAsync();

                return Ok(communityMember);
            }


            return NotFound();
        }
    }
}
