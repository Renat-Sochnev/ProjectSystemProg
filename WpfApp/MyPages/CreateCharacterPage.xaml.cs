using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для CreateCharacterPage.xaml
    /// </summary>
    public partial class CreateCharacterPage : Page
    {
        public static Character character;
        public CreateCharacterPage()
        {
            InitializeComponent();
            ClassCharacterCb.ItemsSource = CRUD.GetBaseCharacters();
            ClassCharacterCb.DisplayMemberPath = "ClassName";
        }

        private void ClassCharacterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            character = ClassCharacterCb.SelectedItem as Character;
            StrengthTb.Text = character.Strength.ToString() + "/" + character.MaxStrength.ToString();
            DexterityTb.Text = character.Dexterity.ToString() + "/" + character.MaxDexterity.ToString();
            InteligenceTb.Text = character.Inteligence.ToString() + "/" + character.MaxInteligence;
            VitalityTb.Text = character.Vitality.ToString() + "/" + character.MaxVitality.ToString();

            HealthTb.Text = character.Health.ToString();
            ManaTb.Text = character.Mana.ToString();
            PhysicalDamageTb.Text = character.PhysicalDamage.ToString();
            ArmorTb.Text = character.Armor.ToString();
            MagicDamageTb.Text = character.MagicDamage.ToString();
            MagicDefenseTb.Text = character.MagicDefense.ToString();
            CriticalChanseTb.Text = character.CriticalChance.ToString();
            CriticalDamageTb.Text = character.CriticalDamage.ToString();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                StringBuilder sb = new StringBuilder();
                if(NameTb.Text == "")
                {
                    sb.AppendLine("Введите имя персонажа");
                }
                if(CRUD.GetCharacter(NameTb.Text) != null)
                {
                    sb.AppendLine("Такое имя персонажа недоступно");
                }
                if(ClassCharacterCb.SelectedIndex == -1)
                {
                    sb.AppendLine("Выберите класс персонажа");
                }
                if(sb.Length > 0)
                {
                    MessageBox.Show(sb.ToString());
                }
                else
                {
                    character.Name = NameTb.Text;
                    character.MinStrength = character.Strength;
                    character.MinDexterity = character.Dexterity;
                    character.MinInteligence = character.Inteligence;
                    character.MinVitality = character.Vitality;
                    CRUD.CreateNamedCharacter(character);
                    MessageBox.Show("Персонаж успешно создан");
                    App.selectedCharacter = CRUD.GetCharacter(character.Name);
                    NavigationService.Navigate(new LoadCharacterPage());
                }
        //}
        //    catch
        //    {
        //        MessageBox.Show("Возникла ошибка");
        //    }
        }
    }
}
