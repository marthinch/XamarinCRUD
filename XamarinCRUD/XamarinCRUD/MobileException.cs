using System;

namespace MobilePOS
{
    public class MobileException : Exception
    {
        public MobileException(string message) : base(message) { }
    }
}
