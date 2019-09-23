using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_consultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_consultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        //RECEBE CEP DIGITADO
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            //COLOCA CEP NA URL
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();
            //RECEBE JSON
            string Conteudo = wc.DownloadString(NovoEnderecoURL);
            //DESERIALIZA, CONVERTE P/ OBJ
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            //CASO O JSON RETURNE NULL (EX: CEP: 00000000 NAO ENCONTRADO)
            if (end.Cep == null) return null;

            return end;
        }
    }
}
