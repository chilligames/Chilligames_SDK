using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
using Chilligames.APIs;

/// <summary>
/// playpref
/// 1:User_register
/// </summary>
/// 
namespace Chilligames.Dashboard
{

    public class Dashboard : EditorWindow
    {

        int layer_select = 0;
        int select_tier = Entity_Admin.Active_Tier;
        string name_application_new;
        bool Recovery_email;
        bool[] select_genre = new bool[19];
        bool[] new_game_mode = new bool[4];
        bool[] Monetization = new bool[5];
        bool[] Target_platform = new bool[9];
        bool Submit_new_application;
        string Website_new_application;
        Vector2 vertical_view_genre = new Vector2();


        [MenuItem("Chilligames/Dashboard")]
        public static void Dashboard_show()
        {
            if (EditorPrefs.GetBool("Register"))
            {
                CreateInstance<Dashboard>().Show();
            }
            else
            {
                CreateInstance<Register>().Show();
            }

        }

        private void OnGUI()
        {


            GUIContent[] tools = new GUIContent[6] { new GUIContent { text = "Dashboard", }, new GUIContent { text = "Upgrade tier", tooltip = "Price and buy tier" }, new GUIContent { text = "Studio Setting", tooltip = "All setting for studio" }, new GUIContent { text = "Users", tooltip = " define rolls for user" }, new GUIContent { text = "rolls", tooltip = "Add user for access to backend" }, new GUIContent { text = "New application", tooltip = "Creat applicaion" }, };


            EditorGUILayout.LabelField("Wellcome To Chilligames [Backend]");

            EditorGUILayout.LabelField($"You are login as :{Entity_Admin.Email}");
            switch (Entity_Admin.Active_Tier)
            {
                case 0:
                    {
                        EditorGUILayout.LabelField("Active Tier: Free");
                    }
                    break;
                case 1:
                    {
                        GUILayout.Label("Active Tier:pro");

                    }
                    break;
                case 2:
                    {
                        GUILayout.Label("Active Tier: Enterprise");
                    }
                    break;
            }
            EditorGUILayout.Space();


            layer_select = GUILayout.Toolbar(layer_select, tools);

            EditorGUILayout.Space();

            switch (layer_select)
            {
                case 0:
                    {

                        if (Entity_Admin.List_application.Count == 0)
                        {


                            EditorGUILayout.HelpBox("You are not a application", MessageType.Warning, true);

                            GUILayout.Button("Creat application");
                        }
                        else
                        {
                            EditorGUILayout.LabelField("Select Application for manage");

                            for (int i = 0; i < Entity_Admin.List_application.Count; i++)
                            {
                                application(i);
                            }

                            void application(int index)
                            {

                                EditorGUILayout.LabelField($"ID Application : {Entity_Admin.List_application[index]}");
                                EditorGUILayout.LabelField($"Name Application:{Entity_apps.Name_application}");
                                bool Press_btn_manage = GUILayout.Button(new GUIContent("Manage"));
                                if (Press_btn_manage)
                                {
                                    App_Dashboard.Name_app = Entity_Admin.List_application[index];
                                    CreateInstance<App_Dashboard>().ShowAuxWindow();
                                }
                            }
                        }
                    }
                    break;
                case 1:
                    {

                        select_tier = GUILayout.Toolbar(select_tier, new string[3] { "Free tier", "Pro tier", "Enterprise" });

                        switch (select_tier)
                        {
                            case 0:
                                {
                                    GUILayout.Label("*The basic things every game needs");
                                    GUILayout.Space(30f);
                                    //GUILayout.Label($"Price : {Entity_Admin.Prices[0]}T Enjoy!");

                                    GUILayout.Button("Select");
                                }
                                break;
                            case 1:
                                {
                                    //Entity_Admin.Prices[1] = 2.3;
                                    GUILayout.Label("*More features to support growth and enhance monetization");
                                    GUILayout.Space(30f);
                                    //GUILayout.Label($"Price : {Entity_Admin.Prices[1]}T per Mons");
                                    GUILayout.Button("Select tier");
                                }
                                break;
                            case 2:
                                {
                                    //Entity_Admin.Prices[2] = 4.9;

                                    GUILayout.Label("*Premium services and dedicated support");
                                    GUILayout.Space(30f);
                                    //GUILayout.Label($"Price : {Entity_Admin.Prices[2] }T per Mons");
                                    GUILayout.Button("Select tier");
                                }
                                break;
                        }
                    }
                    break;
                case 2:
                    {
                        GUILayout.Label($"Email:{Entity_Admin.Email}");
                        GUILayout.Label("For Recovery email pleas enter new email:");
                        GUILayout.TextField("Enter email");
                        //recovery code
                        //
                        Recovery_email = GUILayout.Button("Recovery Email");
                        GUILayout.Space(30);
                        //EditorGUILayout.SelectableLabel($"Vrifie Code :{Entity_Admin.Vrifie_code}");
                        GUILayout.Button("revrified");
                    }
                    break;


                case 5:
                    {

                        GUILayout.Label("Enter Application Name");
                        name_application_new = GUILayout.TextField(name_application_new);
                        GUILayout.Label("Enter website");

                        Website_new_application = GUILayout.TextField(Website_new_application);
                        GUILayout.Label("Entitys");
                        GUILayout.Space(20);
                        vertical_view_genre = GUILayout.BeginScrollView(vertical_view_genre);
                        GUILayout.Label("Select Genre:");
                        select_genre[0] = GUILayout.Toggle(select_genre[0], "Action");
                        select_genre[1] = GUILayout.Toggle(select_genre[1], " Action-adventure");
                        select_genre[2] = GUILayout.Toggle(select_genre[2], " Adventure ");
                        select_genre[3] = GUILayout.Toggle(select_genre[3], " Arcade");
                        select_genre[4] = GUILayout.Toggle(select_genre[4], " Card / board ");
                        select_genre[5] = GUILayout.Toggle(select_genre[5], "Casino");
                        select_genre[6] = GUILayout.Toggle(select_genre[6], " Educational ");
                        select_genre[7] = GUILayout.Toggle(select_genre[7], " Fighting");
                        select_genre[8] = GUILayout.Toggle(select_genre[8], " Idle");
                        select_genre[9] = GUILayout.Toggle(select_genre[9], " Puzzle");
                        select_genre[10] = GUILayout.Toggle(select_genre[10], " Racing / flying ");
                        select_genre[11] = GUILayout.Toggle(select_genre[11], " Real-time strategy ");
                        select_genre[12] = GUILayout.Toggle(select_genre[12], " Rhythm / dance ");
                        select_genre[13] = GUILayout.Toggle(select_genre[13], " Role-playing ");
                        select_genre[14] = GUILayout.Toggle(select_genre[14], " Sandbox / survival ");
                        select_genre[15] = GUILayout.Toggle(select_genre[15], " Shooter");
                        select_genre[16] = GUILayout.Toggle(select_genre[16], " Simulation");
                        select_genre[17] = GUILayout.Toggle(select_genre[17], " Sports");
                        select_genre[18] = GUILayout.Toggle(select_genre[18], " Turn-based strategy ");
                        GUILayout.Space(30);
                        GUILayout.Label("Select Mode");
                        new_game_mode[0] = GUILayout.Toggle(new_game_mode[0], "Singel_play");
                        new_game_mode[1] = GUILayout.Toggle(new_game_mode[1], "MultiPlay");
                        GUILayout.Space(30);
                        GUILayout.Label("Monetization");
                        Monetization[0] = GUILayout.Toggle(Monetization[0], "Free to play");
                        Monetization[1] = GUILayout.Toggle(Monetization[1], " Paid to download ");
                        Monetization[2] = GUILayout.Toggle(Monetization[2], " Ad-supported ");
                        Monetization[3] = GUILayout.Toggle(Monetization[3], " In-app purchase ");
                        Monetization[4] = GUILayout.Toggle(Monetization[4], " Subscription");
                        GUILayout.Space(30);
                        GUILayout.Label("Target marketplaces");
                        Target_platform[0] = GUILayout.Toggle(Target_platform[0], "IOS");
                        Target_platform[1] = GUILayout.Toggle(Target_platform[1], "Android");
                        Target_platform[2] = GUILayout.Toggle(Target_platform[2], "Steam");
                        Target_platform[3] = GUILayout.Toggle(Target_platform[3], "Windows");
                        Target_platform[4] = GUILayout.Toggle(Target_platform[4], "Xbox");
                        Target_platform[5] = GUILayout.Toggle(Target_platform[5], "Playstation");
                        Target_platform[6] = GUILayout.Toggle(Target_platform[6], "Nintendo");
                        Target_platform[7] = GUILayout.Toggle(Target_platform[7], "Web");
                        Target_platform[8] = GUILayout.Toggle(Target_platform[8], "Other");
                        EditorGUILayout.EndScrollView();
                        Submit_new_application = GUILayout.Button("Submit application");
                    }
                    break;

            }



        }
    }

    public class Register : EditorWindow
    {

        string Email = "Enter your Email";
        string[] Password = new string[2] { "Password_1 ", "Password_2 " };
        bool BTN_register;
        bool Btn_login;



        private void OnGUI()
        {

            GUILayout.Label("Enter your email:");

            Email = GUILayout.TextField(Email, 50);
            GUILayout.Label("enter your password");
            Password[0] = GUILayout.PasswordField(Password[0], '*');
            GUILayout.Label("Enter agine Password:");
            Password[1] = GUILayout.PasswordField(Password[1], '*');

            BTN_register = GUILayout.Button(new GUIContent("Register", "register"));
            GUILayout.Label("You old user?");

            Btn_login = GUILayout.Button("Login");

            //if player press btn_register
            if (BTN_register)
            {
                result_reg();
                async void result_reg()
                {
                    await HTTP.Admin_requst(new Requsts.Dashboard_req.Admin_register { Email = Email, Password = Password[1] },

                        (result) =>
                        {

                            Entity_Admin.ID = result.ID;
                            Entity_Admin.Status_active = result.Result;
                            Entity_Admin.Password = result.Password;
                            Entity_Admin.Email = result.Email;
                            Entity_Admin.Active_Tier = result.Tier;
                            Entity_Admin.Setting = result.Setting;
                            Entity_Admin.Users = result.Users;
                            Entity_Admin.Rolls = result.Rolls;
                            Entity_Admin.Application = result.Application;



                            foreach (var item in Entity_Admin.Application)
                            {
                                Entity_Admin.List_application.Add(item.ToString());
                            }


                            if (Entity_Admin.ID.Length > 5)
                            {
                                Close();

                                CreateInstance<Dashboard>().Show();
                            }
                            else
                            {
                                EditorGUILayout.HelpBox("not_active", MessageType.Error);
                            }

                        }, null);

                }


            }


            if (Btn_login)
            {
                CreateInstance<Login>().Show();
                Close();
            }


        }



    }


    public class Login : EditorWindow
    {

        string Text_Email;
        string Text_password;
        bool Press_btn_login;
        private void OnGUI()
        {

            GUILayout.Label("Enter your email:");
            Text_Email = GUILayout.TextField(Text_Email);
            GUILayout.Label("Enter Your password:");
            Text_password = GUILayout.TextField(Text_password);
            Press_btn_login = GUILayout.Button("Login");

            if (Press_btn_login)
            {
                login();

                async void login()
                {

                    await HTTP.Admin_login(new Requsts.Dashboard_req.Admin_login { Email = Text_Email, Password = Text_password }, (result_login) =>
                          {

                              Entity_Admin.ID = result_login.ID;
                              Entity_Admin.Status_active = result_login.Result;
                              Entity_Admin.Password = result_login.Password;
                              Entity_Admin.Email = result_login.Email;
                              Entity_Admin.Active_Tier = result_login.Tier;
                              Entity_Admin.Setting = result_login.Setting;
                              Entity_Admin.Users = result_login.Users;
                              Entity_Admin.Rolls = result_login.Rolls;
                              Entity_Admin.Application = result_login.Application;
                              Debug.Log(Entity_Admin.Application.Length);

                              for (int i = 0; i < Entity_Admin.Application.Length; i++)
                              {
                                  Entity_Admin.List_application.Add(Entity_Admin.Application[i].ToString());
                              }

                              CreateInstance<Dashboard>().Show();
                          },
                    (Error) =>
                    {
                        Debug.Log("code_err_here");
                    });

                }
            }


        }

    }



}


public class App_Dashboard : EditorWindow
{

    public struct App_enitiy
    {
        public object[] Quick_viwe;
        public object[] Users;
        public object[] Economy;
        public object[] Tabels;
        public object[] Real_Data;
        public object[] Teams;
        public object[] Real_content;
        public object[] Automation;
        public object[] Analytics;
        public object[] ADD_on;
        public object[] Setting;
        public object[] Admins;
    }

    public static string Name_app { get; set; }

    int Toolbar_selecter;
    int Tab_quick_viwe;
    int Tab_Users;
    int Tab_Economy;
    int Tab_Tabels;
    int tab_Real_data;
    int Tab_teams;
    int Tab_real_content;
    int Tab_automantion;
    int Tab_analystic;
    int Tab_Setting;
    int Tab_loges;
    int Tab_help;


    private void Awake()
    {
        titleContent = new GUIContent($"You are manage :  [ {Name_app} ]");
        maxSize = new Vector2(1200, 500);
        minSize = new Vector2(1200, 500);

    }

    private void OnGUI()
    {
        Toolbar_selecter = GUILayout.Toolbar(Toolbar_selecter, new string[] { "quick viwe", "Users", "Economy", "Tabels", "Real Data", "Teams", "Real content", "Automation", "analytics", "Add on", "Setting", "Admins", "Help" });

        switch (Toolbar_selecter)
        {
            case 0:
                {
                    Tab_quick_viwe = GUILayout.Toolbar(Tab_quick_viwe, new string[] { "Overview", "Monitoring" });
                    switch (Tab_quick_viwe)
                    {

                        case 0:
                            {

                                EditorGUILayout.BeginHorizontal();

                                GUILayout.Box($" \n [Unique Users] \n \n " +
                                    $"24 Hours ago: \t Amount:{2}  Change:{2}  \n \n " +
                                    $"1 Day ago: \t Amount:{2}  Change:{2}  \n \n " +
                                    $"7 Day ago: \t Amount:{3}  Change:{4}  \n \n " +
                                    $"30 Day ago:{200} \n \n ");

                                GUILayout.Box($" \n [Loigns] \n \n " +
                                    $"24 Hours ago: \t Amount:{3}  Change:{3}  \n \n " +
                                    $"1 Day ago: \t Amount:{3}  Change:{1}  \n \n " +
                                    $"7 Day ago: \t Amount:{3}  Change:{1}  \n \n" +
                                    $"30 Day ago:{222} \n \n ");

                                GUILayout.Box($" \n [New Users] \n \n" +
                                    $"24 Hours ago: \t Amount:{3}  Change:{2}  \n \n" +
                                    $"1 Day ago: \t Amount:{3}  Change:{2}  \n \n" +
                                    $"7 Day ago: \t Amount:{3}  Change:{4}  \n \n");

                                GUILayout.Box($" \n [Report] \n \n " +
                                    $"Unique users: \t YesterDay:{2}  Last month:{2} \n \n " +
                                    $"New users: \t YesterDay:{4} Last mounth:{4}  \n \n " +
                                    $"Purchases: \t YesterDay:{2}  Last mounth:{2}  \n \n " +
                                    $"Spenders: \t YesterDay:{3}  Last mounth:{4}  \n \n " +
                                    $"ARPU: \t \t YesterDay:{2}  Last mounth:{5}  \n \n " +
                                    $"ARPPU: \t \t YesterDay:{3}  Last mounth:{3}  \n \n " +
                                    $"API calls: \t \t YesterDay{5}  Last mounth:{3}  \n \n ");
                                EditorGUILayout.EndHorizontal();

                                GUILayout.Space(30);

                                EditorGUILayout.BeginHorizontal();
                                GUILayout.Label("API Call");
                                EditorGUILayout.CurveField(new AnimationCurve());
                                GUILayout.Label("Cloud Script processing times");
                                EditorGUILayout.CurveField(new AnimationCurve());
                                GUILayout.Label("New Users");
                                EditorGUILayout.CurveField(new AnimationCurve());

                                EditorGUILayout.EndHorizontal();



                                GUILayout.Label("overviwe");


                            }
                            break;
                        case 1:
                            {
                                GUILayout.Label("Monitor");
                            }
                            break;
                    }
                }
                break;
            case 1:
                {
                    Tab_Users = GUILayout.Toolbar(Tab_Users, new string[] { "Users", "Segments", "Analyis users" });
                    switch (Tab_Users)
                    {

                        case 0:
                            {
                                GUILayout.Label("Users");
                            }
                            break;
                        case 1:
                            {
                                GUILayout.Label("Segments");
                            }
                            break;
                        case 2:
                            {
                                GUILayout.Label("Analys player");
                            }
                            break;
                    }

                }
                break;
            case 2:
                {
                    Tab_Economy = GUILayout.Toolbar(Tab_Economy, new string[] { "Catalog", "Curency" });
                    switch (Tab_Economy)
                    {
                        case 0:
                            {
                                GUILayout.Label("catalog");

                            }
                            break;
                        case 1:
                            {
                                GUILayout.Label("Curency");
                            }
                            break;
                    }
                }
                break;
            case 3:
                {
                    Tab_Tabels = GUILayout.Toolbar(Tab_Tabels, new string[] { "Static Tabel", "Dynamic" });
                    switch (Tab_Tabels)
                    {
                        case 0:
                            {
                                GUILayout.Label("Static_tabel");
                            }
                            break;
                        case 1:
                            {
                                GUILayout.Label("Dynamic_tabel");
                            }
                            break;
                    }

                }
                break;
            case 4:
                {
                    tab_Real_data = GUILayout.Toolbar(tab_Real_data, new string[] { "Extended server", "Rooms", "real data" });

                    switch (tab_Real_data)
                    {


                        case 0:
                            {
                                GUILayout.Label("Extnded server");

                            }
                            break;
                        case 1:
                            {
                                GUILayout.Label("Roobs");
                            }
                            break;
                        case 2:
                            {
                                GUILayout.Label("real data");
                            }
                            break;

                    }


                }
                break;
            case 5:
                {
                    GUILayout.Label("Teams");
                }
                break;
            case 6:
                {
                    Tab_real_content = GUILayout.Toolbar(Tab_real_content, new string[] { "Title real", "title news", "real files", "collections", "real massege(push notifaction)" });
                    switch (Tab_real_content)
                    {


                        case 0:
                            {
                                GUILayout.Label("Title real");
                            }
                            break;
                        case 1:
                            {
                                GUILayout.Label("titel news");
                            }
                            break;
                        case 2:
                            {
                                GUILayout.Label("titel real file");
                            }
                            break;
                        case 3:
                            {
                                GUILayout.Label("Collectins");
                            }
                            break;
                        case 4:
                            {
                                GUILayout.Label("real massege");
                            }
                            break;
                    }


                }
                break;
            case 7:
                {
                    Tab_automantion = GUILayout.Toolbar(Tab_automantion, new string[] { "Cloud script", "A/B test", "Rules", "Scheduled Tasks" });
                    switch (Tab_automantion)
                    {
                        case 0:
                            {
                                GUILayout.Label("Cloud script");
                            }
                            break;
                        case 1:
                            {
                                GUILayout.Label("A/B test");
                            }
                            break;
                        case 2:
                            {
                                GUILayout.Label("Rules");
                            }
                            break;
                        case 3:
                            {
                                GUILayout.Label("Scheduled Tasks");
                            }
                            break;
                    }
                }
                break;
            case 8:
                {
                    Tab_automantion = GUILayout.Toolbar(Tab_automantion, new string[] { "Trends", "Event history", "Reports", "webhook", "Event", "Event Archive" });
                    switch (Tab_automantion)
                    {
                        case 0:
                            {
                                GUILayout.Label("Terends");
                            }
                            break;
                        case 1:
                            {
                                GUILayout.Label("Event history");
                            }
                            break;
                        case 2:
                            {
                                GUILayout.Label("reports");

                            }
                            break;
                        case 3:
                            {
                                GUILayout.Label("webhook");
                            }
                            break;
                        case 4:
                            {
                                GUILayout.Label("events");
                            }
                            break;
                        case 5:
                            {
                                GUILayout.Label("event archive");
                            }
                            break;
                    }

                }
                break;
            case 9:
                {
                    GUILayout.Label("addon");
                }
                break;
            case 10:
                {
                    Tab_Setting = GUILayout.Toolbar(Tab_Setting, new string[] { "General", "API setting", "secret keys", "realmassege setting", "Limits", "user setting", "Open id", "deta collection" });
                    switch (Tab_Setting)
                    {
                        case 0:
                            {
                                GUILayout.Label("General");
                            }
                            break;
                        case 1:
                            {
                                GUILayout.Label("APIsetting");
                            }
                            break;
                        case 2:
                            {
                                GUILayout.Label("ecret keys");
                            }
                            break;
                        case 3:
                            {
                                GUILayout.Label("real masseges");
                            }
                            break;
                        case 4:
                            {
                                GUILayout.Label("Limits");
                            }
                            break;
                        case 5:
                            {
                                GUILayout.Label("user setting");
                            }
                            break;
                        case 6:
                            {
                                GUILayout.Label("Open id");
                            }
                            break;
                        case 7:
                            {
                                GUILayout.Label("data_collecton");
                            }
                            break;
                    }
                }
                break;
            case 11:
                {
                    GUILayout.Label("logs");
                }
                break;
            case 12:
                {
                    GUILayout.Label("help");
                }

                break;
        }
    }

}


public struct Entity_Admin
{

    #region Dashboard
    public static string ID;
    public static bool Status_active;
    public static string Password;
    public static string Email;
    public static string Nick_name;
    public static int Active_Tier;
    public static object[] Setting;
    public static object[] Users;
    public static object[] Rolls;
    public static object[] Application;
    public static List<string> List_application = new List<string>(100);
    #endregion
    #region App_dashboard



    #endregion


}


public struct Entity_apps
{
    public static string Name_application;

}





