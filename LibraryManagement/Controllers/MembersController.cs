using LibraryManagement.DTOs.Members;
using LibraryManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,Librarian,Staff")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _memberService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Administrator,Librarian,Staff")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _memberService.GetByIdAsync(id);

            if (member == null)
            {
                return NotFound(new
                {
                    message = "Member not found."
                });
            }

            return Ok(member);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Librarian,Staff")]
        public async Task<IActionResult> Create(CreateMemberDto dto)
        {
            var result = await _memberService.CreateAsync(dto);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    message = result.Error
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Member!.Id },
                result.Member);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator,Librarian,Staff")]
        public async Task<IActionResult> Update(
            int id,
            UpdateMemberDto dto)
        {
            var result = await _memberService.UpdateAsync(id, dto);

            if (!result.Success)
            {
                if (result.Error == "Member not found.")
                {
                    return NotFound(new
                    {
                        message = result.Error
                    });
                }

                return BadRequest(new
                {
                    message = result.Error
                });
            }

            return Ok(new
            {
                message = "Member updated successfully."
            });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator,Librarian")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _memberService.DeleteAsync(id);

            if (!result.Success)
            {
                if (result.Error == "Member not found.")
                {
                    return NotFound(new
                    {
                        message = result.Error
                    });
                }

                return BadRequest(new
                {
                    message = result.Error
                });
            }

            return Ok(new
            {
                message = "Member deactivated successfully."
            });
        }
    }
}
