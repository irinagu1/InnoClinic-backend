namespace Services.Contracts;

public interface IServiceManager
{
    IDoctorService DoctorService { get; }
}