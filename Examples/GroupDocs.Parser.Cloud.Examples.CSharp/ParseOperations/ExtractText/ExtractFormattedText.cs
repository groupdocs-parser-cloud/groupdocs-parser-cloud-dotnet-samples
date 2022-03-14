using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to extract formatted text from document.
    /// </summary>
    public class ExtractFormattedText
    {
        public static void Run()
        {
            Console.WriteLine("ExtractFormattedText");
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new ParseApi(configuration);

            try
            {
                var options = new TextOptions
                {
                    FileInfo = new FileInfo
                    {
                        FilePath = "words-processing/docx/formatted-document.docx",
                        StorageName = Common.MyStorage
                    },
                    FormattedTextOptions = new FormattedTextOptions
                    {
                        Mode = "Markdown"
                    }
                };

                var request = new TextRequest(options);
                var response = apiInstance.Text(request);
                Console.WriteLine($"Text: {response.Text}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling ParseApi: " + e.Message + "\n");
            }
        }
    }
}