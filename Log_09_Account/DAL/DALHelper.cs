using System.Data;
using System.Reflection;
using Log_09_Account.CF;
using Newtonsoft.Json;

namespace Log_09_Account.DAL
{
    public class DALHelper
    {
        #region API Url
        Uri baseAddress = new Uri("https://testapi.gncms.in");
        #endregion

        #region Constructor
        public readonly HttpClient _client;
        public DALHelper()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        #endregion

        #region GetJSONResponseFromAPI
        public async Task<List<T>?> GetJSONResponseFromAPI<T>(String API_URL, Dictionary<string, string> data)
        {
            var encodedData = new FormUrlEncodedContent(data);
            bool IsResult = false;
            string OutputMessage = "";
            HttpResponseMessage response = await _client.PostAsync($"{_client.BaseAddress}{API_URL}", encodedData);
            List<T>? responseData = CommonFunctions.GetAllList<T>(response, out IsResult, out OutputMessage);
            return responseData.ToList();
        }
        #endregion

        #region GetJSONResponseSuccess
        public async Task<bool> GetJSONResponseSuccess(String API_URL, Dictionary<string, string> data)
        {
            var encodedData = new FormUrlEncodedContent(data);
            bool IsResult = false;
            string OutputMessage = "";
            HttpResponseMessage response = await _client.PostAsync($"{_client.BaseAddress}/{API_URL}", encodedData);
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                dynamic? jsonObject = JsonConvert.DeserializeObject(responseData);
                if (jsonObject.IsResult != null)
                {
                    IsResult = Convert.ToBoolean(jsonObject.IsResult);
                    OutputMessage = jsonObject.Message;
                    if (IsResult)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region ExceptionHandler
        public ExceptionHandlerResult ExceptionHandler(Exception ex)
        {
            /**********************************************************************
             *  Turn ON/OFF exception by setting 'IsToThrowAnyException'
             **********************************************************************/
            bool isToThrowAnyException = true;


            /**********************************************************************
             *  Write your code to modify the value of 'exceptionToThrow'
             *  else set default value as below.
             **********************************************************************/
            Exception exceptionToThrow = ex;

            ExceptionHandlerResult vExceptionHandlerResult = new ExceptionHandlerResult()
            {
                IsToThrowAnyException = isToThrowAnyException,
                ExceptionToThrow = exceptionToThrow
            };

            return vExceptionHandlerResult;
        }
        #endregion

        #region ConvertDataTableToEntity
        public static List<T> ConvertDataTableToEntity<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName && !dr[column.ColumnName].Equals(System.DBNull.Value))
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }
                        else
                            continue;
                    }
                }
                data.Add(obj);
            }
            return data;
        }

        #endregion

        #region EntityToString
        public string EntityToString<T>(T obj)
        {
            String ENT_String = String.Empty;
            ENT_String = JsonConvert.SerializeObject(obj);

            ENT_String = ENT_String.Replace(":", " → ");
            ENT_String = ENT_String.Replace(",", " ░ ");
            ENT_String = ENT_String.Replace("\"", "");
            ENT_String = ENT_String.Replace("{", "");
            ENT_String = ENT_String.Replace("}", "");
            return ENT_String;
        }
        #endregion
    }

    #region Exception Handler
    public class ExceptionHandlerResult
    {
        public bool IsToThrowAnyException { get; set; }
        public Exception ExceptionToThrow { get; set; }
    }
    #endregion Exception Handler

}
