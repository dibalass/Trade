using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Trade.Models;

namespace Trade.Views
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private Product currentProduct;
        private bool isAdd = false;
        private string originalPhotoString = null;

        public AddProductWindow()
        {
            InitializeComponent();

            currentProduct = new Product();
            DataContext = currentProduct;
            //idLabel.Visibility = Visibility.Collapsed;
            //idTextBox.Visibility = Visibility.Collapsed;
            currentProduct.ProductPhoto = "нет";
            addUpdateButton.Content = "Добавить";
            productNameTextBox.Focus();
            window.Title = "ООО Ткани - добавление продукта";
        }

        public AddProductWindow (Product product, bool isAdd)
        {
            InitializeComponent();
            currentProduct = product;
            this.isAdd = isAdd;
            DataContext = currentProduct;
            //idTextBox.IsReadOnly = true;
            addUpdateButton.Content = "Изменить";
            productNameTextBox.Focus();
            window.Title = "ООО Ткани - изменение продукта";
        }

        private void loadWindow (object sender, RoutedEventArgs e)
        {
            using (var context = new TradeContext())
            {
                //unitComboBox.ItemsSource = context.Products.ToList();
                //articleTextBox.Text = "ProductArticleNumber";

                unitComboBox.ItemsSource = context.Units.ToList();
                unitComboBox.DisplayMemberPath = "UnitName";
                categoriesComboBox.ItemsSource = context.Categories.ToList();
                categoriesComboBox.DisplayMemberPath = "CategoryName";
                suppliersComboBox.ItemsSource = context.Providers.ToList();
                suppliersComboBox.DisplayMemberPath = "ProviderName";
                manufacturerComboBox.ItemsSource = context.Manufacturers.ToList();
                manufacturerComboBox.DisplayMemberPath = "ManufacturerName";

                unitComboBox.SelectedItem = context.Units.FirstOrDefault(u => u.UnitId == currentProduct.PrductUnitId);
                categoriesComboBox.SelectedItem = context.Categories.FirstOrDefault(c => c.CategoryId == currentProduct.ProductCategoryId);
                suppliersComboBox.SelectedItem = context.Providers.FirstOrDefault(p => p.ProviderId == currentProduct.ProductProviderId);
                manufacturerComboBox.SelectedItem = context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == currentProduct.ProductManufacturerId);

            }
        }

        private void addUpdateProduct (object sender, RoutedEventArgs e)
        {
            var validationContext = new ValidationContext(currentProduct);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var isValid = Validator.TryValidateObject(currentProduct, validationContext, results, true);

            if (!isValid)
            {
                errorsLabel.Content = string.Empty;

                foreach (var error in results)
                {
                    errorsLabel.Content += error.ErrorMessage + "\r\n";
                }
                return;
            }

            using (var context = new TradeContext())
            {
                if (isAdd) context.Products.Update(currentProduct);
                else context.Entry(currentProduct).State = EntityState.Added;
                context.SaveChanges();
            }

            originalPhotoString = currentProduct.ProductPhoto;

            Close();
        }

        private void updatePhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Изображения (*.png;*.jpg)|*.png;*.jpg",
                Title = "Выбор изображения"
            };

            if (dialog.ShowDialog() == true)
            {
                if (!string.IsNullOrEmpty(originalPhotoString) && originalPhotoString != "нет")
                { 
                    var oldPhotoFullPath = Path.Combine(Environment.CurrentDirectory, "Images", originalPhotoString);
                    if (File.Exists(oldPhotoFullPath))
                    {
                        File.Delete(oldPhotoFullPath);
                    }
                }    
                var newPhotoName = Path.GetRandomFileName() + ".png";
                var selectedPhoto = dialog.FileName;
                var newPhotoFullName = Path.Combine(Environment.CurrentDirectory, "Images", newPhotoName);

                if (!IsImageSizeValid(selectedPhoto))
                {
                    MessageBox.Show("Размер изображение слишком велик. Пожалуйста, выберите другое изображение.");
                    return;
                }

                File.Copy(selectedPhoto, newPhotoFullName);
                currentProduct.ProductPhoto = newPhotoName;

                DataContext = null;
                DataContext = currentProduct;
            }

        }

        private bool IsImageSizeValid (string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            return fileInfo.Length <= 2097152;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
