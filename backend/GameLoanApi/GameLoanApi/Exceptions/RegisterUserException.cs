using System;

namespace GameLoanApi.Exceptions
{
    public class RegisterUserException: Exception
    {
        public RegisterUserException(string message):
            base("Error trying to register user: "+ message)
        {
        }
    }
}
