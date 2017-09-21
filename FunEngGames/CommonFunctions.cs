

using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FunEngGames
{
    class CommonFunctions
    {

        public string GET2(string url)
        {
            HttpWebRequest req = null;

            req = (HttpWebRequest)HttpWebRequest.Create(url);

            //These are not network credentials, just custom headers
            req.Headers.Add("app_id", "");
            req.Headers.Add("app_key", "");

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





        public void GenerateMoreInfo(DataGridView senderGrid, DataGridViewCellEventArgs e, string category)
        {
            try
            {
                string json2 = GET2("https://od-api.oxforddictionaries.com:443/api/v1/entries/en/" + senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Trim().ToLower() + "/synonyms;antonyms");// + category);


                var words = JsonConvert.DeserializeObject<WordObject>(json2);


                string s = "";
               // if (category == "synonyms")
                //{
                    if (words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses != null && words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses[0].synonyms!=null)
                    {

                        foreach (Synonym text in words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses[0].synonyms)
                        {
                            s = s + UppercaseFirst(text.text) + "\n\t";
                        }
                    }
                    else if (words.results[0].lexicalEntries[0].entries[0].senses != null && words.results[0].lexicalEntries[0].entries[0].senses[0].synonyms != null)

                    {
                        foreach (Synonym text in words.results[0].lexicalEntries[0].entries[0].senses[0].synonyms)
                        {
                            s = s + UppercaseFirst(text.text) + "\n\t";
                        }


                    }

                if (s.Trim() != "") { s = "Synonyms:\n\t" + s; }

                // }
                // else
                // {
                string a = "";

                //w += "\rAntonyms:\n\t";

                if (words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses != null && words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses[0].antonyms !=null)
                    {
                        foreach (Antonym text in words.results[0].lexicalEntries[0].entries[0].senses[0].subsenses[0].antonyms)
                        {
                            a = a + UppercaseFirst(text.text) + "\n\t";
                        }
                    }
                    else if (words.results[0].lexicalEntries[0].entries[0].senses != null && words.results[0].lexicalEntries[0].entries[0].senses[0].antonyms != null)

                    {
                        foreach (Antonym2 text in words.results[0].lexicalEntries[0].entries[0].senses[0].antonyms)
                        {
                            a = a + UppercaseFirst(text.text) + "\n\t";
                        }
                    }

                if (a.Trim() != "") { a = "\rAntonyms:\n\t" + a; }

                // }


                string json22 = GET2("https://od-api.oxforddictionaries.com:443/api/v1/entries/en/" + senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Trim().ToLower());


                var wordss = JsonConvert.DeserializeObject<WordObject>(json22);

                string def = wordss.results[0].lexicalEntries[0].entries[0].senses[0].definitions[0];
                string exa = "";

                string w = "";

                if (wordss.results[0].lexicalEntries[0].entries[0].senses[0].examples != null)
                {
                    exa = wordss.results[0].lexicalEntries[0].entries[0].senses[0].examples[0].text;
                    w += "\nDefinitions:\n" + UppercaseFirst(def) + "\n\tExample: " + UppercaseFirst(exa) + "\n\n";

                }
                else{
                    w += "\nDefinitions:\n" + UppercaseFirst(def) + "\n\n";

                }

               // w += "\nDefinitions:\n " + UppercaseFirst(def) + "\n\tExample: " + UppercaseFirst(exa) + "\n\n";
                if (wordss.results[0].lexicalEntries[0].entries[0].senses[0].subsenses != null)
                {
                    foreach (Subsens text in wordss.results[0].lexicalEntries[0].entries[0].senses[0].subsenses)
                    {
                        if (text.definitions != null)
                        {
                            w = w + UppercaseFirst(text.definitions[0]) + "\n\t";
                        }
                        if (text.examples != null)
                        {
                            w += "Example: " + UppercaseFirst(text.examples[0].text) + "\n\n";
                        }
                    }
                }

                MessageBox.Show(s+a+w, "More information for: " + senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //Pronounce specific word
        public void Pronounce(string word)
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
