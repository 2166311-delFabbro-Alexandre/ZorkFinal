using System;
using System.IO;

namespace ZorkFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Acteur perso;
            GenerateurClasse generateur = new GenerateurClasse();
            perso = generateur.GenererClasse();

            perso.AfficherEtat();

            



        }
    }
}
