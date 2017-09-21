using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.b2;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.b1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainLevels ml = new mainLevels();
            ml.Show();
            this.Hide();

            _storyline m2 = new _storyline();
           // m2.Show();
           // this.Hide();

            _levelUP LevelUP = new _levelUP();
           // LevelUP.Show();
           // this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public string GET2(string url)
        {
            HttpWebRequest req = null;

            string PrimeUrl = "https://od-api.oxforddictionaries.com:443/api/v1/entries/en/";
            string uri = PrimeUrl + "robot";
            req = (HttpWebRequest)HttpWebRequest.Create(url);

            //These are not network credentials, just custom headers
            req.Headers.Add("app_id", "8f414221");
            req.Headers.Add("app_key", "bde66019e18fd00ed1cd2befaa18d625");

            req.Method = WebRequestMethods.Http.Get;
            req.Accept = "application/json";

            using (HttpWebResponse HWR_Response = (HttpWebResponse)req.GetResponse())
            using (Stream respStream = HWR_Response.GetResponseStream())
            using (StreamReader sr = new StreamReader(respStream, Encoding.UTF8))
            {
                string theJson = sr.ReadToEnd();

                return theJson;

                //Debug.WriteLine(theJson);
                //Console.WriteLine(theJson);
            }

            //Console.ReadKey();
        }

        public string GET(string url)
        {  try
            {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers["app_id"] = "8f414221";
            request.Headers["app_key"] = "bde66019e18fd00ed1cd2befaa18d625";
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";

                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            // https://od-api.oxforddictionaries.com:443/api/v1/entries/en/good/synonyms
            string json2 = GET2("https://od-api.oxforddictionaries.com:443/api/v1/entries/en/good/synonyms");


            var words = JsonConvert.DeserializeObject<WordObject>(json2);


            string w = "";
            foreach (Synonym text in words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses[0].synonyms)
            {
                w = w + text.text + "\n";
            }



            string json22 = GET2("https://od-api.oxforddictionaries.com:443/api/v1/entries/en/good");


            var wordss = JsonConvert.DeserializeObject<WordObject>(json22);

            string def = wordss.results[0].lexicalEntries[0].entries[0].senses[0].definitions[0];
            string exa = wordss.results[0].lexicalEntries[0].entries[0].senses[0].examples[0].text;

            w += "Def: " + def + "\n\tExample: " + exa + "\n";
            foreach (Subsens text in wordss.results[0].lexicalEntries[0].entries[0].senses[0].subsenses)
            {
                w = w + "Def: " + text.definitions[0] + "\n\tExample: " + text.examples[0].text + "\n";
            }

            /*
            var destination = Path.Combine(
                System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.ApplicationData),
                    "music.mp3");

            await new WebClient().DownloadFileTaskAsync(new Uri(wordss.results[0].lexicalEntries[0].pronunciations[0].audioFile), destination);
            */

            PlayMp3FromUrl(wordss.results[0].lexicalEntries[0].pronunciations[0].audioFile);

            MessageBox.Show(w);
            /*
            try
            {
               // JObject jo = JObject.Parse(json2);
               // WordRoot word2 = jo.ToObject<WordRoot>();

                dynamic word2 = new WordRoot();
                word2 = JsonConvert.DeserializeObject(json2);

                //var word2 = JsonConvert.DeserializeObject<WordRoot>(json2);
                MessageBox.Show(
                    word2.results[0].senses[0].definition.ToString().Replace("[", "").Replace("]", "") + "\n" +
                      word2.results[0].senses[0].examples[0].text
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }




        public static void PlayMp3FromUrl(string url)
        {
            using (Stream ms = new MemoryStream())
            {
                using (Stream stream = WebRequest.Create(url)
                    .GetResponse().GetResponseStream())
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }

                ms.Position = 0;
                using (WaveStream blockAlignedStream =
                    new BlockAlignReductionStream(
                        WaveFormatConversionStream.CreatePcmStream(
                            new Mp3FileReader(ms))))
                {
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(blockAlignedStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                }
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
           
        }
    }
}
