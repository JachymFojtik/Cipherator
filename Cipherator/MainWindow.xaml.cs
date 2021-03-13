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

namespace Cipherator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            rawXor.Tag = finXor;
            finXor.Tag = rawXor;
        }      
        static string XOR(string text, string key)
            {
                var result = new StringBuilder();

                for (int c = 0; c < text.Length; c++)
                    result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));

                return result.ToString();
            }
        static string Caesar(string value, int shift)
        {
            shift %= 26;
            char[] buffer = value.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                letter = (char)(letter + shift);
                buffer[i] = letter;
            }
            return new string(buffer);
        }

        private void Xor_Write(object sender, TextChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            (t.Tag as TextBox).Text = XOR(t.Text, "PRAVDA");
        }

        private void Caesar_Write(object sender, TextChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Name == "rawCae")
            {
                finCae.Text = Caesar(rawCae.Text, 7);
                return;
            }
            else rawCae.Text = Caesar(finCae.Text, -7);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vlevo vložte text, který chcete zašifrovat.\n" +
                            "Vpravo se vypíše zašifrovaný text\n" +
                            "Pro dešivrování již zašifrovaného textu, vložte jej vpravo");
        }
    }
}
