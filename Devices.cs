using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onions
{

    public class MODELIST
    {
        public string MODEL { get; set; }
        public string URLIMAGE { get; set; }
    }

    public class BRANDLIST
    {
        public string BRAND { get; set; }      
        public List<MODELIST> MODELIST { get; set; }
    }

    public static class MainFormVisible
    {

        public static bool IsVisible { get; set; }

    }

    public static class SearchDialogVisible 
    {
        private static bool IsAvailable;

        public static bool IsThisVisible
        {
            
            get{return IsAvailable; }
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
