﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using RestSharp.Contrib;
namespace Dotnetblogs.Repositorium.Blogs
{
    public class Blog : IValueConverter
    {
        public string UrlToBlog { get; set; }

        public Blog(string urlToBlog)
        {
            UrlToBlog = urlToBlog;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            int maxLength = 200;
            int strLength = 0;
            string fixedString = "";

            fixedString = Regex.Replace(value.ToString(), "<[^>]+>", string.Empty);
            fixedString = fixedString.Replace("\r", "").Replace("\n", "");
            fixedString = HttpUtility.HtmlDecode(fixedString);
            strLength = fixedString.ToString().Length;

            if (strLength == 0)
            {
                return null;
            }

            else if (strLength >= maxLength)
            {
                fixedString = fixedString.Substring(0, maxLength);
                fixedString = fixedString.Substring(0, fixedString.LastIndexOf(" "));
            }

            fixedString += "...";

            return fixedString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
