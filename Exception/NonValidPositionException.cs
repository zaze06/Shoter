using System;
namespace Shoter.Exception
{
    public class NonValidPositionException : System.Exception
    {
        string mes;
        public NonValidPositionException(string mes){
            this.mes = mes;
        }
        public override string Message
        {
            get
            {
                return mes;
            }
        }
    }
}