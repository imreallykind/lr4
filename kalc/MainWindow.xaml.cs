using kabachok;
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

namespace kalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool IsOperation = false;
        public MainWindow()
        {
            InitializeComponent();
            EnteringField.Text=Properties.Settings.Default.save;
            langCombo.SelectedIndex = Properties.Settings.Default.LangSave;
        }
        private void GetResult()
        {
            Kabachok kabachok = new Kabachok();
            if (kabachok.GetResult(EnteringField.Text) == "$")
            {
                MessageBox.Show("АДНА ОШИПКА И ТЫ ИДЁШЬ НАХУЙ СО СВОИМИ КАБАЧКАМИ");
                EnteringField.Text = "";
            }
            else
            {
                EnteringField.Text = kabachok.GetResult(EnteringField.Text);
                Properties.Settings.Default.save = EnteringField.Text;
                Properties.Settings.Default.Save();
            }
            IsOperation = false;
            //char Operation  = ' ';
            //bool flag = false;
            //string a = "", b = "";
            //string str = EnteringField.Text;
            //foreach (char s in str)
            //{
            //    if (Char.IsDigit(s) == true)
            //    {
            //        if (!flag)
            //            a += s.ToString();
            //        else
            //            b += s.ToString();
            //    }
            //    else
            //    {
            //        flag = true;
            //        Operation = s;
            //    }
            //}
            ////MessageBox.Show(a+"$"+Operation.ToString()+"$"+b);
            //if (a.Length < 9 && a.Length != 0 && b.Length < 9 && b.Length != 0)
            //{
            //    switch (Operation)
            //    {
            //        case '+': EnteringField.Text = (Int32.Parse(a) + Int32.Parse(b)).ToString(); break;
            //        case '-': EnteringField.Text = (Int32.Parse(a) - Int32.Parse(b)).ToString(); break;
            //        case '*': EnteringField.Text = (Int32.Parse(a) * Int32.Parse(b)).ToString(); break;
            //        case '/': EnteringField.Text = (Int32.Parse(a) / Int32.Parse(b)).ToString(); break;
            //        default:
            //            MessageBox.Show(Operation.ToString()+" 1ДА ПОШЕЛ ТЫ НАХУЙ СО СВОИМИ КАБАЧКАМИ");
            //            break;
            //    }
            //    IsOperation = false;
            //    Properties.Settings.Default.save = EnteringField.Text;
            //    Properties.Settings.Default.Save();
            //}
            //else MessageBox.Show("ДА ПОШЕЛ ТЫ НАХУЙ СО СВОИМИ КАБАЧКАМИ");
        }
        private void DeletionBtn_Click(object sender, RoutedEventArgs e)
        {
            if(EnteringField.Text.Length != 0)
            {
                string LastSymbol = EnteringField.Text[EnteringField.Text.Length - 1].ToString();
                if (LastSymbol == "+" || LastSymbol == "-" || LastSymbol == "*" || LastSymbol == "/")
                    IsOperation = false;
                EnteringField.Text = EnteringField.Text.Remove(EnteringField.Text.Length-1);
            }
        }
        #region Numbers
        private void OneBtn_Click(object sender, RoutedEventArgs e)
        {
            EnteringField.Text += "1";
        }

        private void TwoBtn_Click(object sender, RoutedEventArgs e)
        {
            EnteringField.Text += "2";
        }

        private void ThreeBtn_Click(object sender, RoutedEventArgs e)
        {
            EnteringField.Text += "3";
        }

        private void FourBtn_Click(object sender, RoutedEventArgs e)
        {
            EnteringField.Text += "4";
        }

        private void FiveBtn_Click(object sender, RoutedEventArgs e)
        {
            EnteringField.Text += "5";
        }

        private void SixBtn_Click(object sender, RoutedEventArgs e)
        {
            EnteringField.Text += "6";
        }

        private void SevenBtn_Click(object sender, RoutedEventArgs e)
        {
            EnteringField.Text += "7";
        }

        private void EightBtn_Click(object sender, RoutedEventArgs e)
        {
            EnteringField.Text += "8";
        }

        private void NineBtn_Click(object sender, RoutedEventArgs e)
        {
            EnteringField.Text += "9";
        }

        private void ZeroBtn_Click(object sender, RoutedEventArgs e)
        {
            EnteringField.Text += "0";
        }

        #endregion
        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!IsOperation)
            {
                IsOperation = true;
                EnteringField.Text += "+";
            }
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!IsOperation)
            {
                IsOperation = true;
                EnteringField.Text += "-";
            }
        }

        private void MultiplicationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!IsOperation)
            {
                IsOperation = true;
                EnteringField.Text += "*";
            }
        }

        private void EqualityBtn_Click(object sender, RoutedEventArgs e)
        {
            GetResult();
            //EnteringField.Text += "=";
        }

        private void DestructionBtn_Click(object sender, RoutedEventArgs e)
        {
            IsOperation = false;
            EnteringField.Text = "";
        }


        private void DevisionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!IsOperation)
            {
                IsOperation = true;
                EnteringField.Text += "/";
            }
        }
        private void LanguageChange(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            string lang = (cb.SelectedItem as ComboBoxItem).Tag.ToString();
            var uri = new Uri("res/" + lang + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            Properties.Settings.Default.LangSave = cb.SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
