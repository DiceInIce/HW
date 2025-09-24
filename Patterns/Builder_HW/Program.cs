
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Builder
{
    
    public class Report
    {
        private string _result = "";


        public void addContent(string content)
        {
            _result += content + "\n";
        }

        public string getResult()
        {
            return _result;
        }

        public int getWordCount()
        {
            return 0;
        }
    }

    public interface IReportBuilder
    {

        void setTitle();
        
        void addHeader(string title);

        void addSection(string sectionTitle, string sectionContent);

        void addBulletList(string listTitle, List<string> items);

        void addFooter (string footer);

        Report build();

    }


    public class TextReportBuilder : IReportBuilder
    {
        private Report _report = new();

        public void setTitle()
        {
            _report.addContent($"=== Текстовый отчёт ===");
        }

        public void addHeader(string header)
        {
            _report.addContent($"-----------------------------\n{header}\n-----------------------------");
        }

        public void addSection(string sectionTitle, string sectionContent)
        {
            _report.addContent($"---{sectionTitle}---\n{sectionContent}");
        }

        public void addBulletList(string listTitle, List<string> items)
        {
            _report.addContent($"{listTitle}:");
            foreach (string i in items)
            {
                _report.addContent($" * {i}");
            }
            _report.addContent("");
        }

        public void addFooter( string footer)
        {
            _report.addContent($"Вывод: {footer}\n\n\n");
        }

        public Report build()
        {
            _report.addContent("\n\n\n");
            return _report;
        }
    }

    public class MarkdownReportBuilder : IReportBuilder
    {
        private Report _report = new();

        public void setTitle()
        {
            _report.addContent($"=== Markdown отчёт ===");
        }

        public void addHeader(string header)
        {
            _report.addContent($"#**{header}**");
        }

        public void addSection(string sectionTitle, string sectionContent)
        {
            _report.addContent($"##{sectionTitle}\n{sectionContent}");
        }

        public void addBulletList(string listTitle, List<string> items)
        {
            _report.addContent($"##{listTitle}:");
            foreach (string i in items)
            {
                _report.addContent($" * {i}");
            }
            _report.addContent("");
        }

        public void addFooter(string footer)
        {
            _report.addContent($"###Вывод: {footer}");
        }

        public Report build()
        {
            _report.addContent("\n\n\n");
            return _report;
        }
    }

    public class HtmlReportBuilder : IReportBuilder
    {
        private Report _report = new();

        public void setTitle()
        {
            _report.addContent($"=== HTML отчёт ===\n<html><body>");
        }

        public void addHeader(string header)
        {
            _report.addContent($"<h1><i>{header}</i></h1>");
        }

        public void addSection(string sectionTitle, string sectionContent)
        {
            _report.addContent($"<section>\n<h2>{sectionTitle}</h2>\n<p>{sectionContent}</p>\n</section>");
        }

        public void addBulletList(string listTitle,List<string> items)
        {
            _report.addContent($"<h2>{listTitle}</h2>\n<ul>");
            foreach (string i in items)
            {
                _report.addContent($"\t<li>{i}</li>");
            }
            _report.addContent("</ul>\n");
        }

        public void addFooter(string footer)
        {
            _report.addContent($"<footer><h2>Вывод</h2>:<p> {footer}</p></footer>");
        }

        public Report build()
        {
            _report.addContent("</body></html>\n\n\n");
            return _report;
        }
    }


    public class ReportDirector
    {
        private IReportBuilder _reportBuilder;

        public ReportDirector(IReportBuilder builder)
        {
            _reportBuilder = builder;
        }

        public void constructShortReport(string title, string dataTitle, string data) 
        {
            _reportBuilder.setTitle();
            _reportBuilder.addHeader(title);
            _reportBuilder.addSection(dataTitle, data);
        }

        public void constructDetailedReport(string title, string findingsTitle, List<string> findings, string conclusion)
        {
            _reportBuilder.setTitle();
            _reportBuilder.addHeader(title);
            _reportBuilder.addBulletList(findingsTitle, findings);
            _reportBuilder.addFooter(conclusion);
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new TextReportBuilder();
            var director = new ReportDirector(builder);
            List<string> data = ["Загрузка СPU: 45%", "Потребление RAM: 2.1GB", "Свободно на диске: 15GB"];

            director.constructShortReport("Анализ производительности", "Метрики:", "Какие то данные");
            Report shortTextReport = builder.build();
            Console.WriteLine(shortTextReport.getResult());

            var builder2 = new MarkdownReportBuilder();
            var director2 = new ReportDirector(builder2);

            director2.constructDetailedReport("Анализ производительности", "Метрики за последний час", data, "Отчёт сгенерирован автоматически");
            Report detailedMarkdownReport = builder2.build();
            Console.WriteLine(detailedMarkdownReport.getResult());

            var builder3 = new HtmlReportBuilder();
            var director3 = new ReportDirector(builder3);

            director3.constructDetailedReport("Анализ производительности", "Метрики за последний час", data, "Отчёт сгенерирован автоматически");
            Report detailedHtmlReport = builder3.build();
            Console.WriteLine(detailedHtmlReport.getResult());

        }
    }
}