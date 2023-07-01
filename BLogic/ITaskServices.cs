using System;
using System.Collections.Generic;
using System.Text;

namespace BLogic
{
    public interface ITaskServices
    {
        string Query(string URN);
        string Pay(string URN);
        public string ServiceName { get;  }

    }
}
