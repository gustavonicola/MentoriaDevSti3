using MentoriaDevSti3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// Interaction logic for UcPedido.xaml
    /// </summary>
    public partial class UcPedido : UserControl
    {

        private UcPedidoViewModel UcPedidoVm = new UcPedidoViewModel();

        
        public UcPedido()
        {
            InitializeComponent();
            
            InicializarOperacao();

        }

        private void CmbProduto_DropDownClosed(object sender, EventArgs e)
        {
            if(sender is ComboBox cmb && cmb.SelectedItem is ProdutosViewModel produto)
            {
                UcPedidoVm.ValorUnit = produto.Valor;
            }
        }

        private void btnAdicionarItem_Click(object sender, RoutedEventArgs e)
        {
            AdicionarItem();
        }

        private void BtnFinalizarPedido_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InicializarOperacao()
        {
            DataContext = UcPedidoVm;

            UcPedidoVm.ListaClientes = new ObservableCollection<ClienteViewModel>
            {
                new ClienteViewModel { Nome = "Cliente 1" },
                new ClienteViewModel { Nome = "Cliente 2" }
            };

            UcPedidoVm.ListaProdutos = new ObservableCollection<ProdutosViewModel>
            {
                new ProdutosViewModel { Nome = "Produto 1", Valor = 10},
                new ProdutosViewModel { Nome = "Produto 2", Valor = 20},
            };

            UcPedidoVm.ListaPagamentos = new ObservableCollection<string>
            {
                "Dinheiro",
                "Boleto",
                "Cartão de Crédito",
                "Cartão de Débito",
                "Pix",
            };

            UcPedidoVm.Quantidade = 1;
            UcPedidoVm.ItemsAdicionados = new ObservableCollection<UcPedidoItemViewModel>();
        }

        private void AdicionarItem()
        {
            var produtoSelecionado = CmbProduto.SelectedItem as ProdutosViewModel;

            var itemVm = new UcPedidoItemViewModel
            {
                Nome = produtoSelecionado.Nome,
                Quantidade = UcPedidoVm.Quantidade,
                ValorUnit = UcPedidoVm.ValorUnit,
                ValorTotalItem = UcPedidoVm.Quantidade * UcPedidoVm.ValorUnit
            };

            UcPedidoVm.ItemsAdicionados.Add(itemVm);

            UcPedidoVm.ValorTotalPedido = UcPedidoVm.ItemsAdicionados.Sum(i => i.ValorTotalItem);
        }
    }
}
