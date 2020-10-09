using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Angular_Net.Controllers.Models;
using PowerBILibrary.Interfaces;
using PowerBILibrary.Models;

namespace Angular_Net.Controllers
{
    public class ApiController : Controller
    {
        private readonly IAzureTokenGenerator _tokenGenerator;
        private readonly IReportEmbedding _reportEmbedding;
        /*private readonly IDashboardEmbedding _dashboardEmbedding;
        private readonly ITileEmbedding _tileEmbedding;
        private readonly ITileRedirection _tileRedirection;
*/
        public ApiController(IAzureTokenGenerator tokenGenerator,
            IReportEmbedding reportEmbedding,
  /*          IDashboardEmbedding dashboardEmbedding,
            ITileEmbedding tileEmbedding,
            ITileRedirection tileRedirection)
  */      {
            _tokenGenerator = tokenGenerator;
            _reportEmbedding = reportEmbedding;
    /*        _dashboardEmbedding = dashboardEmbedding;
            _tileEmbedding = tileEmbedding;
            _tileRedirection = tileRedirection;
    */    }


    [HttpPost]
    [Route("api/embedding/report")]
    public async Task<ActionResult<EmbedModel>> GetReportEmbedModel(
        [FromBody] ReportRequest reportRequest)
    {
        var azureAdToken = await _tokenGenerator.GetAndCacheAuthToken();
        var embedModel =
            await _reportEmbedding.GetEmbeddingDetailsForReport(reportRequest.ReportName, azureAdToken);

        return embedModel;
    }




}
}
