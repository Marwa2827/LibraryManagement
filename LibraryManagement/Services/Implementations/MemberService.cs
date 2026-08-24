using LibraryManagement.Data;
using LibraryManagement.DTOs.Members;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services.Implementations
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext _context;

        public MemberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MemberResponseDto>> GetAllAsync()
        {
            return await _context.Members
                .AsNoTracking()
                .Select(m => new MemberResponseDto
                {
                    Id = m.Id,
                    MemberCode = m.MemberCode,
                    FullName = m.FullName,
                    Email = m.Email,
                    Phone = m.Phone,
                    Address = m.Address,
                    JoinDate = m.JoinDate,
                    IsActive = m.IsActive
                })
                .ToListAsync();
        }

        public async Task<MemberResponseDto?> GetByIdAsync(int id)
        {
            return await _context.Members
                .AsNoTracking()
                .Where(m => m.Id == id)
                .Select(m => new MemberResponseDto
                {
                    Id = m.Id,
                    MemberCode = m.MemberCode,
                    FullName = m.FullName,
                    Email = m.Email,
                    Phone = m.Phone,
                    Address = m.Address,
                    JoinDate = m.JoinDate,
                    IsActive = m.IsActive
                })
                .FirstOrDefaultAsync();
        }

        public async Task<(bool Success, string? Error, MemberResponseDto? Member)>
            CreateAsync(CreateMemberDto dto)
        {
            // Check duplicate email only if email was provided
            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                var emailExists = await _context.Members
                    .AnyAsync(m => m.Email == dto.Email);

                if (emailExists)
                {
                    return (
                        false,
                        "A member with this email already exists.",
                        null);
                }
            }

            var member = new Member
            {
                MemberCode = await GenerateMemberCodeAsync(),
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                IsActive = true
            };

            _context.Members.Add(member);

            await _context.SaveChangesAsync();

            var result = await GetByIdAsync(member.Id);

            return (true, null, result);
        }

        public async Task<(bool Success, string? Error)>
            UpdateAsync(int id, UpdateMemberDto dto)
        {
            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);

            if (member == null)
            {
                return (false, "Member not found.");
            }

            // Check duplicate email only if email was provided
            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                var emailExists = await _context.Members
                    .AnyAsync(m =>
                        m.Email == dto.Email &&
                        m.Id != id);

                if (emailExists)
                {
                    return (
                        false,
                        "A member with this email already exists.");
                }
            }

            member.FullName = dto.FullName;
            member.Email = dto.Email;
            member.Phone = dto.Phone;
            member.Address = dto.Address;
            member.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return (true, null);
        }

        public async Task<(bool Success, string? Error)>
            DeleteAsync(int id)
        {
            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);

            if (member == null)
            {
                return (false, "Member not found.");
            }

            var hasBorrowings = await _context.Borrowings
                .AnyAsync(b => b.MemberId == id);

            if (hasBorrowings)
            {
                return (
                    false,
                    "Cannot deactivate a member with borrowing history.");
            }

            member.IsActive = false;

            await _context.SaveChangesAsync();

            return (true, null);
        }

        private async Task<string> GenerateMemberCodeAsync()
        {
            var lastMember = await _context.Members
                .OrderByDescending(m => m.Id)
                .FirstOrDefaultAsync();

            var nextNumber = lastMember == null
                ? 1
                : lastMember.Id + 1;

            return $"MEM-{nextNumber:D5}";
        }
    }
}
