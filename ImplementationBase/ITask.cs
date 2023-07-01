using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementationBase
{
    public interface ITask
    {
        string Id
        {
            get;
        }
        string Description
        {
            get;
        }
        int Run();
    }
}
