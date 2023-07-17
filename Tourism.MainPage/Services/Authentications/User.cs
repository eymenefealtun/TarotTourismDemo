
using System.Collections.Generic;
using System.Linq;
using Tourism.Entities.Concrete;

namespace Tourism.MainPage.Services.Authentications
{
    public static class User
    {
        public static OperatorUser _currentOperatorUser
        {
            get;
            set;

        }

        public static List<OperatorUserRole> _operatorUserRoles { get; set; }
        public static List<string> _operatorUserRolesInString { get; set; }

        public static List<OperatorUserRole> GetCurrentUserRoles()
        {
            return _operatorUserRoles;
        }

        public static List<string> GetCurrentUserRolesInString()
        {
            return _operatorUserRolesInString;
        }
        public static OperatorUser CurrentUser()
        {
            return _currentOperatorUser;
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
