using System;
using System.Collections.Generic;

namespace HNI_TPmoyennes
{
    class Eleve{
        public string prenom { get; set; }
        public string nom { get; set; }

        public List<Note> notes { get; set; }

        public Classe classe { get; set; }

        public Eleve(string prenom, string nom, Classe classe)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.classe = classe;

            notes = new List<Note>();
        }

        public void ajouterNote(Note nouvelleNote)
        {
            // Un eleve recoit au maximum 200 notes.
            if (notes.Count >= 200)
            {
                Console.WriteLine ("Un eleve ne peut pas recevoir plus de 200 notes.");
            }else{
                notes.Add(nouvelleNote);
            }
        } 

        public float moyenneMatiere(int idMatiere)
        {
            float somme = 0;
            int nbNotes = 0;

            foreach (Note uneNote in notes)
            {
                if (uneNote.matiere == idMatiere)
                {
                    somme += uneNote.note;
                    nbNotes++;
                }
            }

            // Evite une division par zero.
            if (nbNotes == 0)
            {
                return 0;
            }

            float moyenne = somme / nbNotes;
            return tronquer(moyenne);
        }

        public float moyenneGeneral()
        {
            if (classe.matieres.Count == 0)
            {
                return 0;
            }

            float sommeMoyennes = 0;

            for (int i = 0; i < classe.matieres.Count; i++)
            {
                sommeMoyennes += moyenneMatiere(i);
            }

            float moyenne = sommeMoyennes / classe.matieres.Count;
            return tronquer(moyenne);
        }

        private float tronquer(float valeur)
        {
            return (float)(Math.Truncate(valeur * 100) / 100);
        }

    }

}