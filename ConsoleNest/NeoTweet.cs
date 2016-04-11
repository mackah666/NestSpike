using Nest;
using System;

namespace ConsoleNest
{
    internal class NeoTweet
    {
        [Number(Name = "Id", Index = NonStringIndexOption.No)]
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime PostDate { get; set; }
        [String(Name = "User", Index = FieldIndexOption.Analyzed)]
        public string User { get; set; }
    }
}