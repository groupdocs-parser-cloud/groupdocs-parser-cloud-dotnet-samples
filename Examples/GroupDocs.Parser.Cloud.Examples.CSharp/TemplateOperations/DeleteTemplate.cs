using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to delete template file from storage.
    /// </summary>
    public class DeleteTemplate
    {
        public static void Run()
        {
            Console.WriteLine("DeleteTemplate");
            // For example purposes create template if not exists.
            TemplateUtils.CreateIfNotExist("templates/template-for-companies.json");
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new TemplateApi(configuration);

            try
            {
                var options = new TemplateOptions
                {
                    StorageName = Common.MyStorage,
                    TemplatePath = "templates/template-for-companies.json"
                };

                var request = new DeleteTemplateRequest(options);

                apiInstance.DeleteTemplate(request);
                Console.WriteLine("Done.");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling TemplateApi: " + e.Message + "\n");
            }
        }
    }
}