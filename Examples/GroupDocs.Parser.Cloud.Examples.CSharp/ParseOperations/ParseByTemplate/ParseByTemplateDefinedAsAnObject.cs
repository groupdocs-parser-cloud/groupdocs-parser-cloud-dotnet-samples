using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to parse a document using template object.
    /// </summary>
    public class ParseByTemplateDefinedAsAnObject
    {
        public static void Run()
        {
            Console.WriteLine("ParseByTemplateDefinedAsAnObject");
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new ParseApi(configuration);

            try
            {
                var options = new ParseOptions
                {
                    FileInfo = new FileInfo { FilePath = "words-processing/docx/companies.docx", StorageName = Common.MyStorage },
                    Template = TemplateUtils.GetTemplate()
                };

                var request = new ParseRequest(options);

                var response = apiInstance.Parse(request);

                foreach (var data in response.FieldsData)
                {
                    if (data.PageArea.PageTextArea != null)
                    {
                        Console.WriteLine($"Field name: {data.Name}. Text : {data.PageArea.PageTextArea.Text}");
                    }

                    if (data.PageArea.PageTableArea != null)
                    {
                        Console.WriteLine($"Table name: {data.Name}.");

                        foreach (var cell in data.PageArea.PageTableArea.PageTableAreaCells)
                        {
                            Console.WriteLine(
                                $"Table cell. Row {cell.RowIndex} column {cell.ColumnIndex}. Text: {cell.PageArea.PageTextArea.Text}");
                        }
                    }
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling ParseApi: " + e.Message + "\n");
            }
        }
    }
}