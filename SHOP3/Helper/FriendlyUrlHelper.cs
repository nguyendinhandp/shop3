﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SHOP3.Helper
{
    public class FriendlyUrlHelper
    {

        public static string Change(string name)
        {
            string str = name.ToLower().Trim();
            str = Regex.Replace(str, @"[áàảạãăắằẳẵặâấầẩẫậ]", "a");
            str = Regex.Replace(str, @"[êếềệểéèẹẻễẽ]", "e");
            str = Regex.Replace(str, @"[ôồốộổơờớợởòóọỏỗỗõ]", "o");
            str = Regex.Replace(str, @"[íìỉịĩ]", "i");
            str = Regex.Replace(str, @"[ưứừựửủụúùữũ]", "u");
            str = Regex.Replace(str, @"[đ]", "d");
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @" - ", "").Trim();
            str = Regex.Replace(str, @"\s+", "").Trim();
            str = Regex.Replace(str, @"\s", "");
            return str;

        }
        public static string GetFriendlyTitle(string name)
        {
            
            string str = name.ToLower().Trim();
            str = Regex.Replace(str, @"[áàảạãăắằẳẵặâấầẩẫậ]", "a");
            str = Regex.Replace(str, @"[êếềệểéèẹẻễẽ]", "e");
            str = Regex.Replace(str, @"[ôồốộổơờớợởòóọỏỗỗõ]", "o");
            str = Regex.Replace(str, @"[íìỉịĩ]", "i");
            str = Regex.Replace(str, @"[ưứừựửủụúùữũ]", "u");
            str = Regex.Replace(str, @"[đ]", "d");
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @" - ", "-").Trim();
            str = Regex.Replace(str, @"\s+", "-").Trim();
            str = Regex.Replace(str, @"\s", "-");
            return str;

        }

    }
}
