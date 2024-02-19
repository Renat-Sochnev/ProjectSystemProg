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
using WpfApp.MyClasses;

namespace WpfApp.MyPages
{
    /// <summary>
    /// Логика взаимодействия для ListCharacterPage.xaml
    /// </summary>
    public partial class ListCharacterPage : Page
    {
        public ListCharacterPage()
        {
            InitializeComponent();
            CharacterList.ItemsSource = CRUD.GetNamedCharacters();
            List<Character> classes = CRUD.GetBaseCharacters();
            classes.Insert(0, new Character("Все"));
            ClassNameCb.ItemsSource = classes;
            ClassNameCb.DisplayMemberPath = "ClassName";
        }
        private void Refresh()
        {
            List<Character> characters = CRUD.GetNamedCharacters();
            if (ClassNameCb.SelectedIndex > 0)
                characters = characters.Where(x => x.ClassName == (ClassNameCb.SelectedItem as string)).ToList();
            if (NameTb.Text != "")
                characters = characters.Where(x => x.Name.Contains(NameTb.Text)).ToList();
            CharacterList.ItemsSource = characters;
        }
        private void NameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void ClassNameCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void GoMAinPageBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void CharacterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedCharacter = (Character)CharacterList.SelectedItem;
            NavigationService.Navigate(new LoadCharacterPage());
        }
    }
}
