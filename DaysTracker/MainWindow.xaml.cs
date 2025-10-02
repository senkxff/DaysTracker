using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DaysTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string DATA_FILE = "days_data.json";
        private int _count = 0;

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                CountDays.Text = _count.ToString();
                SaveDataToJson(); // Сохраняем при каждом изменении
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += (s, e) => DragMove();
            LoadDataFromJson(); // Загружаем данные при запуске
            CountDays.Text = Count.ToString();
        }

        // Класс для хранения данных в JSON
        public class DaysData
        {
            public int DaysCount { get; set; }
        }

        // Сохранение данных в JSON файл
        private void SaveDataToJson()
        {
            try
            {
                var data = new DaysData { DaysCount = Count };
                string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(DATA_FILE, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Загрузка данных из JSON файла
        private void LoadDataFromJson()
        {
            try
            {
                if (File.Exists(DATA_FILE))
                {
                    string jsonString = File.ReadAllText(DATA_FILE);
                    var data = JsonSerializer.Deserialize<DaysData>(jsonString);
                    _count = data?.DaysCount ?? 0;
                }
                else
                {
                    _count = 0; // Значение по умолчанию, если файл не существует
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _count = 0; // Значение по умолчанию в случае ошибки
            }
        }

        private void Close_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Add_btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Add_btn.Foreground = Brushes.Green;
        }

        private void Add_btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Add_btn.Foreground = Brushes.White;
        }

        private void Minus_btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Minus_btn.Foreground = Brushes.Red;
        }

        private void Minus_btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Minus_btn.Foreground = Brushes.White;
        }

        private void Add_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Count++;
        }

        private void Minus_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Count > 0)
                Count--;
        }

        private void Minus_btn_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Count = 0;
        }

        // Дополнительно: сохраняем данные при закрытии приложения
        protected override void OnClosed(EventArgs e)
        {
            SaveDataToJson();
            base.OnClosed(e);
        }
    }
}