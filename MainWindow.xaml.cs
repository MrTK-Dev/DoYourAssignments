﻿using DYA.Scripts.Models;
using DYA.Scripts;
using DYA.Scripts.DATA;
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

            //Bind the DataGrid to the data
            //Assignments.DataContext = new TestData().GetCourses();
            
            Savings.DATACACHE = new List<CourseModel>(new TestData().GetCourses());

            Console.WriteLine("DATACACHE Assignments Counts: " + Savings.DATACACHE[1].Assignments.Count);
            Console.WriteLine("TestData Assignments Counts: " + new TestData().GetCourses()[1].Assignments.Count);

            Savings.SaveToFile();

            Savings.LoadFromFile();

            Assignments.DataContext = new ObservableCollection<CourseModel>(Savings.DATACACHE);
        }
    }
}
