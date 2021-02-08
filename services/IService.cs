using GestionEtudiat.entityframework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiat.services
{
    interface IService<C,P>
    {
        DataTable ListerEtudiantParClasse(C cl);
        bool CreerClasse(C cl);
        List<C> ListerClasse();
        bool CreerPersonne(P pers);
        P SeConnecter(String login, String pwd);
        P ChercherProfesseurParMatricule(String matricule);
        bool AttribuerClasse(C cl, P pers, List<String> modules, String annee);
        List<P> ListerProfesseur();
        List<String> ListerModulesProfesseurParClasse(C cl,P pers);

    }
}
