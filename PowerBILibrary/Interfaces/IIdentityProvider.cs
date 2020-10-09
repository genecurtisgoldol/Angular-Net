using Microsoft.PowerBI.Api.Models;

namespace PowerBILibrary.Interfaces
{
    public interface IIdentityProvider
    {
        EffectiveIdentity GetUserIdentity();
        EffectiveIdentity GetUserIdentityWithDatasetId(string datasetId);
    }
}
