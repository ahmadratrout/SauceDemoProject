using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Diagnostics;
using System.IO;
using System.Reactive;
using System;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium.BiDi.Modules.Script;

namespace SauceDemoProject
{
    public class Program
    {
        static void Main(string[] args)
        {

            #region Web Driver
            
            #endregion

            #region Ui Test
            var testSet = new TestSets.E2EUiTest();
            testSet.Execute();
            #endregion
        }
    }
}
