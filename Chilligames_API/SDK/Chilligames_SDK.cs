using Chilligames.Json;
using Chilligames.SDK.Model_Client;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Chilligames.SDK.Model_Client
{
    public class Req_Login
    {
        public string _id;
    }
    public class Req_login_with_username_password
    {
        public string Username;
        public string Password;
    }

    public class Req_send_recovery_email
    {
        public string Email;
    }

    public class Req_submit_recovery_email
    {
        public string Key;
        public string Email;
    }

    public class Req_change_password
    {
        public string Email;
        public string New_Password;
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
        public int Count;

    }
    public class Req_recive_leaderboard_near_user
    {
        public string _id;
        public string Name_laederboard;
        public int Count;

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

    public class Req_recive_list_friend
    {
        public string _id;
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

    public class Req_cheack_new_message
    {
        public string _id;
    }

    public class Req_mark_messeges_as_read
    {
        public string _id;
    }

    public class Req_creat_server
    {
        public string Name_App;
        public string _id;
        public object Setting;
    }
    public class Req_recive_list_servers_User
    {
        public string _id;
        public string Name_app;
    }
    public class Req_data_server
    {
        public string _id_server;
        public string Name_app;
    }
    public class Req_Exit_server
    {
        public string _id;
        public string _id_server;
        public string Name_App;
    }
    public class Req_recive_all_server
    {
        public string Name_App;
        public int Count;

    }
    public class Req_cheack_server_in_profile
    {
        public string _id;
        public string Name_App;
        public string _id_server;
    }
    public class Req_enter_to_server
    {
        public string _id;
        public string Name_App;
        public string _id_server;
    }
    public class Req_change_server_data_fild
    {
        public string _id_server;
        public string Name_app;
        public string Pipe_line_data;
        public string Data_inject;
    }
    public class Req_push_data_to_server
    {
        public string Name_app;
        public string _id_server;
        public string Pipe_line_data;
        public object Inject_data;
    }
    public class Req_send_message_to_chatroom
    {
        public string _id;
        public string Name_App;
        public string Message;
    }
    public class Req_recive_chatroom_messages
    {
        public string Name_App;
    }
    public class Req_report_message
    {
        public string _id_message;
        public string Name_app;

    }
    public class Req_recive_messages
    {
        public string _id;

    }
    public class Req_recive_message_each_user
    {
        public string _id;
        public string _id_other_player;
    }
    public class Req_recive_notifactions
    {
        public string _id;
        public string Name_App;
    }
    public class Req_remove_notifactions
    {
        public string _id;
        public string Name_App;
    }
    public class Req_search_user
    {
        public string Nickname;
    }
    public class Req_cheack_nickname
    {
        public string Nickname;
    }
    public class Req_cheack_username
    {
        public string Username;
    }
    public class Req_Insert_coin
    {
        public string _id;
        public int Coin;
    }
    public class Req_sync_coin_with_server
    {
        public string _id;
        public int Coin;
    }
    public class Req_recive_coin
    {
        public string _id;
    }
    public class Req_Push_offer_to_all_user
    {
        public string Name_App;
        public string Key;
        public string Name_Entity;
        public int Count;
        public int Coin;
        public string ID_entity;
    }

    public class Req_push_offer_to_one
    {
        public string _id;
        public string Key;
        public string Name_App;
        public string Name_Entity;
        public int Count;
        public int Coin;
        public string _id_entity;
    }

    public class Req_recive_offers
    {
        public string _id;
        public string Name_App;
    }

    public class Req_remove_offers
    {
        public string Name_App;
        public string ID_entity;
    }

    public class Req_convert_coin_to_money_money_to_coin
    {
        public string _id;
        public int Coin;
        public Mode Select_mode = new Mode();


        public enum Mode : int
        {
            Coin, Money
        }
    }

    public class Req_contact_us
    {
        public string NameApp;
        public string Email_admin;
        public string Messege;
        public string Data_use;
    }

    public class Req_rate_to_game
    {
        public string _id;
        public string Name_app;
        public string Rate;
    }
}

namespace Chilligames.SDK
{

    public class Chilligames_SDK : MonoBehaviour
    {
        protected readonly static string APIs_link = "http://198.143.178.164:3333/APIs";

        internal class API_Client
        {

            /// <summary>
            /// quick Login just login with Token
            /// </summary>
            /// <param name="Req_login"></param>
            /// <param name="Result_login"></param>
            /// <param name="ERROR"></param>
            public static void Quick_login(Req_Login Req_login, Action<string> Result_login, Action<NetworkError> ERROR)
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
                            www.Abort();
                            if (www.downloadHandler.text == "1")
                            {
                                Result_login("1");
                            }
                            else if (www.downloadHandler.text == "0")
                            {
                                Result_login("0");
                            }

                            break;
                        }
                        else
                        {
                            await Task.Delay(1);
                            if (www.isNetworkError || www.isHttpError || www.timeout == 1)
                            {

                                if (www.isNetworkError)
                                {
                                    ERROR(NetworkError.WrongConnection);
                                }
                                if (www.isHttpError)
                                {
                                    ERROR(NetworkError.WrongOperation);
                                }
                                if (www.timeout == 1)
                                {
                                    ERROR(NetworkError.Timeout);
                                }
                                print("Err_not_login_login_break");
                                www.Abort();
                                break;
                            }
                        }
                    }
                }

            }


            /// <summary>
            /// quick register 
            /// </summary>
            /// <param name="result_register"></param>
            /// <param name="ERROR">
            /// ERR 8: http ERR
            /// ERR 2: Network ERR
            /// ERR 6: Timeout ERR
            /// </param>
            public static void Quick_register(Action<Result_quick_register> result_register, Action<NetworkError> ERROR)
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

                                if (www.isHttpError)
                                {
                                    ERROR(NetworkError.WrongOperation);

                                }
                                if (www.isNetworkError)
                                {
                                    ERROR(NetworkError.WrongConnection);
                                }
                                if (www.timeout == 1)
                                {
                                    ERROR(NetworkError.Timeout);
                                }
                                print("Register_fild_break_register");
                                www.Abort();
                                break;
                            }

                        }
                    }
                }

            }


            /// <summary>
            /// login with user name password
            /// </summary>
            /// <param name="req_Login_With_Username_Password"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Login_with_username_Password(Req_login_with_username_password req_Login_With_Username_Password, Action<string> result, Action<ERRORs> ERRORS)
            {
                Login();

                async void Login()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "LWUP");
                    www.SetRequestHeader("Username", req_Login_With_Username_Password.Username);
                    www.SetRequestHeader("Password", req_Login_With_Username_Password.Password);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            result(www.downloadHandler.text);
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
            /// recovery email user 
            /// we send recovery code to user 
            /// if proccess complite callback 1
            /// if proccess notcomplite callback 0
            /// </summary>
            /// <param name="send_Recovery_Email"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Recovery_email_send(Req_send_recovery_email send_Recovery_Email, Action<string> result, Action<ERRORs> ERRORS)
            {
                Recovery();

                async void Recovery()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);

                    www.SetRequestHeader("Pipe_line", "RE");
                    www.SetRequestHeader("Email", send_Recovery_Email.Email);
                    www.SendWebRequest();

                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result(www.downloadHandler.text);
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
            /// if key true callaback 1 
            /// if key false callback 0
            /// </summary>
            /// <param name="req_Submit_Recovery"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Submit_recovery_email(Req_submit_recovery_email req_Submit_Recovery, Action<string> result, Action<ERRORs> ERRORS)
            {
                submit();

                async void submit()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "SRE");
                    www.SetRequestHeader("Email", req_Submit_Recovery.Email);
                    www.SetRequestHeader("Key", req_Submit_Recovery.Key);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result(www.downloadHandler.text);
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


            public static void Change_password(Req_change_password req_Change_Password, Action result, Action<ERRORs> ERRORS)
            {
                Change();

                async void Change()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "CP");
                    www.SetRequestHeader("Email", req_Change_Password.Email);
                    www.SetRequestHeader("Password", req_Change_Password.New_Password);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result();
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
            /// recive info User
            /// </summary>
            /// <param name="req_Recive_Info_Player"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Recive_info_user(Req_recive_Info_player req_Recive_Info_Player, Action<Result_info_user> result, Action<ERRORs> ERRORS)
            {
                Recive_info_user();

                async void Recive_info_user()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RIU");
                    www.SetRequestHeader("_id", req_Recive_Info_Player._id);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result(ChilligamesJson.DeserializeObject<Result_info_user>(www.downloadHandler.text));
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


            /// <summary>
            /// recive leader board
            /// </summary>
            /// <param name="req_Recive_Leader"></param>
            /// <param name="result"></param>
            /// <param name="ERROR"></param>
            public static void Recive_leader_board(Req_recive_leader_board req_Recive_Leader, Action<Result_leader_board[]> result, Action<ERRORs> ERROR)
            {
                Recive_leader_board();


                async void Recive_leader_board()
                {

                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RLB");
                    www.SetRequestHeader("Leader_board", req_Recive_Leader.Name_leader_board);
                    www.SetRequestHeader("Count", req_Recive_Leader.Count.ToString());
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


            public static void Recive_leader_board_near_user(Req_recive_leaderboard_near_user req_Recive_Leaderboard_Near_User, Action<Result_leader_board[]> Result, Action<ERRORs> ERRORS)
            {
                recive();

                async void recive()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RLBNU");
                    www.SetRequestHeader("_id", req_Recive_Leaderboard_Near_User._id);
                    www.SetRequestHeader("Leader_board", req_Recive_Leaderboard_Near_User.Name_laederboard);
                    www.SetRequestHeader("Count", req_Recive_Leaderboard_Near_User.Count.ToString());
                    www.SendWebRequest();

                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            Result(ChilligamesJson.DeserializeObject<Result_leader_board[]>(www.downloadHandler.text));
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
                            result(ChilligamesJson.DeserializeObject<Jdoc>(www.downloadHandler.text));
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
            /// if Call back 1 can Change nickname
            /// if callback 0 cant change
            /// </summary>
            /// <param name="req_Cheack_Nickname"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Cheack_nick_name(Req_cheack_nickname req_Cheack_Nickname, Action<string> result, Action<ERRORs> ERRORS)
            {
                cheack();

                async void cheack()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "CNN");
                    www.SetRequestHeader("Nickname", req_Cheack_Nickname.Nickname);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result(www.downloadHandler.text);
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
            /// if callback 1 can change user name
            /// if callback 0 cant change user name
            /// </summary>
            /// <param name="req_Cheack_Username"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Cheack_user_name(Req_cheack_username req_Cheack_Username, Action<string> result, Action<ERRORs> ERRORS)
            {
                cheack();

                async void cheack()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "CUN");
                    www.SetRequestHeader("Username", req_Cheack_Username.Username);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result(www.downloadHandler.text);
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
            /// recive list friend
            /// </summary>
            /// <param name="req_Recive_List_Friend"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Recive_list_friend(Req_recive_list_friend req_Recive_List_Friend, Action result, Action<ERRORs> ERRORS)
            {
                recive_list();

                async void recive_list()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RLF");
                    www.SetRequestHeader("_id", req_Recive_List_Friend._id);
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
            /// cheack new messages
            /// </summary>
            /// <param name="req_Cheack_New_Message"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Cheack_status_new_message(Req_cheack_new_message req_Cheack_New_Message, Action<string> result, Action<ERRORs> ERRORS)
            {
                Cheack();

                async void Cheack()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "CNM");
                    www.SetRequestHeader("_id", req_Cheack_New_Message._id);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result(www.downloadHandler.text);
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
            /// mark all messeges as read 
            /// </summary>
            /// <param name="req_Mark_Messeges_As_Read"></param>
            public static void Mark_all_messages_as_read(Req_mark_messeges_as_read req_Mark_Messeges_As_Read)
            {
                mark();
                async void mark()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "MAMAR");
                    www.SetRequestHeader("_id", req_Mark_Messeges_As_Read._id);
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
                    www.SetRequestHeader("Name_App", Req_Server_creat.Name_App);
                    www.SetRequestHeader("_id", Req_Server_creat._id);
                    www.SetRequestHeader("Setting_Server", ChilligamesJson.SerializeObject(Req_Server_creat.Setting));
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
            /// data server user recive mikone
            /// </summary>
            /// <typeparam name="Schema_server"></typeparam>
            /// <param name="req_Recive_Servers"></param>
            /// <param name="Result"></param>
            /// <param name="ERRORS"></param>
            public static void Recive_List_server_user(Req_recive_list_servers_User req_Recive_Servers, Action<object[]> Result, Action<ERRORs> ERRORS)
            {
                Recive_data();

                async void Recive_data()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RLSU");
                    www.SetRequestHeader("_id", req_Recive_Servers._id);
                    www.SetRequestHeader("Name_App", req_Recive_Servers.Name_app);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();

                            if (www.downloadHandler.text != "")
                            {
                                Result(ChilligamesJson.DeserializeObject<object[]>(www.downloadHandler.text));
                            }

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
            /// recive data servers
            /// </summary>
            /// <typeparam name="Schema_data_server"></typeparam>
            /// <param name="req_Data_Server"></param>
            /// <param name="Result"></param>
            /// <param name="ERRORS"></param>
            public static void Recive_data_server<Schema_data_server>(Req_data_server req_Data_Server, Action<Schema_data_server> Result, Action<ERRORs> ERRORS)
            {
                Recive();

                async void Recive()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RDS");
                    www.SetRequestHeader("_id_Server", req_Data_Server._id_server);
                    www.SetRequestHeader("Name_App", req_Data_Server.Name_app);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            Result(ChilligamesJson.DeserializeObject<Schema_data_server>(www.downloadHandler.text));

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
            /// recive servers
            /// </summary>
            /// <param name="req_Recive_All_Server"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Recive_all_servers(Req_recive_all_server req_Recive_All_Server, Action<object[]> result, Action<ERRORs> ERRORS)
            {
                recive();

                async void recive()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RAS");
                    www.SetRequestHeader("Name_App", req_Recive_All_Server.Name_App);
                    www.SetRequestHeader("Count", req_Recive_All_Server.Count.ToString());
                    www.SendWebRequest();

                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result(ChilligamesJson.DeserializeObject<object[]>(www.downloadHandler.text));
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
            /// exit from server
            /// </summary>
            /// <param name="Req_Exit_Server"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Exit_server(Req_Exit_server Req_Exit_Server, Action result, Action<ERRORs> ERRORS)
            {
                exit();

                async void exit()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "ES");
                    www.SetRequestHeader("_id", Req_Exit_Server._id);
                    www.SetRequestHeader("_id_Server", Req_Exit_Server._id_server);
                    www.SetRequestHeader("Name_App", Req_Exit_Server.Name_App);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result();

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
            /// if callback 1 finde in profile
            /// if callback 2 not finde in profile
            /// </summary>
            /// <param name="req_Cheack_Server_In_Profile"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Cheack_Server_In_Profile(Req_cheack_server_in_profile req_Cheack_Server_In_Profile, Action<string> result, Action<ERRORs> ERRORS)
            {
                Cheack();
                async void Cheack()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "CSIP");
                    www.SetRequestHeader("_id", req_Cheack_Server_In_Profile._id);
                    www.SetRequestHeader("Name_App", req_Cheack_Server_In_Profile.Name_App);
                    www.SetRequestHeader("_id_Server", req_Cheack_Server_In_Profile._id_server);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result(www.downloadHandler.text);

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
            /// enter to server
            /// </summary>
            /// <param name="req_Enter_To_Server"></param>
            /// <param name="result"></param>
            /// <param name="ERROR"></param>
            public static void Enter_to_server(Req_enter_to_server req_Enter_To_Server, Action result, Action<ERRORs> ERROR)
            {
                enter();
                async void enter()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "ETS");
                    www.SetRequestHeader("_id", req_Enter_To_Server._id);
                    www.SetRequestHeader("Name_App", req_Enter_To_Server.Name_App);
                    www.SetRequestHeader("_id_Server", req_Enter_To_Server._id_server);
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
            /// change data fild server 
            /// best value for change numeric
            /// for pipe line data use this pattern  for EX if you need change player in setting count:
            /// Setting.Player
            /// 
            /// [cheack]
            /// </summary>
            /// <param name="req_Change_Server_Data_Fild"></param>
            /// <param name="result"></param>
            /// <param name="err"></param>
            public static void Change_data_to_server_fild(Req_change_server_data_fild req_Change_Server_Data_Fild, Action result, Action ERRORS)
            {
                change_value();

                async void change_value()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "CDTS");
                    www.SetRequestHeader("Name_app ", req_Change_Server_Data_Fild.Name_app);
                    www.SetRequestHeader("_id_Server", req_Change_Server_Data_Fild._id_server);
                    www.SetRequestHeader("Pipe_line_data", req_Change_Server_Data_Fild.Pipe_line_data);
                    www.SetRequestHeader("Data_inject", req_Change_Server_Data_Fild.Data_inject);
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
            /// for pluse data use number EX: 3 , 4 ,5 
            /// for Minuse data use number EX: -9 ,-4,-90
            ///for pipe line data use this pattern  for EX if you need change player in setting count:
            /// Setting.Player
            /// </summary>
            /// <param name="req_Change_Server_Data_Fild"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Pluse_or_minuse_value_fild_server(Req_change_server_data_fild req_Change_Server_Data_Fild, Action result, Action ERRORS)
            {
                pluse_minuse();

                async void pluse_minuse()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "PDSF");
                    www.SetRequestHeader("Name_APP", req_Change_Server_Data_Fild.Name_app);
                    www.SetRequestHeader("_id_Server", req_Change_Server_Data_Fild._id_server);
                    www.SetRequestHeader("Pipe_line_data", req_Change_Server_Data_Fild.Pipe_line_data);
                    www.SetRequestHeader("Data_inject", req_Change_Server_Data_Fild.Data_inject);
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
            /// for push data to arry in data base 
            /// for pipe line data use this pattern  for EX if you need change player in setting count:
            /// Setting.Player
            /// </summary>
            /// <param name="req_Push_Data_To_Server"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Push_data_to_server_fild(Req_push_data_to_server req_Push_Data_To_Server, Action result, Action ERRORS)
            {
                push();

                async void push()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "PDTSF");
                    www.SetRequestHeader("Name_App", req_Push_Data_To_Server.Name_app);
                    www.SetRequestHeader("_id_Server", req_Push_Data_To_Server._id_server);
                    www.SetRequestHeader("Pipe_line_data", req_Push_Data_To_Server.Pipe_line_data);
                    www.SetRequestHeader("Data_inject", ChilligamesJson.SerializeObject(req_Push_Data_To_Server.Inject_data));
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result();
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
            /// send message to chatroom public
            /// </summary>
            /// <param name="Send_Message_To_Chatroom"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Send_message_to_Chatroom(Req_send_message_to_chatroom Send_Message_To_Chatroom, Action result, Action<ERRORs> ERRORS)
            {
                send_message();


                async void send_message()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "SMTC");
                    www.SetRequestHeader("_id", Send_Message_To_Chatroom._id);
                    www.SetRequestHeader("Name_App", Send_Message_To_Chatroom.Name_App);
                    www.SetRequestHeader("Message", Send_Message_To_Chatroom.Message);
                    www.SendWebRequest();

                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result();

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
            /// recive chatroom messages
            /// </summary>
            /// <typeparam name="Schema_messages"></typeparam>
            /// <param name="req_Recive_Chatroom"></param>
            /// <param name="Result"></param>
            /// <param name="ERRORS"></param>
            public static void Recive_Chatroom_messages(Req_recive_chatroom_messages req_Recive_Chatroom, Action<Result_massages_chatroom[]> Result, Action<ERRORs> ERRORS)
            {
                recive_chatroom();

                async void recive_chatroom()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RCM");
                    www.SetRequestHeader("Name_App", req_Recive_Chatroom.Name_App);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            Result(ChilligamesJson.DeserializeObject<Result_massages_chatroom[]>(www.downloadHandler.text));
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
            /// report message
            /// </summary>
            /// <param name="req_Report_Message"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Report_message(Req_report_message req_Report_Message, Action result, Action<ERRORs> ERRORS)
            {
                report();

                async void report()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RM");
                    www.SetRequestHeader("Name_App", req_Report_Message.Name_app);
                    www.SetRequestHeader("_id_message", req_Report_Message._id_message);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result();
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
            /// recive all message
            /// </summary>
            /// <param name="req_Recive_Messages"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Recive_message_User(Req_recive_messages req_Recive_Messages, Action<Result_message[]> result, Action<ERRORs> ERRORS)
            {
                recive();

                async void recive()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RMU");
                    www.SetRequestHeader("_id", req_Recive_Messages._id);
                    www.SendWebRequest();

                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result(ChilligamesJson.DeserializeObject<Result_message[]>(www.downloadHandler.text));
                            break;
                        }
                        else
                        {
                            if (www.isHttpError || www.isNetworkError)
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
            /// recive each messege
            /// </summary>
            /// <param name="req_Recive_Message_Each_User"></param>
            /// <param name="Result"></param>
            /// <param name="ERRORS"></param>
            public static void Recive_messege_each_user(Req_recive_message_each_user req_Recive_Message_Each_User, Action<Result_each_messege[]> Result, Action<ERRORs> ERRORS)
            {
                recive();

                async void recive()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RMEU");
                    www.SetRequestHeader("_id", req_Recive_Message_Each_User._id);
                    www.SetRequestHeader("_id_other_player", req_Recive_Message_Each_User._id_other_player);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();

                            Result(ChilligamesJson.DeserializeObject<Result_each_messege[]>(www.downloadHandler.text));

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
            /// recive notifactions
            /// </summary>
            /// <param name="req_Recive_Notifactions"></param>
            /// <param name="Result"></param>
            /// <param name="ERRORS"></param>
            public static void Recive_notifactions(Req_recive_notifactions req_Recive_Notifactions, Action<Result_Notifactions[]> Result, Action<ERRORs> ERRORS)
            {
                recive();

                async void recive()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RN");
                    www.SetRequestHeader("_id", req_Recive_Notifactions._id);
                    www.SetRequestHeader("Name_App", req_Recive_Notifactions.Name_App);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            Result(ChilligamesJson.DeserializeObject<Result_Notifactions[]>(www.downloadHandler.text));
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
            /// remove all notifaction app
            /// </summary>
            /// <param name="req_Remove_Notifactions"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Remove_Notifaction(Req_remove_notifactions req_Remove_Notifactions, Action result, Action<ERRORs> ERRORS)
            {
                Remove();

                async void Remove()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RNU");
                    www.SetRequestHeader("_id", req_Remove_Notifactions._id);
                    www.SetRequestHeader("Name_App", req_Remove_Notifactions.Name_App);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result();
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


            public static void Search_Users(Req_search_user req_Search_User, Action not_finde, Action<Result_search_user> result, Action<ERRORs> ERRORS)
            {
                recive();
                async void recive()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "SU");
                    www.SetRequestHeader("Nickname", req_Search_User.Nickname);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            if (www.downloadHandler.text == "0")
                            {
                                not_finde();
                                break;
                            }
                            else
                            {
                                result(ChilligamesJson.DeserializeObject<Result_search_user>(www.downloadHandler.text));
                                break;
                            }
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
            /// coin insert to user
            /// </summary>
            /// <param name="req_Insert_Coin"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Coin_Insert(Req_Insert_coin req_Insert_Coin, Action result, Action<ERRORs> ERRORS)
            {
                insert();

                async void insert()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "CI");
                    www.SetRequestHeader("_id", req_Insert_Coin._id);
                    www.SetRequestHeader("Coin", req_Insert_Coin.Coin.ToString());
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
            /// sync coin with server
            /// </summary>
            /// <param name="req_Sync_Coin_With_Server"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Sync_coin_with_server(Req_sync_coin_with_server req_Sync_Coin_With_Server, Action result, Action<ERRORs> ERRORS)
            {
                sync();
                async void sync()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "SCWS");
                    www.SetRequestHeader("_id", req_Sync_Coin_With_Server._id);
                    www.SetRequestHeader("Coin", req_Sync_Coin_With_Server.Coin.ToString());
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
            /// recive coin
            /// </summary>
            /// <param name="req_Recive_Coin"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Recive_Coin_mony(Req_recive_coin req_Recive_Coin, Action<Result_wallet> result, Action<ERRORs> ERRORS)
            {
                recive();

                async void recive()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RCMU");
                    www.SetRequestHeader("_id", req_Recive_Coin._id);
                    www.SendWebRequest();

                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result(ChilligamesJson.DeserializeObject<Result_wallet>(www.downloadHandler.text));
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
            /// push offer for all player
            /// </summary>
            /// <param name="req_Push_Offer_To_All_User"></param>
            public static void Push_Offer_to_all_player(Req_Push_offer_to_all_user req_Push_Offer_To_All_User)
            {
                Push();

                async void Push()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Key", req_Push_Offer_To_All_User.Key);
                    www.SetRequestHeader("Pipe_line", "POFA");
                    www.SetRequestHeader("Name_App", req_Push_Offer_To_All_User.Name_App);
                    www.SetRequestHeader("Name_Entity", req_Push_Offer_To_All_User.Name_Entity);
                    www.SetRequestHeader("Count", req_Push_Offer_To_All_User.Count.ToString());
                    www.SetRequestHeader("Coin", req_Push_Offer_To_All_User.Coin.ToString());
                    www.SetRequestHeader("ID_Entity", req_Push_Offer_To_All_User.ID_entity);
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
            /// push offer for one player
            /// </summary>
            /// <param name="req_Push_Offer_To_One"></param>
            /// <param name=""></param>
            public static void Push_Offer_to_one(Req_push_offer_to_one req_Push_Offer_To_One)
            {
                push_offer();

                async void push_offer()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "POFO");
                    www.SetRequestHeader("_id", req_Push_Offer_To_One._id);
                    www.SetRequestHeader("Key", req_Push_Offer_To_One.Key);
                    www.SetRequestHeader("Name_App", req_Push_Offer_To_One.Name_App);
                    www.SetRequestHeader("Name_Entity", req_Push_Offer_To_One.Name_Entity);
                    www.SetRequestHeader("Count", req_Push_Offer_To_One.Count.ToString());
                    www.SetRequestHeader("Coin", req_Push_Offer_To_One.Coin.ToString());
                    www.SetRequestHeader("ID_Entity", req_Push_Offer_To_One._id_entity);
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
            /// recive offers
            /// </summary>
            /// <param name="req_Recive_Offers"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Recive_offers(Req_recive_offers req_Recive_Offers, Action<Result_offers[]> result, Action<ERRORs> ERRORS)
            {
                recive();

                async void recive()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RO");
                    www.SetRequestHeader("_id", req_Recive_Offers._id);
                    www.SetRequestHeader("Name_App", req_Recive_Offers.Name_App);
                    www.SendWebRequest();

                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            if (www.downloadHandler.text.Length > 1)
                            {
                                result(ChilligamesJson.DeserializeObject<Result_offers[]>(www.downloadHandler.text));
                            }

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
            /// finde offer and delet for all remove all offer for all users
            /// </summary>
            /// <param name="req_Remove_Offers"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Remove_all_offer_match(Req_remove_offers req_Remove_Offers, Action result, Action<ERRORs> ERRORS)
            {
                remove();
                async void remove()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RAOM");
                    www.SetRequestHeader("Name_App", req_Remove_Offers.Name_App);
                    www.SetRequestHeader("ID_Entity", req_Remove_Offers.ID_entity);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result();
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
            /// CONVER coin to money or convert money to coin
            /// Mode => if 0 coit to money
            /// mode => if 1 money to coin
            /// </summary>
            /// <param name="req_Convert_Coin_To_Money_Money_To_Coin"></param>
            /// <param name="Result"></param>
            /// <param name="ERRORS"></param>
            public static void Convert_wallet(Req_convert_coin_to_money_money_to_coin req_Convert_Coin_To_Money_Money_To_Coin, Action Result, Action<ERRORs> ERRORS)
            {
                Convert();
                async void Convert()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "CMTC");
                    www.SetRequestHeader("_id", req_Convert_Coin_To_Money_Money_To_Coin._id);
                    www.SetRequestHeader("Mode", ((int)req_Convert_Coin_To_Money_Money_To_Coin.Select_mode).ToString());
                    www.SetRequestHeader("Coin", req_Convert_Coin_To_Money_Money_To_Coin.Coin.ToString());
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
            /// send message player to admin email
            /// </summary>
            /// <param name="req_Contact_Us"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Send_contact_us(Req_contact_us req_Contact_Us, Action result, Action<ERRORs> ERRORS)
            {
                send();

                async void send()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "CU");
                    www.SetRequestHeader("Name_App", req_Contact_Us.NameApp);
                    www.SetRequestHeader("Email", req_Contact_Us.Email_admin);
                    www.SetRequestHeader("Message", req_Contact_Us.Messege);
                    www.SetRequestHeader("Data_user", req_Contact_Us.Data_use);
                    www.SendWebRequest();

                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result();
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
            /// rate to game result in panel admin
            /// </summary>
            /// <param name="req_Rate_To_Game"></param>
            /// <param name="result"></param>
            /// <param name="ERRORS"></param>
            public static void Rate_to_game(Req_rate_to_game req_Rate_To_Game, Action result, Action<ERRORs> ERRORS)
            {
                rate();
                async void rate()
                {
                    UnityWebRequest www = UnityWebRequest.Get(APIs_link);
                    www.SetRequestHeader("Pipe_line", "RTG");
                    www.SetRequestHeader("_id", req_Rate_To_Game._id);
                    www.SetRequestHeader("Name_APP", req_Rate_To_Game.Name_app);
                    www.SetRequestHeader("Rate", req_Rate_To_Game.Rate);
                    www.SendWebRequest();
                    while (true)
                    {
                        if (www.isDone)
                        {
                            www.Abort();
                            result();
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
                public object Servers = null;
            }

            public class Result_info_user
            {
                public string Username = null;
                public string Email = null;
                public string Nickname = null;
                public string Status = null;
            }

            public class Result_leader_board
            {
                public string _id = null;
                public string Nickname = null;
                public int? Score = null;
            }

            public class Result_massages_chatroom
            {
                public string _id = null;
                public string Postion = null;
                public string ID = null;
                public string Nick_Name = null;
                public string Message = null;
                public string Time = null;
                public int? Report = null;
            }

            public class Result_message
            {
                public object[] Message = null;
                public string ID = null;
                public string Last_Date = null;
                public int? Status = null;
            }

            public class Result_each_messege
            {
                public string PM = null;
                public string Time = null;
                public string ID = null;
            }

            public class Result_Notifactions
            {
                public string Title = null;
                public string Body = null;
            }

            public class Result_search_user
            {
                public string _id = null;
                public object Info = null;

                public class Deserilseinfo
                {
                    public string Nickname = null;
                }
            }

            public class Result_wallet
            {
                public int? Coin = null;
                public double? Money = null;
            }

            public class Result_offers
            {
                public string ID = null;
                public string Key = null;
                public string Name_Entity = null;
                public int? Count = null;
                public int? Coin = null;

            }

            public class Result_list_freind
            {
                public object[] Friends = null;

                public class Deserilse_friend
                {
                    public string ID = null;
                    public int? Status = null;
                }
            }

            public class ERRORs
            {


            }



        }

    }


}
