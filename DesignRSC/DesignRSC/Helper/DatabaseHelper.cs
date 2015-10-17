using SQLite;
//using suitApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suitApp.Helper
{
    class DatabaseHelper
    {
      /*  SQLiteConnection dbConn;

        public async Task<bool> onCreate(string DB_PATH)
        {
            try
            {
                if (!CheckFileExists(DB_PATH).Result)
                {
                    using (dbConn = new SQLiteConnection(DB_PATH))
                    {
                        dbConn.CreateTable<LoginDatabase>();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Retrieve the specific contact from the database. 
        public LoginDatabase ReadContact(int contactid)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<LoginDatabase>("select * from LoginDatabase where Id =" + contactid).FirstOrDefault();
                return existingconact;
            }
        }
        // Retrieve the all contact list from the database. 
        public ObservableCollection<LoginDatabase> ReadContacts()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<LoginDatabase> myCollection = dbConn.Table<LoginDatabase>().ToList<LoginDatabase>();
                ObservableCollection<LoginDatabase> ContactsList = new ObservableCollection<LoginDatabase>(myCollection);
                return ContactsList;
            }
        }

        //Update existing conatct 
        public void UpdateContact(LoginDatabase contact)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<LoginDatabase>("select * from LoginDatabase where Id =" + contact.Id).FirstOrDefault();
                if (existingconact != null)
                {
                    existingconact.Name = contact.Name;
                    existingconact.Surname = contact.Surname;
                    existingconact.Username = contact.Username;
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Update(existingconact);
                    });
                }
            }
        }
        //count contacts
        public bool CountContact()
        {
            using (var dbCon = new SQLiteConnection(App.DB_PATH))
            {
                int existingcontact = dbCon.Query<LoginDatabase>("select * from LoginDatabase").Count;

                if (existingcontact > 0)
                {
                    return true;
                }
                return false;
            }


        }

        //selet user
        public LoginDatabase SelectUser()
        {
            using (var dbCon = new SQLiteConnection(App.DB_PATH))
            {
                LoginDatabase user = dbCon.Query<LoginDatabase>("select * from LoginDatabase").FirstOrDefault();
                return user;
            }
        }

        // Insert the new contact in the Contacts table. 
        public void Insert(LoginDatabase newcontact)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(newcontact);
                });
            }
        }

        //Delete specific contact 
        public void DeleteContact(int Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<LoginDatabase>("select * from LoginDatabase where Id =" + Id).FirstOrDefault();
                if (existingconact != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingconact);
                    });
                }
            }
        }
        //Delete all contactlist or delete Contacts table 
        public void DeleteAllContact()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //dbConn.RunInTransaction(() => 
                //   { 
                dbConn.DropTable<LoginDatabase>();
                dbConn.CreateTable<LoginDatabase>();
                dbConn.Dispose();
                dbConn.Close();
                //}); 
            }
        }*/


    }
}
