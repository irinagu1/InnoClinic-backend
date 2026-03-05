namespace IntegrationTests;

internal static class HttpHelper
{
    internal const string GetAllDoctors = "api/doctors";  
    internal static string DoctorWithId(string id) 
        => GetAllDoctors + "/" + id;
    
} 