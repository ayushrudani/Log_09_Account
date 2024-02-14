using Microsoft.AspNetCore.Mvc;

namespace Log_09_Account.CF
{
    public static class UserOperationRights
    {
        //public static UserOperationRightsModel CheckForOperation(string Area, string Controller, string Action)
        public static UserOperationRightsModel CheckForOperation(ControllerContext controllerContext)
        {
            var CurrentArea = controllerContext.RouteData.Values["area"].ToString();
            var CurrentController = controllerContext.RouteData.Values["controller"].ToString();
            var CurrentAction = controllerContext.RouteData.Values["action"].ToString();


            UserOperationRightsModel vUserOperationRights = new UserOperationRightsModel();
            Int32 UserID = 1; //CV.UserID();

            // Database Call

            // Set Properties from Database
            vUserOperationRights.IsAdd = true;
            vUserOperationRights.IsEdit = true;
            vUserOperationRights.IsDelete = true;
            vUserOperationRights.IsExport = true;
            vUserOperationRights.IsPrint = true;
            vUserOperationRights.PageHelpText = null;
            vUserOperationRights.PageImportantNote = null;

            return vUserOperationRights;
        }

    }
}
