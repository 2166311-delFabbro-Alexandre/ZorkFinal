namespace ZorkFinal
{
    class Acteur
    {
        public string Nom {get;set;}
        public int MaxHp {get;set;}
        public int Hp {get;set;}
        public int MaxArmure {get;set;}
        public int Armure {get;set;}
        public int RegenArmure {get;set;}
        public int Agilite {get;set;}
        public int Dommage {get;set;}
        public string Description {get;set;}
        public int TauxCritique {get;set;}

        public Acteur(string nom, int maxHp, int maxArmure, int regenArmure, int agilite, int dommage, string description)
        {
            this.Nom = nom;
            this.MaxHp = maxHp;
            this.Hp = maxHp;
            this.MaxArmure = maxArmure;
            this.Armure = maxArmure;
            this.RegenArmure = regenArmure;
            this.Agilite = agilite;
            this.Dommage = dommage;
            this.Description = description;
            this.TauxCritique = agilite/2;
        }
        /*
        *méthode pour calculer et afficher les dégâts contre un ennemi
        *
        *@param1 recoit Acteur défenseur
        *
        *@return retourne l'hp restant d'un ennemi
        */
        public void Attaquer(Acteur defenseur)
        {
            System.Random random = new System.Random();
            int pourcentage = random.Next(1,101);
            int degats = 0;

            if(100-this.TauxCritique < pourcentage)
            {
                degats = this.Dommage * 3/2;
                System.Console.WriteLine($"{this.Nom} fait {degats} dégats à {defenseur.Nom}.");
            }

            else if (defenseur.Agilite > pourcentage)
            {
                System.Console.WriteLine($"{this.Nom} rate son attaque!");
            }

            else
            {
                degats = this.Dommage;
                System.Console.WriteLine($"{this.Nom} inflige {degats} points de dégats à {defenseur.Nom}.");
            }

            defenseur.Defendre(degats);
        }

        /*Méthode pour calculer et changer les stats du défenseur
        *
        *@param1 degats infligés
        */
        private void Defendre(int degats)
        {
            this.Armure -= degats;

            if(this.Armure < 0)
            {
                this.Hp+=this.Armure;
                this.Armure = 0;
            }

            this.Armure += this.RegenArmure;

            if(this.Armure > this.MaxArmure)
            {
                this.Armure = this.MaxArmure;
            }
        }

        /*Méthode pour return si l'acteur est vivant
        *
        *@return bool true si vivant
        */
        public bool EstVivant()
        {
            bool vivant= false;

            if(this.Hp > 0)
            {
                vivant = true;
            }

            return vivant;
        }

        //Méthode pour afficher l'état d'un acteur
        public void AfficherEtat()
        {
            System.Console.WriteLine(" {0}\n {1}/{2} HP\n {3}/{4} Armure", this.Nom,this.Hp,this.MaxHp,this.Armure,this.MaxArmure);
            System.Console.ReadLine();
        }
        
    }
}