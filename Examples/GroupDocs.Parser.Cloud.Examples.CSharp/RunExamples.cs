using System;

namespace GroupDocs.Parser.Cloud.Examples.CSharp
{
    public class RunExamples
    {
        public static void Main(string[] args)
        {
            //// ***********************************************************
            ////          GroupDocs.Parser Cloud API Examples
            //// ***********************************************************

            //TODO: Get your AppSID and AppKey at https://dashboard.groupdocs.cloud (free registration is required).
            Common.MyAppSid = "XXXXX-XXXXX-XXXXX";
            Common.MyAppKey = "XXXXXXXXXX";
            Common.MyStorage = "XXXXX";

            // Uploading sample test files from local disk to cloud storage
            Common.UploadSampleTestFiles();

            #region Info operations

            GetSupportedFileTypes.Run();

            //GetDocumentInformation.Run();

            //GetContainerItemsInformation.Run();

            #endregion

            #region Parse operations

            #region Parse by template

            //ParseByTemplateStoredInUserStorage.Run();

            //ParseByTemplateDefinedAsAnObject.Run();

            ParseByTemplateOfADocumentInsideAContainer.Run();

            #endregion

            #region Extract text

            //ExtractTextFromTheWholeDocument.Run();

            //ExtractTextByAPageNumberRange.Run();

            //ExtractFormattedText.Run();

            //ExtractTextFromADocumentInsideAContainer.Run();

            #endregion

            #region Extract images

            //ExtractImagesFromTheWholeDocument.Run();

            //ExtractImagesByAPageNumberRange.Run();

            //ExtractImagesFromADocumentInsideAContainer.Run();

            #endregion

            #endregion

            #region Template operations

            //CreateOrUpdateTemplate.Run();

            //GetTemplate.Run();

            //DeleteTemplate.Run();

            #endregion

            Console.WriteLine("Completed!");
            Console.ReadKey();
        }
    }
}