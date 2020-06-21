using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreateTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateData : ContentPage
    {
        private bool IsSave = false;
        static List<string> FileName = new List<string>();
        static List<string> FileType = new List<string>();
        static List<byte[]> FileData = new List<byte[]>();
        static string Id;
        static string Name;

        public CreateData(string id, string name)
        {
            Id = id;
            Name = name;
            InitializeComponent();
        }


        //private async void OnSaveButtonClicked(object sender, EventArgs e)
        //{
        //    //var author      = UserInfor.UserID; 
        //    var UserID = UserInfor.UserID; //author

        //    var title = entryTitle.Text;
        //    var body = entryBody.Text;

        //    var authority = entryAuthority.Text ?? "All"; //entryauthority = number
        //    var filesPath = entryFilesPath.Text ?? "other";

        //    var date = String.Format("{0}-{1}-{2}", DateTime.Today.Year, DateTime.Today.ToString("MM"), DateTime.Today.ToString("dd"));
        //    var initialDate = String.Format("{0}-{1}-{2}", DateTime.Today.Year, DateTime.Today.ToString("MM"), DateTime.Today.ToString("dd"));

        //    //for post
        //    List<string> fileName = this.fileName;
        //    List<string> fileType = this.fileType;
        //    List<byte[]> fileData = this.fileData;


        //    bool save = await DisplayAlert("", "Do you want to save it", "Yse", "No");
        //    if (save)
        //    {
        //        if (!String.IsNullOrWhiteSpace(title) && !String.IsNullOrWhiteSpace(body) && !String.IsNullOrWhiteSpace(author))
        //        {
        //            //here is the function to create the article
        //            await Task.Run(() => ArticleFunctions.CreateArticleByForm( , title, body, authority,
        //                                                  filesPath,
        //                                                  fileName, fileType, fileData,
        //                                                  date, initialDate));

        //            await Task.Run(() => CreateTempArticle(author, title, body, authority, filesPath, date));

        //            await DisplayAlert("", "Successful!", "OK");

        //            isSave = true;
        //        }
        //        else
        //        {
        //            await DisplayAlert("Something missing.",
        //                String.Format("{0} Cannot be empty.", String.IsNullOrWhiteSpace(title) ? "Title" : "Body"),
        //                "Ok");
        //        }
        //    }
        //}
        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //var author      = UserInfor.UserID; 
            //var UserID = UserInfor.UserID; //author

            var title = entryTitle.Text;
            var body = entryBody.Text;

            var authority = Id ?? "1"; //get the id from tapimageEven
            var filesPath = Name ?? "other"; //get the id from tapimageEven

            var date = String.Format("{0}-{1}-{2}", DateTime.Today.Year, DateTime.Today.ToString("MM"), DateTime.Today.ToString("dd"));
            var initialDate = String.Format("{0}-{1}-{2}", DateTime.Today.Year, DateTime.Today.ToString("MM"), DateTime.Today.ToString("dd"));

            //for post
            List<string> fileName = FileName;
            List<string> fileType = FileType;
            List<byte[]> fileData = FileData;


            bool save = await DisplayAlert("", "Do you want to save it", "Yse", "No");
            if (save)
            {
                if (!String.IsNullOrWhiteSpace(title) && !String.IsNullOrWhiteSpace(body))
                {
                    progress.IsVisible = true;
                    progress.Progress = 0;
                    progress.ProgressTo(0.9, 5000, Easing.Linear);
                    //here is the function to create the article
                    await Task.Run(() => ArticleFunctions.CreateArticleByForm(title, body, authority,
                                                          filesPath,
                                                          fileName, fileType, fileData,
                                                          date, initialDate));

                    //await Task.Run(() => CreateTempArticle( title, body, authority, filesPath, date ));

                    await DisplayAlert("", "Successful!", "OK");
                    await Navigation.PopAsync();
                    IsSave = true;
                }
                else
                {
                    await DisplayAlert("Something missing.",
                        String.Format("{0} Cannot be empty.", String.IsNullOrWhiteSpace(title) ? "Title" : "Body"),
                        "Ok");
                }
            }
        }

        //private void CreateTempArticle(string title, string body, string authority, string filesPath, string date)
        //{
        //    string tempImageName = "";
        //    string tempFileName = "";
        //    if (fileName.Count > 0)
        //    {
        //        tempImageName = fileName.Where(x => x.Contains(".jpg") || x.Contains(".png")).FirstOrDefault() ?? "default.png";
        //        tempFileName = fileName.Where(x => !x.Contains(".jpg") && !x.Contains(".png")).FirstOrDefault() ?? "default.png";

        //    }

        //    ListPageforContext.listOfAllContent.Insert(0, new Articles
        //    {
        //        title = title,
        //        body = body,
        //        author = author,
        //        author_id = author,
        //        authority = authority,
        //        image = "/media/" + tempImageName,
        //        files = "/media/" + filesPath + "/" + tempFileName,
        //        date = date,
        //        filesPath = filesPath
        //    });
        //}

        //private void CreateTempArticle( string title, string body, string authority, string filesPath, string date)
        //{
        //    string tempImageName = "";
        //    string tempFileName = "";
        //    if (FileName.Count > 0)
        //    {
        //        tempImageName = FileName.Where(x => x.Contains(".jpg") || x.Contains(".png")).FirstOrDefault() ?? "default.png";
        //        tempFileName = FileName.Where(x => !x.Contains(".jpg") && !x.Contains(".png")).FirstOrDefault() ?? "default.html";
        //    }

        //    ListPageforContext.ArticlesList.Insert(0, new Articles
        //    {
        //        title = title,
        //        body = body,
        //        //author = author,
        //        //author_id = author,
        //        authority = authority,
        //        image = "/media/" + tempImageName,
        //        files = "/media/" + filesPath + "/" + tempFileName,
        //        date = date,
        //        filesPath = filesPath
        //    });
        //}
        private async void OnEntryFilesButtonClicked(object sender, EventArgs e)
        {
            var filePicker = await FilePicker.GetFileFromLocalAsync();
            if (filePicker != null)
            {
                //don't do anthing if everything is same
                if (FileName.Contains(FilePicker.nameOfFile) && FileType.Contains(FilePicker.sufixOfFile))
                {
                    await DisplayAlert("", "This file is exist/已存在，请选择其他文件", "Ok");
                    return;
                }
                FileName.Add(FilePicker.nameOfFile);
                FileType.Add(FilePicker.sufixOfFile);
                FileData.Add(FilePicker.fileData);
                labelFiles.Text += "\n" + FileName.Last();
            }
            labelFiles.Text = FileName.Count > 0 ? labelFiles.Text : "File choosing./选择文件: ";
        }


        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (IsSave)
            {
                await Navigation.PopAsync();
            }
            else
            {
                bool back = await DisplayAlert("", "Are you sure to discard?", "Yes", "Cancel");
                if (back)
                {
                    await Navigation.PopAsync();
                }
            }

        }
    }
}