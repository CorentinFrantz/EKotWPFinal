using Newtonsoft.Json;
using ProjetC.Model;
using ProjetC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetC.DAL
{
    public class DataAccess
    {

        public async Task<List<FAQ>> getAllFaq()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://ekotprojet.azurewebsites.net/api/faqs");
            string json = await response.Content.ReadAsStringAsync();
            var faqList = Newtonsoft.Json.JsonConvert.DeserializeObject<FAQ[]>(json);
            return faqList.ToList<FAQ>();
        }

        public async Task<List<RendezVous>> getAllProblem()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://ekotprojet.azurewebsites.net/api/rendezvous");
            string json = await response.Content.ReadAsStringAsync();
            var problemList = Newtonsoft.Json.JsonConvert.DeserializeObject<RendezVous[]>(json);
            return problemList.ToList<RendezVous>();
        }

        public async Task<bool> NewRendezVous(RendezVous rdv)
        {
            HttpClient client = new HttpClient();
            string json = JsonConvert.SerializeObject(rdv);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://ekotprojet.azurewebsites.net/api/rendezvous", content);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<List<Permanence>> getAllPerma()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://ekotprojet.azurewebsites.net/api/permanences");
            string json = await response.Content.ReadAsStringAsync();
            var problemList = Newtonsoft.Json.JsonConvert.DeserializeObject<Permanence[]>(json);
            return problemList.ToList<Permanence>();
        }


        public async Task<List<Admin>> getPassword()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://ekotprojet.azurewebsites.net/api/administrateurs");
            string json = await response.Content.ReadAsStringAsync();
            var admin = Newtonsoft.Json.JsonConvert.DeserializeObject<Admin[]>(json);
            return admin.ToList<Admin>();
        }
    }
}
