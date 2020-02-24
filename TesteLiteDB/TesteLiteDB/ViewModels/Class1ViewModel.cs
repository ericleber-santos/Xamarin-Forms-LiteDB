using System.Linq;
using System.Windows.Input;
using TesteLiteDB.Data;
using TesteLiteDB.Models;
using Xamarin.Forms;
using System.Collections.Generic;

namespace TesteLiteDB.ViewModels
{
    public class Class1ViewModel : BaseViewModel
    {
        public ICommand ExibirUltimoCommand => new Command(() => ExibirUltimo(), () => IsNotBusy);

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }

            set
            {
                SetProperty(ref _descricao, value);               
            }
        }      

        public Class1ViewModel()
        {
            Title = "MainPage - TesteLiteDB";            
            Descricao = "Clique no Botão \"Exibir Último Registro\"!";
        }

        public bool Salvar()
        {
            int codigo = (Class1DAO.GetUltimoInserido() == null ? 100 : Class1DAO.GetUltimoInserido().CLASS_CODIGO + 1);

            if (Class1DAO.Atualizar(new Class1() { CLASS_CODIGO = codigo, CLASS_DESCRICAO = $"{codigo} - Testando LiteDB" }))
            {
                return true;
            }

            return false;
        }

        public void ExibirUltimo()
        {
            if(!IsBusy)
            {
                IsBusy = true;              

                if (Salvar())
                {                  
                    Descricao = (Class1DAO.GetUltimoInserido() != null ? Class1DAO.GetUltimoInserido().CLASS_DESCRICAO : "Oops deu ruim!");  
                }

                IsBusy = false;
            }            
        }
    }
}
