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
            Presentation p = new Presentation();
            int choice;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" Back to 80's " + '\n' + '\n');
            Console.WriteLine("Press 1 for Play, 2 for more Informations, or 3 for Quit, " + '\n');
            choice = Convert.ToInt16(Console.ReadLine());
            //int choice = g.choixMenu(3); ;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Choix numero 1 !" + '\n');
                    Game g = new Game(); //Lance le jeu
                    break;
                case 2:
                    Console.WriteLine("Choix numero 2 !" + '\n');
                    ///// Presention des divers perso /////
                    p.TextIntro();
                    p.Gobelin();
                    p.Demon();
                    Console.WriteLine("Et un ennemi mystère ?" + '\n');
                    Console.WriteLine("Revenir au jeu ou quitter ?" + '\n' + "1 Back to game, 2 Quit");
                    choice = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    if (choice == 1)
                    {
                        Interface();
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Ok thanks you");
                        Environment.Exit(0);
                    }
                    break;
                default:
                    Console.WriteLine("Erreur veuillez entrer le chiffre indique");
                    //Task.Delay(4000);
                    //Console.Clear();
                    Interface();
                    break;
            }
            //}
        } //end of Interface

    } //end of Menu
}
