using DAN_LII_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LII_Dejan_Prodanovic.Service
{
    class ServiceClass:IService
    {
        public tblUser GetUserByUserName(string username)
        {
            try
            {
                using (MyCakesDbEntities context = new MyCakesDbEntities())
                {


                    tblUser user = (from x in context.tblUsers
                                    where x.Username.Equals(username)

                                    select x).First();

                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblUser AddUser(tblUser user)
        {
            try
            {
                using (MyCakesDbEntities context = new MyCakesDbEntities())
                {

                    tblUser newUser = new tblUser();
                    newUser.Fullname = user.Fullname;
                    newUser.TelephoneNumber = user.TelephoneNumber;
                    newUser.UserAddress = user.UserAddress;
                    newUser.Username = user.Username;
                    newUser.UserPassword = user.UserPassword;

                    context.tblUsers.Add(newUser);
                    context.SaveChanges();

                    return newUser;


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
