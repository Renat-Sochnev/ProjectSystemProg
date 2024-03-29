﻿using System;
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
using WpfApp.MyClasses;
using WpfApp.MyClasses.WeaponClasses;

namespace WpfApp.MyPages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            //CRUD.CreateBaseCharacter(new Character("WARRIOR", 30, 250, 15, 80, 10, 50, 25, 100));
            //CRUD.CreateBaseCharacter(new Character("ROGUE", 20, 65, 30, 250, 15, 70, 20, 80));
            //CRUD.CreateBaseCharacter(new Character("WIZARD", 15, 45, 20, 80, 35, 250, 15, 70));


            //CRUD.CreateWeapon(new Wand("Волшебная палочка"));
            //CRUD.CreateWeapon(new Wand("Зачарованная волшебная палочка", 2));
            //CRUD.CreateWeapon(new Wand("Редкая волшебная палочка", 3));
        }

        private void CreateCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateCharacterPage());
        }

        private void LoadCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListCharacterPage());
        }
    }
}
