
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
            
            Acteur acteur;
            int reponse = 0;

            for(int i = 0; i < 3; i++)
            {
                reponse = PoserQuestion(this.Questions[i]);

                switch(reponse)
                {
                    case 1:
                        this.Magicien++;
                        break;
                    case 2:
                        this.Voleur++;
                        break;
                    case 3:
                        this.Guerrier++;
                        break;
                }
            }

            if(this.Magicien > this.Voleur && this.Magicien > this.Guerrier)
            {
                acteur = this.Classes[0];
            }
            else if(this.Voleur > this.Magicien && this.Voleur > this.Guerrier)
            {
                acteur = this.Classes[1];
            }
            else if(this.Guerrier > this.Magicien && this.Guerrier > this.Voleur)
            {
                acteur = this.Classes[2];
            }
            else
            {
                reponse = PoserQuestion(this.Questions[3]);

                switch(reponse)
                {
                    case 1:
                        acteur = this.Classes[2];
                        break;
                    case 2:
                        acteur = this.Classes[0];
                        break;
                    case 3:
                        acteur = this.Classes[1];
                        break;
                    default:
                        acteur = this.Classes[0];
                        break;
                }
            }

            return acteur;
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
            
            int maxHp = 0, maxArmure = 0, regenArmure = 0, agilite = 0, dommage = 0;
            string nom = "", description = "";

            nom = classe[0];
            int.TryParse(classe[1], out maxHp);
            
            int.TryParse(classe[2], out maxArmure);
            
            int.TryParse(classe[3], out regenArmure);
            
            int.TryParse(classe[4], out agilite);
            
            int.TryParse(classe[5], out dommage);
            description = classe[6];

            return new Acteur(nom,maxHp,maxArmure,regenArmure,agilite,dommage,description);
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