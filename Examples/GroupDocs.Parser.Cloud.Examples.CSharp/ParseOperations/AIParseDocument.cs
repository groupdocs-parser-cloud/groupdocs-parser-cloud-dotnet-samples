using System;
using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    public class AIParseDocument
    {
        public static void Run()
        {
            var config = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var api = new ParseApi(config);

            var options = new AIParseOptions
            {
                FileInfo = new FileInfo
                {
                    FilePath = "pdf/Invoice.pdf",
                    StorageName = Common.MyStorage
                },
                Template = new
                {
                    InvoiceNumber = "",
                    InvoiceDate = "",
                    TotalAmount = ""
                }
            };

            var request = new AIParseRequest(options);
            var result = api.AIParse(request);

            Console.WriteLine("AI Parse result:");
            Console.WriteLine(result);
        }
    }
}