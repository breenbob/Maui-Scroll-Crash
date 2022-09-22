using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8247_ScrollCrash.Models
{
    public class PhoneBookGrouping : List<PhoneBookItem>
    {
        public PhoneBookGrouping(string title, string shortName, IList<PhoneBookItem> items)
        {
            Title = title;
            ShortName = shortName;

            AddRange(items);
            //All = new List<PhoneBookItem>(items);
        }

        public string Title { get; set; }
        public string ShortName { get; set; }

        public IList<PhoneBookItem> PhoneBookGroupings => this;
    }
}
