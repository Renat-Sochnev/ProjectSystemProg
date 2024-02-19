using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Логика взаимодействия для LoadCharacterPage.xaml
    /// </summary>
    public partial class LoadCharacterPage : Page
    {
        public static Character character { get; set; }
        public LoadCharacterPage()
        {
            InitializeComponent();
            character = App.selectedCharacter;
            NameTb.Text = character.Name;
            ClassNameTb.Text = character.ClassName;

            List<Weapon> weapons = CRUD.GetAllWeapons();
            weapons.Insert(0, new Weapon("Нет"));
            WeaponCb.ItemsSource = weapons;
            WeaponCb.DisplayMemberPath = "Name";
            if(character.Weapon != null)
                WeaponCb.Text = character.Weapon.Name;
            else
                WeaponCb.SelectedIndex = 0;
        }

        private void Calculating()
        {
            CRUD.UpdateCharacter(character);
            LevelTb.Text = character.Level.ToString();
            ExpirienceTb.Text = character.Experience.ToString();
            StatPointsTb.Text = character.StatPoints.ToString();
            StrengthTb.Text = character.Strength.ToString() + "/" + character.MaxStrength.ToString();
            DexterityTb.Text = character.Dexterity.ToString() + "/" + character.MaxDexterity.ToString();
            InteligenceTb.Text = character.Inteligence.ToString() + "/" + character.MaxInteligence.ToString();
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

        private void GoMainPageBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void DecreaseStrengthBtn_Click(object sender, RoutedEventArgs e)
        {
            if(character.Strength > character.MinStrength)
            {
                character.Strength--;
                character.StatPoints++;
                Calculating();
            }
        }

        private void IncreaseStrengthBtn_Click(object sender, RoutedEventArgs e)
        {
            if (character.Strength < character.MaxStrength && character.StatPoints > 0)
            {
                character.Strength++;
                character.StatPoints--;
                Calculating();
            }
        }

        private void DecreaseDexterityBtn_Click(object sender, RoutedEventArgs e)
        {
            if (character.Dexterity > character.MinDexterity)
            {
                character.Dexterity--;
                character.StatPoints++;
                Calculating();
            }
        }

        private void IncreaseDexterityBtn_Click(object sender, RoutedEventArgs e)
        {
            if (character.Dexterity < character.MaxDexterity && character.StatPoints > 0)
            {
                character.Dexterity++;
                character.StatPoints--;
                Calculating();
            }
        }

        private void DecreaseInteligenceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (character.Inteligence > character.MinInteligence)
            {
                character.Inteligence--;
                character.StatPoints++;
                Calculating();
            }
        }

        private void IncreaseInteligenceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (character.Inteligence < character.MaxInteligence && character.StatPoints > 0)
            {
                character.Inteligence++;
                character.StatPoints--;
                Calculating();
            }
        }

        private void DecreaseVitalityBtn_Click(object sender, RoutedEventArgs e)
        {
            if (character.Vitality > character.MinVitality)
            {
                character.Vitality--;
                character.StatPoints++;
                Calculating();
            }
        }

        private void IncreaseVitalityBtn_Click(object sender, RoutedEventArgs e)
        {
            if (character.Vitality < character.MaxInteligence && character.StatPoints > 0)
            {
                character.Vitality++;
                character.StatPoints--;
                Calculating();
            }
        }
        private void IncreaseExpirience(int increase)
        {
            character.Experience += increase;
            int count = 0;
            for (int i = 1; i <= character.Level; i++)
            {
                count += i;
            }
            if (character.Experience - count * 1000 >= 0)
            {
                if (character.Level < 50)
                {
                    character.Level++;
                    character.StatPoints += 5;
                }
            }
            Calculating();
        }
        private void Increase500ExpirienceBtn_Click(object sender, RoutedEventArgs e)
        {
            IncreaseExpirience(500);
        }

        private void Increase1000ExpirienceBtn_Click(object sender, RoutedEventArgs e)
        {
            IncreaseExpirience(1000);
        }

        private void GoListCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListCharacterPage());
        }

        private void WeaponCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(WeaponCb.SelectedIndex == 0)
                character.UnequipWeapon();
            else
                character.EquipWeapon(WeaponCb.SelectedItem as Weapon);
            Calculating();
        }
    }
}
