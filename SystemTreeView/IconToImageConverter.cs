using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SystemTreeView
{

    #region HeaderToImageConverter

    [ValueConversion(typeof(string), typeof(bool))]
    public class IconToImageConverter : IValueConverter
    {
        public static IconToImageConverter Instance = new IconToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            ImageSource source = null;
            if (value is string path)
            {
                switch (path)
                {
                    case "drive":
                        source = new BitmapImage(new Uri("pack://application:,,,/Images/diskdrive.png"));
                        break;

                    case "folder":
                        source = new BitmapImage(new Uri("pack://application:,,,/Images/folder.png"));
                        break;

                    default:
                        if (path.StartsWith("file"))
                        {

                            using (System.Drawing.Bitmap bmp = System.Drawing.Icon.ExtractAssociatedIcon(path.Substring(5)).ToBitmap())
                            {
                                var stream = new MemoryStream();
                                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                                source = BitmapFrame.Create(stream);
                            }
                        }
                        break;
                }
            }
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }

    #endregion
}

