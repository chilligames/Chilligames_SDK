using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using Chilligames.SDK.Model_Client;

namespace Chilligames.SDK.Model_Client
{
    public class Req_Login
    {
        public string Name_app;
        public string Token_player;
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
            /// quick Login just login with Token
            /// </summary>
            /// <param name="Req_login"></param>
            /// <param name="Result_login"></param>
            /// <param name="ERROR"></param>
            public static void Quick_login(Req_Login Req_login, Action<Result_register> Result_login, Action<ERRORs> ERROR)
            {
                UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                www.SetRequestHeader("Name_app", Req_login.Name_app);
                www.SetRequestHeader("Pipe_line", "QL");
                www.SetRequestHeader("Token", Req_login.Token_player);

                www.SendWebRequest();


            }


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
                                    if (Token_users == null)
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




            public class Result_register
            {
                public string ID;
                public string Avatar;
                public object[] Identities;
                public object[] Ban;
                public object[] Friends;
                public object[] Log;
                public object[] Files;
                public object[] Data;
                public object[] Inventory;
                public object[] Notifactions;
                public object[] Teams;
                public object[] Wallet;
                public object[] Servers;

            }

         
            public class ERRORs
            {


            }
        }

    }


}
