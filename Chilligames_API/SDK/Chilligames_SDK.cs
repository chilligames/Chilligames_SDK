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
        public string _id;
    }
    public class Req_send_score
    {
        public string Leader_board;
        public string ID;
        public int Score;
        public string Nick_name;
    }

    public class Info_model
    {
        public object Username;
        public object Password;
        public object Email;
        public object Nickname;
    }



}
namespace Chilligames.SDK
{

    public class Chilligames_SDK : MonoBehaviour
    {
        protected readonly static string APIs_link = "http://127.0.0.1:3333/APIs";

        internal class API_Client
        {

            /// <summary>
            /// quick Login just login with Token
            /// </summary>
            /// <param name="Req_login"></param>
            /// <param name="Result_login"></param>
            /// <param name="ERROR"></param>
            public static void Quick_login(Req_Login Req_login, Action<Result_Login> Result_login, Action<ERRORs> ERROR)
            {
                UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                www.SetRequestHeader("Pipe_line", "QL");
                www.SetRequestHeader("_id", Req_login._id);

                www.SendWebRequest();
                login();

                async void login()
                {
                    while (true)
                    {
                        if (www.isDone)
                        {
                            Result_Login User_data = Json.ChilligamesJson.DeserializeObject<Result_Login>(www.downloadHandler.text);
                            Result_login(User_data);
                            www.Abort();
                            break;
                        }
                        else
                        {
                            await Task.Delay(1);
                            if (www.isNetworkError || www.isHttpError || www.timeout == 1)
                            {
                                print("Err_not_login_login_break");
                                break;
                            }
                        }
                    }
                }

            }



            /// <summary>
            /// quick register with ID
            /// </summary>
            /// <param name="Requst_quick_reg"></param>
            /// <param name="result_register"></param>
            /// <param name="ERROR"></param>
            public static void Quick_register(Action<Result_quick_register> result_register, Action<ERRORs> ERROR)
            {
                quick_register();

                async void quick_register()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "QR");
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            result_register(new Result_quick_register { _id = www.downloadHandler.text });
                            www.Dispose();
                            break;
                        }
                        else
                        {
                            await Task.Delay(1);
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                print("Register_fild_break_register");
                                break;
                            }

                        }
                    }
                }

            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="send_Score"></param>
            /// <param name="result"></param>
            public static void Send_Score_to_leader_board(Req_send_score Send_Score, Action result)
            {
                UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                www.SetRequestHeader("Pipe_line", "SSTLB");
                www.SetRequestHeader("_id", Send_Score.ID);
                www.SetRequestHeader("Leader_board", Send_Score.Leader_board);
                www.SetRequestHeader("Nick_name", Send_Score.Nick_name);
                www.SetRequestHeader("Score", Send_Score.Score.ToString());
                www.SendWebRequest();

                Cheack_down();

                async void Cheack_down()
                {
                    while (true)
                    {
                        if (www.isDone)
                        {

                            www.Abort();
                            break;
                        }
                        else
                        {
                            await Task.Delay(1);
                        }

                    }
                }
            }

            public class Result_quick_register
            {
                public string _id;
            }


            public class Result_Login
            {
                public string _id = "";
                public string Avatar = "";
                public object Info = null;
                public object[] Ban = null;
                public object[] Friends = null;
                public object[] Log = null;
                public object[] Files = null;
                public object Data = null;
                public object[] Inventory = null;
                public object[] Notifactions = null;
                public object Teams = null;
                public object Wallet = null;
                public object[] Servers = null;

            }


            public class ERRORs
            {


            }
        }

    }


}
