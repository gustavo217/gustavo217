using DesafioLeoMadeira.ViewObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace DesafioLeoMandeira.Services
{
    public abstract class BaseServices
    {

        private const string PONTO = ".";
        private const string TRACO = "-";

        public async Task<T> ExecutarPostWebApi<T>(string urlApi, object obj)
        {

            Uri uri = new Uri(urlApi);

            string resultado = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;

                string json = JsonConvert.SerializeObject(obj);

                var content = new StringContent(json, Encoding.UTF8, "application/json");                                                               

                var response = client.PostAsync(urlApi, content).Result;


                resultado = await response.Content.ReadAsStringAsync();
            }

            return Deserializar<T>(resultado);

        }
       
        public async Task<T> ExecutarGetWebApi<T>(string urlApi, object obj)
        {

            Uri uri = new Uri(urlApi);

            string resultado = string.Empty;

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = uri;

                var result = await client.GetAsync("");

                HttpContent content = result.Content;

                resultado = content.ReadAsStringAsync().Result;

            }

            return Deserializar<T>(resultado);

        }       
        public T Deserializar<T>(string content)
        {


            FileInfo f = new FileInfo("Deserializando.log");

            var sr = f.AppendText();


            T obj = default(T);


            if (obj!= null)
                sr.WriteLine("------------------ desserializando o objeto " + content);

            try
            {
               
                obj = (T)JsonConvert.DeserializeObject(content, typeof(T));


                sr.WriteLine("------------------ objeto desserializado com sucesso ------------------- ");


                return obj;

            }
            catch (Exception err)
            {
                sr.WriteLine("------------------ erro ao desseralizar o objeto " + content + "-----------------");

                sr.WriteLine("");

                sr.WriteLine("msg de erro " + err.Message);

                sr.WriteLine("");

                sr.WriteLine("stack trace " + err.StackTrace);

                //return default;
            }

            finally
            {
                sr.Flush();
                sr.Close();
                sr.Dispose();
            }

            return obj;
        }


       


    }
}
