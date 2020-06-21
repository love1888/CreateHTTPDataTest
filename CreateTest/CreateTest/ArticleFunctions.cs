using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CreateTest
{
    public class ArticleFunctions : ContentPage
    {
        public static string ErrowInfor;
        //static string postUrl = CollectionOfUrl.ArticleCreateUri;
        const string formStracture = "Content-Disposition: form-data; name=";

        //public static void DeleteArticle(string postUrl)
        //{
        //    //CookieContainer mycookies = new CookieContainer();
        //    var msg = HttpMethods.Get(postUrl, postUrl);
        //    var Token = GetBetween(msg);

        //    string postData = "csrfmiddlewaretoken=" + Token;
        //    HttpMethods.Post("", postUrl, postData, postUrl);
        //}

        static string GetBetween(string msg)
        {
            var start = "csrfmiddlewaretoken\" value=\"";
            try
            {
                int startIndex = msg.IndexOf(start) + start.Length;
                int stopIndex = startIndex + 64;  //the value of the token is 64 digit.
                //int stopIndex = msg.IndexOf(stop);
                return msg.Substring(startIndex, stopIndex - startIndex);
            }
            catch (Exception)
            {

                return "nothing here!";
            }

        }
        //-----------------------------------------------------------------------


        public static void CreateArticleByForm(string title, string body, string authority,
                                               string filesPath,
                                               List<string> files, List<string> filesType, List<byte[]> fileData,
                                               string date, string initialDate)
        {
            //CookieContainer mycookies = new CookieContainer();
            //var msg = HttpMethods.Get(postUrl, postUrl);
            var Token = GetBetween("csrfmiddlewaretoken\" value=\"abababababababababababababababababababababababababababababababab\"");

            byte[] byteData = GeneryMultiDataForm(Token, title, body, authority,
                                                  filesPath,
                                                  files, filesType, fileData,
                                                  date, initialDate);
            string sss = Encoding.UTF8.GetString(byteData);
            try
            {
                Console.WriteLine(sss);
                //var str = HttpMethods.PostF("Form", postUrl, byteData, postUrl);
            }
            catch (Exception infor)
            {
                ErrowInfor = infor.ToString();
            }
        }
        //public static void CreateArticleByForm(string author, string title, string body, string authority,
        //                                       string filesPath,
        //                                       List<string> files, List<string> filesType, List<byte[]> fileData,
        //                                       string date, string initialDate)
        //{
        //    CookieContainer mycookies = new CookieContainer();
        //    var msg = HttpMethods.Get(postUrl, postUrl, ref mycookies);
        //    var Token = GetBetween(msg);

        //    byte[] byteData = GeneryMultiDataForm(Token, author, title, body, authority,
        //                                          filesPath,
        //                                          files, filesType, fileData,
        //                                          date, initialDate);
        //    string sss = Encoding.UTF8.GetString(byteData);
        //    try
        //    {
        //        Console.WriteLine(sss);
        //        var str = HttpMethods.PostF("Form", postUrl, byteData, postUrl, mycookies);
        //    }
        //    catch (Exception infor)
        //    {
        //        ErrowInfor = infor.ToString();
        //    }
        //}
        //-------------------create all content of Article with multiple form-----------------
        //public static byte[] GeneryMultiDataForm(string Token, string author, string title, string body, string authority,
        //                                         string filesPath,
        //                                         List<string> fileName, List<string> filesType, List<byte[]> fileData,
        //                                         string date, string initialDate)
        //{
        //    string data = GeneryStringContent("csrfmiddlewaretoken", Token) +
        //                  GeneryStringContent("author", author) +
        //                  GeneryStringContent("title", title) +
        //                  GeneryStringContent("body", body) +
        //                  GeneryStringContent("authority", authority) +
        //                  GeneryStringContent("filesPath", filesPath) +
        //                  GeneryStringContent("date", date) +
        //                  GeneryStringContent("initial-date", initialDate);// 

        //    byte[] byteDataHead = Encoding.UTF8.GetBytes(data);

        //    //byte[] byteDataImage = GeneryFiles(files, filesType, fileData);
        //    //-------------------------------------------------------------------------------------------
        //    int byteLengthIncrease = 0;
        //    byte[] byteDataOfFileList = new byte[0];
        //    //for (int i = 0; i < fileData.Count; i++)
        //    //{
        //    //    byte[] byteDataFile = GeneryFiles(fileName[i], filesType[i], fileData[i]);
        //    //    byteDataOfFileList = new byte[byteLengthIncrease + byteDataFile.Length];

        //    //    byteDataFile.CopyTo(byteDataOfFileList, byteLengthIncrease);

        //    //    byteLengthIncrease = byteDataOfFileList.Length;
        //    //}
        //    //try
        //    //{
        //    if (fileData.Count > 0)
        //    {
        //        byte[] byteDataOfFile = GeneryFiles(fileName[0], filesType[0], fileData[0]);
        //        if (fileData.Count > 1)
        //        {
        //            byte[] byteDataOfFile1 = GeneryFiles(fileName[1], filesType[1], fileData[1]);
        //            byteDataOfFileList = new byte[byteDataOfFile.Length + byteDataOfFile1.Length];
        //            byteDataOfFile.CopyTo(byteDataOfFileList, 0);
        //            byteDataOfFile1.CopyTo(byteDataOfFileList, byteDataOfFile.Length);
        //        }
        //        else
        //        {
        //            byteDataOfFileList = new byte[byteDataOfFile.Length];
        //            byteDataOfFile.CopyTo(byteDataOfFileList, 0);
        //        }
        //    }

        //    //}
        //    //catch (Exception)
        //    //{

        //    //    throw;
        //    //}

        //    //===========================================================================================
        //    byte[] byteDataFoot = Encoding.UTF8.GetBytes(GeneryBoundary() + "--\r\n");

        //    //-------------------------------------------------------------------------------------------
        //    var byteData = new byte[byteDataHead.Length + byteDataOfFileList.Length + byteDataFoot.Length];
        //    byteDataHead.CopyTo(byteData, 0);
        //    byteDataOfFileList.CopyTo(byteData, byteDataHead.Length);
        //    byteDataFoot.CopyTo(byteData, byteDataHead.Length + byteDataOfFileList.Length);

        //    return byteData;
        //}

        public static byte[] GeneryMultiDataForm(string Token, string title, string body, string authority,
                                                 string filesPath,
                                                 List<string> fileName, List<string> filesType, List<byte[]> fileData,
                                                 string date, string initialDate)
        {
            string data = GeneryStringContent("csrfmiddlewaretoken", Token) +
                          GeneryStringContent("title", title) +
                          GeneryStringContent("body", body) +
                          GeneryStringContent("authority", authority) +
                          GeneryStringContent("filesPath", filesPath) +
                          GeneryStringContent("date", date) +
                          GeneryStringContent("initial-date", initialDate);// 

            byte[] byteDataHead = Encoding.UTF8.GetBytes(data);

            //byte[] byteDataImage = GeneryFiles(files, filesType, fileData);
            //-------------------------------------------------------------------------------------------
            //int byteLengthIncrease = 0;
            byte[] byteDataOfFileList = new byte[0];
            //for (int i = 0; i < fileData.Count; i++)
            //{
            //    byte[] byteDataFile = GeneryFiles(fileName[i], filesType[i], fileData[i]);
            //    byteDataOfFileList = new byte[byteLengthIncrease + byteDataFile.Length];

            //    byteDataFile.CopyTo(byteDataOfFileList, byteLengthIncrease);

            //    byteLengthIncrease = byteDataOfFileList.Length;
            //}
            //try
            //{
            if (fileData.Count > 0)
            {
                byte[] byteDataOfFile = GeneryFiles(fileName[0], filesType[0], fileData[0]);
                if (fileData.Count > 1)
                {
                    byte[] byteDataOfFile1 = GeneryFiles(fileName[1], filesType[1], fileData[1]);
                    byteDataOfFileList = new byte[byteDataOfFile.Length + byteDataOfFile1.Length];
                    byteDataOfFile.CopyTo(byteDataOfFileList, 0);
                    byteDataOfFile1.CopyTo(byteDataOfFileList, byteDataOfFile.Length);
                }
                else
                {
                    byteDataOfFileList = new byte[byteDataOfFile.Length];
                    byteDataOfFile.CopyTo(byteDataOfFileList, 0);
                }
            }

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            //===========================================================================================
            byte[] byteDataFoot = Encoding.UTF8.GetBytes(GeneryBoundary() + "--\r\n");

            //-------------------------------------------------------------------------------------------
            var byteData = new byte[byteDataHead.Length + byteDataOfFileList.Length + byteDataFoot.Length];
            byteDataHead.CopyTo(byteData, 0);
            byteDataOfFileList.CopyTo(byteData, byteDataHead.Length);
            byteDataFoot.CopyTo(byteData, byteDataHead.Length + byteDataOfFileList.Length);

            return byteData;
        }
        //--------------------create boundary and token----------------------------------------
        private static string GeneryBoundary()
        {
            var boundaryValue = "------MWbMtPFormBoundary2jrORzmpBHbtJUr7";
            return boundaryValue;
        }

        //--------------------create other information-----------------------------------------
        private static string GeneryStringContent(string name, string value)
        {
            var form = GeneryBoundary() + "\r\n" + String.Format(formStracture + "\"{0}\"\r\n\r\n{1}\r\n", name, value);//here 
            return form;
        }


        //private static string GeneryFiles(string fileName, string fileType, string fileData)
        private static byte[] GeneryFiles(string fileName, string fileType, byte[] fileData)
        {
            var listOfFileData = new byte[0];

            string IfileContentType = fileType != null ? "Content-Type: " + fileType : "Content-Type: application/octet-stream";
            string IFileType = IfileContentType.Contains("image") ? "image" : "files";
            string IfileName = fileName ?? "";
            byte[] IfileData = fileData;

            byte[] fileFormHead = Encoding.UTF8.GetBytes(GeneryBoundary() + "\r\n" + String.Format(formStracture + "\"{0}\"; filename=\"{1}\"\r\n{2}\r\n\r\n", IFileType, IfileName, IfileContentType));//here
            byte[] fileFormFoot = Encoding.UTF8.GetBytes("\r\n");
            //now we can have the whole data
            byte[] formData = new byte[0];
            if (IfileData != null)
            {
                formData = new byte[fileFormHead.Length + IfileData.Length + fileFormFoot.Length];
                fileFormHead.CopyTo(formData, 0);
                IfileData.CopyTo(formData, fileFormHead.Length);
                fileFormFoot.CopyTo(formData, IfileData.Length + fileFormHead.Length);

            }
            return formData;
        }

    }
}
