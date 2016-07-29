using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace ConfigBasedService
{
    [ServiceContract]
    public class MessageListenerService : IMessageListenerService
    {
        [OperationContract]
        public bool ReceiveMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                return false;

            return true;
        }
    }
}