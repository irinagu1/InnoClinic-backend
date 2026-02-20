using Contracts;
using Services.Contracts;

namespace Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IDoctorService> _doctorService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _doctorService = new Lazy<IDoctorService>(()=> new DoctorService(repositoryManager));
    }

    public IDoctorService DoctorService => _doctorService.Value;
}