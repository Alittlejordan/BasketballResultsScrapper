Basketball Stats Scraper
This project is a simple console application for scraping basketball statistics from the Basketball Reference website and sending them via email.

## Project Structure
The project is organized into the following classes:

`UserInput:` Gathers user input, including email credentials and recipient information.
`BasketballReferenceScraper:` Handles the scraping of basketball statistics from the Basketball Reference website.
`EmailSender:` Manages the sending of emails using the SMTP protocol.

## Prerequisites
.NET SDK must be installed on your machine.
Dependencies
HtmlAgilityPack: Used for parsing HTML and extracting data from the website.

## Features

User Input Handling: The UserInput class allows users to input their email credentials and recipient information securely.

Scraping Template: The ScrapeData function in the BasketballReferenceScraper class serves as a template for users to customize according to their specific scraping needs.

Recent Basketball Games: The ScrapeRecentBasketballGames function is already implemented to scrape recent basketball games data from the specified URL.

## How to Run
Clone the repository to your local machine.
Open the solution in your preferred C# IDE.
Build and run the application.
Contributing
Contributions are welcome! Feel free to open issues or pull requests.

## Notes
Sender Email Requirement: The sender email address used in the EmailSender class must be an Outlook email address. 
This is because different email providers have different SMTP server configurations, 
and the current implementation is specifically configured for Outlook.

The ScrapeData function in the BasketballReferenceScraper class is a template for users to edit based on their specific scraping needs.

Feel free to customize any section as needed for your project.





