using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace FrediWpf.Model
{
    class BDD
    {

        // Trouver un moyen de mettre les méthodes/fonction en private
        // Et le contourner 

        public MySqlConnection connection;


        public BDD()
        {
            InitConnexion();
           
        }
        public string Server()
        {

            string Server = "localhost";        // Mettre le nom du Serveur 
            return Server;
        }

        public string DataBase()
        {
            string DataBase = "fredi";          // Mettre le nom de la base de données
            return DataBase;
        }

        public string UserID()
        {
            string UserID = "root";             // Mettre le identifiant connexion de la base de données
            return UserID;
        }

        public string Password()
        {
            string Password = "rootroot";       // Mettre le password de connexion de la base de données
            return Password;
        }

        protected void InitConnexion()
        {
            // Création de la chaîne de connexion
            string connectionString = "SERVER="+ Server() + "; DATABASE=" + DataBase() + "; UID="+UserID()+"; PASSWORD="+Password();
            this.connection = new MySqlConnection(connectionString);
        }
        
        public string PassMail()
        {
            string PassMail = "notifm2L";       // Mettre le passxord pour l'addresse de notofaction
            return PassMail;
        }
    }


}
