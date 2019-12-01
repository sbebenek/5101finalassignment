using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

//WARNING: Until I figure out how to prevent such situations, *ONLY USE 'select * from AUTHORS..." queries and DO NOT DO INNER JOINS*
//This class reads the database and puts the results into a Author object, and returns a list of authors

//Some of this code is from SCHOOLDB.cs from the class examples

namespace n00831998_final_assg
{
    public class AUTHORDB
    {
        
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "website"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        //returns a list of Authors
        public List<Author> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            List<Author> ResultSet = new List<Author>();

            
            try
            {
                Debug.WriteLine("Connection Initialized...");

                //open the db connection
                Connect.Open();
                //give the connection a query
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader(); //cmd. function for updating and deleting


                //for every row in the result set
                while (resultset.Read())
                {
                    //this line needs to be modified if the number of columns in Authors changes
                    //new Author(authorid, authorfname, authorlname, authorjoindate)
                    Author author = new Author(Convert.ToInt32(resultset.GetString(0)), resultset.GetString(1), resultset.GetString(2), resultset.GetString(3));

                    ResultSet.Add(author);
                }//end row
                resultset.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong!");
                Debug.WriteLine(ex.ToString());

            }
            

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }

        //returns an Author object from the database at the given authorid
        public Author FindAuthor(int id)
        {
            //Utilize the connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //create a blank author
            Author author = new Author();

            try
            {
                string query = "select * from AUTHORS where authorid = " + id;
                Debug.WriteLine("Connection Initialized...");
                //open the db connection
                Connect.Open();
                //Run out query against the database
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();


                while (resultset.Read())
                {
                    //new Author(authorid, authorfname, authorlname, authorjoindate)
                    author = new Author(Convert.ToInt32(resultset.GetString(0)), resultset.GetString(1), resultset.GetString(2), resultset.GetString(3));


                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Debug.WriteLine("Attempting to transfer data of " + resultset.GetName(i));
                        Debug.WriteLine("Attempting to transfer data of " + resultset.GetString(i));
                    }
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the find Author method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return author;
        }

        //deletes an entry from the Author table at the given authorid
        public void DeleteAuthor(int id)
        {
            //Utilize the connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);


            try
            {
                string query = "delete from AUTHORS where authorid=" + id;

                Debug.WriteLine("Connection Initialized...");
                //open the db connection
                Connect.Open();
                //Run out query against the database
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();



            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the find Author method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");
        }
        
        //adds an author to the authors table with the given authorfname and authorlname
        public void AddAuthor(string fname, string lname)
        {
            //Utilize the connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);


            try
            {
                string query = "insert into AUTHORS (authorfname, authorlname, authorjoindate) values ('" + fname + "', '" + lname + "', curdate())";

                Debug.WriteLine("Connection Initialized...");
                //open the db connection
                Connect.Open();
                //Run out query against the database
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();



            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the find Author method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");
        }
        
        //Updates an author with the given authorid, authorfname, and authorlame
        public void UpdateAuthor(int authorid, string fname, string lname)
        {
            //Utilize the connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);


            try
            {
                string query = "update AUTHORS set authorfname = '" + fname + "', authorlname = '" + lname + "' where authorid=" + authorid;

                Debug.WriteLine("Connection Initialized...");
                //open the db connection
                Connect.Open();
                //Run out query against the database
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();



            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the find Author method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");
        }
    }
}