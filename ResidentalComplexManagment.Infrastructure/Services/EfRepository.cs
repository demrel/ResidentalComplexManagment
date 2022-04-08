using Ardalis.Specification.EntityFrameworkCore;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Core.Entities;
using ResidentalComplexManagment.Core.Interface;
using ResidentalComplexManagment.Infrastructure.Data;
using ResidentalComplexManagment.Infrastructure.Helper;

namespace ResidentalComplexManagment.Infrastructure.Services;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : BaseEntity, IAggregateRoot
{
    private readonly ICurrentUserService _currentUserService;
    public EfRepository(AppDBContext dbContext, ICurrentUserService currentUserService) : base(dbContext)
    {
        _currentUserService = currentUserService;
    }

    public override Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        entity.Id = Guid.NewGuid().GetAlphaNumeric();
        entity.CreatedBy = _currentUserService.UserId;
        entity.Created = DateTime.UtcNow;
        return base.AddAsync(entity, cancellationToken);
    }


    public override Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        entity.Id = Guid.NewGuid().GetAlphaNumeric();
        entity.LastModifiedBy = _currentUserService.UserId;
        entity.LastModified = DateTime.UtcNow;
        return base.UpdateAsync(entity, cancellationToken);
    }

   
}