using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsPresentationProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] words = { "PASTE", "PIZZA", "PASTA", "BURGER", "SHORMA", "LUX" };
        int current =0;
        public MainWindow(string cat)
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            ds.ReadXml(@"D:\HADI\WindowsPresentationProject\WindowsPresentationProject\words.xml");
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "cat='" + cat + "'";
            words = new string[dv.Count];
            for (int i = 0; i < dv.Count; i++)
            {
                words[i] = dv[i][1].ToString();
            }
            next();
        }
        public void next()
        {
            guess_panel.Children.Clear();
            for (int i = 0; i < words[current].Length; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = "_";
                tb.FontSize = 40;
                tb.Margin = new Thickness(10, 0, 0, 0);
                guess_panel.Children.Add(tb);
            }
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            char which = Convert.ToChar(btn.Content.ToString());
            for (int i = 0; i < words[current].Length; i++)
			{
                if (words[current][i] == which)
	           {
                   TextBlock tb = (TextBlock)guess_panel.Children[i];
 		           tb.Text = btn.Content.ToString();
	           }   
			}
            bool alldone = true;
            for (int i = 0; i < words[current].Length; i++)
            {
                TextBlock tb = (TextBlock)guess_panel.Children[i];
                if(tb.Text == "_")
                {
                    alldone = false;
                    break;
                }
            }
            if (alldone)
            {
                current++;
                next();
                    
            }
            }
        }
    }

