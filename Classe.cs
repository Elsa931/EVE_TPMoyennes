using System;

namespace HNI_TPmoyennes
{
    class Classe{
        public string nomClasse { get; set; }

        public List<Eleve> eleves { get; set; }
        public List<string> matieres { get; set; }

        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;

            eleves = new List<Eleve>();
            matieres = new List<string>();
        }

        public void ajouterEleve(string prenom, string nom)
        {
            // Une classe accueille au maximum 30 eleves.
            if (eleves.Count >= 30)
            {
                Console.WriteLine ("Une classe ne peut pas accueillir plus de 30 eleves.");
            }else{
                Eleve nouvelEleve = new Eleve(prenom, nom, this);
                eleves.Add(nouvelEleve);
            }
        }

        public void ajouterMatiere(string nomMatiere)
        {
            // Au maximum 10 matieres.
            if (matieres.Count >= 10)
            {
                Console.WriteLine ("Une classe ne peut pas avoir plus de 10 matieres.");
            }else{
                matieres.Add(nomMatiere);
            } 
        }

        public float moyenneMatiere(int idMatiere)
        {
            if (eleves.Count == 0)
            {
                return 0;
            }

            float sommeMoyennes = 0;

            foreach (Eleve eleve in eleves)
            {
                sommeMoyennes += eleve.moyenneMatiere(idMatiere);
            }

            float moyenne = sommeMoyennes / eleves.Count;
            return tronquer(moyenne);
        }

        public float moyenneGeneral()
        {
            if (matieres.Count == 0)
            {
                return 0;
            }

            float sommeMoyennes = 0;

            for (int i = 0; i < matieres.Count; i++)
            {
                sommeMoyennes += moyenneMatiere(i);
            }

            float moyenne = sommeMoyennes / matieres.Count;
            return tronquer(moyenne);
        }

        private float tronquer(float valeur)
        {
            return (float)(Math.Truncate(valeur * 100) / 100);
        }

    }

}