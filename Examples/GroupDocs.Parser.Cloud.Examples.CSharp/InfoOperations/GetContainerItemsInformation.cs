using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to obtain container items information.
    /// </summary>
    public class GetContainerItemsInformation
    {
        public static void Run()
        {
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new InfoApi(configuration);

            try
            {
                var fileInfo = new FileInfo
                {
                    FilePath = "containers/archive/zip.zip",
                    StorageName = Common.MyStorage
                };

                var options = new ContainerOptions
                {
                    FileInfo = fileInfo
                };

                var request = new GetContainerInfoRequest(options);
                var response = apiInstance.GetContainerInfo(request);

                foreach (var item in response.ContainerItems)
                {
                    Console.WriteLine($"Name: {item.Name}. FilePath: {item.FilePath}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling InfoApi: " + e.Message);
            }
        }
    }
}