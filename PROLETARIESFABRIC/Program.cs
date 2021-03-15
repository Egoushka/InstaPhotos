using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PROLETARIESFABRIC
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the URL of the person's profile");
            string profileUrl = Console.ReadLine();
            Console.WriteLine("Enter the path to the folder");
            string savePath = Console.ReadLine();
            var chromeOptions = new ChromeOptions();
            int index = 0;
            using (WebClient client = new WebClient())
            {
                using (var browser = new ChromeDriver(chromeOptions))
                {
                    browser.Navigate().GoToUrl(profileUrl);
                    foreach (var item in browser.FindElementsByClassName("FFVAD"))
                    {
                        var photoUrl = item.GetAttribute("src");
                        client.DownloadFile(new Uri(photoUrl), $@"{savePath}\" + index++ + ".png");
                    }
                }
            }

        }
    }
}