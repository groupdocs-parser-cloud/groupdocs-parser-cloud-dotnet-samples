using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to extract images from whole document.
    /// </summary>
    public class ExtractImagesFromTheWholeDocument
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
                    }
                };

                var request = new ImagesRequest(options);
                var response = apiInstance.Images(request);
                foreach (var image in response.Images)
                {
                    Console.WriteLine($"Image path in storage: {image.Path}. Download url: {image.DownloadUrl}");
                    Console.WriteLine($"File format: {image.FileFormat}. Page index: {image.PageIndex}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling ParseApi: " + e.Message);
            }
        }
    }
}