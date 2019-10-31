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
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new ParseApi(configuration);

            try
            {
                var options = new ExtractTextOptions
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

                var request = new ExtractTextRequest(options);
                var response = apiInstance.ExtractText(request);
                Console.WriteLine($"Text: {response.Text}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling ParseApi: " + e.Message);
            }
        }
    }
}