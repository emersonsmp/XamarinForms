using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_consultarCEP.Servico.Modelo;
using App01_consultarCEP.Servico;

namespace App01_consultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()//construtor
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
            
        }

        private void BuscarCEP(object sender, EventArgs args){

            //pega o cep digitado, trim-> remove espaços do fim e inicio;
            string cep = CEP.Text.Trim();

            if (IsValidCEP(cep)){
                try{//Trata excecoes
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if(end != null){
                      RESULTADO.Text = string.Format("Endereço: {2} de {3} {0}, {1}", end.Localidade, end.Uf, end.Logradouro, end.Bairro);
                    }
                    else{
                      DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP: "+ cep, "OK");
                    }
          
                }catch(Exception e){
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
               
            }
           
        }

        //Validações
        private bool IsValidCEP(string cep){
            bool valido = true;

            //verifica se possui 8 numeros:
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }

            int NovoCEP = 0;

            //verifica se só possui numeros:
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas por numeros", "OK");
                valido = false;
            }


            return valido;
        }
    }
}
