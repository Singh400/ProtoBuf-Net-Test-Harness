using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf.Meta;

namespace WithCachedPool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var runtimeTypeModel = TypeModel.Create();
            runtimeTypeModel.Add(typeof(MainResponse), true);

            int length = 2260;

            if (args.Length > 0)
            {
                length = int.Parse(args[0]);
            }

            Console.WriteLine("Length: " + length);
            const string theString = "aaaaaaaaaaaaaaaaaaaaaaaaa";

            var outerResults = new Result[length];
            var innerResults = new Result[length];

            for (var index = 0; index < length; index++)
            {
                var result = new Result
                {
                    TheString = theString
                };

                outerResults[index] = result;
                innerResults[index] = result;
            }

            var response = new MainResponse
            {
                OuterResponse = new OuterResponse
                {
                    OuterResults = outerResults
                },
                InnerResponse = new InnerResponse
                {
                    InnerResults = innerResults
                }
            };

            var ticks = DateTimeOffset.Now.Ticks;

            for (var i = 0; i < 10; i++)
            {
                using (var stream = File.Create($"{ticks}.bin"))
                {
                    runtimeTypeModel.Serialize(stream, response);
                }
            }

        }
    }
}
