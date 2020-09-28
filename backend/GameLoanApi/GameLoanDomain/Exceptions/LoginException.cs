using System;

namespace GameLoanDomain.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string message) :
            base("Error trying to Log In: " + message)
        {
        }
    }
}
