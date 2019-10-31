﻿using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to extract images from container item.
    /// </summary>
    public class ExtractImagesFromADocumentInsideAContainer
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
                        FilePath = "pdf/PDF with attachements.pdf",
                        Password = "password",
                        StorageName = Common.MyStorage
                    },
                    ContainerItemInfo = new ContainerItemInfo { RelativePath = "template-document.pdf" },
                    StartPageNumber = 2,
                    CountPagesToExtract = 1
                };

                var request = new ExtractImagesRequest(options);
                var response = apiInstance.ExtractImages(request);
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