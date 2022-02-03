//////////////////////////////////////
// generated ISampleService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface ISampleService
    {
        Task<string> AddSample(Sample entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Sample> entities, string Message)> FindSample(Expression<Func<Sample, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Sample> entities, string Message)> GetAllSample(CancellationToken cancellationToken = default);
        Task<(Sample? entity, string Message)> GetSampleById(int id, CancellationToken cancellationToken = default);
        Task<string> RemoveSample(int id, CancellationToken cancellationToken = default);
        Task<string> UpdateSample(Sample entity, CancellationToken cancellationToken = default);
    }
}
