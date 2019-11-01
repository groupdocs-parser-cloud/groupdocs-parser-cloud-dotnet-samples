using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to extract text from whole document.
    /// </summary>
    public class ExtractTextFromTheWholeDocument
    {
        public static void Run()
        {
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new ParseApi(configuration);

            try
            {
                var options = new TextOptions
                {
                    FileInfo = new FileInfo
                    {
                        FilePath = "email/eml/embedded-image-and-attachment.eml",
                        StorageName = Common.MyStorage
                    }
                };

                var request = new TextRequest(options);
                var response = apiInstance.Text(request);
                Console.WriteLine($"Text: {response.Text}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling ParseApi: " + e.Message);
            }
        }
    }
}