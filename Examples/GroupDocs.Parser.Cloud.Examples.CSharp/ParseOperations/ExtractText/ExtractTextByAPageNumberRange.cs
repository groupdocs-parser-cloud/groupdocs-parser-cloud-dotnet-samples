using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to extract text from pages range.
    /// </summary>
    public class ExtractTextByAPageNumberRange
    {
        public static void Run()
        {
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new ParseApi(configuration);

            try
            {
                var options = new ExtractTextOptions
                {
                    FileInfo = new FileInfo
                    {
                        FilePath = "cells/two-worksheets.xlsx",
                        StorageName = Common.MyStorage
                    },
                    StartPageNumber = 1,
                    CountPagesToExtract = 1
                };

                var request = new ExtractTextRequest(options);
                var response = apiInstance.ExtractText(request);
                foreach (var page in response.Pages)
                {
                    Console.WriteLine($"PageIndex: {page.PageIndex}. Text: {page.Text}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling ParseApi: " + e.Message);
            }
        }
    }
}