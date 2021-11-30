using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace InstagramAspMVC.Utils
{
    public class ValidateUtils
    {
        public bool checkFormatEmail(string email)
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!rEmail.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsValidVietNamPhoneNumber(string phoneNum)
        {
            if (string.IsNullOrEmpty(phoneNum))
                return false;
            string sMailPattern = @"^((09(\d){8})|(086(\d){7})|(088(\d){7})|(089(\d){7})|(03(\d){8}))$";
            return Regex.IsMatch(phoneNum.Trim(), sMailPattern);
        }
    }
}