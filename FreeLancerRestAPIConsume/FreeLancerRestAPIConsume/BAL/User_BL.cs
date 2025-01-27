using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreeLancerRestAPIConsume.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;


namespace FreeLancerRestAPIConsume.BAL
{
    public class User_BL
    {
        ///<summary>  
        /// This method is used to get the User list  
        ///</summary>  
        ///<returns></returns>  
        public IEnumerable<Users> GetUserList()
        {
            //List<Users> ObjUsers = null;
           // List<Users> userInfo = null;  IEnumerable<Users> users = null;
            IEnumerable<Users> users = null;
            try
            {

                //IEnumerable<Users> users = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54910/");

                    //Called Member default GET All records  
                    //GetAsync to send a GET request   
                    // PutAsync to send a PUT request  
                    var responseTask = client.GetAsync("api/User/GetUserList");
                    responseTask.Wait();

                    //To store result of web api response.   
                    var result = responseTask.Result;

                    //If success received   
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Users>>();
                        readTask.Wait();

                        users = readTask.Result;
                    }
                    else
                    {
                        //Error response received   
                        users = Enumerable.Empty<Users>();
                        //ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
                //return users;
            //}
            }
            catch (Exception)
            {
                throw;
            }
            return users;
        }

        ///<summary>  
        /// This method is used to get Users details by User id    
        ///</summary>  
        ///<returns></returns>  
        //public List<Users> GetUserDetailsById(int id)
        //{
        //    //List<Users> ObjUsers = null;
        //    // List<Users> userInfo = null;  IEnumerable<Users> users = null;
        //    List<Users> users = null;
        //    try
        //    {

        //        //IEnumerable<Users> users = null;

        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("http://localhost:54910/");

        //            //Called Member default GET All records  
        //            //GetAsync to send a GET request   
        //            // PutAsync to send a PUT request  
        //            var responseTask = client.GetAsync("api/User/GetUserInfoById?userid=" + id);
        //            responseTask.Wait();

        //            //To store result of web api response.   
        //            var result = responseTask.Result;

        //            //If success received   
        //            if (result.IsSuccessStatusCode)
        //            {
        //                //var readTask = result.Content.ReadAsAsync<IList<Users>>();
        //                //readTask.Wait();

        //                //users =  readTask.Result;

        //                var readTask = result.Content.ReadAsAsync<List<Users>>();
        //                readTask.Wait();
        //                users = readTask.Result;
        //            }
        //            else
        //            {
        //                //Error response received   
        //                //users = <List<Users>>();
        //                //ModelState.AddModelError(string.Empty, "Server error try after some time.");
        //            }
        //        }
        //        return users;
        //        //}
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return users;
        //}



        public List<Users> GetUserDetailsById(int id)
        {
            //List<Users> ObjUsers = null;
            // List<Users> userInfo = null;  IEnumerable<Users> users = null;
            List<Users> users = null;
            try
            {

                //IEnumerable<Users> users = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54910/");

                    //Called Member default GET All records  
                    //GetAsync to send a GET request   
                    // PutAsync to send a PUT request  
                    var responseTask = client.GetAsync("api/User/GetUserInfoById?userid=" + id);
                    responseTask.Wait();

                    //To store result of web api response.   
                    var result = responseTask.Result;

                    //If success received   
                    if (result.IsSuccessStatusCode)
                    {
                        //var readTask = result.Content.ReadAsAsync<IList<Users>>();
                        //readTask.Wait();

                        //users =  readTask.Result;

                        var readTask = result.Content.ReadAsAsync<List<Users>>();
                        readTask.Wait();
                        users = readTask.Result;
                    }
                    else
                    {
                        //Error response received   
                        //users = <List<Users>>();
                        //ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
                //return users;
                //}
            }
            catch (Exception)
            {
                throw;
            }
            return users;
        }

        ///<summary>  
        /// This method is used to add  User info  
        ///</summary>  
        ///<param name="User"></param>  
        ///<returns></returns>  
        public int AddUserInfo(Users User)
        {
            int resul = 0;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54910/");

                    //Called Member default Update records  
                    //GetAsync to send a Put request   
                    // PutAsync to send a PUT request  
                    var json = JsonConvert.SerializeObject(User);
                   // HttpResponseMessage response = client.POSTAsJsonAsync("api/user/AddUserInfo", json).Result;
                    HttpResponseMessage response = client.PostAsJsonAsync("api/user/AddUserInfo", User).Result;
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                        //TempData["msg"] = "User Details updated successfully";
                    }

                }
               // return resul;
            }
            catch (Exception)
            {
                throw;
            }
            return resul;
        }
        ///<summary>  
        /// This method is used to add  User info  
        ///</summary>  
        ///<param name="User"></param>  
        ///<returns></returns>  
        public int UpdateUserInfo(Users User)
        {
            int resul= 0;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54910/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Called Member default Update records  
                    //GetAsync to send a Put request   
                    // PutAsync to send a PUT request  
                    var json = JsonConvert.SerializeObject(User);
                    HttpResponseMessage response = client.PutAsJsonAsync("api/user/UpdateUserInfo", User).Result;

                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                        //TempData["msg"] = "User Details updated successfully";
                    }

                }
               // return resul;
            }
            catch (Exception)
            {
                throw;
            }
            return resul;
        }
        ///<summary>  
        /// This method is used to delete User info  
        ///</summary>  
        ///<param name="User"></param>  
        ///<returns></returns>  
        public int DeleteUserInfo(int Id)
        {
            int result = 0;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54910/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    //Called Member default delete records  
                    //HttpResponseMessage response =  client.DeleteAsync("api/user/DeleteUserInfo?userId=" + User.UserId);
                    HttpResponseMessage response = client.DeleteAsync("api/user/UpdateUserInfo?userId="+ Id).Result;
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                        //TempData["msg"] = "User Details updated successfully";
                    }

                }
                //return result;
            }
            catch (Exception)
            {
                return 0;
            }
            return result;
        }

        public List<Users> GetUserDetailsByName(string UserName,string Email)
        {
            //List<Users> ObjUsers = null;
            // List<Users> userInfo = null;  IEnumerable<Users> users = null;
            List<Users> users = null;
            try
            {

                //IEnumerable<Users> users = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54910/");

                    //Called Member default GET All records  
                    //GetAsync to send a GET request   
                    // PutAsync to send a PUT request  
                    var responseTask = client.GetAsync("api/User/GetUserInfoByUserName?userName=%" + UserName + "%&eMail=%"+Email+"%");
                    responseTask.Wait();

                    //To store result of web api response.   
                    var result = responseTask.Result;

                    //If success received   
                    if (result.IsSuccessStatusCode)
                    {
                        //var readTask = result.Content.ReadAsAsync<IList<Users>>();
                        //readTask.Wait();

                        //users =  readTask.Result;

                        var readTask = result.Content.ReadAsAsync<List<Users>>();
                        readTask.Wait();
                        users = readTask.Result;
                    }
                    else
                    {
                        //Error response received   
                        //users = <List<Users>>();
                        //ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
                //return users;
                //}
            }
            catch (Exception)
            {
                throw;
            }
            return users;
        }


    }
}