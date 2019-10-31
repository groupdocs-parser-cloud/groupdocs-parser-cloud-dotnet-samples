﻿using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to obtain all supported file types.
    /// </summary>
    public class GetSupportedFileTypes
    {
        public static void Run()
        {
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new InfoApi(configuration);

            try
            {
                // Get supported file formats
                var response = apiInstance.GetSupportedFileFormats();

                foreach (var entry in response.Formats)
                {
                    Console.WriteLine($"{entry.FileFormat}: {entry.Extension}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling InfoApi: " + e.Message);
            }
        }
    }
}