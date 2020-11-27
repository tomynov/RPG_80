using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Windows;

namespace Rpg
{
    class Game
    {
        private Player hero;
        private List<Monster> Monstres;
        private Boolean IsGameOver;
        private string ArenaName;
        private int CurrentLevel;
        Menu menu = new Menu();

        //SoundPlayer sound = new SoundPlayer(Machine_Heart.mp3);

        public Game()
        {
            Presentation p = new Presentation();
            /// Permet au joueur de choisir sa classe ////
            Console.WriteLine("Type 1 for became a Warrior ! 2 for  Mage !" + '\n');
            int choice = choixMenu(2);
            //choice = Convert.ToInt16(Console.ReadLine());
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
        } //end of Game

        /*
         *  Ajout d'une musique de fond
         *  
         * private void playSound()
        {
            SoundPlayer simpleSound = new SoundPlayer("Machine_Heart.mp3");
            simpleSound.Play();
        }
        *
        */
        public void Lancement() //Initialise le combat en ajoutant les monstres dans une liste
        {

            //playSound(); //Lancement de la musique d'ambiance

            Monstres = new List<Monster>();
            Monstres.Add(new Monster(Monster.Role.Gobelin, "Troll apprenti"));
            Monstres.Add(new Monster(Monster.Role.Gobelin, "Troll sauvage"));
            Monstres.Add(new Monster(Monster.Role.Demon, "Lucifer"));
            Monstres.Add(new Monster(Monster.Role.Boss, "???"));

            var r = new Random();
            int test = r.Next(Monstres.Count);
            //Console.WriteLine(Monstres[test] +" est votre nouvel ennemi");

            Combat();
        } //end of Lancement 


        private void Combat()
        {
            Player p = hero;
            Monster m = Monstres[CurrentLevel];
            Presentation pr = new Presentation();
            DateTime t1 = DateTime.Now;

            while (p.Hp> 0 && m.Hp>0)
            {
                Console.WriteLine(p.Name + " a " + p.Hp + " Hp");
                Console.WriteLine(m.Name + " a " + m.Hp + " Hp" + '\n');
                Console.WriteLine("Choisissez : 1:Atk 2:Inventaire 3:Fuir");
                int choice = choixMenu(4);
                switch (choice)
                {
                    case 1:
                        Attaque();
                        break;
                    case 2:
                        OpenInventory();
                        break;
                    case 3:
                        Console.WriteLine("Sage décision...");
                        Quit();
                        break;
                    case 4:
                        pr.Boss(); //texte cache
                        break;
                    default:
                        Console.WriteLine("Ce n'est pas le bon chiffre" + '\n');
                        break;
                }
            }

            if (p.Hp>0) //le joueur est encore en vie
            {
                Console.WriteLine('\n' +"Congratulation" + '\n');

                if (CurrentLevel < 1)
                {
                    Console.WriteLine("Open your inventory: there is something new...");
                    Console.WriteLine("It's just the beginning, now you have few more battles with new ennemis !" + '\n');
                }

                CurrentLevel++; //On passe au monstre suivant
                hero.Inventory.Add(m.Loot); //L'ennemi battu lache un item prédéfinit

                if (CurrentLevel == 4) //Cas où le joueur a battu le boss
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vous avez fini le jeu !!");
                    DateTime t2 = DateTime.Now;
                    Console.WriteLine(t2 - t1+ "sec: Recommencer et cette fois soyez plus rapide !");
                    Console.WriteLine("1: Revenir au menu : 1  2: Quitter");
                    int choice = choixMenu(3);
                    switch (choice) //Permet au joueur de recommencer ou de quitter la partie
                    {
                        case 1:
                            menu.Interface();
                            break;
                        case 2:
                            Quit();
                            break;
                        default:
                            Console.WriteLine("Erreur veuillez entrer le chiffre indique");
                            break;
                    }
                    Quit();
                }
            }
            else
            {
                Console.WriteLine("Looser!");
                Quit();
            }
            Lancement(); //Permet d'enchainer les combats
        } //end of Combat

        private void Attaque()
        {
            Player p = hero;
            Monster m = Monstres[CurrentLevel];

            m.Hp -= Math.Clamp(p.Atk - m.Def, 0, 200);
            p.Hp -= Math.Clamp(m.Atk - p.Def, 0, 200);

        }//end of Attaque

        private void OpenInventory()
        {
            for (int i = 0; i < hero.Inventory.Count; i++)
            {
                Console.WriteLine((i+1) +":"+hero.Inventory[i].Name);
            }
            Console.WriteLine((hero.Inventory.Count +1) + ":" + "Return to Battle" +'\n');

            int choix = choixMenu(hero.Inventory.Count+1);

            if ((hero.Inventory.Count + 1) == choix)
                return;

            hero.Inventory[choix - 1].Use(hero);

            if (hero.Inventory[choix - 1].NumberOfUse <= 0)
                hero.Inventory.RemoveAt(choix - 1);
        } //end of OpenInventory

        public int choixMenu(int max)
        {
            Boolean choixValide = false;
            int choix = 0;
            while (!choixValide)
            {
                string saisie = Console.ReadLine();
                if (int.TryParse(saisie, out choix))
                {
                    choixValide = true;
                }
                else
                {
                    choixValide = false;
                    Console.WriteLine(choix + " Entrée incorrecte. Veuillez réessayer.");
                }
            }
            return (int)choix;
        } //end of choixMenu

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

    } //end of class Game
}
