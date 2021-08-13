using DYA.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DYA
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //GetData() creates a collection of Customer data from a database
            ObservableCollection<CourseModel> custdata = GetData();

            //Bind the DataGrid to the customer data
            Assignments.DataContext = custdata;
        }

        public ObservableCollection<CourseModel> GetData()
        {
            List<CourseModel> listData = new List<CourseModel>();

            CourseModel Ex1 = new CourseModel()
            {
                ID = 0,
                Name = "Ex1"
            };

            CourseModel Info = new CourseModel()
            {
                ID = 1,
                Name = "Info"
            };

            CourseModel MfP = new CourseModel()
            {
                ID = 2,
                Name = "MfP"
            };

            CourseModel MRM = new CourseModel()
            {
                ID = 3,
                Name = "MRM"
            };

            listData.Add(Ex1);
            listData.Add(Info);
            listData.Add(MfP);
            listData.Add(MRM);

            return new ObservableCollection<CourseModel>(listData);
        }
    }
}
