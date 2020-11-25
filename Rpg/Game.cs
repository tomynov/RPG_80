using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Game
    {
        private Player hero;
        private List<Monster> Monstres;
        private Boolean IsGameOver;
        private string ArenaName;
        private int CurrentLevel;
        public static int NbGame;

        public Game()
        {
            Presentation p = new Presentation();
            int choice;
            Console.WriteLine("Type 1 for became a Warrior ! 2 for  Mage !" + '\n');
            choice = Convert.ToInt16(Console.ReadLine());
            //Console.Clear();
            switch (choice)
            {
                case 1:
                    p.Warrior();
                    hero = new Player(Player.Role.Warrior, "Brutus");
                    break;
                case 2:
                    p.Mage();
                    hero = new Player(Player.Role.Mage, "Merlin");
                    break;
                default:
                    Console.WriteLine("Erreur veuillez le chiffre indique");
                    break;
            }
            Lancement();
        }

        public void Lancement() { 

            //CurrentLevel = 0;

            Monstres = new List<Monster>();
            Monstres.Add(new Monster(Monster.Role.Gobelin, "Troll apprenti"));
            Monstres.Add(new Monster(Monster.Role.Gobelin, "Troll sauvage"));
            Monstres.Add(new Monster(Monster.Role.Demon, "Lucifer"));

            var r = new Random();
            int test = r.Next(Monstres.Count);
            //Console.WriteLine(Monstres[test] +" est votre nouvel ennemi");

            Combat();
        } //end of Game


        private void Combat()
        {
            Player p = hero;
            Monster m = Monstres[CurrentLevel];

            while (p.Hp> 0 && m.Hp>0)
            {
                Console.WriteLine(p.Name + " a " + p.Hp + " Hp");
                Console.WriteLine(m.Name + " a " + m.Hp + " Hp" + '\n');
                Console.WriteLine("Choisissez : 1:Atk 2:Inventaire 3:Fuir");

                int choix = choixMenu(3);
                switch(choix)
                {
                    case 1:
                        Attaque();
                        break;
                    case 2:
                        OpenInventory();
                        break;
                    case 3:
                        Quit();
                        break;
                }
            }

            if (p.Hp>0)
            {
                Console.WriteLine('\n' +"Congratulation");
                hero.Inventory.Add(m.Loot);
                Console.WriteLine("Open your inventory there is something new...");
                Console.WriteLine("It's just the beginning, now you have few more battles !" + '\n');
            }
            else
            {
                Console.WriteLine("Looser!");
                Quit();
            }
            Lancement();
        } //end of Combat

        private void Attaque()
        {
            var rand = new Random();

            Player p = hero;
            Monster m = Monstres[CurrentLevel];

            m.Hp -= Math.Clamp(p.Atk - m.Def, 0, 150);
            p.Hp -= Math.Clamp(m.Atk - p.Def, 0, 150);

        }//end of Attaque

        private void OpenInventory()
        {
            for (int i = 0; i < hero.Inventory.Count; i++)
            {
                Console.WriteLine((i+1) +":"+hero.Inventory[i].Name);
            }
            Console.WriteLine((hero.Inventory.Count +1) + ":" + "Return to Battle");

            int choix = choixMenu(hero.Inventory.Count+1);

            if ((hero.Inventory.Count + 1) == choix)
                return;

            hero.Inventory[choix - 1].Use(hero);

            if (hero.Inventory[choix - 1].NumberOfUse <= 0)
                hero.Inventory.RemoveAt(choix - 1);
        }

        public int choixMenu(int max)
        {
            Boolean choixValide = false;
            int choix = 0;
            while (choixValide != true)
            {
                choix = int.Parse(Console.ReadLine());
                if ((int)choix > 0 && (int)choix <= max)
                {
                    choixValide = true;
                }
                else
                {
                    Console.WriteLine(choix + " Entrée incorrecte. Veuillez réessayer.");
                }
            }
            return (int)choix;
        }

        public static void Quit()
        {
            Environment.Exit(0);
        }

        public void save()
        {

        }

        public void Load()
        {

        }

    } //end of Game
}
