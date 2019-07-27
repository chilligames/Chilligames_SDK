using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using Chilligames.SDK.Model_Client;

namespace Chilligames.SDK.Model_Client
{
    public class Req_reg_user_Username_pass
    {
        public string UserName;
        public string Password;
    }
    public class Token_entity
    {
        public string Token_app;
        public string Token_admin;
    }

}
namespace Chilligames.SDK
{

    public class Chilligames_SDK : MonoBehaviour
    {
        public static string Token_App;
        public static string Token_Admin;

        protected readonly static string APIs_link = "http://127.0.0.1:3333/APIs";

        /// <summary>
        /// intialize of chilligames 
        /// </summary>
        /// <param name="Token_Admin">your token</param>
        /// <param name="Token_App">your app token</param>
        public static void Initialize(string Token_Admin, string Token_App)
        {
            intil();

            async void intil()
            {
                UnityWebRequest www = UnityWebRequest.Get("http://127.0.0.1:3332/API");
                www.SetRequestHeader("Token_App", Token_App);
                www.SetRequestHeader("Token_Admin", Token_Admin);
                www.SendWebRequest();

                while (true)
                {
                    if (www.isDone)
                    {
                        www.Abort();

                        Chilligames_SDK.Token_Admin = Json.ChilligamesJson.DeserializeObject<Token_entity>(www.downloadHandler.text).Token_admin;
                        Chilligames_SDK.Token_App = Json.ChilligamesJson.DeserializeObject<Token_entity>(www.downloadHandler.text).Token_app;
                        if (Token_App != "" && Token_Admin != "")
                        {
                            print("token_finde");
                        }
                        else
                        {
                            print("Token_not_finde");
                        }

                        break;
                    }
                    else
                    {
                        await Task.Delay(20);
                    }
                }


            }
        }



        internal class API_Client
        {

            public static void Register_Users_with_Username_Password(Req_reg_user_Username_pass Requst_register, Action<Result_register> Result, Action<ERROR_register> ERROR)
            {
                req();

                async void req()
                {
                    print("req_send");
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("User_name", Requst_register.UserName);
                    www.SetRequestHeader("Password", Requst_register.Password);
                    www.SetRequestHeader("Pipe_line", "RUP");
                    www.SetRequestHeader("Token", Token_App);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {

                            print(www.downloadHandler.text);
                            www.Abort();
                            break;
                        }
                        else
                        {
                            await Task.Delay(20);
                        }
                    }
                }

            }



            public class Result_register
            {

            }
            public class ERROR_register
            {

            }
        }


        internal class API_Admin
        {

        }


    }


}
