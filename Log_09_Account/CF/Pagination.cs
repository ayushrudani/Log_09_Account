using Microsoft.AspNetCore.Mvc.Rendering;

namespace Log_09_Account.CF
{
    public static class Pagination
    {
        #region GetPageInformation
        public static string GetPageInformation(PagedListPagerModel p)
        {
            string vReturn = String.Empty;
            if (p.TotalItems > 0)
            {
                vReturn = string.Format("Showing <b>{0}</b> to <b>{1}</b> of <b>{2}</b> entries, Page <b>{3}</b> of <b>{4}</b>", p.ItemFrom, p.ItemTo, p.TotalItems, p.CurrentPageNo, p.TotalPages);
            }
            else
            {
                vReturn = "No record found..!";
            }
            return vReturn;
        }
        #endregion


        #region GetPagedListPageSizes
        public static IList<SelectListItem> GetPagedListPageSizes()
        {
            IList<SelectListItem> vPageSizeList = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "25",
                    Value = "25",
                    Selected = true
                },
                new SelectListItem()
                {
                    Text = "50",
                    Value = "50"

                },
                new SelectListItem()
                {
                    Text = "100",
                    Value = "100"

                }
            };
            return vPageSizeList;
        }
        #endregion
    }
}
