/*
 * Some of this code is from SCHOOLDB.cs from the class examples
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace n00831998_final_assg
{
    public class PAGEDB
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

        
        public List<WebPage> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            
            List<WebPage> ResultSet = new List<WebPage>();

            
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
                    //this line needs to be modified if the number of columns in Pages changes
                    //new WebPage(pageid, pagetitle, pagebody, publishdate, authorid)
                    WebPage wp = new WebPage(Convert.ToInt32(resultset.GetString(0)), resultset.GetString(1), resultset.GetString(2), resultset.GetString(3), Convert.ToInt32(resultset.GetString(4)));
                    
                    ResultSet.Add(wp);
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

        //returns a WebPage object from the database at the given pageid
        public WebPage FindPage(int id)
        {
            //Utilize the connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //create a "blank" student so that our method can return something if we're not successful catching student data
            WebPage page = new WebPage();

            try
            {
                //Build a custom query with the id information provided
                string query = "select * from PAGES where pageid = " + id;
                Debug.WriteLine("Connection Initialized...");
                //open the db connection
                Connect.Open();
                //Run out query against the database
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();


                //read through the result set
                while (resultset.Read())
                {
                    page = new WebPage(Convert.ToInt32(resultset.GetString(0)), resultset.GetString(1), resultset.GetString(2), resultset.GetString(3), Convert.ToInt32(resultset.GetString(4)));

                    

                    //Look at each column in the result set row, add both the column name and the column value to our Student dictionary
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Debug.WriteLine("Attempting to transfer data of " + resultset.GetName(i));
                        Debug.WriteLine("Attempting to transfer data of " + resultset.GetString(i));
                    }
                    //Add the student to the list of students
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the find Page method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return page;
        }

        //deletes a page from the Pages table at the given pageid
        public void DeletePage(int id)
        {
            //Utilize the connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            try
            {
                //Build a custom query with the id information provided
                string query = "delete from PAGES where pageid=" + id;

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

        //adds a page to the PAGES table with the given title, body, and authorid
        public void AddPage(string pagetitle, string pagebody, int authorid)
        {
            //Utilize the connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            try
            {
                string query = "insert into PAGES (pagetitle, pagebody, pagepublishdate, authorid) values ('" + pagetitle + "', '" + pagebody + "', curdate(), " + authorid + ")";

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
        
        //adds a page to the PAGES table with the given title, body, and authorid
        public void UpdatePage(int pageid, string pagetitle, string pagebody, int authorid)
        {
            //Utilize the connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            try
            {
                string query = "update PAGES set pagetitle = '" + pagetitle + "', pagebody = '" + pagebody + "', authorid = " + authorid + " where pageid=" + pageid;

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