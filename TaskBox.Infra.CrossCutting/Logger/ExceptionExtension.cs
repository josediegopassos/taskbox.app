using System.Text;

namespace TaskBox.Infra.CrossCutting.Logger
{
    public static class ExceptionExtension
    {
        public static string GetErrorMsg(this Exception ex)
        {
            var sb = new StringBuilder(ex?.Message);
            var inner = ex.InnerException;

            while (inner != null)
            {
                sb.Append($" - {inner.Message}");
                inner = inner.InnerException;
            }
            return sb.ToString();
        }

        public static List<string> GetErrorList(this Exception ex)
        {
            var errorList = new List<string>();

            if (ex != null)
            {
                errorList.Add(ex.Message);
            }

            var inner = ex?.InnerException;
            while (inner != null)
            {
                errorList.Add(inner.Message);
                inner = inner.InnerException;
            }

            return errorList;
        }
    }
}
