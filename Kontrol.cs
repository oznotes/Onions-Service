﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onions
{
    public static class MainFormVisible
    {
        public static bool IsVisible { get; set; }
    }

    public static class SearchDialogVisible
    {
        private static bool IsAvailable;
        public static bool IsThisVisible
        {
            get { return IsAvailable; }
            set
            {
                IsAvailable = value;
                MainForm.SearchDialogVisibleChanged();
            }
        }
    }
    public static class WhatLanguageIsActivate
    {
        public static string ThisLanguage
        {
            get
            {
                string[] lines = File.ReadAllLines(@"config.ini");
                return lines[0].ToString();
            }
            set
            {
                using (StreamWriter writetext = new StreamWriter(@"config.ini"))
                {
                    writetext.WriteLine(value);
                }
            }
        }
    }
}

