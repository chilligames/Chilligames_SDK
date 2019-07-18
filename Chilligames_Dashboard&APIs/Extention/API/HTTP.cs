using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading;
using System.Threading.Tasks;
using Chilligames.Dashboard;

namespace Chilligames.APIs
{


    public class HTTP : MonoBehaviour
    {
        public const string API_address_Register = "http://127.0.0.1:3333/admin/register";
        public const string API_address_login = "http://127.0.0.1:3333/admin/login";

        #region Dashboard

        /// <summary>
        /// admin requst for register new admin 
        /// </summary>
        /// <param name="Requst_register"> parametr for register new admin</param>
        /// <param name="Result_register"> result register callback here</param>
        /// <param name="ERROR"> error callback </param>
        /// <returns></returns>
        public static async Task<bool> Admin_requst(Requsts.Dashboard_req.Admin_register Requst_register, Action<Result.Result_Admin> Result_register, Action<Error> ERROR)
        {

            UnityWebRequest www = UnityWebRequest.Get(API_address_Register);

            www.SetRequestHeader("Password", Requst_register.Password);
            www.SetRequestHeader("Email", Requst_register.Email);

            www.SendWebRequest();


            while (true)
            {

                if (www.isDone)
                {


                    Debug.Log(www.downloadHandler.text);


                    Result_register(Json.ChilligamesJson.DeserializeObject<Result.Result_Admin>(www.downloadHandler.text));

                    www.Abort();
                    return true;

                }
                else
                {
                    await Task.Delay(100);
                }

            }


        }



        public static async Task Admin_login(Requsts.Dashboard_req.Admin_login Requst_login, Action<Result.Result_Admin> Result_login, Action<Error> ERROR)
        {


            UnityWebRequest requst = UnityWebRequest.Get(API_address_login);

            requst.SetRequestHeader("Email", Requst_login.Email);
            requst.SetRequestHeader("Password", Requst_login.Password);

            requst.SendWebRequest();

            while (true)
            {
                if (requst.isDone)
                {

                    Result_login(Json.ChilligamesJson.DeserializeObject<Result.Result_Admin>(requst.downloadHandler.text));

                    requst.Abort();
                    break;

                }
                else
                {
                    await Task.Delay(200);

                }

            }




        }
        #endregion
    }


    /// <summary>
    /// All Requst raw here
    /// </summary>
    public class Requsts
    {
        public class Dashboard_req
        {


            /// <summary>
            /// admin raw requst
            /// </summary>
            public class Admin_register
            {
                public string Email;
                public string Password;
            }


            /// <summary>
            /// raw admin login entity
            /// </summary>
            public class Admin_login
            {
                public string Email;
                public string Password;
            }

        }


    }


    /// <summary>
    /// All result raw
    /// </summary>
    public class Result
    {
        public class Result_Admin
        {
            public string ID;
            public bool Result;
            public string Password;
            public string Email;
            public int Tier;
            public object[] Setting;
            public object[] Users;
            public object[] Rolls;
            public object[] Application;

        }

        public bool Result_back;

    }


    /// <summary>
    /// all ERR raw
    /// </summary>
    public class Error
    {
        public string Massege;


        public NetworkError NetworkError = new NetworkError();

    }


}
