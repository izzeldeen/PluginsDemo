using BLogic;
using System;

namespace Terminal
{
    public class TerminalServices : ITaskServices
    {
        public string ServiceName => "TerminalServices";

        public string Pay(string URN)
        {
            return "Terminal Pay Implementation is working";
        }

        public string Query(string URN)
        {
            return "Terminal Query Implementation is working";
        }
    }
}
