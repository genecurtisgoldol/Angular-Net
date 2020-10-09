using PowerBILibrary.Models;
using System.Threading.Tasks;

namespace PowerBILibrary.Interfaces
{
    public interface IReportEmbedding
    {
        Task<EmbedModel> GetEmbeddingDetailsForReport(string reportName, string azureADToken);
    }
}
