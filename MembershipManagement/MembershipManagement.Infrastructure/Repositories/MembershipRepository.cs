using Microsoft.EntityFrameworkCore;
using MembershipManagement.Application.Common.Interfaces;
using MembershipManagement.Domain.Memberships.Entities;
using MembershipManagement.Infrastructure.Persistence;

namespace MembershipManagement.Infrastructure.Repositories;

public class MembershipRepository : IMembershipRepository
{
    private readonly ApplicationDbContext _context;

    public MembershipRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Membership membership,
        CancellationToken cancellationToken)
    {
        await _context.Memberships.AddAsync(
            membership,
            cancellationToken);

        await _context.SaveChangesAsync(
            cancellationToken);
    }

    public async Task<Membership?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await _context.Memberships
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }
}