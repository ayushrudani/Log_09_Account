//using ClosedXML.Excel;
using System.ComponentModel;
using System.Data;
using ClosedXML.Excel;
using Newtonsoft.Json;

namespace Log_09_Account.CF
{
    public static class CommonFunctions
    {
        private static IHttpContextAccessor _httpContextAccessor;

        #region Constructor
        static CommonFunctions()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        #endregion

        #region GET_Client_IP
        public static string? GetClientIP()
        {
            return _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
        #endregion

        #region GetAllList from API
        public static List<T>? GetAllList<T>(HttpResponseMessage response, out bool IsResult, out string OutputMessage)
        {
            List<T> resultList = new List<T>();
            IsResult = false;
            OutputMessage = "";
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                dynamic? jsonObject = JsonConvert.DeserializeObject(data);
                if (jsonObject.IsResult != null)
                {
                    IsResult = Convert.ToBoolean(jsonObject.IsResult);
                    OutputMessage = jsonObject.Message;
                    if (IsResult)
                    {
                        var dataOfObject = jsonObject.ResultList;
                        var extractedDataJson = JsonConvert.SerializeObject(dataOfObject, Formatting.Indented);
                        resultList = JsonConvert.DeserializeObject<List<T>>(extractedDataJson);
                        return resultList;
                    }
                }
            }
            return null;
        }
        #endregion

        #region GetData From API
        public static Task<T>? GetData<T>(HttpResponseMessage response, out bool IsResult, out string OutputMessage)
        {
            Task<T>? result = default(Task<T>);
            IsResult = false;
            OutputMessage = "";
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                dynamic? jsonObject = JsonConvert.DeserializeObject(data);

                if (jsonObject.IsResult != null)
                {
                    IsResult = Convert.ToBoolean(jsonObject.IsResult);
                    OutputMessage = jsonObject.Message;
                    if (IsResult)
                    {
                        var dataOfObject = jsonObject.ResultList[0];
                        var extractedDataJson = JsonConvert.SerializeObject(dataOfObject, Formatting.Indented);
                        result = JsonConvert.DeserializeObject<T>(extractedDataJson);
                        return result;
                    }
                }
            }
            return null;
        }
        #endregion

        #region List To Data Table
        public static DataTable ToDataTable<T>(this List<T> iList)
        {
            DataTable dataTable = new DataTable();
            PropertyDescriptorCollection propertyDescriptorCollection =
                TypeDescriptor.GetProperties(typeof(T));
            for (int i = 0; i < propertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type type = propertyDescriptor.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type);


                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }
            object[] values = new object[propertyDescriptorCollection.Count];
            foreach (T iListItem in iList)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
        #endregion

        #region DownloadExcel
        public static MemoryStream DownloadExcel(DataTable dt, string SheetName)
        {
            var workbook = new XLWorkbook();
            // Add a worksheet to the workbook
            var worksheet = workbook.Worksheets.Add(dt, SheetName);

            // Make the header row bold
            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Style.Fill.BackgroundColor = XLColor.White;

            // Adjust column widths based on content
            worksheet.Columns().AdjustToContents();

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                stream.Seek(0, SeekOrigin.Begin);
                return stream;
            }
        }
        #endregion
    }
}
