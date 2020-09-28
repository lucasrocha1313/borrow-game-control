using System;

namespace GameLoanApi.Exceptions
{
    public class LoginException: Exception
    {
        public LoginException(string message) :
            base("Error trying to Log In: " + message)
        {
        }
    }
}
