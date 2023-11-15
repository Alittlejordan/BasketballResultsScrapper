using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BasketballResultsScrapper
{
    internal class BasketballReferenceScrapper
    {

        //is a custom method that will scrape data from a webpage and return it as a string
        public string ScrapeData()
        {
            // Create HtmlWeb and load the webpage
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://www.basketball-reference.com/boxscores/");

            // Select nodes using XPath or CSS selectors
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//your/xpath/here");

            if(nodes==null)
            {
                return "No data found";
            }
            // Extract and process the data
            string scrapedData = "";
            foreach (HtmlNode node in nodes)
            {
                string data = node.InnerText;
                // Process the data as needed
                scrapedData += data + "\n";
            }

            return scrapedData;
        }


        //this method will scrape the RecentGames from the basketball-reference.com website and return it as a string
        public string ScrapRecentBasketBallGames()
        {
            // Replace this URL with the actual URL for the page
            string url = "https://www.basketball-reference.com/boxscores/";

            // Create HtmlWeb and load the webpage
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);

            // Select all div elements containing game summaries
            var gameSummaryContainers = document.DocumentNode.SelectNodes("//div[contains(@class,'game_summary')]");

            if (gameSummaryContainers != null)
            {
                StringBuilder result = new StringBuilder();

                foreach (var gameSummaryContainer in gameSummaryContainers)
                {
                    // Extract team names and scores
                    var team1Name = gameSummaryContainer.SelectSingleNode(".//tr[@class='loser']/td[1]/a")?.InnerText.Trim();
                    var team1Score = gameSummaryContainer.SelectSingleNode(".//tr[@class='loser']/td[2]")?.InnerText.Trim();

                    var team2Name = gameSummaryContainer.SelectSingleNode(".//tr[@class='winner']/td[1]/a")?.InnerText.Trim();
                    var team2Score = gameSummaryContainer.SelectSingleNode(".//tr[@class='winner']/td[2]")?.InnerText.Trim();

                    // Display or collect the extracted data
                    result.AppendLine($"Team 1: {team1Name}, Score: {team1Score}");
                    result.AppendLine($"Team 2: {team2Name}, Score: {team2Score}");
                    result.AppendLine();
                }
                return result.ToString();
            }
            else
            {
                Console.WriteLine("No game summaries found.");
                return "No game summaries found.";
            }
        }
    }
}

          
        
