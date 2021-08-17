using DYA.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DYA.Converters
{
    [ValueConversion(typeof(AssignmentModel), typeof(string))]
    public class AssignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                AssignmentModel newAssignment = (AssignmentModel)value;

                return newAssignment.PointsReached.ToString() + "/" + newAssignment.PointsMax.ToString();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    //public class VisibilityConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        return (Visibility)value == Visibility.Visible;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        return (bool)value ? Visibility.Visible : Visibility.Collapsed;
    //    }
    //}
}
