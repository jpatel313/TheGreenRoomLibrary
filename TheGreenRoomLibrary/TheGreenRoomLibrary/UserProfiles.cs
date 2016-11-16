using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreenRoomLibrary
{
    class UserProfiles
    {
        public string username;
        public string password;
        //private int booksOut;
        public Boolean admin;

        public UserProfiles(String user, String pass)
        {
            username = user;
            password = pass;
            admin = false;
        }
        
        public static void makeAdmin(UserProfiles user)
        {
            user.admin = true;
        }

        public UserProfiles()
        {
            
        }
    }
}
