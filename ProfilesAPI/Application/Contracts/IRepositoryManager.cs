namespace Contracts;

public interface IRepositoryManager 
{
    IDoctorRepository Doctor { get; }
    Task SaveAsync();
}