using System.ComponentModel.DataAnnotations;

namespace Log_09_Account.Areas.ACC.Models
{
    public class ACC_AccountModel
    {
        /*******************************************************************
        *	FILTERS
        *******************************************************************/
        [Display(Name = "Page Size", Prompt = "Enter Page Size")]
        public int? F_PageSize { get; set; }

        [Display(Name = "Total Records", Prompt = "Enter Total Records")]
        public int? F_TotalRecords { get; set; }

        [Display(Name = "Account Type ID", Prompt = "Enter Account Type ID")]
        public int? F_AccountTypeID { get; set; }

        [Display(Name = "Account Name", Prompt = "Enter Account Name")]
        public string? F_AccountName { get; set; }

        [Display(Name = "Account Print Name", Prompt = "Enter Account Print Name")]
        public string? F_AccountPrintName { get; set; }

        [Display(Name = "Account Group ID", Prompt = "Enter Account Group ID")]
        public int? F_AccountGroupID { get; set; }

        [Display(Name = "Is Zero")]
        public bool? F_IsZero { get; set; } = false;

        [Display(Name = "Is CR")]
        public bool? F_IsCR { get; set; }

        [Display(Name = "Is RCM")]
        public bool? F_IsRCM { get; set; }

        [Display(Name = "Security Operation ID", Prompt = "Enter Security Operation ID")]
        public int? F_SecOperationID { get; set; }

        [Required, Display(Name = "No. of Rows")]
        public int F_NoOfRows { get; set; }

        public int? F_PageNo { get; set; }

        public int F_PageOffset { get; set; } = 0;



        /*******************************************************************
   *	ADDEDIT FORM
   *******************************************************************/
        public int AccountID { get; set; }

        [Display(Name = "Institute Code", Prompt = "Enter Institute Code")]
        public string? InstituteCode { get; set; }

        [Display(Name = "Account Type ID", Prompt = "Enter Account Type ID")]
        public int? AccountTypeID { get; set; }

        [Display(Name = "Account Name", Prompt = "Enter Account Name")]
        public string? AccountName { get; set; }

        [Display(Name = "Account Print Name", Prompt = "Enter Account Print Name")]
        public string? AccountPrintName { get; set; }

        [Display(Name = "Description", Prompt = "Enter Description")]
        public string? Description { get; set; }

        [Display(Name = "Account Group ID", Prompt = "Enter Account Group ID")]
        public int? AccountGroupID { get; set; }

        [Display(Name = "Account In", Prompt = "Enter Account In")]
        public string? AccountIn { get; set; }

        [Display(Name = "Balance On", Prompt = "Enter Balance On")]
        public string? BalanceOn { get; set; }

        [Display(Name = "Opening Balance Amount", Prompt = "Enter Opening Balance Amount")]
        public decimal? OBAmount { get; set; }

        [Display(Name = "Opening Balance Amount Display", Prompt = "Enter Opening Balance Amount Display")]
        public decimal? OBAmountDisplay { get; set; }

        [Display(Name = "Opening Balance On", Prompt = "Enter Opening Balance On")]
        public string? OBon { get; set; }

        [Display(Name = "Top Account Group ID", Prompt = "Enter Top Account Group ID")]
        public int? TopAccountGroupID { get; set; }

        [Display(Name = "Relative Account Group ID", Prompt = "Enter Relative Account Group ID")]
        public int? RelativeAccountGroupID { get; set; }

        [Display(Name = "Is Active", Prompt = "Enter Is Active")]
        public bool IsActive { get; set; } = false;

        [Display(Name = "Is RCM", Prompt = "Enter Is RCM")]
        public bool IsRCM { get; set; } = false;

        [Display(Name = "Remarks", Prompt = "Enter Remarks")]
        public string? Remarks { get; set; }

        [Display(Name = "Company ID", Prompt = "Enter Company ID")]
        public int? CompanyID { get; set; }

        [Display(Name = "User ID", Prompt = "Enter User ID")]
        public int? UserID { get; set; }

        [Display(Name = "Created", Prompt = "Enter Created")]
        public DateTime? Created { get; set; }

        [Display(Name = "Modified", Prompt = "Enter Modified")]
        public DateTime? Modified { get; set; }

        [Display(Name = "City ID", Prompt = "Enter City ID")]
        public int? CityID { get; set; }

        [Display(Name = "XML MST Company", Prompt = "Enter XML MST Company")]
        public string? xmlMST_Company { get; set; }

        [Display(Name = "Is TDS Applicable", Prompt = "Enter Is TDS Applicable")]
        public bool? IsTDSApplicable { get; set; }

        [Display(Name = "PAN", Prompt = "Enter PAN")]
        public string? PAN { get; set; }

        [Display(Name = "GST No.", Prompt = "Enter GST No.")]
        public string? GSTNo { get; set; }
    }
}
