using Microsoft.Extensions.Options;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

using PowerBILibrary.Interfaces;
using PowerBILibrary.Models;



namespace PowerBILibrary.Embedding
{
    public class ReportEmbedding : IReportEmbedding
    {
        private readonly WorkspaceConfiguration _workspaceConfiguration;
        private readonly IIdentityProvider _identityProvider;

        public ReportEmbedding(
            IOptions<WorkspaceConfiguration> workspaceConfiguration,
            IIdentityProvider identityProvider)
        {
            _workspaceConfiguration = workspaceConfiguration.Value;
            _identityProvider = identityProvider;
        }

        public async Task<EmbedModel> GetEmbeddingDetailsForReport(string reportName, string azureADToken)
        {
            var tokenCredential = new TokenCredentials(azureADToken);
            using (var pbiClient = new PowerBIClient(tokenCredential))
            {
                var reports = await pbiClient.Reports.GetReportsAsync(new Guid(_workspaceConfiguration.WorkspaceId));
                var report = reports.Value.First(x =>
                        string.Equals(x.Name, reportName, System.StringComparison.OrdinalIgnoreCase));

                /*var dataset =
                    await pbiClient.Datasets.GetDatasetInGroupAsync(new Guid(_workspaceConfiguration.WorkspaceId),
                            report.DatasetId);
               
                var parameters = BuildTokenRequestParameters(dataset); */

                var parameters = new GenerateTokenRequest(
                   accessLevel: "View",
                   datasetId: report.DatasetId
               );

                var reportToken =
                    pbiClient.Reports.GenerateTokenInGroup(new Guid(_workspaceConfiguration.WorkspaceId),
                            report.Id, parameters);
               

                return new EmbedModel
                {
                    Id = report.Id.ToString(),
                    EmbedUrl = report.EmbedUrl,
                    AccessToken = reportToken.Token
                };
            }
        }

        private GenerateTokenRequest BuildTokenRequestParameters(Dataset dataset)
        {
            var parameters = new GenerateTokenRequest(
                accessLevel: "View",
                datasetId: dataset.Id
            );

            if (dataset.IsEffectiveIdentityRequired.HasValue && dataset.IsEffectiveIdentityRequired.Value)
            {
                var userIdentity = _identityProvider.GetUserIdentityWithDatasetId(dataset.Id);
                parameters.Identities = new List<EffectiveIdentity>
                {
                    userIdentity
                };
            }

            return parameters;
        }
    }
}
