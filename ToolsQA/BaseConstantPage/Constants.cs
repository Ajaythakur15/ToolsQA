using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.Util;

namespace ToolsQA.BaseConstantPage
{
    internal static class Constants
    {
        public static readonly string BaseUrl = PropertyReader.GetPropertyValue("baseUrl");
        public static readonly string BaseUrl2 = PropertyReader.GetPropertyValue("baseUrl2");
        public static readonly string BaseUrl3 = PropertyReader.GetPropertyValue("baseUrl3");
        public static readonly string BaseUrl4 = PropertyReader.GetPropertyValue("baseUrl4");
        public static readonly string BaseUrl5 = PropertyReader.GetPropertyValue("baseUrl5");
    }
}
