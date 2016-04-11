using Nest;
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
            //var local = new Uri("http://localhost:9200");
            //var settings = new Nest.ConnectionSettings(local);
            //var elastic = new Nest.ElasticClient(settings);

            //// time to create 

            //var res = elastic.ClusterHealth();


            //Console.WriteLine(res.ClusterName);

            //for (int i = 0; i < 20; i++)
            //{

            //    var blogPost = new BlogPost
            //    {
            //        Id = Guid.NewGuid(),
            //        Title = "Another blog post",
            //        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum molestie a arcu eget blandit!"
            //    };

            //    var blogId = blogPost.Id;


            //    var res1 = elastic.Index(blogPost, 
            //        b=>b.Index("index_blog"));

            //    var resGet = elastic.Search<BlogPost>(s=>s
            //    .From(0)
            //    .Size(10)
            //    .Query(q=>q.Term(p=>p.Id, "blogId")));

            //    Console.WriteLine(resGet); 
            //}

            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            int rollingId = 1;

            for (int i = 0; i < 10; i++)
            {

                var tweet = new NeoTweet
                {
                    Id = rollingId,
                    User = "kimchy",
                    PostDate = DateTime.Now,
                    Message = "Trying out NEST, so far so good?"
                };

                var response = client.Index(tweet, idx => idx.Index("neoindex")); //or specify index via settings.DefaultIndex("mytweetindex");
                Console.WriteLine(response);
                ++rollingId;
                System.Threading.Thread.Sleep(TimeSpan.FromMinutes(1));
            }




            Console.ReadLine();
        }
    }
}
