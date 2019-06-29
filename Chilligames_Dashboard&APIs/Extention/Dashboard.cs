﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using System;
using UnityEditor.EditorTools;

/// <summary>
/// playpref
/// 1:User_register
/// </summary>
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

        EditorGUILayout.LabelField($"You are login as :{Entity_Admin.Nick_name}");
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

                    if (Entity_Admin.List_application.Count < 2)
                    {
                        Entity_Admin.List_application.Add("hard");
                        Entity_Admin.List_application.Add("hi");

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

                            EditorGUILayout.LabelField($"Name Aplication : {Entity_Admin.List_application[index]}");
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
                                GUILayout.Label($"Price : {Entity_Admin.Prices[0]}T Enjoy!");

                                GUILayout.Button("Select");
                            }
                            break;
                        case 1:
                            {
                                Entity_Admin.Prices[1] = 2.3;
                                GUILayout.Label("*More features to support growth and enhance monetization");
                                GUILayout.Space(30f);
                                GUILayout.Label($"Price : {Entity_Admin.Prices[1]}T per Mons");
                                GUILayout.Button("Select tier");
                            }
                            break;
                        case 2:
                            {
                                Entity_Admin.Prices[2] = 4.9;

                                GUILayout.Label("*Premium services and dedicated support");
                                GUILayout.Space(30f);
                                GUILayout.Label($"Price : {Entity_Admin.Prices[2] }T per Mons");
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
                    EditorGUILayout.SelectableLabel($"Vrifie Code :{Entity_Admin.Vrifie_code}");
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
    bool Button = false;




    private void OnGUI()
    {

        GUILayout.Label("Enter your email:");

        Email = GUILayout.TextField(Email, 50);
        GUILayout.Label("enter your password");
        Password[0] = GUILayout.PasswordField(Password[0], '*');
        GUILayout.Label("Enter agine Password:");
        Password[1] = GUILayout.PasswordField(Password[1], '*');

        Button = GUILayout.Button(new GUIContent("Register", "register"));

        if (Button)
        {
            result_reg();
            async void result_reg()
            {
                bool result_register = await HTTP.Admin_requst(new Requsts.Req_Admin { Email = Email, Password = Password[1] }, null, null);
                if (result_register)
                {
                    CreateInstance<Dashboard>().Show();

                    Close();

                }
            }


        }



    }



}

public class App_Dashboard : EditorWindow
{
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
    int Tab_addons;
    int Tab_Setting;
    int Tab_Admins;
    int Tab_help;
    public static string Name_app { get; set; }

    private void Awake()
    {
        titleContent = new GUIContent($"You are manage :  [ {Name_app} ]");
        maxSize = new Vector2(1200, 500);
        minSize = new Vector2(1200, 500);
    }

    private void OnGUI()
    {
        Toolbar_selecter = GUILayout.Toolbar(Toolbar_selecter, new string[13] { "quick viwe", "Users", "Economy", "Tabels", "Real Data", "Teams", "Real content", "Automation", "analytics", "Add on", "Setting", "Admins", "Help" });

        switch (Toolbar_selecter)
        {
            case 0:
                {
                    Tab_quick_viwe = GUILayout.Toolbar(Tab_quick_viwe, new string[2] { "Overview", "Monitoring" });
                    switch (Tab_quick_viwe)
                    {

                        case 0:
                            {
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
                    Tab_Users = GUILayout.Toolbar(Tab_Users, new string[3] { "Users", "Segments", "Analyis users" });
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
                    Tab_Economy = GUILayout.Toolbar(Tab_Economy, new string[2] { "Catalog", "Curency" });
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
                    Tab_Tabels = GUILayout.Toolbar(Tab_Tabels, new string[2] { "Static Tabel", "Dynamic" });
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
                    Tab_real_content = GUILayout.Toolbar(Tab_real_content,new string[6] {"","","","","","" });
                }
                break;
            case 7:
                {

                }
                break;
            case 8:
                {

                }
                break;
            case 9:
                {

                }
                break;
            case 10:
                {

                }
                break;
            case 11:
                {


                }
                break;
            case 12:
                {

                }
                break;
        }
    }

}



public struct Entity_Admin
{

    #region Dashboard
    public static string Email { get; set; }
    public static string Password { get; set; }

    public static string Nick_name { get; set; }

    public static int Active_Tier { get; set; }

    public static double[] Prices = new double[3];
    public static string Vrifie_code { get; set; }

    public static List<string> List_application = new List<string>(100);
    #endregion
    #region App_dashboard



    #endregion


}


