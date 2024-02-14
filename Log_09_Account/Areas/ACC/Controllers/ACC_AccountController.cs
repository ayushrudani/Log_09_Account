using System.Data;
using Log_09_Account.Areas.ACC.Models;
using Log_09_Account.BAL.ACC_Account;
using Log_09_Account.CF;
using Log_09_Account.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Log_09_Account.Areas.ACC.Controllers
{
    // [CheckAccess]
    [Area("ACC")]
    [Route("[Controller]/[action]")]
    public class ACC_AccountController : Controller
    {
        #region 10.0 Local Variables
        ACC_AccountBAL balACC_Account = new ACC_AccountBAL();
        #endregion 10.0 Local Variables

        #region List Page Methods

        #region Index
        public IActionResult Index()
        {
            FillDropDownList();
            return View();
        }
        #endregion

        #region Search Result
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(ACC_AccountModel modelACC_Account)
        {
            UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
            ViewBag.UserOperationRights = vUserOperationRightsModel;

            #region 12.2 Set Default Value
            ViewBag.SearchResultHeaderText = CV.SearchResultHeaderText;

            modelACC_Account.F_PageNo = modelACC_Account.F_PageNo == null ? 1 : modelACC_Account.F_PageNo;
            modelACC_Account.F_PageSize = modelACC_Account.F_PageSize == null ? 25 : modelACC_Account.F_PageSize;
            #endregion 12.2 Set Default Value            

            //modelACC_Account.F_PageNo = 1;
            //modelACC_Account.F_PageSize = 25;

            //lisyt<resultmodel>
            var vChapterList = balACC_Account.dbo_PR_ACC_Account_SelectAll(modelACC_Account);

            PagedListPagerModel vPagedListPager = new PagedListPagerModel(vChapterList.First().TotalRecords, Convert.ToInt32(modelACC_Account.F_PageNo), Convert.ToInt32(modelACC_Account.F_PageSize));
            vPagedListPager.PageInfo = Pagination.GetPageInformation(vPagedListPager);
            vPagedListPager.PageSizeList = Pagination.GetPagedListPageSizes();

            var vModel = new Tuple<ACC_AccountModel, PagedListPagerModel, List<dbo_PR_ACC_Account_SelectAll_Result>>(modelACC_Account, vPagedListPager, vChapterList);

            return PartialView("_ACC_AccountList", vModel);
        }
        #endregion Search Result

        #region ExportExcel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExportExcel(ACC_AccountModel modelACC_Account, int TotalRecords)
        {
            UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
            ViewBag.UserOperationRights = vUserOperationRightsModel;

            modelACC_Account.F_PageNo = 1;
            modelACC_Account.F_PageSize = TotalRecords;
            var vAccountList = balACC_Account.dbo_PR_ACC_Account_SelectAll(modelACC_Account);

            DataTable dt = EntityToDataTable.ConvertToDataTable(vAccountList);

            var contentType = "application/vnmodelACC_Account.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "AccountList.xlsx";

            return File(CommonFunctions.DownloadExcel(dt, "Chapter").ToArray(), contentType, fileName);
        }
        #endregion ExportExcel

        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int AccountID)
        {
            bool vReturen = balACC_Account.dbo_PR_ACC_Account_Delete(AccountID);
            return RedirectToAction("Index");
        }
        #endregion

        #endregion

        #region FillLabels
        private void FillLabels(ControllerContext controllerContext)
        {
            var CurrentArea = controllerContext.RouteData.Values["area"].ToString();
            var CurrentController = controllerContext.RouteData.Values["controller"].ToString();
            var CurrentAction = controllerContext.RouteData.Values["action"].ToString();
            ViewBag.lblAccountName = "Account";
        }
        #endregion FillLabels

        #region Fill DropDown List
        private void FillDropDownList()
        {
            ViewBag.AccountGroupList = CommonFillMethods.FillDropDownListAccountGroupID();
            ViewBag.AccountTypeList = CommonFillMethods.FillDropDownListAccountTypeID();
        }
        #endregion

        #region 11.0 Page Load Event - Add/Edit
        public IActionResult AddEdit(int? AccountID)
        {

            #region 11.2 IsAdd, IsEdit Rights
            UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
            ViewBag.UserOperationRights = vUserOperationRightsModel;

            if (!vUserOperationRightsModel.IsAdd && !vUserOperationRightsModel.IsEdit)
            {
                return RedirectToAction("Index", "Error", new { Area = "" });
            }
            else if (vUserOperationRightsModel.IsAdd && !vUserOperationRightsModel.IsEdit && AccountID != null)
            {
                return RedirectToAction("Index", "Error", new { Area = "" });
            }
            else if (!vUserOperationRightsModel.IsAdd && vUserOperationRightsModel.IsEdit && AccountID == null)
            {
                return RedirectToAction("Index", "Error", new { Area = "" });
            }
            #endregion 11.2 IsAdd, IsEdit Rights    

            #region 11.2 Fill Lables
            FillLabels(ControllerContext);
            #endregion 11.2 Fill Lables            

            #region 11.3 Dropdown List Fill Section
            FillDropDownList();
            #endregion 11.3 Dropdown List Fill Section

            #region 11.4 Set Control Default Value
            ACC_AccountModel AccountModel = new ACC_AccountModel();
            #endregion 11.4 Set Control Default Value

            if (AccountID != null || AccountID > 0)
            {
                ViewBag.Action = "Edit";

                //var d = balACC_Account.dbo_PR_ACC_Account_SelectByPk(AccountID).SingleOrDefault();
                var d = balACC_Account.dbo_PR_ACC_Account_SelectByPk(AccountID);

                //Mapper.Initialize(config => config.CreateMap<API_Consume.DAL.dbo_PR_ACC_Account_SelectByPK_Result, ACC_AccountModel>());
                //var vModel = AutoMapper.Mapper.Map<API_Consume.DAL.dbo_PR_ACC_Account_SelectByPK_Result, ACC_AccountModel>(d);

                return View("ACC_AccountAddEdit", d);
                //var data = await balACC_Account.ACC_Account_SelectByPk(AccountID);
                //return View("ACC_AccountAddEdit", data);
            }
            ViewBag.Action = "Add";
            return View("ACC_AccountAddEdit", AccountModel);
            //ViewBag.Action = "Add";
            //return View("ACC_AccountAddEdit",null);
        }
        #endregion 11.0 Page Load Event - Add/Edit

        #region 15.0 Save Button Event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(ACC_AccountModel modelACC_Account)
        {
            try
            {
                #region Validate Field
                string errorMsg = "";
                if (modelACC_Account.AccountTypeID == null)
                {
                    errorMsg += "<li>Select Account Type</li>";
                }
                if (modelACC_Account.AccountGroupID == null)
                {
                    errorMsg += "<li>Enter  No</li>";
                }
                if (errorMsg != "")
                {
                    TempData["ErrorMessage"] = errorMsg;
                    return View("ACC_AccountAddEdit", modelACC_Account);
                }
                #endregion Validate Field

                #region Gather Data
                #endregion Gather Data
                modelACC_Account.xmlMST_Company = "<dtMST_Company><CompanyID>2</CompanyID></dtMST_Company><dtMST_Company><CompanyID>3</CompanyID></dtMST_Company>";

                if (modelACC_Account.AccountID == 0)
                {
                    bool vReturn = balACC_Account.dbo_PR_ACC_Account_Insert(modelACC_Account);
                    if (vReturn)
                    {
                        TempData["SuccessMessage"] = "Record Inserted Successfully..!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Some Error Has Occured..!";
                    }
                }
                else
                {
                    bool vReturn = balACC_Account.dbo_PR_ACC_Account_Update(modelACC_Account);
                    if (vReturn)
                    {
                        TempData["SuccessMessage"] = "Record Updated Successfully..!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Some Error Has Occured..!";
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("ACC_AccountAddEdit", modelACC_Account);
            }
        }
        #endregion 15.0 Save Button Event
    }
}
