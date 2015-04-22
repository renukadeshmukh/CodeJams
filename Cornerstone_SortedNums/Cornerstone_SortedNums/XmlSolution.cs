using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodingChallengeCS
{
    public class XmlSolution
    {
        public string path { get; set; }

        public XmlSolution(string path)
        {
            this.path = "..\\..\\" + path;
        }



        internal List<string> GetAllBookTitles()
        {
            XElement po = XElement.Load(@path);
            List<string> bookTitles = new List<string>();

            IEnumerable<XElement> titles =
                from el in po.Descendants("title")
                select el;

            foreach (var item in titles)
            {
                bookTitles.Add(item.Value);
     
            }
            return bookTitles;
        }

        internal List<string> GetMostExpensiveTitles()
        {
            XElement po = XElement.Load(@path);
            List<string> expensiveBooks = new List<string>();

            decimal maxCost = -1;

            IEnumerable<XElement> books =
                from el in po.Descendants("book")
                select el;

            foreach (var book in books)
            {
                XElement p = book.Element("price");
                decimal cost = Decimal.Parse(p.Value);
                if (cost > maxCost)
                {
                    maxCost = cost;
                    expensiveBooks = new List<string>();
                    XElement title = book.Element("title");
                    expensiveBooks.Add(title.Value);
                }
                else if (cost == maxCost) {
                    XElement title = book.Element("title");
                    expensiveBooks.Add(title.Value);
                }

            }
            return expensiveBooks;
        }

        internal List<string> GetAllAuthorsInStock()
        {
            XElement po = XElement.Load(@path);
            List<string> authors = new List<string>();

            IEnumerable<XElement> authorsElem =
                from el in po.Descendants("author")
                select el;
            foreach (var book in authorsElem)
            {
                XElement fname = book.Element("firstName");
                if (fname != null) {
                    XElement lname = book.Element("lastName");
                    if (lname == null)
                        authors.Add(fname.Value);
                    else authors.Add(fname.Value + " " + lname.Value);
                
                }
                else {
                    XElement name = book.Element("name");
                    authors.Add(name.Value);
                }
                
            }

            return authors.Distinct().ToList();
        }
    }

    
}
