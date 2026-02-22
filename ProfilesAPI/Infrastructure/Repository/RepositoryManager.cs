using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IDoctorRepository> _doctorRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _doctorRepository = new 
            Lazy<IDoctorRepository>(()=> new DoctorRepository(repositoryContext));
    }

    public IDoctorRepository Doctor => _doctorRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();

    public async Task SaveAsync() =>
        await _repositoryContext.SaveChangesAsync();
}