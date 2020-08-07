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
                using (MyCakesEntities context = new MyCakesEntities())
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
                using (MyCakesEntities context = new MyCakesEntities())
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

        public tblUser GetUserByUserNameAndPassword(string username, string password)
        {
            try
            {
                using (MyCakesEntities context = new MyCakesEntities())
                {


                    tblUser user = (from x in context.tblUsers
                                    where x.Username.Equals(username)
                                    && x.UserPassword.Equals(password)
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

        public List<tblCake> GetChildrenCakes()
        {
            try
            {
                using (MyCakesEntities context = new MyCakesEntities())
                {
                    List<tblCake> list = new List<tblCake>();
                    list = (from x in context.tblCakes
                            where x.CakeType.Equals("d")
                            select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblCake> GetAdultsCakes()
        {
            try
            {
                using (MyCakesEntities context = new MyCakesEntities())
                {
                    List<tblCake> list = new List<tblCake>();
                    list = (from x in context.tblCakes
                            where x.CakeType.Equals("o")
                            select x).ToList();
                    return list;
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
