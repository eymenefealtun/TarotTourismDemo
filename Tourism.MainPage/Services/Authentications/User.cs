
using System.Linq;
using Tourism.Entities.Concrete;

namespace Tourism.MainPage.Services.Authentications
{
    public static class User
    {
        public static OperatorUser currentOperatorUser
        {
            get;
            set;

        }


        public static OperatorUser CurrentUser()
        {
            return currentOperatorUser;
        }

        public enum UserStatuses
        {
            admin,
            manager,
            subWorker,
            worker
        }

        public static bool IsOperatorUserAuthorized(int operatorUserLevel, int[] requiredStatus)
        {
            bool isAuthorized = false;

            if (requiredStatus.Contains(operatorUserLevel))
                isAuthorized = true;

            return isAuthorized;

        }


    }
}
