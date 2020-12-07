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

namespace ISPlabs
{
    /*Создать однооконное приложение WPF,
используя минимум элементов управления. Ознакомится со структурой проектов WPF. */
    public partial class MainWindow : Window
    {
        string leftop = ""; // Левый операнд
        string operation = ""; // Знак операции
        string rightop = ""; // Правый операнд

        public MainWindow()
        {
            InitializeComponent();
            string text = "Да, в интернете полным полно готовых калькуляторов, и не составляет\n" +
                        " труда подсматривать идеи и даже смотреть код (части кода я видел готовые в инете) \n," +
                        " так что структуру я взял из готового решения и сколько-то его дополнил, всё таки в условии \n" +
                        "у нас свобода выбора задания, хотя я не думал, что калькулятор так легко делается в WPF";
            Comment.Text = text;
            // Обработчик для всех кнопок на гриде
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            textBlock.Text += s;
            int num;
            bool result = Int32.TryParse(s, out num);
            // Если текст - это число
            if (result == true)
            {
                if (operation == "")
                {
                    // надо почистить, если при ошибках что выводили и обновляли всё
                    if (leftop == "")
                    {
                        textBlock.Text = "";
                        textBlock.Text += s;
                    }
                    leftop += s;
                }
                else
                {
                    rightop += s;
                }
            }
            // Если было введено не число
            else
            {
                if (s == "=")
                {
                    if (operation == "/" && Int64.Parse(rightop) == 0)
                    {
                        textBlock.Text += "Айяйяй, не делите на ноль пожалуйста ";
                        leftop = "";
                        rightop = "";
                        operation = "";
                    }
                    else
                    {
                        Update_RightOp();
                        textBlock.Text += rightop;
                        operation = "";
                    }
                    string text = "Не делал обработку багов серьёзных с операндами, \n " +
                            "из стандартных косяков калькуляторов обработал деление на ноль и ещё пару штук, \n" +
                            "но не всё, так что совсем грустно не будет :)";
                    Comment.Text = text;
                }
                else if (s == "CLEAR")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "";
                }
                // Получаем операцию
                else
                {
                    // Если правый операнд уже имеется, то присваиваем его значение левому
                    // операнду, а правый операнд очищаем, читерство конеш, и не скажешь при использовании
                    // что делается так, но всё же
                    if (operation == "-" && s == "-" && rightop == "")
                    {
                        operation = "+";
                        return;
                    }
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }
        // Обновляем значение правого операнда
        private void Update_RightOp()
        {
            int num1 = Int32.Parse(leftop);
            int num2 = Int32.Parse(rightop);
            // И выполняем операцию
            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    rightop = (num1 / num2).ToString();
                    break;
            }
        }
    }
}
