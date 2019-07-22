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

}
namespace Chilligames.SDK
{

    public class Chilligames_SDK : MonoBehaviour
    {
        public static string Pipe_line_app;
        public static string Pipe_line_Admin;

        public static void Initialize(string Token_Admin, string Token_App)
        {
            intil();

            async void intil()
            {
                UnityWebRequest www = UnityWebRequest.Get("http://127.0.0.1:3333/API");
                www.SetRequestHeader("Token_App", Token_App);
                www.SetRequestHeader("Token_Admin", Token_Admin);
                www.SendWebRequest();

                while (true)
                {
                    print(www.downloadProgress);
                    if (www.isDone)
                    {
                        Pipe_line_Admin = www.downloadHandler.text;
                        print(Pipe_line_Admin);
                        break;
                    }
                    else
                    {
                        await Task.Delay(500);
                    }
                }

            }
        }



        internal class API_Client
        {

            public static void Register_Users_with_Username_Password(Req_reg_user_Username_pass Requst_register, Action<Result_register> Result, Action<ERROR_register> ERROR)
            {





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
