using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class Menu
    {
        //bool choice = false;
        public async Task Interface()
        {
            int choice;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" Back to 80's " + '\n' + '\n');

            Console.WriteLine("Press 1 for Play, 2 for more Informations, or 3 for Quit, " + '\n');
            choice = Convert.ToInt16(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Choix numero 1 !" + '\n');
                    Game g = new Game();
                    break;
                case 2:
                    Console.WriteLine("Choix numero 2 !" + '\n');
                    TextIntro();
                    Console.WriteLine("Revenir au jeu ou quitter ?" + '\n' + "1 back to game, 2 Quit");
                    choice = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    if (choice == 1)
                    {
                        Interface();
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("ok thanks you");
                        Environment.Exit(0);
                    }
                    break;
                case 3:
                    Console.WriteLine("Choix numero 3 !" + '\n');
                    Console.WriteLine("Bye");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Erreur veuillez le chiffre indique");
                    //Task.Delay(4000);
                    //Console.Clear();
                    Interface();
                    break;
                }
            //}
        } //end of Interface

        public void TextIntro()
        {
            Console.WriteLine("Back to 80's est un jeu qui revient aux sources, à l'orgine des premeirs jeux de rôle" + '\n');
            Console.WriteLine("Vous avez la possibilité d'incarner un Mage ou Guerrier pour affronter des ennemis divers et variés!" + '\n');
        }

    } //end of Menu
}
