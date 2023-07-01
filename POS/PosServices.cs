using BLogic;
using System;

namespace POS
{
    public class PosServices : ITaskServices
    {
        public string ServiceName => "PosServices";

        public string Pay(string URN)
        {
            return "Pos Pay Implementation is working";
        }

        public string Query(string URN)
        {
            return "Pos Query Implementation is working";
        }
    }
}
