using Farmacity.Domain.Models;
using Farmacity.Infrastructure.Data;
using Farmacity.Infrastructure.Repositories.Interfaces;
using Farmacity.Shared.DTOs.PaginationDtos;
using Farmacity.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Farmacity.Infrastructure.Repositories.Classes;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
{
    protected DbSet<T> _dbSet;
    protected DbContext _dbContext;
    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
        _dbContext = dbContext;
    }
    public virtual async Task<List<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<List<T>> GetAllWithPagination(PaginationDto paginationDto)
    {
        var recordsQueriable = _dbSet.AsQueryable();

        return await recordsQueriable.Paginate(paginationDto).ToListAsync();
    }

    public virtual async Task<T> GetById(int id)
    {
        var recordDb = await _dbSet.FindAsync(id);
        return recordDb!;
    }

    public async Task<T> Create(T model, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(model, cancellationToken);
        return model;
    }
    public virtual async Task<T> Update(int id, T model)
    {
        var existingData = await _dbSet.FindAsync(id);

        _dbContext.Entry(existingData).CurrentValues.SetValues(model);

        return existingData!;
    }

    public async Task<T> Delete(int id)
    {
        var recordToDelete = await GetById(id);

        await _dbSet.Where(x => x.Id == id).ExecuteDeleteAsync();

        return recordToDelete;
    }

}
