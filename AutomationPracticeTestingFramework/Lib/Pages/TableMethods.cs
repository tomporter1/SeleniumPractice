using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TechTalk.SpecFlow;

namespace AutomationPracticeTestingFramework.Lib.Pages
{
    internal class TableMethods
    {
        internal static List<string> ToStringList(ReadOnlyCollection<IWebElement> priceRows)
        {
            List<string> output = new List<string>();
            foreach (IWebElement row in priceRows)
            {
                output.Add(row.Text);
            }
            return output;
        }

        internal static List<string> TableToList(Table expected)
        {
            List<string> output = new List<string>();
            foreach (TableRow row in expected.Rows)
            {
                output.Add(row.Values.First());
            }
            return output;
        }
    }
}