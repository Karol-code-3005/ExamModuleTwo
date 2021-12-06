using System;

namespace CCPolandAPI.Services.ErrorHandling.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg): base(msg)
        {

        }
    }
}
