using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to extract text from container item.
    /// </summary>
    public class ExtractTextFromADocumentInsideAContainer
    {
        public static void Run()
        {
            Console.WriteLine("ExtractTextFromADocumentInsideAContainer");
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new ParseApi(configuration);

            try
            {
                var options = new TextOptions
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

                var request = new TextRequest(options);
                var response = apiInstance.Text(request);
                Console.WriteLine($"Text: {response.Pages[0].Text}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling ParseApi: " + e.Message + "\n");
            }
        }
    }
}