using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using Chilligames.SDK.Model_Client;

namespace Chilligames.SDK.Model_Client
{
    public class Req_send_data_to_tabels
    {
        public string Name_tabel;
       public double value;
    }
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
        protected static string Token_users;
        protected static string Token_app;
        protected readonly static string APIs_link = "http://127.0.0.1:3333/APIs";




        /// <summary>
        /// intialize of chilligames 
        /// </summary>
        /// <param name="Token_Admin">your token</param>
        /// <param name="Token_App">your app token</param>
        public static void Initialize(string Token_Admin, string Token_App)
        {

            Application.runInBackground = true;

            if (GameObject.Find("Chilligames(Clone)"))
            {
                intil();
            }
            else
            {
                var Chilligames = Instantiate(new GameObject { name = "Chilligames" });
                Chilligames.AddComponent<Chilligames_SDK>();
                DontDestroyOnLoad(Chilligames);
                if (GameObject.Find("Chilligames"))
                {
                    Destroy(GameObject.Find("Chilligames"));
                }
                intil();
            }


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
            /// <summary>
            /// quick register with ID
            /// </summary>
            /// <param name="Requst_quick_reg"></param>
            /// <param name="result_register"></param>
            /// <param name="ERROR"></param>
            public static void Quick_register(Action<Result_register> result_register, Action<ERRORs> ERROR)
            {

                quick_register();

                async void quick_register()
                {
                    while (true)
                    {

                        if (Token_app != null)
                        {
                            UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                            www.SetRequestHeader("Token", Token_app);
                            www.SetRequestHeader("Pipe_line", "QR");
                            www.SendWebRequest();
                            while (true)
                            {
                                if (www.isDone)
                                {
                                    if (Token_users== null)
                                    {
                                        Token_users = www.downloadHandler.text;
                                    }
                                    print(Token_users);
                                    www.Dispose();
                                    break;
                                }
                                else
                                {
                                    await Task.Delay(20);
                                }

                            }
                            break;

                        }
                        else
                        {
                            await Task.Delay(10);
                        }

                    }
                }

            }



            /// <summary>
            /// register with user password
            /// </summary>
            /// <param name="Requst_register"></param>
            /// <param name="Result"></param>
            /// <param name="ERROR"></param>
            public static void Register_Users_with_Username_Password(Req_reg_user_Username_pass Requst_register, Action<Result_register> Result, Action<ERRORs> ERROR)
            {
                req();

                async void req()
                {
                    while (true)
                    {

                        if (Token_app != null)
                        {
                            requst();
                            break;
                        }
                        else
                        {
                            await Task.Delay(20);

                        }
                    }

                    async void requst()
                    {
                        UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                        www.SetRequestHeader("User_name", Requst_register.UserName);
                        www.SetRequestHeader("Password", Requst_register.Password);
                        www.SetRequestHeader("Pipe_line", "RUP");

                        www.SetRequestHeader("Token", Token_app);

                        www.SendWebRequest();

                        while (true)
                        {
                            if (www.isDone)
                            {
                                Token_users = www.downloadHandler.text;
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
            }


            public static void Send_data_to_tabels(Req_send_data_to_tabels req_Send_Data,Action<Result_Send_data_to_tabel> result,Action<ERRORs> Errors)
            {

                UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                www.SetRequestHeader("Token", Token_app);
                www.SetRequestHeader("ID", Token_users);
                www.SetRequestHeader("Tabel_name", req_Send_Data.Name_tabel);
                www.SetRequestHeader("Data_Tabel", req_Send_Data.value.ToString());
                www.SetRequestHeader("Pipe_line", "SDTT");

                www.SendWebRequest();


            }


            public class Result_register
            {
                public string Token_user;
            }

            public class Result_Send_data_to_tabel
            {

            }
            public class ERRORs
            {

            }
        }

    }


}
