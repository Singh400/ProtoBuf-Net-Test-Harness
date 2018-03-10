using System;
using System.IO;
using ProtoBuf.Meta;

namespace ProtoBufTestHarness
{
    public class Program
    {
        private const string theString = "aaaaaaaaaaaaaaaaaaaaaaaaa";

        public static void Main(string[] args)
        {
            var runtimeTypeModel = TypeModel.Create();
            

            int length = 2260;

            if (args.Length > 0)
            {
                length = int.Parse(args[0]);
            }

            Console.WriteLine("Length: " + length);
            bool withOutGroups = args.Length > 0 && args[1].Equals("no", StringComparison.OrdinalIgnoreCase);
            bool withGroups = args.Length > 0 && args[1].Equals("yes", StringComparison.OrdinalIgnoreCase);


            if (withOutGroups)
            {
                Console.WriteLine("With Out Groups");
                runtimeTypeModel.Add(typeof(ResponseWithoutGroups), true);
                var response = ResponseWithoutGroups(length);
                for (var i = 0; i < 10; i++)
                {
                    using (var stream = File.Create(@"..\..\..\Output\withOutGroups.bin"))
                    {
                        runtimeTypeModel.Serialize(stream, response);
                    }
                }
            }

            if (withGroups)
            {
                Console.WriteLine("With Groups");
                runtimeTypeModel.Add(typeof(ResponseWithGroups), true);
                var response = ResponseWithGroups(length);
                for (var i = 0; i < 10; i++)
                {
                    using (var stream = File.Create(@"..\..\..\Output\withGroups.bin"))
                    {
                        runtimeTypeModel.Serialize(stream, response);
                    }
                }
            }
        }

        private static ResponseWithGroups ResponseWithGroups(int length)
        {
            var outerResults = new ResultWithGroups[length];
            var innerResults = new ResultWithGroups[length];

            for (var index = 0; index < length; index++)
            {
                var result = new ResultWithGroups
                {
                    TheString = theString
                };

                outerResults[index] = result;
                innerResults[index] = result;
            }

            var response = new ResponseWithGroups
            {
                OuterResponse = new OuterWithGroups
                {
                    OuterResults = outerResults
                },
                InnerResponse = new InnerWithGroups
                {
                    InnerResults = innerResults
                }
            };

            return response;
        }

        private static ResponseWithoutGroups ResponseWithoutGroups(int length)
        {
            var outerResults = new ResultWithoutGroups[length];
            var innerResults = new ResultWithoutGroups[length];

            for (var index = 0; index < length; index++)
            {
                var result = new ResultWithoutGroups
                {
                    TheString = theString
                };

                outerResults[index] = result;
                innerResults[index] = result;
            }

            var response = new ResponseWithoutGroups
            {
                OuterResponse = new OuterWithoutGroups
                {
                    OuterResults = outerResults
                },
                InnerResponse = new InnerWithoutGroups
                {
                    InnerResults = innerResults
                }
            };

            return response;
        }
    }
}
