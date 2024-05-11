using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.Util;

namespace ToolsQA.BaseConstantPage
{
    internal static class Constants
    {
        public static readonly string BaseUrl = PropertyReader.GetPropertyValue("baseUrl");
    }
}
