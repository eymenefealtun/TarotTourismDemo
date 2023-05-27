﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;

namespace Tourism.MainPage.MVVM.View
{
    public partial class CustomerOperationView : UserControl
    {

        private ICustomerOperationService _customerOperationService;
        public string _documentCode;
        public int _operationId;

        public CustomerOperationView()
        {
        }

        public CustomerOperationView(int operationId, string documentCode)
        {
            InitializeComponent();
            _customerOperationService = Instancefactory.GetInstance<ICustomerOperationService>();
            _operationId = operationId;
            _documentCode = documentCode;
            dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomerOperation(_operationId);
            txbOperation.Text = _documentCode;
        }

        private void dgwCustomerOperation_Loaded(object sender, RoutedEventArgs e)
        {
            if (dgwCustomerOperation.Items.Count > 0)
            {
                ColoringRowsByDocumentCode();
                DeleteBedType();
            }
        }

        private void DeleteBedType()
        {
            for (int i = 0; i < dgwCustomerOperation.Items.Count; i++)
            {
                DataGridRow dataGridRow = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cellContent = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRow) as TextBlock;               
                
                if (cellContent.Text == "Double")
                {
                    DataGridRow dataGridRowPlusOne = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i + 1);
                    TextBlock cellContentPlusOne = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRowPlusOne) as TextBlock;
                    cellContentPlusOne.Text = String.Empty;
                    i++;
                }
                else if (cellContent.Text == "Triple")
                {
                    DataGridRow dataGridRowPlusOne = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i + 1);
                    TextBlock cellContentPlusOne = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRowPlusOne) as TextBlock;

                    DataGridRow dataGridRowPlusTwo = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i + 2);
                    TextBlock cellContentPlusTwo = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRowPlusTwo) as TextBlock;
                    cellContentPlusOne.Text = String.Empty;
                    cellContentPlusTwo.Text = String.Empty;
                    i += 2;
                }
                else if (cellContent.Text == "Quad")
                {
                    DataGridRow dataGridRowPlusOne = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i + 1);
                    TextBlock cellContentPlusOne = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRowPlusOne) as TextBlock;

                    DataGridRow dataGridRowPlusTwo = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i + 2);
                    TextBlock cellContentPlusTwo = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRowPlusTwo) as TextBlock;

                    DataGridRow dataGridRowPlusThree = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i + 3);
                    TextBlock cellContentPlusThree = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRowPlusThree) as TextBlock;

                    cellContentPlusOne.Text = String.Empty;
                    cellContentPlusTwo.Text = String.Empty;
                    cellContentPlusThree.Text = String.Empty;
                    i += 3;
                }
            }
        }

        private void ColoringRowsByDocumentCode()
        {
            DataGridRow firstRow = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(0);
            firstRow.Background = Brushes.White;
            int j = 0;

            for (int i = 1; i < dgwCustomerOperation.Items.Count; i++)
            {
                DataGridRow dataGridRow = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cellContent = dgwCustomerOperation.Columns[8].GetCellContent(dataGridRow) as TextBlock;

                DataGridRow dataGridRowMinusOne = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i - 1);
                TextBlock cellContentMinusOne = dgwCustomerOperation.Columns[8].GetCellContent(dataGridRowMinusOne) as TextBlock;

                if (cellContent.Text == cellContentMinusOne.Text && j == 0)
                {
                    dataGridRow.Background = Brushes.White;
                }
                else if (cellContent.Text != cellContentMinusOne.Text && j == 0)
                {
                    dataGridRow.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#dbdcdc");
                    j = 1;
                }
                else if (cellContent.Text == cellContentMinusOne.Text && j != 0)
                {
                    dataGridRow.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#dbdcdc");
                    j++;
                }
                else if (cellContent.Text != cellContentMinusOne.Text && j != 0)
                {
                    dataGridRow.Background = Brushes.White;
                    j = 0;
                }
            }
        }

        private void tboxCustomerOperationSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!String.IsNullOrEmpty(tboxCustomerOperationSearch.Text))
            {
                dgwCustomerOperation.ItemsSource = _customerOperationService.SearchCustomerOperation(tboxCustomerOperationSearch.Text, _operationId);
            }
            else
            {
                dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomerOperation(_operationId);
            }
        }

        private void GetCustomerOperationView()
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            GetCustomerOperationView();
        }

        private void btnBack_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnBack.Opacity = 0.1;
        }


    }
}
