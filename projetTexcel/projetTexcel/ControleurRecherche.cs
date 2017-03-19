using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetTexcel
{
    class ControleurRecherche
    {
        public ControleurRecherche()
        {

        }
        public void rechercheGenre()
        {
            frmRecherce form = new frmRecherce();
            dbProvider db = new dbProvider();
            List<List<object>> liste = new List<List<object>>();
            liste = db.VueRecherche(6, "*");
            form.clear();
            foreach (var item in liste)
            {
                string[] genre = new string[4];
                int i = 0;
                foreach (var item2 in item)
                {
                    genre[i] = item2.ToString();
                    i++;
                }
                form.arrangerList(genre);

            }
            form.Show();
        }
        public void renvoiGenre(int genre)
        {
            CTraitements traitement = new CTraitements();

        }
    }
}
