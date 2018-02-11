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
using System.Collections.ObjectModel;

namespace SystemTreeView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public class Node //ViewModel
    {
        public string Header { get; set; }
        public string Tag { get; set; }
        public string Icon { get; set; }
        public ObservableCollection<Node> Nodes { get; set; }
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<Node> Nodes;

        public MainWindow()
        {
            InitializeComponent();
            Nodes = new ObservableCollection<Node>();
            foldersTree.ItemsSource = Nodes;
        }

        private void FoldersTree_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in Directory.GetLogicalDrives())
            {
                Node item = new Node
                {
                    Header = s,
                    Tag = s,
                    Icon = "drive",
                    Nodes = new ObservableCollection<Node>() { null}
                };
                Nodes.Add(item);
            }
        }

        void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is TreeViewItem item && item.DataContext is Node nodeItem && nodeItem.Nodes.Count == 1 && nodeItem.Nodes[0] == null)
                {
                    nodeItem.Nodes.Clear();
                    foreach (string s in Directory.GetDirectories(nodeItem.Tag))
                    {
                        Node newItem = new Node
                        {
                            Header = s.Substring(s.LastIndexOf(@"\") + 1),
                            Tag = s,
                            Icon = "folder",
                            Nodes = new ObservableCollection<Node>() { null }
                            
                        };
                        nodeItem.Nodes.Add(newItem);
                    }

                    foreach (string s in Directory.GetFiles(nodeItem.Tag))
                    {
                        Node newItem = new Node
                        {
                            Header = s.Substring(s.LastIndexOf(@"\") + 1),
                            Tag = s,
                            Icon = "file " + s,
                            Nodes = new ObservableCollection<Node>() { }
                        };
                        
                        nodeItem.Nodes.Add(newItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ImageSource ImageSourceFromIcon(System.Drawing.Icon ico)
        {
            ImageSource imageSource;

            using (System.Drawing.Bitmap bmp = ico.ToBitmap())
            {
                var stream = new MemoryStream();
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                imageSource = BitmapFrame.Create(stream);
                return imageSource;
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
