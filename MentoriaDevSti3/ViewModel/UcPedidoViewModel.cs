using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MentoriaDevSti3.ViewModel
{
    public class UcPedidoViewModel : PropertyChange
    {
        private ObservableCollection<ClienteViewModel> _listaClientes;
        
        public ObservableCollection<ClienteViewModel> ListaClientes
        {
            get => _listaClientes;
            set
            {
                _listaClientes = value;
                OnPropertyChanged(nameof(ListaClientes));
            }
        }

        private ObservableCollection<ProdutosViewModel> _listaProdutos;

        public ObservableCollection<ProdutosViewModel> ListaProdutos
        {
            get => _listaProdutos;
            set
            {
                _listaProdutos = value;
                OnPropertyChanged(nameof(ListaProdutos));
            }
        }

        private ObservableCollection<string> _listaPagamentos;

        public ObservableCollection<string> ListaPagamentos
        {
            get => _listaPagamentos;
            set
            {
                _listaPagamentos = value;
                OnPropertyChanged(nameof(ListaPagamentos));
            }
        }

        private int _quantidade;

        public int Quantidade
        {
            get => _quantidade;
            set
            {
                _quantidade = value;
                OnPropertyChanged(nameof(Quantidade));
            }
        }


        private decimal _valorUnit;

        public decimal ValorUnit
        {
            get => _valorUnit;
            set
            {
                _valorUnit = value;
                OnPropertyChanged(nameof(ValorUnit));
            }
        }


        private decimal _valorTotalPedido;

        public decimal ValorTotalPedido
        {
            get => _valorTotalPedido;
            set
            {
                _valorTotalPedido = value;
                OnPropertyChanged(nameof(ValorTotalPedido));
            }
        }


        private ObservableCollection<UcPedidoItemViewModel> _itemsAdicionados;

        public ObservableCollection<UcPedidoItemViewModel> ItemsAdicionados
        {
            get => _itemsAdicionados;
            set
            {
                _itemsAdicionados = value;
                OnPropertyChanged(nameof(ItemsAdicionados));
            }
        }

    }
}
