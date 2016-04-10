
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

            var res = elastic.ClusterHealth();


            Console.WriteLine(res.ClusterName);

            Console.ReadLine();
        }
    }
}
