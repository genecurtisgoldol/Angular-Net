using System.Threading.Tasks;

namespace PowerBILibrary.Interfaces
{
    public interface IAzureTokenGenerator
    {
        Task<string> GetAuthToken();
        Task<string> GetAndCacheAuthToken();
    }
}
