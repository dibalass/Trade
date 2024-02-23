using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;
using Trade.Models;

namespace Trade.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        private int totalRecords = 0;

        public ProductsWindow(bool isAdmin)
        {
            InitializeComponent();

            var context = new TradeContext();
            productsListView.ItemsSource = context.Products
                .Include(p => p.ProductManufacturer)
                .ToList();

            productsListView.ItemsSource = context.Products
                .Include(p => p.ProductCategory)
                .ToList();



            // производители
            var manufacturers = context.Manufacturers.ToList();
            manufacturers.Insert(0, new Manufacturer { ManufacturerId = 0, ManufacturerName = "Все производители" });
            filterComboBox.ItemsSource = manufacturers;

            // производители
            var categories = context.Categories.ToList();
            categories.Insert(0, new Category { CategoryId = 0, CategoryName = "Все категории" });
            filterCategoriesComboBox.ItemsSource = categories;

            filterCategoriesComboBox.SelectedIndex = 0;
            filterComboBox.SelectedIndex = 0;
            sortingComboBox.SelectedIndex = 0;

            LoadTotalRecords();
            UpdateProductsList();
            updateButton.IsEnabled = false;
            deleteButton.IsEnabled = false;

            if (!isAdmin)
            {
                addButton.Visibility = Visibility.Hidden;
                deleteButton.Visibility = Visibility.Hidden;
                updateButton.Visibility = Visibility.Hidden;
            }
        }

        private void LoadTotalRecords()
        {
            using (var context = new TradeContext())
            {
                totalRecords = context.Products.Count();
            }
        }

        private void searchProduct(object sender, TextChangedEventArgs e) => UpdateProductsList();
        private void filterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateProductsList();
        private void filterCategoriesComboBox_SelectionChanged (object sender, SelectionChangedEventArgs e) => UpdateProductsList();
        private void sortingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateProductsList();


        private void UpdateProductsList()
        {
            using (var context = new TradeContext())
            {
                var query = context.Products.Include(p => p.ProductManufacturer).Include(p => p.ProductCategory).AsQueryable();

                // Фильтрация по производителю
                var selectedManufacturer = (Manufacturer)filterComboBox.SelectedItem;
                if (selectedManufacturer != null && selectedManufacturer.ManufacturerId != 0)
                {
                    query = query.Where(p => p.ProductManufacturerId == selectedManufacturer.ManufacturerId);
                }

                // Фильтрация по категориям
                var selectedCategories = (Category) filterCategoriesComboBox.SelectedItem;
                if (selectedCategories != null && selectedCategories.CategoryId != 0)
                {
                    query = query.Where(p => p.ProductCategoryId == selectedCategories.CategoryId);
                }

                // Поиск по названию товара
                var searchQuery = searchTextBox.Text;
                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    query = query.Where(p => p.ProductName.Contains(searchQuery));
                }

                // Сортировка
                switch (sortingComboBox.SelectedIndex)
                {
                    case 1: // По возрастанию цены
                        query = query.OrderBy(p => p.ProductCost);
                        break;
                    case 2: // По убыванию цены
                        query = query.OrderByDescending(p => p.ProductCost);
                        break;
                }

                var filteredList = query.ToList();
                productsListView.ItemsSource = filteredList;

                recordsTextBlock.Text = $"Показано {filteredList.Count} из {totalRecords} записей";
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AddButton_Click (object sender, RoutedEventArgs e)
        {
            var window = new AddProductWindow();
            window.ShowDialog();
            UpdateProductsList();
        }

        private void checkSelection (object sender, SelectionChangedEventArgs e)
        {
            bool hasSelectedItems = productsListView.SelectedItems.Count > 0;
            updateButton.IsEnabled = hasSelectedItems;
            deleteButton.IsEnabled = hasSelectedItems;
        }

        private void updateProduct (object sender, RoutedEventArgs e)
        {
            Product? selectedProduct = productsListView.SelectedItem as Product;
            if (selectedProduct is not null)
            {
                var window = new AddProductWindow(selectedProduct, true);
                window.ShowDialog();
                UpdateProductsList();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Product? selectedProduct = productsListView.SelectedItem as Product;
            if (selectedProduct != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить продукт?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new TradeContext())
                    {
                        var productToRemove = context.Products.FirstOrDefault(p => p.ProductArticleNumber == selectedProduct.ProductArticleNumber);

                        if (productToRemove != null)
                        {
                            string article = selectedProduct.ProductArticleNumber;
                            var sorted = context.OrderProducts.Include(p => p.Order).ToList();

                            if (sorted.Any(p => p.ProductArticleNumber == article && p.Order.OrderStatus == 1))
                            {
                                MessageBox.Show("Невозможно удалить продукт, так как он присутствует в одном или нескольких незавершенных заказах.");
                                return;
                            }

                            context.Products.Remove(productToRemove);
                            context.SaveChanges();
                        }
                    }
                    UpdateProductsList();
                }
            }
        }
    }
}
