using System;
using System.IO;

namespace ZorkFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Acteur perso = new Acteur("",0,0,0,0,0,"");
            GenerateurClasse generateur = new GenerateurClasse();
            perso = generateur.GenererClasse();

            perso.AfficherEtat();

            



        }
    }
}
