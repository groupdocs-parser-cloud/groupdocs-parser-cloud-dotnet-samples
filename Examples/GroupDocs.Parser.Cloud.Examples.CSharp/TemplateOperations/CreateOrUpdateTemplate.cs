using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to save template file in storage.
    /// </summary>
    public class CreateOrUpdateTemplate
    {
        public static void Run()
        {
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new TemplateApi(configuration);

            try
            {
                var options = new CreateTemplateOptions
                {
                    Template = TemplateUtils.GetTemplate(),
                    StorageName = Common.MyStorage,
                    TemplatePath = "templates/template-for-companies.json"
                };

                var request = new CreateTemplateRequest(options);
                var response = apiInstance.CreateTemplate(request);

                Console.WriteLine($"Path to saved template in storage: {response.TemplatePath}. Link to download template: {response.Url}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling TemplateApi: " + e.Message);
            }
        }
    }
}