

using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;

namespace FunEngGames
{
    class CommonFunctions
    {
        
        //Get json from Oxford api
        public string GET2(string url)
        {
            HttpWebRequest req = null;

            req = (HttpWebRequest)HttpWebRequest.Create(url);

            //put your Oxford app_id and app_key here
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
            }
        }



        //Paly online mp3 file
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




        //Get url content 
        public string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
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




        //Genterate synonyms, antonyms and defintions with example to a give word using Oxford api
        public void GenerateMoreInfo(string word, string category)
        {
            try
            {
                string json2 = GET2("https://od-api.oxforddictionaries.com:443/api/v1/entries/en/" + word.Trim().ToLower() + "/synonyms;antonyms");// + category);


                var words = JsonConvert.DeserializeObject<WordObject>(json2);


                string s = "";
               // if (category == "synonyms")
                //{
                    if (words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses != null && words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses[0].synonyms!=null)
                    {

                        foreach (Synonym text in words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses[0].synonyms)
                        {
                            s = s + UppercaseFirst(text.text) + "\r\n";
                        }
                    }
                     if (words.results[0].lexicalEntries[0].entries[0].senses != null && words.results[0].lexicalEntries[0].entries[0].senses[0].synonyms != null)

                    {
                        foreach (Synonym text in words.results[0].lexicalEntries[0].entries[0].senses[0].synonyms)
                        {
                            s = s + UppercaseFirst(text.text) + "\r\n";
                        }


                    }

                //if (s.Trim() != "") { s = "Synonyms:\n\t" + s; }

                // }
                // else
                // {
                string a = "";

                //w += "\rAntonyms:\n\t";

                if (words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses != null && words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses[0].antonyms !=null)
                    {
                        foreach (Antonym text in words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses[0].antonyms)
                        {
                            a = a + UppercaseFirst(text.text) + "\r\n";
                        }
                    }
                     if (words.results[0].lexicalEntries[0].entries[0].senses != null && words.results[0].lexicalEntries[0].entries[0].senses[0].antonyms != null)

                    {
                        foreach (Antonym2 text in words.results[0].lexicalEntries[0].entries[0].senses[0].antonyms)
                        {
                            a = a + UppercaseFirst(text.text) + "\r\n";
                        }
                    }

                //if (a.Trim() != "") { a = "\rAntonyms:\n\t" + a; }

                // }


                string json22 = GET2("https://od-api.oxforddictionaries.com:443/api/v1/entries/en/" + word.Trim().ToLower());


                var wordss = JsonConvert.DeserializeObject<WordObject>(json22);

                string def = wordss.results[0].lexicalEntries[0].entries[0].senses[0].definitions[0];
                string exa = "";

                string w = "";

                if (wordss.results[0].lexicalEntries[0].entries[0].senses[0].examples != null)
                {
                    exa = wordss.results[0].lexicalEntries[0].entries[0].senses[0].examples[0].text;
                    w += "\r\n" + UppercaseFirst(def) + "\r\n\tExample: " + UppercaseFirst(exa) + "\r\n\r\n";

                }
                else{
                    w += "\n\n" + UppercaseFirst(def) + "\r\n\n";

                }


               // w += "\nDefinitions:\n " + UppercaseFirst(def) + "\n\tExample: " + UppercaseFirst(exa) + "\n\n";
                if (wordss.results[0].lexicalEntries[0].entries[0].senses[0].subsenses != null)
                {
                    foreach (Subsens text in wordss.results[0].lexicalEntries[0].entries[0].senses[0].subsenses)
                    {
                        if (text.definitions != null)
                        {
                            w = w + "----------------------\r\n"+ UppercaseFirst(text.definitions[0]) + "\r\n\t";
                        }
                        if (text.examples != null)
                        {
                            w += "Example: " + UppercaseFirst(text.examples[0].text) + "\r\n\r\n";
                        }
                    }
                }

                //MessageBox.Show(s+a+w, "More information for: " + word.ToString());

                MoreInfo MoreInfo = new MoreInfo();

                //hide antonyms column
                if (a.Trim() == "")
                {
                    MoreInfo.lblAntTitle.Visible    = false;
                    MoreInfo.lblAntonyms.Visible    = false;
                    MoreInfo.txtAnt.Visible         = false;
                }

                MoreInfo.Text = "Fun English Learning Games: More information for: " + word.ToString();
                MoreInfo.lblWord.Text = word.ToString();
                MoreInfo.txtSyn.Text = s.Trim(); ;
                MoreInfo.txtAnt.Text = a.Trim();
                MoreInfo.txtDef.Text = w.Trim(); ;
                MoreInfo.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //Pronounce specific word using Oxford api
        public void Pronounce2(string word)
        {
            try
            {
                string json22 = GET2("https://od-api.oxforddictionaries.com:443/api/v1/entries/en/" + word.Trim().ToLower());
                var wordss = JsonConvert.DeserializeObject<WordObject>(json22);

                if (wordss.results[0].lexicalEntries[0].pronunciations != null && wordss.results[0].lexicalEntries[0].pronunciations[0].audioFile != null)
                {
                    PlayMp3FromUrl(wordss.results[0].lexicalEntries[0].pronunciations[0].audioFile);
                }
                else
                {
                    MessageBox.Show("No pronunciations found, Sorry");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Pronounce specific word using SpeechSynthesizer class
        public void Pronounce(string word)
        {
            try
            {
                Random rnd = new Random();
                int rand = rnd.Next(11);

                SpeechSynthesizer synthesizer = new SpeechSynthesizer();

                if (rand == 0)
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult); // to change VoiceGender and VoiceAge check out those links below
                }
                if (rand == 1)
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child); // to change VoiceGender and VoiceAge check out those links below
                }
                if (rand == 2)
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior); // to change VoiceGender and VoiceAge check out those links below
                }
                if (rand == 3)
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen); // to change VoiceGender and VoiceAge check out those links below
                }
                if (rand == 4)
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult); // to change VoiceGender and VoiceAge check out those links below
                }
                if (rand == 5)
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Child); // to change VoiceGender and VoiceAge check out those links below
                }
                if (rand == 6)
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior); // to change VoiceGender and VoiceAge check out those links below
                }
                if (rand == 7)
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Teen); // to change VoiceGender and VoiceAge check out those links below
                }
                if (rand == 8)
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.Adult); // to change VoiceGender and VoiceAge check out those links below
                }
                if (rand == 9)
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.Child); // to change VoiceGender and VoiceAge check out those links below
                }
                if (rand == 10)
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.Senior); // to change VoiceGender and VoiceAge check out those links below
                }
                if (rand == 11)
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.Teen); // to change VoiceGender and VoiceAge check out those links below
                }

                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = -2;     // -10...10

                // Synchronous
                //synthesizer.Speak(word);

                // Asynchronous
                synthesizer.SpeakAsync(word);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        //Change the first letter of a word or a sentense to uppercase
        public string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }




    }
}
