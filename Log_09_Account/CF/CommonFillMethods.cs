using Log_09_Account.BAL.ACC_Account;
using Log_09_Account.DAL;

namespace Log_09_Account.CF
{
    public class CommonFillMethods
    {
        public static List<dbo_PR_AccountType_SelectComboBox_Result>? FillDropDownListAccountTypeID()
        {
            ACC_AccountBAL balACC_Account = new ACC_AccountBAL();
            return balACC_Account.dbo_PR_ACC_AccountType_SelectComboBox(CV.InstituteCode, CV.CompanyID);
        }

        public static List<dbo_PR_AccountGroup_SelectComboBox_Result>? FillDropDownListAccountGroupID()
        {
            ACC_AccountBAL balACC_Account = new ACC_AccountBAL();
            return balACC_Account.dbo_PR_ACC_AccountGroup_SelectComboBox(CV.InstituteCode, CV.CompanyID);
        }
    }
}
