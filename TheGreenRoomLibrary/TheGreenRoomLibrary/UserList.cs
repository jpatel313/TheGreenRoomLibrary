using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreenRoomLibrary
{
    class UserList
    {
        public static List<UserProfiles> readUsers()
        {
            List<UserProfiles> UserArray = new List<UserProfiles>();

            string filelocation = "../../UserList.txt";

            StreamReader reader = new StreamReader(filelocation);

            string Data = reader.ReadToEnd().Trim();
            string[] Records = Data.Split('\n');
            

            foreach (string record in Records)
            {
                string[] rc = record.Trim().Split(',');
                if (rc[2].ToLower() == "true")
                {
                   
                    UserProfiles user = new UserProfiles(rc[0], rc[1]);
                    UserProfiles.makeAdmin(user);
                    UserArray.Add(user);
                }
                else if (rc[2].ToLower() == "false")
                {
                   
                    UserArray.Add(new UserProfiles(rc[0], rc[1]));
                }
            }
            reader.Close();
            reader.Dispose();
            return UserArray;
        }


        public static UserProfiles LogIn(List<UserProfiles> Users)
        {
            while (true)
            {
                Console.Write("Username: ");
                string user = Console.ReadLine();
                Console.Write("Password: ");
                string pass = Console.ReadLine();
                foreach (UserProfiles U in Users)
                {
                    if (U.username.ToLower() == user.ToLower() && U.password.ToLower() == pass.ToLower())
                    {
                        return U;
                       
                    }

                }
               
                    Console.WriteLine("Incorrect Login, Please try again");
                
            }
        }

        public static UserProfiles NewAccount()
        {
            Console.Write("What would you like your username to be: ");
            string user = Console.ReadLine();
            Console.Write("What would you like your password to be: ");
            string pass = Console.ReadLine();
            UserProfiles User = new UserProfiles(user, pass);
            return User;
        }

        public static void UpdateUsers(List<UserProfiles> Users)
        {
            
            string filelocation = "../../UserList.txt";
            StreamWriter writer = new StreamWriter(filelocation);
            List<String> LS = new List<string>();
            foreach (UserProfiles U in Users)
            {
                LS.Add(U.username + ",");
                

                
                    LS.Add(U.password + ",");
                    LS.Add(Convert.ToString(U.admin + "\n"));
                    


            }
            foreach (String s in LS)
            {
                writer.Write(s);
            }
            writer.Close();
        }
    }
}
