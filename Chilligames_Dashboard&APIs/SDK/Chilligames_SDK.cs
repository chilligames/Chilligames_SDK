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
        public static string UserName;
        public static string Password;
    }

}
namespace Chilligames.SDK
{

    public class Chilligames_SDK : MonoBehaviour
    {
        public static string Pipe_line_app;
        public static string Pipe_line_Admin;
        protected readonly static string APIs_link = "http://127.0.0.1:3333/APIs";

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
                        www.Abort();
                        if (Pipe_line_Admin == "")
                        {
                            print("Token_not_found");
                        }
                        else
                        {
                            print("Succes_to_connect_chilligames_server");
                        }
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
                req();

                async void req()
                {

                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("User_name", Req_reg_user_Username_pass.UserName);
                    www.SetRequestHeader("Password", Req_reg_user_Username_pass.Password);
                    www.SetRequestHeader("Pipe_line", "Reg_User_pass");
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            print(www.downloadHandler);
                            www.Abort();
                            break;
                        }
                        else
                        {
                            await Task.Delay(200);
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
