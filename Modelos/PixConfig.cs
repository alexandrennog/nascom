using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class PixConfig
    {

        [JsonProperty("banco")]
        public string Banco { get; set; }

        [JsonProperty("cliente")]
        public int Cliente { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("chave")]
        public string Chave { get; set; }


        [JsonProperty("client_id")]
        public string Client_id { get; set; }

        [JsonProperty("client_secret")]
        public string client_secret { get; set; }

        [JsonProperty("PathCertificate")]
        public string PathCertificate { get; set; }

        [JsonProperty("PassCertificate")]
        public string PassCertificate { get; set; }


    }
}
