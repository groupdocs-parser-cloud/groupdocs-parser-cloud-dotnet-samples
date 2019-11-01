using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to extract images from pages range.
    /// </summary>
    public class ExtractImagesByAPageNumberRange
    {
        public static void Run()
        {
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new ParseApi(configuration);

            try
            {
                var options = new ImagesOptions()
                {
                    FileInfo = new FileInfo
                    {
                        FilePath = "slides/three-slides.pptx",
                        StorageName = Common.MyStorage
                    },
                    StartPageNumber = 1,
                    CountPagesToExtract = 2
                };

                var request = new ImagesRequest(options);
                var response = apiInstance.Images(request);
                foreach (var page in response.Pages)
                {
                    Console.WriteLine($"Images from {page.PageIndex} page.");
                    foreach (var image in page.Images)
                    {
                        Console.WriteLine($"Image path in storage: {image.Path}. Download url: {image.DownloadUrl}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling ParseApi: " + e.Message);
            }
        }
    }
}