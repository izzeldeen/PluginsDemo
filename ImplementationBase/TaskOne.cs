using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementationBase
{
    public class TaskOne : ITask
    {
        public string Id
        {
            get;
        } = "One";
        public string Description
        {
            get;
        } = "First Implementation plugin";
        public int Run()
        {
            return 1;
        }
    }
}
