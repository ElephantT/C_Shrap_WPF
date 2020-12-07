using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab18
{
    /*Применить в приложении для ввода анкетных данных пользователя связывание
с источниками данных. Рассмотреть связывание с простыми элементами управления и списками*/
    public partial class MainWindow : Window
    {
        List<Person> people_that_passed_form = new List<Person>();
        bool next_color = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddPerson(object sender, RoutedEventArgs e)
        {
            string text_in_form = name.Text;
            string job_in_form = job.Text;
            string city_in_form = (city.Children.OfType<RadioButton>()
                .FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value)).Content.ToString();
            Person to_add = new Person(text_in_form, job_in_form, city_in_form);
            people_that_passed_form.Add(to_add);
            AllAdded.Items.Add(new ListBoxItem
            {
                Content = to_add,
                Background = next_color ?
                Brushes.DarkTurquoise : Brushes.LightGray
            });
            lvDataBinding.ItemsSource = people_that_passed_form;
            lvDataBinding.Items.Refresh();
            MessageBox.Show("Данный человек добавлен в список прошедших опрос анкеты");
            next_color = next_color == true ? false : true;
        }
    }
}
