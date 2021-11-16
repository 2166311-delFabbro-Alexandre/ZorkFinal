namespace ZorkFinal
{
    class Acteur
    {
        public string Nom {get;set;}
        public string Description {get;set;}
        public int MaxHp {get;set;}
        public int Hp {get;set;}
        public int MaxArmure {get;set;}
        public int Armure {get;set;}
        public int RegenArmure {get;set;}
        public int Agilite {get;set;}
        public int Dommage {get;set;}
        public int TauxCritique {get;set;}

        public Acteur(string nom, int maxHp, int maxArmure, int regenArmure, int agilite, int dommage)
        {
            this.Nom = nom;
            this.MaxHp = maxHp;
            this.Hp = maxHp;
            this.MaxArmure = maxArmure;
            this.Armure = maxArmure;
            this.RegenArmure = regenArmure;
            this.Agilite = agilite;
            this.Dommage = dommage;
            this.TauxCritique = agilite/2;
        }

        
    }
}