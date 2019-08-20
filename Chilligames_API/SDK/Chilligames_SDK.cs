using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using Chilligames.SDK.Model_Client;
using Chilligames.Json;

namespace Chilligames.SDK.Model_Client
{
    public class Req_Login
    {
        public string _id;
    }
    public class Req_send_score
    {
        public string Leader_board_name;
        public string _id;
        public int Score;
    }
    public class Info_model
    {
        public object Username;
        public object Password;
        public object Email;
        public object Nickname;
    }
    public class Req_recive_data
    {
        public string _id;
        public string Name_App;
    }
    public class Req_send_data
    {
        public string _id;
        public string Data_user;
        public string Name_app;

    }
    public class Req_recive_rank_postion
    {
        public string _id;
        public string Leader_board_name;
    }

    public class Req_Update_User_Info
    {
        public string _id;
        public string Nickname;
        public string Username;
        public string Email;
        public string Password;
        public string status;

    }

    public class Req_recive_leader_board
    {
        public string Name_leader_board;
        public int Count_leader_board;

    }

    public class Req_recive_Info_player
    {
        public string _id;
    }

    public class Req_status_friend
    {
        public string _id;
        public string _id_other_player;
    }

    public class Req_send_friend_requst
    {
        public string _id;
        public string _id_other_player;

    }

    public class req_cancel_and_dellet_send_freiend
    {
        public string _id;
        public string _id_other_users;
    }

    public class Req_send_message
    {
        public string _id;
        public string _id_other_users;
        public string Message_body;
    }

    public class Req_creat_server
    {
        public string _id;
        public object Setting;
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
                                www.Abort();
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
                                www.Abort();
                                break;
                            }

                        }
                    }
                }

            }


            /// <summary>
            /// send Score to leader_board
            /// </summary>
            /// <param name="send_Score"></param>
            /// <param name="result"></param>
            public static void Send_Score_to_leader_board(Req_send_score Send_Score, Action result)
            {
                UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                www.SetRequestHeader("Pipe_line", "SSTLB");
                www.SetRequestHeader("_id", Send_Score._id);
                www.SetRequestHeader("Leader_board", Send_Score.Leader_board_name);
                www.SetRequestHeader("Score", Send_Score.Score.ToString());
                www.SendWebRequest();

                Cheack_down();

                async void Cheack_down()
                {
                    while (true)
                    {
                        if (www.isDone)
                        {
                            result();
                            www.Abort();
                            break;
                        }
                        else
                        {
                            await Task.Delay(1);
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                www.Abort();
                                break;
                            }
                        }

                    }
                }
            }


            public static void Recive_leader_board(Req_recive_leader_board req_Recive_Leader, Action<Result_leader_board[]> result, Action<ERRORs> ERROR)
            {
                Recive_leader_board();


                async void Recive_leader_board()
                {

                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RLB");
                    www.SetRequestHeader("Leader_board", req_Recive_Leader.Name_leader_board);
                    www.SetRequestHeader("Leader_board_count", req_Recive_Leader.Count_leader_board.ToString());
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {

                            result(ChilligamesJson.DeserializeObject<Result_leader_board[]>(www.downloadHandler.text));
                            www.Abort();
                            break;
                        }
                        else
                        {
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                www.Abort();
                                break;
                            }
                            await Task.Delay(1);
                        }

                    }

                }

            }


            /// <summary>
            /// recive data user 
            /// </summary>
            /// <typeparam name="Jdoc"></typeparam>
            /// <param name="req_Recive_Data"></param>
            /// <param name="result"></param>
            /// <param name="ERR"></param>
            public static void Recive_Data_user<Jdoc>(Req_recive_data req_Recive_Data, Action<Jdoc> result, Action<Action> ERR)
            {
                Recive_data();

                async void Recive_data()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RDU");
                    www.SetRequestHeader("_id", req_Recive_Data._id);
                    www.SetRequestHeader("Name_App", req_Recive_Data.Name_App);
                    www.SendWebRequest();

                    while (true)
                    {
                        if (www.isDone)
                        {
                            result(Json.ChilligamesJson.DeserializeObject<Jdoc>(www.downloadHandler.text));//Cheack

                            www.Abort();
                            break;
                        }
                        else
                        {
                            await Task.Delay(1);
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                www.Abort();
                                break;
                            }

                        }

                    }
                }
            }


            /// <summary>
            /// recive data other player and raw player with schema
            /// </summary>
            /// <typeparam name="Schema_other_player"></typeparam>
            /// <param name="req_Recive_Info"></param>
            /// <param name="result_player"></param>
            /// <param name="ERROR"></param>
            public static void Recive_Info_other_User<Schema_other_player>(Req_recive_Info_player req_Recive_Info, Action<Schema_other_player> result_player, Action<ERRORs> ERROR)
            {
                Reicve_data_other_player();

                async void Reicve_data_other_player()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RIOU");
                    www.SetRequestHeader("_id", req_Recive_Info._id);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            result_player(ChilligamesJson.DeserializeObject<Schema_other_player>(www.downloadHandler.text));
                            www.Abort();
                            break;
                        }
                        else
                        {
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                www.Abort();
                                break;

                            }
                            await Task.Delay(1);
                        }

                    }


                }
            }


            /// <summary>
            /// send data to database 
            /// </summary>
            /// <typeparam name="Jdoc"></typeparam>
            /// <param name="req_send_data"></param>
            /// <param name="result_send"></param>
            /// <param name="ERROR"></param>
            public static void Send_Data_user(Req_send_data req_send_data, Action result_send, Action ERROR)
            {
                send_data();

                async void send_data()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "SDU");
                    www.SetRequestHeader("_id", req_send_data._id);
                    www.SetRequestHeader("Data_user", req_send_data.Data_user);
                    www.SetRequestHeader("Name_App", req_send_data.Name_app);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            print("send_data");
                            www.Abort();
                            break;
                        }
                        else
                        {
                            await Task.Delay(1);
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                www.Abort();
                                break;
                            }
                        }

                    }
                }
            }


            /// <summary>
            /// recive postion rank player
            /// </summary>
            /// <param name="req_Recive_Rank"></param>
            /// <param name="Result"></param>
            /// <param name="ERROR"></param>
            public static void Recive_rank_postion(Req_recive_rank_postion req_Recive_Rank, Action<string> Result, Action<ERRORs> ERROR)
            {

                recive_rank();

                async void recive_rank()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RRP");
                    www.SetRequestHeader("_id", req_Recive_Rank._id);
                    www.SetRequestHeader("Leader_board", req_Recive_Rank.Leader_board_name);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            Result(www.downloadHandler.text);
                            www.Abort();
                            break;
                        }
                        else
                        {
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                www.Abort();
                                break;
                            }
                            await Task.Delay(1);
                        }

                    }
                }

            }


            /// <summary>
            /// update mikone entiti user
            /// </summary>
            /// <param name="req_Update"></param>
            /// <param name="Result"></param>
            /// <param name="ERROR"></param>
            public static void Update_User_Info(Req_Update_User_Info req_Update, Action Result, Action<ERRORs> ERROR)
            {
                update_user();
                async void update_user()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "UUI");
                    www.SetRequestHeader("_id", req_Update._id);
                    www.SetRequestHeader("Nickname", req_Update.Nickname);
                    www.SetRequestHeader("Username", req_Update.Username);
                    www.SetRequestHeader("Email", req_Update.Email);
                    www.SetRequestHeader("Password", req_Update.Password);
                    www.SetRequestHeader("Status", req_Update.status);
                    www.SendWebRequest();

                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            Result();
                            break;
                        }
                        else
                        {
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                www.Abort();
                                break;
                            }
                            await Task.Delay(1);
                        }
                    }
                }
            }


            /// <summary>
            /// cheack status friend with id
            /// if callback 0:not friend
            /// if calllback 1: not accept
            /// if callback2: your friend
            /// </summary>
            /// <param name="req_Status_Friend"></param>
            /// <param name="Result"></param>
            /// <param name="ERRORS"></param>
            public static void Cheack_status_friend(Req_status_friend req_Status_Friend, Action<int> Result, Action<ERRORs> ERRORS)
            {
                Cheack();

                async void Cheack()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "CSF");
                    www.SetRequestHeader("_id", req_Status_Friend._id);
                    www.SetRequestHeader("_id_other_player", req_Status_Friend._id_other_player);
                    www.SendWebRequest();

                    while (true)
                    {
                        if (www.isDone)
                        {
                            Result(int.Parse(www.downloadHandler.text));
                            www.Abort();
                            break;
                        }
                        else
                        {
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                www.Abort();
                                break;
                            }
                            await Task.Delay(1);
                        }

                    }
                }

            }


            /// <summary>
            /// send friend requst 
            /// </summary>
            /// <param name="req_Send_Friend"></param>
            /// <param name="result"></param>
            /// <param name="ERROR"></param>
            public static void Send_friend_requst(Req_send_friend_requst req_Send_Friend, Action result, Action<ERRORs> ERROR)
            {
                send_req();

                async void send_req()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "SFR");
                    www.SetRequestHeader("_id", req_Send_Friend._id);
                    www.SetRequestHeader("_id_other_player", req_Send_Friend._id_other_player);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            break;
                        }
                        else
                        {
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                www.Abort();
                                break;
                            }
                            await Task.Delay(1);
                        }
                    }
                }
            }


            /// <summary>
            /// cancel friend requst
            /// </summary>
            /// <param name="req_Cancel_And_Dellet_Send_"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Cancel_and_dellet_friend_requst(req_cancel_and_dellet_send_freiend req_Cancel_And_Dellet_Send_, Action result, Action<ERRORs> ERRORS)
            {
                Cancel_friend();

                async void Cancel_friend()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "CFR");
                    www.SetRequestHeader("_id", req_Cancel_And_Dellet_Send_._id);
                    www.SetRequestHeader("_id_other_player", req_Cancel_And_Dellet_Send_._id_other_users);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            break;
                        }
                        else
                        {
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                www.Abort();
                                break;
                            }
                            await Task.Delay(1);
                        }

                    }
                }

            }


            /// <summary>
            /// send message to other player
            /// </summary>
            /// <param name="req_Send_Message"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Send_messege_to_player(Req_send_message req_Send_Message, Action result, Action<ERRORs> ERRORS)
            {
                send_messege();

                async void send_messege()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "SMTU");
                    www.SetRequestHeader("_id", req_Send_Message._id);
                    www.SetRequestHeader("_id_other_player", req_Send_Message._id_other_users);
                    www.SetRequestHeader("Message", req_Send_Message.Message_body);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            result();
                            www.Abort();
                            break;
                        }
                        else
                        {
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                www.Abort();
                                break;
                            }
                            await Task.Delay(1);
                        }
                    }
                }
            }


            /// <summary>
            /// creat server
            /// </summary>
            /// <typeparam name="Setting"></typeparam>
            /// <param name="Server"></param>
            /// <param name="Result"></param>
            /// <param name="ERRORS"></param>
            public static void Creat_server(Req_creat_server Req_Server_creat, Action Result, Action<ERRORs> ERRORS)
            {
                Creat();

                async void Creat()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "CS");
                    www.SetRequestHeader("_id", Req_Server_creat._id);
                    www.SetRequestHeader("Setting_Server", ChilligamesJson.SerializeObject(Req_Server_creat.Setting));
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            break;
                        }
                        else
                        {
                            if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                            {
                                www.Abort();
                                break;
                            }
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
                public object Notifactions = null;
                public object Teams = null;
                public object Wallet = null;
                public object[] Servers = null;

            }


            public class Result_leader_board
            {
                public string _id = null;
                public string ID = null;
                public string Nick_name = null;
                public int? Score = null;
            }


            public class result_recive_Messege //cheack
            {
                public object Message = null;
                public object Notifaction = null;



                public class Deserilse_messeges
                {

                    public object[] Recive = null;
                    public object[] Send = null;


                    public class Deserilse_Recive
                    {
                        public object[] message = null;
                        public string ID = null;
                        public string Last_Message = null;
                    }
                }
            }

            public class ERRORs
            {


            }


        }

    }


}
