﻿using System;
using System.IO;
using System.Text;

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

    public static class CorporateDetails
    {
        public static string ThisCompany
        {
            get
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "company.ini";
                if (!File.Exists(path))
                {
                    File.CreateText(path).Close();
                }
                string[] lines = File.ReadAllLines(@"company.ini");
                StringBuilder builder = new StringBuilder();
                foreach (string value in lines)
                {
                    builder.Append(value);
                    builder.Append('\n');
                }
                return builder.ToString();
            }
            set
            {
                using (StreamWriter writetext = new StreamWriter(@"company.ini"))
                {
                    writetext.Write(value);
                }
            }
        }
    }
}