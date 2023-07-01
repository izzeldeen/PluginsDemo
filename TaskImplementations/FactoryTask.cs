using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public class FactoryTask : ITaskServices
    {
        public string TypeName { get => typeof(FactoryTask).Name; }

        public void Print()
        {
            Console.WriteLine("Task Name: " + TypeName);
        }
    }
}
