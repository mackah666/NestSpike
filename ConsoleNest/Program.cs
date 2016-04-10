
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNest
{
    class Program
    {
        static void Main(string[] args)
        {
            var local = new Uri("http://localhost:9200");
            var settings = new Nest.ConnectionSettings(local);
            var elastic = new Nest.ElasticClient(settings);

            // time to create 

            var res = elastic.ClusterHealth();


            Console.WriteLine(res.ClusterName);


            var blogPost = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "First blog post",
                Body = "This is very long blog post!"
            };

            var firstId = blogPost.Id;

            //time to post to elastic


            var res1= elastic.Index(blogPost, p => p
                .Index("my_first_index")
                .Id(blogPost.Id.ToString())
                .Refresh());

            Console.ReadLine();
        }
    }
}
