﻿namespace Tourism.Core.Exceptions
{
    public class UserNotAuthorizedException : Exception
    {
        public int UserLevelId { get; set; }
        public override string Message
        {
            get
            {
                return "You are not authorized";            
            }
        }
        public UserNotAuthorizedException()
        {
        }

        public UserNotAuthorizedException(string? message) : base(message)
        {
        }

        public UserNotAuthorizedException(string? message, Exception? innerException) : base(message, innerException)
        {


        }


    }
}
