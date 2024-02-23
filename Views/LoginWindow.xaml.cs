using System;
using System.Net.WebSockets;
using System.Windows;
using System.Windows.Threading;
using Trade.Models;
using Trade.Views;

namespace Trade
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int blockTime = 10;
        private bool isVisiblePassword = false;

        public MainWindow()
        {
            InitializeComponent();
            loginInput.Focus();
            timer.Tick += Timer_Tick;
        }

        private void blockWindow ()
        {
            IsEnabled = false;
            blockTime = 10;
            timer.Start();
        }

        private void unblockWindow ()
        {
            timer.Stop();
            IsEnabled = true;
            loginButton.Content = "Вход в систему";
        }

        private void Timer_Tick (object? sender, EventArgs e)
        {
            if (blockTime == 0)
            {
                unblockWindow();
                return;
            }

            loginButton.Content = blockTime.ToString();
            blockTime--;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var context = new TradeContext();

            string currentCaptcha = captchaFirstBlock.Text + captchaSecondBlock.Text;
            if (captchaInput.Text.Trim() != currentCaptcha)
            {
                MessageBox.Show("Символы с картинки введены неверно! Окно будет заблокировано",
                    "Ошибка входа",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                updateCaptcha();
                blockWindow();
                return;
            }

            if (!isVisiblePassword) passwordInput.Text = passwordInputHidden.Password;
            else passwordInputHidden.Password = passwordInput.Text;

            var user = context
                .Users
                .FirstOrDefault(u => u.UserLogin == loginInput.Text && u.UserPassword == passwordInput.Text && u.UserPassword == passwordInputHidden.Password);

            if (user is null)
            {
                MessageBox.Show("Неверный логин или пароль. Проверьте введенные данные",
                    "Ошибка входа",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                if (captchaContainer.Visibility != Visibility.Hidden)
                {
                    blockWindow();
                }
                updateCaptcha();
                return;
            }

            var userStatus = user.UserRole;
            if (userStatus == 1)
            {
                ProductsWindow window = new ProductsWindow(true);
                window.Show();
                Close();
            }
            else
            {
                ProductsWindow window = new ProductsWindow(false);
                window.Show();
                Close();
            }
        }

        private DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1),
            IsEnabled = false
        };

        private void updateCaptcha ()
        {
            const string alphabet = "qwertyuiopasdfghjklzxcvbnm1234567890";

            var rng = new Random();

            captchaFirstBlock.Text = $"{alphabet[rng.Next(alphabet.Length)]}{alphabet[rng.Next(alphabet.Length)]}";
            captchaSecondBlock.Text = $"{alphabet[rng.Next(alphabet.Length)]}{alphabet[rng.Next(alphabet.Length)]}";
            captchaSecondBlock.Margin = new Thickness(0, rng.Next(-10, 10), rng.Next(-10, 10), 0);
            captchaContainer.Visibility = Visibility.Visible;
        }

        private void ShowPassword_Checked (object sender, RoutedEventArgs e)
        {
            passwordInputHidden.Visibility = Visibility.Collapsed;
            passwordInput.Visibility = Visibility.Visible;
            passwordInput.Text = passwordInputHidden.Password;
            isVisiblePassword = true;
        }

        private void ShowPassword_Unchecked (object sender, RoutedEventArgs e)
        {
            passwordInputHidden.Visibility = Visibility.Visible;
            passwordInput.Visibility = Visibility.Collapsed;
            passwordInputHidden.Password = passwordInput.Text;
            isVisiblePassword = false;
        }

        private void guestButton_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow window = new ProductsWindow(false);
            window.Show();
            Close();
        }
    }
}