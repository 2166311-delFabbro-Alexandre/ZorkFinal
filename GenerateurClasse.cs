
using System.IO;

namespace ZorkFinal
{
    class GenerateurClasse 
    {
        public string[] Questions {get;set;}
        public Acteur[] Classes {get;set;}
        public int Guerrier {get;set;}
        public int Magicien {get;set;}
        public int Voleur {get;set;}

        public GenerateurClasse()
        {
            string texte = "";
            this.Questions = new string[4];
            this.Classes = new Acteur[3];
            int i = 0;

            StreamReader lecteurQuestions = new StreamReader("questions.txt");
            StreamReader lecteurClasses = new StreamReader("classes.txt");
            
            while(!lecteurQuestions.EndOfStream)
            {         
                    texte = lecteurQuestions.ReadLine();
                    this.Questions[i] = texte;
                    i++;
            }

            lecteurQuestions.Close();

            i=0;

            while(!lecteurClasses.EndOfStream)
            {     

                    texte = lecteurClasses.ReadLine();
                    this.Classes[i] = DecoderClasse(texte.Split(';'));
                    i++;
            }

            
        }

        public Acteur GenererClasse()
        {
            GenerateurClasse generer = new GenerateurClasse();
            Acteur acteur;
            int reponse = 0;

            for(int i = 0; i < 3; i++)
            {
                reponse = PoserQuestion(generer.Questions[i]);

                switch(reponse)
                {
                    case 1:
                        generer.Magicien++;
                        break;
                    case 2:
                        generer.Voleur++;
                        break;
                    case 3:
                        generer.Guerrier++;
                        break;
                }
            }

            if(generer.Magicien > generer.Voleur && generer.Magicien > generer.Guerrier)
            {
                acteur = generer.Classes[0];
            }
            else if(generer.Voleur > generer.Magicien && generer.Voleur > generer.Guerrier)
            {
                acteur = generer.Classes[1];
            }
            else if(generer.Guerrier > generer.Magicien && generer.Guerrier > generer.Voleur)
            {
                acteur = generer.Classes[2];
            }
            else
            {
                reponse = PoserQuestion(generer.Questions[3]);

                switch(reponse)
                {
                    case 1:
                        acteur = generer.Classes[2];
                        break;
                    case 2:
                        acteur = generer.Classes[0];
                        break;
                    case 3:
                        acteur = generer.Classes[1];
                        break;
                }
            }

            return new Acteur;
        }

        /*méthode pour renvoyer une réponse aux questions
        *
        */
        private int PoserQuestion(string question)
        {
            int reponse = 0;

            while(ReponseValide(reponse) == false)
            {
                System.Console.WriteLine(question);
                int.TryParse(System.Console.ReadLine(),out reponse);

                if(!ReponseValide(reponse))
                {
                    System.Console.WriteLine("Veuillez entrer une réponse valide");
                }
            }

            return reponse;
        }

        private bool ReponseValide(int reponse)
        {
            bool valide = false;
            if(reponse == 1)
            {
                valide = true;
            }
            else if(reponse == 2)
            {
                valide = true;
            }
            else if(reponse == 3)
            {
                valide = true;
            }

            return valide;
        }


        private Acteur DecoderClasse(string[] classe)
        {
            Acteur acteur = new Acteur("",0,0,0,0,0,"");
            int maxHp = 0, maxArmure = 0, regenArmure = 0, agilite = 0, dommage = 0;

            acteur.Nom = classe[0];
            int.TryParse(classe[1], out maxHp);
            acteur.MaxHp = maxHp;
            int.TryParse(classe[2], out maxArmure);
            acteur.MaxArmure = maxArmure;
            int.TryParse(classe[3], out regenArmure);
            acteur.RegenArmure = regenArmure;
            int.TryParse(classe[4], out agilite);
            acteur.Agilite = agilite;
            int.TryParse(classe[5], out dommage);
            acteur.Description = classe[6];

            return acteur;
        }
    }
}






// switch(reponse)
//                     {
//                         case "1":
//                             guerrier++;
//                             break;
//                         case "2":
//                             magicien++;
//                             break;
//                         case "3":
//                             voleur++;
//                             break;
//                         default:
//                             System.Console.WriteLine("Vous n'avez pas entré une réponse valide... Je ne donne pas cher de votre peau pour l'ascension de la tour!");
//                             break;
//                     }