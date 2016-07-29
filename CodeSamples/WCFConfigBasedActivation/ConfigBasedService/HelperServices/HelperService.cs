using System.ServiceModel;

namespace ConfigBasedService.HelperServices
{
    [ServiceContract]
    public class HelperService : IHelper
    {
        [OperationContract]
        public bool IsServiceRunning()
        {
            return true;
        }        
    }
}