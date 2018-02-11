using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SystemTreeView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object dummyNode = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FoldersTree_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in Directory.GetLogicalDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = s;
                item.Tag = s;
                item.FontWeight = FontWeights.Normal;
                item.Items.Add(dummyNode);
                item.Expanded += new RoutedEventHandler(folder_Expanded);
                foldersTree.Items.Add(item);
            }
        }

        void folder_Expanded(object sender, RoutedEventArgs e)
        {
            if (sender is TreeViewItem item && item.Items.Count == 1 && item.Items[0] == null) //Check if folder wasn`t opened yet
            {
                item.Items.Clear(); //Not very good solution

                try
                {
                    
                    foreach (string s in Directory.GetDirectories(item.Tag.ToString()))
                    {
                        TreeViewItem subItem = new TreeViewItem
                        {
                            Header = s.Substring(s.LastIndexOf("\\")+1),
                            Tag = s,
                            FontWeight = FontWeights.Normal,
                        };
                        subItem.Items.Add(dummyNode); 
                        subItem.Expanded += new RoutedEventHandler(folder_Expanded);
                        subItem.MouseRightButtonUp += SubItem_MouseRightButtonUp;
                        
                        item.Items.Add(subItem);
                    }
                    foreach (string s in Directory.GetFiles(item.Tag.ToString()))
                    {
                        var Ico = System.Drawing.Icon.ExtractAssociatedIcon(s);
                        TreeViewItem subItem = new TreeViewItem
                        {
                            Header = s.Substring(s.LastIndexOf("\\") + 1),
                            Tag = s,
                            FontWeight = FontWeights.Bold,
                            
                        };
                        
                        subItem.MouseRightButtonUp += SubItem_MouseRightButtonUp;
                        item.Items.Add(subItem);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void SubItem_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if ( sender is TreeViewItem temp && foldersTree.SelectedItem == temp)
            {
                MessageBox.Show(temp.Tag.ToString());
            }
        }
    }
}
