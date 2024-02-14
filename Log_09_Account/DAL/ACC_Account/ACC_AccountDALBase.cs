using System.Data;
using Log_09_Account.Areas.ACC.Models;
using Log_09_Account.CF;

namespace Log_09_Account.DAL
{
    public abstract class ACC_AccountDALBase : DALHelper
    {
        #region Method: dbo_PR_ACC_Account_SelectAll
        public async Task<List<dbo_PR_ACC_Account_SelectAll_Result>?> dbo_PR_ACC_Account_SelectAll(ACC_AccountModel modelACC_Account)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "PageOffset", modelACC_Account.F_PageOffset.ToString() ?? string.Empty},
                    { "PageSize", modelACC_Account.F_PageSize.ToString() ?? string.Empty},
                    { "TotalRecords", modelACC_Account.F_TotalRecords.ToString() ?? string.Empty},
                    { "CompanyID", CV.CompanyID.ToString() ?? string.Empty},
                    { "AccountTypeID", modelACC_Account.F_AccountTypeID.ToString() ?? string.Empty},
                    { "AccountName",modelACC_Account.F_AccountName ?? string.Empty},
                    { "AccountPrintName", modelACC_Account.F_AccountPrintName ?? string.Empty},
                    { "AccountGroupID", modelACC_Account.F_AccountGroupID.ToString() ?? string.Empty},
                    { "UserID", CV.UserID.ToString() ?? string.Empty},
                    { "SecOperationID", modelACC_Account.F_SecOperationID.ToString() ?? string.Empty},

                };
                if (modelACC_Account.F_IsZero != null)
                {
                    data.Add("IsZero", modelACC_Account.F_IsZero.ToString());
                }
                if (modelACC_Account.F_IsCR != null)
                {
                    data.Add("IsCR", modelACC_Account.F_IsCR.ToString());
                }
                if (modelACC_Account.F_IsRCM != null)
                {
                    data.Add("IsRMC", modelACC_Account.F_IsRCM.ToString());
                }

                string APIURL = "AccountSelectPage/CommonAccount/getAccountSelectPage";
                List<dbo_PR_ACC_Account_SelectAll_Result>? resultList = await GetJSONResponseFromAPI<dbo_PR_ACC_Account_SelectAll_Result>(APIURL, data);
                if (resultList != null)
                {
                    DataTable dt = resultList.ToDataTable();
                    return ConvertDataTableToEntity<dbo_PR_ACC_Account_SelectAll_Result>(dt).ToList();
                }
                return null;
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_ACC_Account_SelectByPk
        //public async Task<List<dbo_PR_ACC_Account_SelectByPK_Result>?> dbo_PR_ACC_Account_SelectByPk(int? AccountID)
        //{
        //	try
        //	{
        //		var data = new Dictionary<string, string>()
        //		{
        //			{ "InstituteCode", CV.InstituteCode.ToString() ?? string.Empty},
        //			{ "AccountID", AccountID.ToString() ?? string.Empty},
        //		};

        //		string APIURL = "AccountSelectPK/CommonAccount/getAccountSelectPK";
        //		List<dbo_PR_ACC_Account_SelectByPK_Result>? result = await GetJSONResponseFromAPI<dbo_PR_ACC_Account_SelectByPK_Result>(APIURL, data);
        //		return result;
        //	}
        //	catch (Exception ex)
        //	{
        //		var vExceptionHandler = ExceptionHandler(ex);
        //		if (vExceptionHandler.IsToThrowAnyException)
        //			throw vExceptionHandler.ExceptionToThrow;
        //		return null;
        //	}
        //}
        public async Task<ACC_AccountModel?> dbo_PR_ACC_Account_SelectByPk(int? AccountID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode.ToString() ?? string.Empty},
                    { "AccountID", AccountID.ToString() ?? string.Empty},
                };

                string APIURL = "AccountSelectPK/CommonAccount/getAccountSelectPK";
                List<ACC_AccountModel>? result = await GetJSONResponseFromAPI<ACC_AccountModel>(APIURL, data);
                if (result[0] == null)
                {

                }
                return result[0];
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_ACC_Account_Insert
        public async Task<bool> dbo_PR_ACC_Account_Insert(ACC_AccountModel modelACC_Account)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                        { "InstituteCode", CV.InstituteCode ?? string.Empty},
                        { "AccountTypeID", modelACC_Account.AccountTypeID?.ToString() ?? string.Empty },
                        { "AccountName", modelACC_Account.AccountName ?? string.Empty },
                        { "AccountPrintName", modelACC_Account.AccountPrintName ?? string.Empty },
                        { "Description", modelACC_Account.Description ?? string.Empty },
                        { "AccountGroupID", modelACC_Account.AccountGroupID?.ToString() ?? string.Empty },
                        { "AccountIn", modelACC_Account.AccountIn ?? "1" },
                        { "BalanceOn", modelACC_Account.BalanceOn ?? string.Empty },
                        { "OBAmount", modelACC_Account.OBAmount?.ToString() ?? string.Empty },
                        { "OBAmountDisplay", modelACC_Account.OBAmountDisplay?.ToString() ?? string.Empty },
                        { "OBon", modelACC_Account.OBon ?? string.Empty },
                        { "TopAccountGroupID", modelACC_Account.TopAccountGroupID?.ToString() ?? "1" },
                        { "RelativeAccountGroupID", modelACC_Account.RelativeAccountGroupID?.ToString() ?? "1" },
                        { "IsActive", modelACC_Account.IsActive.ToString() ?? string.Empty },
                        { "IsRCM", modelACC_Account.IsRCM.ToString() ?? string.Empty },
                        { "Remarks", modelACC_Account.Remarks ?? string.Empty },
                        { "CompanyID", CV.CompanyID.ToString() ?? string.Empty},
                        { "UserID", CV.UserID.ToString() ?? string.Empty},
                        //{ "FinYearID", CV.FinYearID.ToString() ?? string.Empty},
                        //{ "BankID", CV.BankID.ToString() ?? string.Empty},
                        { "Created", DateTime.Now.Date.ToString("yyyy-MM-dd") ?? string.Empty},
                        { "Modified", DateTime.Now.Date.ToString("yyyy-MM-dd") ?? string.Empty},
                        { "CityID", CV.CityID.ToString() ?? string.Empty},
                        { "xmlMST_Company", modelACC_Account.xmlMST_Company ?? string.Empty },
                        { "IsTDSApplicable", modelACC_Account.IsTDSApplicable?.ToString() ?? string.Empty },
                        { "PAN", modelACC_Account.PAN ?? string.Empty },
                        { "GSTNo", modelACC_Account.GSTNo ?? string.Empty }
                };

                string APIURL = "AccountInsertWithAllDetail/CommonAccount/AccountInsertWithAllDetail";
                bool result = await GetJSONResponseSuccess(APIURL, data);
                if (result)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return false;
            }
        }
        #endregion SaveIncome

        #region Method: dbo_PR_ACC_Account_Update
        public async Task<bool> dbo_PR_ACC_Account_Update(ACC_AccountModel modelACC_Account)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                        { "InstituteCode", CV.InstituteCode ?? string.Empty},
                        { "AccountID", modelACC_Account.AccountID.ToString() ?? string.Empty },
                        { "AccountTypeID", modelACC_Account.AccountTypeID?.ToString() ?? string.Empty },
                        { "AccountName", modelACC_Account.AccountName ?? string.Empty },
                        { "AccountPrintName", modelACC_Account.AccountPrintName ?? string.Empty },
                        { "Description", modelACC_Account.Description ?? string.Empty },
                        { "AccountGroupID", modelACC_Account.AccountGroupID?.ToString() ?? string.Empty },
                        { "AccountIn", modelACC_Account.AccountIn ??"1" },
                        { "BalanceOn", modelACC_Account.BalanceOn ?? string.Empty },
                        { "OBAmount", modelACC_Account.OBAmount?.ToString() ?? string.Empty },
                        { "OBAmountDisplay", modelACC_Account.OBAmountDisplay?.ToString() ?? string.Empty },
                        { "OBon", modelACC_Account.OBon ?? string.Empty },
                        { "TopAccountGroupID", modelACC_Account.TopAccountGroupID?.ToString() ?? "1" },
                        { "RelativeAccountGroupID", modelACC_Account.RelativeAccountGroupID?.ToString() ?? string.Empty },
                        { "IsActive", modelACC_Account.IsActive.ToString() ?? string.Empty },
                        { "IsRCM", modelACC_Account.IsRCM.ToString() ?? string.Empty },
                        { "Remarks", modelACC_Account.Remarks ?? string.Empty },
                        { "CompanyID", modelACC_Account.CompanyID?.ToString() ?? string.Empty },
                        { "UserID", CV.UserID.ToString() ?? "1"},
                        { "Created", modelACC_Account.Created?.ToString("yyyy-MM-dd") ?? string.Empty },
                        { "Modified", modelACC_Account.Modified?.ToString("yyyy-MM-dd") ?? string.Empty },
                        { "CityID", CV.CityID.ToString() ?? string.Empty},
                        { "xmlMST_Company", modelACC_Account.xmlMST_Company ?? string.Empty },
                        { "IsTDSApplicable", modelACC_Account.IsTDSApplicable?.ToString() ?? string.Empty },
                        { "PAN", modelACC_Account.PAN ?? string.Empty },
                        { "GSTNo", modelACC_Account.GSTNo ?? string.Empty }
                };
                string APIURL = "AccountUpdateWithAllDetail/CommonAccount/AccountUpdateWithAllDetail";
                bool result = await GetJSONResponseSuccess(APIURL, data);
                if (result)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return false;
            }
        }
        #endregion SaveIncome

        #region Method: dbo_PR_ACC_Account_Delete
        public async Task<bool> dbo_PR_ACC_Account_Delete(int AccountID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    {"InstituteCode",CV.InstituteCode.ToString()},
                    {"AccountID",AccountID.ToString() ?? string.Empty},
                    {"UserID",CV.UserID.ToString() }

                };
                string APIURL = "AccountDelete/CommonAccount/AccountDelete";
                bool result = await GetJSONResponseSuccess(APIURL, data);
                if (result)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return false;
            }
        }
        #endregion

        #region dbo_PR_ACC_AccountType_SelectComboBox_Result
        public async Task<List<dbo_PR_AccountType_SelectComboBox_Result>?> dbo_PR_ACC_AccountType_SelectComboBox_Result(string InstituteCode, int CompanyID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", InstituteCode},
                    { "CompanyID", CompanyID.ToString()}
                };
                string APIURl = "AccountTypeSelectComboBoxByCompanyID/CommonAccount/getAccountTypeSelectComboBoxByCompanyID";
                List<dbo_PR_AccountType_SelectComboBox_Result>? result = await GetJSONResponseFromAPI<dbo_PR_AccountType_SelectComboBox_Result>(APIURl, data);

                DataTable dt = result.ToDataTable();

                return ConvertDataTableToEntity<dbo_PR_AccountType_SelectComboBox_Result>(dt).ToList();
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion

        #region dbo_PR_AccountGroup_SelectComboBox_Result
        public async Task<List<dbo_PR_AccountGroup_SelectComboBox_Result>?> dbo_PR_AccountGroup_SelectComboBox_Result(string InstituteCode, int CompanyID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", InstituteCode},
                    { "CompanyID", CompanyID.ToString()}
                };
                string APIURl = "AccountGroupSelectComboBox/CommonAccount/getAccountGroupSelectComboBox";
                List<dbo_PR_AccountGroup_SelectComboBox_Result>? result = await GetJSONResponseFromAPI<dbo_PR_AccountGroup_SelectComboBox_Result>(APIURl, data);

                DataTable dt = result.ToDataTable();

                return ConvertDataTableToEntity<dbo_PR_AccountGroup_SelectComboBox_Result>(dt).ToList();
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion

    }


    #region Entity: dbo_PR_ACC_Account_SelectAll_Result
    public partial class dbo_PR_ACC_Account_SelectAll_Result : DALHelper
    {
        #region Properties

        public int TotalRecords { get; set; }
        public int AccountID { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountName { get; set; }
        public string AccountPrintName { get; set; }
        public string? Description { get; set; }
        public string AccountGroupName { get; set; }
        public string AccountIn { get; set; }
        public string BalanceOn { get; set; }
        public decimal? OBAmount { get; set; }
        public string? OBAmountDisplay { get; set; }
        public string OBon { get; set; }
        public string? TopAccountGroupName { get; set; }
        public string? RelativeAccountGroupName { get; set; }
        public bool IsActive { get; set; }
        public string? Remarks { get; set; }
        public string CompanyName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string? CityName { get; set; }
        public int AccountTypeID { get; set; }
        public int AccountGroupID { get; set; }
        public int? TopAccountGroupID { get; set; }
        public int? RelativeAccountGroupID { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public int? CityID { get; set; }
        public bool IsCustomizedScreen { get; set; }
        public bool IsDelete { get; set; }
        public bool IsRCM { get; set; }

        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: dbo_PR_ACC_Account_SelectByPK_Result
    public partial class dbo_PR_ACC_Account_SelectByPK_Result : DALHelper
    {
        #region Properties
        public int AccountID { get; set; }
        public int AccountTypeID { get; set; }
        public string AccountName { get; set; }
        public string AccountPrintName { get; set; }
        public string Description { get; set; }
        public int AccountGroupID { get; set; }
        public string AccountIn { get; set; }
        public string BalanceOn { get; set; }
        public decimal? OBAmount { get; set; }
        public decimal? OBAmountDisplay { get; set; }
        public string OBon { get; set; }
        public int? TopAccountGroupID { get; set; }
        public int? RelativeAccountGroupID { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int? CityID { get; set; }
        public int ModifiedCount { get; set; }
        public bool IsRCM { get; set; }
        public int? InstituteID { get; set; }
        public bool IsSystemAccount { get; set; }
        public bool IsTDSApplicable { get; set; }
        public string? PAN { get; set; }
        public string? GSTNo { get; set; }
        #endregion
    }
    #endregion

    #region Entity: dbo_PR_AccountType_SelectComboBox_Result
    public partial class dbo_PR_AccountType_SelectComboBox_Result : DALHelper
    {
        #region Properties
        public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; }
        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: dbo_PR_AccountGroup_SelectComboBox_Result
    public partial class dbo_PR_AccountGroup_SelectComboBox_Result : DALHelper
    {
        #region Properties
        public int AccountGroupID { get; set; }
        public string AccountGroupName { get; set; }
        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion
}
