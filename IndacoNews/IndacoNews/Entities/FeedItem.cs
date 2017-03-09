using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndacoNews.Entities
{
    public class FeedItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
