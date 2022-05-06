using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyWebSite.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bogus;

namespace MyWebSite.Models
{
    public static class SeedData
    {
        private static List<Article> FakeArticles(int count)
        {

            var articleFaker = new Faker<Article>()
                .RuleFor(m => m.Title, f => f.Lorem.Sentence())
                .RuleFor(m => m.Body, f => f.Lorem.Paragraph())
                .RuleFor(m => m.Author, "Kara Heffernan");
            return articleFaker.Generate(count);

        }
        private static List<Message> FakeMessages(int count)
        {

            var messageFaker = new Faker<Message>()
                .RuleFor(m => m.Email, f => f.Person.Email)
                .RuleFor(m => m.FullName, f => f.Person.FullName)
                .RuleFor(m => m.Body, f => f.Lorem.Paragraph())
                .RuleFor(m => m.CreatedAt, f => f.Date.Past());
            return messageFaker.Generate(count);

        }
        private static Article[] GetArticleMd(string dirPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            FileInfo[] files = dirInfo.GetFiles();


            List<Article> articles = new List<Article>();

            foreach (FileInfo file in files)
            {
                Article article = new Article()
                {
                    Title = File.ReadAllText(file.FullName).Split("======").First().Replace("\n", "").Replace("# ", ""),
                    Body = File.ReadAllText(file.FullName).Split("======").Last()
                };
                articles.Add(article);
            }
            return articles.ToArray();
        }


        private static Skill[] AddSkill()
        {
            return new Skill[]
            {
                new Skill
                {
                    Name = "Java (Soley through projects in modding the popular videogame Minecraft)",
                    Percentage = 40
                },
                new Skill
                {
                    Name = "Python",
                    Percentage = 80
                },
                new Skill
                {
                    Name = "Power Query/BI",
                    Percentage = 90
                },
                new Skill
                {
                    Name = "Power Apps",
                    Percentage = 65
                },
                new Skill
                {
                    Name = "SQL (Not Oracle)",
                    Percentage = 99
                },
                new Skill
                {
                    Name = ".NET",
                    Percentage = 95
                },
                new Skill
                {
                    Name = "Lua",
                    Percentage = 65
                },
            };
        }
        private static Article[] AddArticle()
        {
            return new Article[] {
                new Article{
                Title = "The end of VBA",
                Body = "VBA is a coding language used by millions of people across the world to automate tasks in Microsoft Office products. It’s a language that has been around for decades and is one of the 'easiest' coding languages to learn if you don’t have a computer science background. It has massive popularity due to it's existence in Office products such as Excel. Microsoft is cracking down on Macros however, since as time goes on, people are still making viruses in them, spreading them through files over the network, while there is no way to protect against them. Microsoft has been making it harder and harder to share these files, and purposefully hides macro functionality from the user in Excel nowadays by not including the Developer tab in the Ribbon by default. Since 2018, there has been a better solution from Microsoft than macros; Power Query. (Also learning how to use tables in excel instead of hardcoding everything to be a raw cell reference. Learn the damn tool people!)",
                Author = "Kara"
                },
                new Article{
                Title = "The rise of the Power Suite",
                Body = "Since Microsoft has been cracking down on Macros, and shoving paid alternatives of polished products that actually work (and actually cost a fair bit of money, of course!) understanding and learning how to leverage these tools has become invaluable in my personal experience. To be able to approach an organisation in need and whip up a program within a low-code environment and interface quicker than traditional development, has given me extremely positive exposure, reaching further around Invercargill. Eventually, I too will be the random IT nerd that everyone knows and has come to rely on. Unfortunately, this also means I've traded all of my time for a paycheck. Once it gets big enough, I hope to retire and follow fulfilling creative activities and devote my time to people.",
                Author = "Kara"
                },
                new Article{
                Title = "A brief history of the web",
                Body = "Back in the hazy days of 1999, Microsoft introduced an ActiveX component into Internet Explorer 5 that for the first time allowed Javascript within a page to fetch additional content from the server without reloading the entire page. These were heady days, and I remember writing a lot of Internet Explorer-only applications that leveraged this technology to load specific regions of content in response to user interactions.",
                Author = "Kara"
                },
                new Article{
                Title = "I’m betting on SPAs",
                Body = "We never considered writing a whole application like that however; navigation still fetched a brand new page from the server, causing a full reload. There were still multiple <SCRIPT> tags per page to load the different Javascript files required, and as this was before build pipe-lines, none of it was minified or compressed.",
                Author = "Kara"
                },
                new Article{
                Title = "Single Page App (SPA)",
                Body = "By 2005, the phrase Single Page App (SPA) had started to surface. The entire application could be loaded once, then handled by Javascript on the client. The only round-trips required to the server would be to fetch specific pieces of data used to generate content. 2010 saw the release of BackboneJS and AngularJS, two frameworks that not only provided the building blocks to construct SPAs more effectively, but also provide some organisation for the mountain of Javascript developers had started to write. In 2011 SproutCore 2.0 was renamed to EmberJS, 2013 saw the first version of React, and in 2016 the new version of Angular was released.",
                Author = "Kara"
                },



        };
        }

        private static Portfolio[] AddPortfolio()
        {
            return new Portfolio[] {
                new Portfolio
                {
                    Title ="Dashboards for Power BI designers",
                    Description = "A Power BI dashboard is a single page, often called a canvas, that tells a story through visualizations. Because it's limited to one page, a well-designed dashboard contains only the highlights of that story. Readers can view related reports for the details. url: https://docs.microsoft.com/en-us/power-bi/create-reports/service-dashboards",
                    Pic = "/pic/power-bi-dashboard.png"
                },
                new Portfolio
                {
                Title = "Power Query Interface Example",
                Description = "Importing your data with Power Query is simple. Excel provides many common data connections that are accessible from the Data tab and can be found from the Get Data command. " +
                "Get data from a single file such as an Excel workbook, Text or CSV file, XML and JSON files. You can also import multiple files from within a given folder. Get data from various databases such as SQL Server, Microsoft Access, Analysis Services, SQL Server Analysis Server, Oracle, IBM DB2, MySQL, PostgreSQL, Sybase, Teradata and SAP HANA databases. " +
                "Get data from Microsoft Azure " +
                "Get data from online services like Sharepoint, Microsoft Exchange, Dynamics 365, Facebook and Salesforce. " +
                "Get data from other sources like a table or range inside the current workbook, from the web, a Microsoft Query, Hadoop, OData feed, ODBC and OLEDB.",
                Pic = "/pic/Power-Query-Data-Preview-Screen-Load-or-Edit.png"
                },

        };
        }
        private static Experience[] AddExperience()
        {


            return new Experience[] { new Experience
                {
                    Title = "Excel Whizz",
                    Location = "SBS, Invercargill",
                    Duration = "Nov 2021-End of Dec 2021",
                    Description = "At the end of 2021, as I was finishing up from my second year of Bachelors in IT at SIT, I was approached by SBS to help process extra disclosures for some loans manually. I had never used Excel for anything more than a calculator whenever I had a brain fart and forgot windows and google search had calculators. It was in this month where I, along with 4 others, processed letters mindlessly. Except me. I was the only one with an IT education and a ridiculously self-destructive problem-solving mind. I learnt so much about base Excel and how SBS' current Excel Whizz developed what we were using, as well as getting to know the people there and the technicalities of the banking system behind the scenes."

                },
                new Experience
                {
                    Title = "Excel Macro-Translater",
                    Location = "SBS, Invercargill",
                    Duration = "End of 2021-2021",
                    Description = "I got, like, really really confused when I saw VBA for the first time. The last guy was using it to fetch data from a relational 'port' of the banking system database. I quickly grew accustomed from my previous experience participating in the Bachelors in IT Course at Southern Institute of Technology Invercargill, and even quicker decided upon hating VBA with a burning passion. This burning passion led me down the path of righteousness, in finding a more recent technology to achieve the same thing, be more scalable, and not freeze up the whole computer I was operating for 20 seconds while it ran."

                },
                new Experience
                {
                    Title = "Power Query Genius",
                    Location = "SBS, Invercargill",
                    Duration = "2022-Now",
                    Description = "My only gripe with Power Query is that Excel files that have external connections to databases, organisation managed web locations (think Sharepoint, OneDrive) need to go through a set-up process first. Can't give it to the client without having to go through a 2 minute set-up process first. Luckily the whole process takes about 2 minutes and I can make a step-by-step setup instructions document per product I deliver, but there are always going to be lUsers that don't want to put effort in to what they are using.",
                    CreateAt = DateTime.Now

                },
                new Experience
                {
                    Title = "Casual IT helpdesk, BI, product solutions deliverer",
                    Location = "SBS, Finance Now Limited, (Invercargill & Remotely)",
                    Duration = "2023-2025",
                    Description = "Helping the company to provid software development consulting service. We have created massive middlewares for Enterprise Management Information Systems, SEO Management Systems, Server Deploying, Database Architecture Design. I used Ruby on Rails to implement these solutions to the requirements of my clients."

                },
                new Experience
                {
                    Title = "Volunteer IT Solutions for Number 10 Invercargill",
                    Location = "Invercargill",
                    Duration = "2024 - 2027",
                    Description = "Number 10 has free health and social services for youth of Southland aged 10-24 years. I actually owe them a great deal for helping me in a time of great depression. I have always wanted to pay back to this organisation in any way that I could. The easiest way has been to fill their non-existance IT role and bring their technologies and processes up to speed. I'm in a much better place thanks to them, and they say the same about their organisation now because of my integral help. I'm so lucky to be in a position where I can give back to the community by doing things that I enjoy!"

                },
                new Experience
                {
                    Title = "IT Director",
                    Location = "SBS, New Zealand",
                    Duration = "2027 - 2045",
                    Description = "In a role that I totally didn't inherit due to family connections and mysterious circumstances, I have led SBS and it's subsidiaries through the future. Supporting, expanding, redesigning and securing the underdog bank a place on the international banking stage."

                },

            };
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyWebSiteContext(serviceProvider.GetRequiredService<DbContextOptions<MyWebSiteContext>>()))
            {

                if (!context.Skill.Any())
                    context.Skill.AddRange(AddSkill());
                if (!context.Experience.Any())
                    context.Experience.AddRange(AddExperience());
                if (!context.Portfolio.Any())
                    context.Portfolio.AddRange(AddPortfolio());
                if (!context.Article.Any())
                    context.Article.AddRange(FakeArticles(20));
                if (!context.Message.Any())
                    context.Message.AddRange(FakeMessages(100));


                context.SaveChanges();
            }
        }
    }
}