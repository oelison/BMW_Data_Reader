using System;
using System.Net;
using System.IO;
using System.Windows.Forms;
using SciPhyLib;

namespace BMW_Data_Reader
{
    public partial class FBMWDataReader : Form
    {
        class UserData
        {
            public String VIN;
            public String Login;
            public String Password;
        }

        private String globalDataPath = "";
        private String loginDataFileName = "BMWLoginData.txt";
        private String logDataFileName = "BMWDataRecorderLog.txt";

        private CookieContainer BMWCookies = new CookieContainer();

        Bearer bearer = new Bearer();
        Logger logger;
        UserData userData = new UserData();

        public FBMWDataReader()
        {
            InitializeComponent();
        }

        private void ChangePath()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            
            folderBrowserDialog.ShowDialog();
            globalDataPath = folderBrowserDialog.SelectedPath + "\\";
            Properties.Settings.Default.GlobalDataPath = globalDataPath;
            Properties.Settings.Default.Save();
            LPath.Text = globalDataPath;
        }

        void ReadLoginData()
        {
            UserData userDataOld = userData;
            userData.Login = "";
            userData.Password = "";
            userData.VIN = "";
            if (System.IO.File.Exists(globalDataPath + loginDataFileName) == true)
            {
                String loginLine = "";
                String passwordLine = "";
                String vinLine = "";
                TextReader textReader = new StreamReader(globalDataPath + loginDataFileName);
                try
                {
                    loginLine = textReader.ReadLine();
                    passwordLine = textReader.ReadLine();
                    vinLine = textReader.ReadLine();
                }
                catch (Exception)
                {
                    logger.WriteLogLine(string.Format("Reading user data failed! Clear file {0} if occour again!", globalDataPath + loginDataFileName));
                }

                textReader.Close();
                String[] loginLineData = loginLine.Split(new char[] { ' ' });
                String[] passwordLineData = passwordLine.Split(new char[] { ' ' });
                String[] vinLineData = vinLine.Split(new char[] { ' ' });
                if ((loginLineData.Length == 2) && (passwordLineData.Length == 2) && (vinLineData.Length == 2))
                {
                    if ((loginLineData[0] == "Login") && (passwordLineData[0] == "Password") && (vinLineData[0] == "VIN"))
                    {
                        FPassword fPassword = new FPassword();
                        DialogResult dialogResult = fPassword.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            String password = fPassword.Password;
                            userData.Login = SciPhyLib.Crypt.Decrypt(loginLineData[1], password);
                            userData.Password = SciPhyLib.Crypt.Decrypt(passwordLineData[1], password);
                            userData.VIN = SciPhyLib.Crypt.Decrypt(vinLineData[1], password);
                            
                        }
                    }
                    else
                    {
                        logger.WriteLogLine(string.Format("Reading user data failed! Keywords unexpected! Clear file {0} if occour again!", globalDataPath + loginDataFileName));
                    }
                }
                else
                {
                    logger.WriteLogLine(string.Format("Reading user data failed! Amount of data unexpected! Clear file {0} if occour again!", globalDataPath + loginDataFileName));
                }
            }
            TBLogin.Text = userData.Login;
            TBPassword.Text = userData.Password;
            TBVIN.Text = userData.VIN;
            if (userDataOld != userData)
            {
                // invalidate bearer when changing credentials
                bearer.expires_in = 0;
            }
        }

        private void FBMWDataReader_Load(object sender, EventArgs e)
        {

            globalDataPath = Properties.Settings.Default.GlobalDataPath;
            if(globalDataPath == "")
            {
                globalDataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
            {
            }
            LPath.Text = globalDataPath;

            logger = new Logger();
            logger.Open(globalDataPath + logDataFileName);
            logger.WriteLogLine("Start Prog");

            ReadLoginData();
        }

        private void FBMWDataReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger.Close();
        }

        private void ReadLoginPage()
        {
            String BMWLoginSite = "https://customer.bmwgroup.com/gcdm/oauth/authenticate";
            string formParams = string.Format("?username={0}&password={1}&client_id=dbf0a542-ebd1-4ff0-a9a7-55172fbfce35&redirect_uri=https:%2F%2Fwww.bmw-connecteddrive.com%2Fapp%2Fstatic%2Fexternal-dispatch.html&response_type=token&scope=authenticate_user fupo&state=eyJtYXJrZXQiOiJkZSIsImxhbmd1YWdlIjoiZGUiLCJkZXN0aW5hdGlvbiI6InVzZXJEYXNoYm9hcmRQYWdlIiwicGFyYW1ldGVycyI6Int9In0&locale=DE-de"
                , userData.Login
                , userData.Password
                );
            HttpWebRequest BMWSiteWebRequest = (HttpWebRequest)HttpWebRequest.Create(BMWLoginSite + formParams);
            BMWSiteWebRequest.CookieContainer = BMWCookies;
            BMWSiteWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            BMWSiteWebRequest.Method = "POST";
            //byte[] bytes = Encoding.ASCII.GetBytes(formParams);
            BMWSiteWebRequest.ContentLength = 0;
            //using (Stream os = BMWSiteWebRequest.GetRequestStream())
            //{
            //    os.Write(bytes, 0, bytes.Length);
            //}
            BMWSiteWebRequest.ContentType = "application/x-www-form-urlencode";
            BMWSiteWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            BMWSiteWebRequest.MaximumAutomaticRedirections = 1;
            WebResponse BMWSiteResponse = BMWSiteWebRequest.GetResponse();
            StreamReader BMWData = new StreamReader(BMWSiteResponse.GetResponseStream());
            TBDebug.Text = BMWData.ReadToEnd() + "\r\n" + BMWSiteResponse.ResponseUri.Fragment;
            bearer = new Bearer(BMWSiteResponse.ResponseUri.Fragment, logger);
            TBDebug.Text += bearer.expieredTime.ToLongDateString() + " " + bearer.expieredTime.ToLongTimeString() + "\r\n";
        }

        private string ReadCarData(String BMWCarDataSite, String Params)
        {
            logger.WriteLogLine("Reading: " + BMWCarDataSite);
            string formParams = string.Format("/{0}{1}", userData.VIN,Params);
            HttpWebRequest BMWSiteWebRequest = (HttpWebRequest)HttpWebRequest.Create(BMWCarDataSite + formParams);
            BMWSiteWebRequest.CookieContainer = BMWCookies;
            BMWSiteWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            BMWSiteWebRequest.Method = "GET";
            BMWSiteWebRequest.ContentLength = 0;
            BMWSiteWebRequest.ContentType = "application/json, text/plain, */*";
            BMWSiteWebRequest.Headers["Authorization"] = "Bearer " + bearer.access_token;
            BMWSiteWebRequest.Headers["Accept-Encoding"] = "gzip, deflate, br";
            BMWSiteWebRequest.Headers["Accept-Language"] = "de-DE,de;q=0.9,en-US;q=0.8,en;q=0.7";
            BMWSiteWebRequest.Host = "www.bmw-connecteddrive.de";
            BMWSiteWebRequest.Referer = "https://www.bmw-connecteddrive.de/app/de/index.html";
            BMWSiteWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            WebResponse BMWSiteResponse = BMWSiteWebRequest.GetResponse();

            StreamReader BMWData = new StreamReader(BMWSiteResponse.GetResponseStream());
            string retVal = BMWData.ReadToEnd() + "\r\n" + BMWSiteResponse.ResponseUri.Fragment;
            TBDebug.Text += retVal;
            return retVal;
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            userData.Login = TBLogin.Text;
            userData.Password = TBPassword.Text;
            userData.VIN = TBVIN.Text;
            FPassword fPassword1 = new FPassword();
            FPassword fPassword2 = new FPassword();
            fPassword1.ShowDialog();
            fPassword2.ShowDialog();
            String Password1 = fPassword1.Password;
            String Password2 = fPassword2.Password;
            if (Password1 == Password2)
            {
                TextWriter loginData = new StreamWriter(globalDataPath + loginDataFileName, false);
                loginData.WriteLine("Login " + SciPhyLib.Crypt.Encrypt(userData.Login, Password1));
                loginData.WriteLine("Password " + SciPhyLib.Crypt.Encrypt(userData.Password, Password1));
                loginData.WriteLine("VIN " + SciPhyLib.Crypt.Encrypt(userData.VIN, Password1));
                loginData.Close();
                logger.WriteLogLine("save logindata");
            }
            else
            {
                MessageBox.Show("Password or PIN is not equal!");
                logger.WriteLogLine("Tried to save logindata: Password or PIN is not equal!");
            }
        }


        //https://www.bmw-connecteddrive.de/api/vehicle/service/v1/ {0}=VIN 
        //https://www.bmw-connecteddrive.de/api/vehicle/servicepartner/v1/ {0}=VIN 
        //https://www.bmw-connecteddrive.de/api/vehicle/navigation/v1/ {0}=VIN 
        //https://www.bmw-connecteddrive.de/api/vehicle/efficiency/v1/ {0}=VIN 
        //https://www.bmw-connecteddrive.de/api/vehicle/remoteservices/chargingprofile/v1/ {0}=VIN 
        //https://www.bmw-connecteddrive.de/api/me/service/mapupdate/download/v1/ {0}=VIN 
        //https://www.bmw-connecteddrive.de/api/vehicle/dynamic/v1/ {0}=VIN ?offset=-120
        //https://www.bmw-connecteddrive.de/api/vehicle/image/v1/ {0}=VIN ?startAngle=0&stepAngle=10&width=780


        private void BReadData_Click(object sender, EventArgs e)
        {
            if (bearer.expires_in > 0)
            {
                if (DateTime.Now > bearer.expieredTime)
                {
                    ReadLoginPage();
                }
            }
            else
            {
                ReadLoginPage();
            }
            if (bearer.expires_in > 0)
            {
                DateTime dateTime = DateTime.Now;
                String dateTimeText = dateTime.Year + dateTime.Month.ToString("00") + dateTime.Day.ToString("00") + "_" +
                    dateTime.Hour.ToString("00") + dateTime.Minute.ToString("00") + dateTime.Second.ToString("00");

                logger.WriteLogLine("read dynamc data");
                string dynamicData = ReadCarData("https://www.bmw-connecteddrive.de/api/vehicle/dynamic/v1", "?offset=-120");
                TextWriter textWriterDynData = new StreamWriter(globalDataPath + "dyn" + dateTimeText + ".txt");
                textWriterDynData.Write(dynamicData);
                textWriterDynData.Close();

                logger.WriteLogLine("read efficiency data");
                string efficiencyData = ReadCarData("https://www.bmw-connecteddrive.de/api/vehicle/efficiency/v1", "");
                TextWriter textWriterEffData = new StreamWriter(globalDataPath + "eff" + dateTimeText + ".txt");
                textWriterEffData.Write(efficiencyData);
                textWriterEffData.Close();

                logger.WriteLogLine("read remoteservices data");
                string remoteData = ReadCarData("https://www.bmw-connecteddrive.de/api/vehicle/remoteservices/chargingprofile/v1", "");
                TextWriter textWriterRemData = new StreamWriter(globalDataPath + "rem" + dateTimeText + ".txt");
                textWriterRemData.Write(remoteData);
                textWriterRemData.Close();

                logger.WriteLogLine("read service data");
                string serviceData = ReadCarData("https://www.bmw-connecteddrive.de/api/vehicle/service/v1", "");
                TextWriter textWriterSrvData = new StreamWriter(globalDataPath + "srv" + dateTimeText + ".txt");
                textWriterSrvData.Write(serviceData);
                textWriterSrvData.Close();

                logger.WriteLogLine("read service partner data");
                string servicePartnerData = ReadCarData("https://www.bmw-connecteddrive.de/api/vehicle/servicepartner/v1", "");
                TextWriter textWriterSrvPartnerData = new StreamWriter(globalDataPath + "srP" + dateTimeText + ".txt");
                textWriterSrvPartnerData.Write(servicePartnerData);
                textWriterSrvPartnerData.Close();
            }
            else
            {
                logger.WriteLogLine("No Bearer Token!");
            }

        }

        private void BChangePath_Click(object sender, EventArgs e)
        {
            ChangePath();
            ReadLoginData();
        }
    }
}
