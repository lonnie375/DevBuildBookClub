using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;
using Dapper; 
namespace DevBuildMVCBookClub.Models
{
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=bookclub;Uid=root;Pwd=QuickenROcketMortgage1111!; convert zero datetime=True");

        //CRUD Operations for Person 

        //Read All 
        public static List<Person> GetAllPeople()
        {
            return DB.GetAll<Person>().ToList(); 
        }

        //Read One 
        public static Person GetOnePerson(int personId)
        {
            return DB.Get<Person>(personId);    
        }

        //Create 
        public static Person InsertPerson(Person newPerson)
        {
            DB.Insert<Person>(newPerson);
            return newPerson; 
        }
        //Edit 
        public static void UpdatePerson(Person editPerson)
        {
            DB.Update<Person>(editPerson);  
        }

        //Delete 
        public static void DeletePerson(int personId)
        {
            //Check if the person has any presentations 
            var personExist = $"select * from presentation where person_id = {personId}";
            if (personExist != null) //They have presentations
            {
                //Delete presenatations 
                DB.Execute($"delete from presentation where person_id =@person_id", new { person_id = personId });
                Person newPerson = new Person();
                newPerson.Id = personId;
                DB.Delete<Person>(newPerson);

            }

        }
            /////////////////////////////////////////
            ////////////////////////////////////////

            //CRUD Operations for Presentation 

            //Read All 
            public static List<Presentation> GetAllPresentations()
        {
            return DB.GetAll<Presentation>().ToList();
        }

        //Read One 
        public static Presentation GetOnePresentation(int id)
        {
            return DB.Get<Presentation>(id);
        }

        //Create 
        public static Presentation InsertPresentation(Presentation present)
        {
            DB.Insert<Presentation>(present);
            return present; 
        }

        //Edit 
        public static void UpdatePresentation(Presentation present)
        {
            DB.Update<Presentation>(present); 
        }

        //Delete 
        public static void DeletePresentation(int id)
        {
            Presentation present = new Presentation(); 
            present.Id = id;
            DB.Delete<Presentation>(present);
        }
    }
}
