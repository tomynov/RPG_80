using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Presentation
    {
        public void TextIntro()
        {
            Console.WriteLine("Back to 80's est un jeu qui revient aux sources, à l'orgine des premiers jeux de rôle" + '\n');
            Console.WriteLine("Vous avez la possibilité d'incarner un Mage ou Guerrier pour affronter des ennemis divers et variés!" + '\n');
        }
        public void Warrior()
        {
            Console.WriteLine("Excellent choix Guerrier !");
            Console.WriteLine("Vous avez peut être moins d'attaque mais vous êtes tout de fois plus résistant !" +'\n');
        }

        public void Mage()
        {
            Console.WriteLine("Excellent choix Mage !");
            Console.WriteLine("Vous avez peut être moins résistant mais vous êtes tout de fois plus d'attaque !" + '\n');
        }

        public void Gobelin()
        {
            Console.WriteLine("Les gobelins sont nombreux !");
            Console.WriteLine("Heureusement pour vous ils sont faibles" + '\n');
        }

        public void Demon()
        {
            Console.WriteLine("Les Démons sont aussis fourbes que puissant");
            Console.WriteLine("Si vous le pouvez fuyez !" + '\n');
        }
        public void Boss()
        {
            Console.WriteLine("Le Boss est d'une puissance redoutable !");
            Console.WriteLine("Battez-le et vous deviendrez une légende" + '\n');
        }
    }
}
