using System;
using GroupDocs.Parser.Cloud.Sdk.Model;
using System.Collections.Generic;
using GroupDocs.Parser.Cloud.Sdk.Api;
using GroupDocs.Parser.Cloud.Sdk.Client;
using GroupDocs.Parser.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    public class TemplateUtils
    {
        public static void CreateIfNotExist(string path)
        {
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new TemplateApi(configuration);
            var storageInstance = new StorageApi(configuration);

            try
            {
                var existRequest = new ObjectExistsRequest(path);
                if (storageInstance.ObjectExists(existRequest).Exists == true)
                {
                    return;
                }

                var options = new CreateTemplateOptions
                {
                    Template = GetTemplate(),
                    StorageName = Common.MyStorage,
                    TemplatePath = path
                };

                var request = new CreateTemplateRequest(options);
                var response = apiInstance.CreateTemplate(request);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling TemplateApi: " + e.Message);
            }
        }

        public static Template GetTemplate()
        {
            var template = new Template
            {
                Fields = new List<Field>
                {
                    new Field
                    {
                        FieldName = "Address",
                        FieldPosition = new FieldPosition
                        {
                            FieldPositionType = "Regex",
                            Regex = "Company address:"
                        }
                    },
                    new Field
                    {
                        FieldName = "CompanyAddress",
                        FieldPosition = new FieldPosition
                        {
                            FieldPositionType = "Linked",
                            LinkedFieldName = "ADDRESS",
                            IsRightLinked = true,
                            SearchArea = new Size { Height = 10, Width = 100 },
                            AutoScale = true
                        }
                    },
                    new Field
                    {
                        FieldName = "Company",
                        FieldPosition = new FieldPosition
                        {
                            FieldPositionType = "Regex",
                            Regex = "Company name:"
                        }
                    },
                    new Field
                    {
                        FieldName = "CompanyName",
                        FieldPosition = new FieldPosition
                        {
                            FieldPositionType = "Linked",
                            LinkedFieldName = "Company",
                            IsRightLinked = true,
                            SearchArea = new Size { Height = 10, Width = 100 },
                            AutoScale = true
                        }
                    }
                },
                Tables = new List<Table>
                {
                    new Table
                    {
                        TableName = "Companies",
                        DetectorParameters = new DetectorParameters
                        {
                            Rectangle = new Rectangle
                            {
                                Position = new Point
                                {
                                    X = 77,
                                    Y = 279
                                },
                                Size = new Size
                                {
                                    Height = 60,
                                    Width = 480
                                }
                            }
                        }
                    }
                }
            };
            return template;
        }
    }
}