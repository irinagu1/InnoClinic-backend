using Contracts;
using Services.Contracts;

namespace Services;

internal sealed class DoctorService : IDoctorService
{
    private readonly IRepositoryManager _repository;

    public DoctorService(IRepositoryManager repositoryManager)
    {
        _repository = repositoryManager;
    }
    
}