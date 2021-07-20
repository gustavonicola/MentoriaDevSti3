﻿using MentoriaDevSti3.View.UserControls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MentoriaDevSti3.View
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            InicializarUc(sender);
        }

        private void InicializarUc(object sender)
        {
            if(sender is Button btn)
            {
                switch (btn.Name)
                {
                    case nameof(BtnProduto):
                        Conteudo.Content = new UcProdutos();
                        break;
                    
                    case nameof(BtnClientes):
                        Conteudo.Content = new UcClientes();
                        break;

                    case nameof(BtnPedido):
                        Conteudo.Content = new UcPedido();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
