using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNest
{
    [ElasticsearchType(IdProperty = "Id", Name = "blog_post")]
    public class BlogPost
    {
        [String(Name = "_id", Index = FieldIndexOption.NotAnalyzed)]
        public Guid? Id { get; set; }

        [String(Name = "title", Index = FieldIndexOption.Analyzed)]
        public string Title { get; set; }

        [String(Name = "body", Index = FieldIndexOption.Analyzed)]
        public string Body { get; set; }

        public override string ToString()
        {
            return string.Format("Id: '{0}', Title: '{1}', Body: '{2}'", Id, Title, Body);
        }
    }
}
