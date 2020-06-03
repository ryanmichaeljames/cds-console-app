using Microsoft.PowerPlatform.Cds.Client;

namespace CdsConsoleApp
{
    public class CdsService
    {
        private readonly CdsConfig _cdsConfig;

        public CdsService(CdsConfig cdsConfig)
        {
            _cdsConfig = cdsConfig;
        }

        public CdsServiceClient GetClient(){
            return new CdsServiceClient($"AuthType=ClientSecret;url={_cdsConfig.Url};ClientId={_cdsConfig.ClientId};ClientSecret={_cdsConfig.ClientSecret}");
        }
    }
}
