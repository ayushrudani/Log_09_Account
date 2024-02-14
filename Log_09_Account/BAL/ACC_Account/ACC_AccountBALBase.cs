using Log_09_Account.Areas.ACC.Models;
using Log_09_Account.DAL;

namespace Log_09_Account.BAL.ACC_Account
{
    public class ACC_AccountBALBase
    {
        #region Method: dbo_PR_ACC_Account_SelectAll
        public List<dbo_PR_ACC_Account_SelectAll_Result>? dbo_PR_ACC_Account_SelectAll(ACC_AccountModel modelACC_Account)
        {
            ACC_AccountDAL dalACC_AccountModel = new ACC_AccountDAL();
            // list<resultmodel>
            return dalACC_AccountModel.dbo_PR_ACC_Account_SelectAll(modelACC_Account).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_Account_SelectByPk
        //public List<dbo_PR_ACC_Account_SelectByPK_Result>? dbo_PR_ACC_Account_SelectByPk(int? AccountID)
        //      {
        //          ACC_AccountDAL dalACC_AccountModel = new ACC_AccountDAL();
        //          return dalACC_AccountModel.dbo_PR_ACC_Account_SelectByPk(AccountID).Result;
        //      }
        public ACC_AccountModel? dbo_PR_ACC_Account_SelectByPk(int? AccountID)
        {
            ACC_AccountDAL dalACC_AccountModel = new ACC_AccountDAL();
            return dalACC_AccountModel.dbo_PR_ACC_Account_SelectByPk(AccountID).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_Account_Insert
        public bool dbo_PR_ACC_Account_Insert(ACC_AccountModel modelACC_Account)
        {
            ACC_AccountDAL dalACC_AccountModel = new ACC_AccountDAL();
            return dalACC_AccountModel.dbo_PR_ACC_Account_Insert(modelACC_Account).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_Account_Update
        public bool dbo_PR_ACC_Account_Update(ACC_AccountModel modelACC_Account)
        {
            ACC_AccountDAL dalACC_AccountModel = new ACC_AccountDAL();
            return dalACC_AccountModel.dbo_PR_ACC_Account_Update(modelACC_Account).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_Account_Delete

        public bool dbo_PR_ACC_Account_Delete(int AccountID)
        {
            ACC_AccountDAL dalACC_AccountModel = new ACC_AccountDAL();
            return dalACC_AccountModel.dbo_PR_ACC_Account_Delete(AccountID).Result;
        }

        #endregion

        #region Method: dbo_PR_ACC_AccountType_SelectComboBox
        public List<dbo_PR_AccountType_SelectComboBox_Result>? dbo_PR_ACC_AccountType_SelectComboBox(string InstituteCode, int CompnyID)
        {
            ACC_AccountDAL dalACC_AccountModel = new ACC_AccountDAL();
            return dalACC_AccountModel.dbo_PR_ACC_AccountType_SelectComboBox_Result(InstituteCode, CompnyID).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_AccountGroup_SelectComboBox
        public List<dbo_PR_AccountGroup_SelectComboBox_Result>? dbo_PR_ACC_AccountGroup_SelectComboBox(string InstituteCode, int CompnyID)
        {
            ACC_AccountDAL dalACC_AccountModel = new ACC_AccountDAL();
            return dalACC_AccountModel.dbo_PR_AccountGroup_SelectComboBox_Result(InstituteCode, CompnyID).Result;
        }
        #endregion

    }
}
