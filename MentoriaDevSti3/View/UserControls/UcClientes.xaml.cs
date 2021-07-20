using MentoriaDevSti3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MentoriaDevSti3.View.UserControls
{
    /// <summary>
    /// Interaction logic for UcClientes.xaml
    /// </summary>
    public partial class UcClientes : UserControl
    {
        private UcClienteViewModel UcClientevm = new UcClienteViewModel();

        public UcClientes()
        {
            InitializeComponent();

            DataContext = UcClientevm;
            UcClientevm.ClientesAdicionados = new ObservableCollection<ClienteViewModel>();
            UcClientevm.DataNascimento = new DateTime(1990, 1, 1);
        }

        private bool ValidarCliente()
        {
            if (string.IsNullOrEmpty(UcClientevm.Nome))
            {
                MessageBox.Show("O Campo nome é obrigatório.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }

        private void AdicionarCliente()
        {
            var novoCliente = new ClienteViewModel
            {
                Nome = UcClientevm.Nome,
                DataNascimento = UcClientevm.DataNascimento,
                Cep = UcClientevm.Cep,
                Endereco = UcClientevm.Endereco,
                Cidade = UcClientevm.Cidade
            };

            UcClientevm.ClientesAdicionados.Add(novoCliente);
        }

        private void AlterarCliente()
        {
            // será desenvolvido na aula de banco de dados
        }

        private void LimparCampos()
        {
            UcClientevm.Nome = "";
            UcClientevm.DataNascimento = new DateTime(1900, 1, 1);
            UcClientevm.Cep = 0;
            UcClientevm.Endereco = "";
            UcClientevm.Cidade = "";
            UcClientevm.Alteracao = false;
        }

        private void PreencherCampos(ClienteViewModel cliente)
        {
            UcClientevm.Nome = cliente.Nome;
            UcClientevm.DataNascimento = cliente.DataNascimento;
            UcClientevm.Cep = cliente.Cep;
            UcClientevm.Endereco = cliente.Endereco;
            UcClientevm.Cidade = cliente.Cidade;

            UcClientevm.Alteracao = true;
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCliente())
                return;

            if (UcClientevm.Alteracao)
            {
                AlterarCliente();
            }
            else
            {
                AdicionarCliente();
            }

            LimparCampos();
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = (sender as Button).Tag as ClienteViewModel;

            PreencherCampos(cliente);
        }

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
