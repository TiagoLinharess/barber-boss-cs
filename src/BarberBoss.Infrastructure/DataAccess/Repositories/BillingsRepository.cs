using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Billings;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infrastructure.DataAccess.Repositories;

internal class BillingsRepository : IBillingsReadOnlyRepository, IBillingsUpdateOnlyRepository, IBillingsWriteOnlyRepository
{
    private readonly BarberBossDbContext _dbContext;
    public BillingsRepository(BarberBossDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Billing billing)
    {
        await _dbContext.Billings.AddAsync(billing);
    }

    public async Task<List<Billing>> Read()
    {
        return await _dbContext
            .Billings
            .AsNoTracking()
            .ToListAsync();
    }

    async Task<Billing?> IBillingsReadOnlyRepository.ReadAt(long id)
    {
        return await _dbContext
            .Billings
            .AsNoTracking()
            .FirstOrDefaultAsync(billing => billing.Id == id);
    }

    async Task<Billing?> IBillingsUpdateOnlyRepository.ReadAt(long id)
    {
        return await _dbContext
            .Billings
            .FirstOrDefaultAsync(billing => billing.Id == id);
    }

    public void Update(Billing expense)
    {
        _dbContext.Billings.Update(expense);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Billings.FirstOrDefaultAsync(expense => expense.Id == id);

        if (result is null) return false;

        _dbContext.Billings.Remove(result);

        return true;
    }
}
