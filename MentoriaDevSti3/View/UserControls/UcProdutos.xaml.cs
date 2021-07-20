using MentoriaDevSti3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UcProdutos.xaml
    /// </summary>
    public partial class UcProdutos : UserControl
    {
        private UcProdutoViewModel UcProdutovm = new UcProdutoViewModel();
        public UcProdutos()
        {
            InitializeComponent();
            
            DataContext = UcProdutovm;

            UcProdutovm.ProdutosAdicionados = new ObservableCollection<ProdutosViewModel>();
        }

        private void AlterarProduto()
        {
            // Será desenvolvido na aula de banco de dados.
        }

        private void PreencherCampos(ProdutosViewModel produto)
        {
            UcProdutovm.Nome = produto.Nome;
            UcProdutovm.Valor = produto.Valor;

            UcProdutovm.Alteracao = true;
        }

        private void AdicionarProduto()
        {
            var novoProduto = new ProdutosViewModel
            {
                Nome = UcProdutovm.Nome,
                Valor = UcProdutovm.Valor
            };

            UcProdutovm.ProdutosAdicionados.Add(novoProduto);
        }

        private void LimparCampos()
        {
            UcProdutovm.Nome = "";
            UcProdutovm.Valor = 0;
            UcProdutovm.Alteracao = false;
        }

        private bool ValidarProduto()
        {
            if (string.IsNullOrEmpty(UcProdutovm.Nome))
            {
                MessageBox.Show("O Campo nome é obrigatório.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidarProduto())
                return;

            if (UcProdutovm.Alteracao)
            {
                AlterarProduto();
            }
            else
            {
                AdicionarProduto();
            }
            
            LimparCampos();
        }

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {
            // Será desenvolvido na aula de banco de dados.
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            var produto = (sender as Button).Tag as ProdutosViewModel;
            PreencherCampos(produto);
            
        }

        private void TxtValor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
    }
}