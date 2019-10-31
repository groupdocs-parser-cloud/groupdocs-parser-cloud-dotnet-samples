using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to get template file from storage.
    /// </summary>
    public class GetTemplate
    {
        public static void Run()
        {
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

                var request = new GetTemplateRequest(options);

                // could be used in parse by template method
                var template = apiInstance.GetTemplate(request);

                foreach (var field in template.Fields)
                {
                    Console.WriteLine($"Field: {field.FieldName}");
                }

                foreach (var table in template.Tables)
                {
                    Console.WriteLine($"Table: {table.TableName}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling TemplateApi: " + e.Message);
            }
        }
    }
}