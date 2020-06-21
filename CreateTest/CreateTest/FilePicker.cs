using Plugin.FilePicker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateTest
{
    public class FilePicker
    {
        //about data
        public static readonly string[] TypeList = { ".png", ".jpg", ".html", ".text", ".word", ".pdf", ".mp4", ".mp3" };

        //about file
        public static FileInfo fileInfo;
        public static string filePath;
        public static string nameOfFile;
        public static string sufixOfFile;

        public static byte[] fileData;

        public static async Task<string> GetFileFromLocalAsync()//<( byte[], string, Stream, string, string)>
        {
            var file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {

                filePath = file.FilePath; //get the path of file
                fileInfo = new FileInfo(file.FilePath); //get the information of file
                nameOfFile = fileInfo.Name; //get the name for file
                //sufixOfFile = nameOfFile.Split('.').Last(); //get the sufix of file
                switch (sufixOfFile = nameOfFile.Split('.').Last())
                {
                    case "png":
                        sufixOfFile = "image/png";
                        break;
                    case "jpg":
                        sufixOfFile = "image/jpg";
                        break;
                    case "html":
                        sufixOfFile = "text/html";
                        break;
                    case "text":
                        sufixOfFile = "text/plain";
                        break;
                    case "word":
                        sufixOfFile = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                        break;
                    case "pdf":
                        sufixOfFile = "application/pdf";
                        break;
                    case "mp4":
                        sufixOfFile = "video/mp4";
                        break;
                    case "mp3":
                        sufixOfFile = "audio/mp3";
                        break;
                }
                bool TypeOfFile = TypeList.Any(x => nameOfFile.EndsWith(x));
                if (TypeOfFile)
                {
                    fileData = file.DataArray;
                    //image, audio, video, application, text/plain, text/html, application/vnd.openxmlformats-officedocument.wordprocessingml.document

                    return "Get it";
                }
                return null;
            }
            return null;
        }
    }
}
