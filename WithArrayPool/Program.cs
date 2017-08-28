﻿using System;
using System.IO;
using ProtoBuf.Meta;

namespace WithArrayPool
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

            for (var i = 0; i < 10; i++)
            {
                using (var stream = File.Create(@"..\..\..\Output\WithArrayPool.bin"))
                {
                    runtimeTypeModel.Serialize(stream, response);
                }
            }
        }
    }
}