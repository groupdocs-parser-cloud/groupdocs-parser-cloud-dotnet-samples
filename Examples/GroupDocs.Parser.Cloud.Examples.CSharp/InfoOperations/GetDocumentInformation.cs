using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to obtain document file information.
    /// </summary>
    public class GetDocumentInformation
    {
        public static void Run()
        {
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new InfoApi(configuration);

            try
            {
                var fileInfo = new FileInfo
                {
                    FilePath = "words-processing/docx/password-protected.docx",
                    Password = "password",
                    StorageName = Common.MyStorage
                };

                var options = new InfoOptions()
                {
                    FileInfo = fileInfo
                };

                var request = new GetInfoRequest(options);

                var response = apiInstance.GetInfo(request);
                    Console.WriteLine("InfoResult.PageCount: " + response.PageCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling InfoApi: " + e.Message);
            }
        }
    }
}