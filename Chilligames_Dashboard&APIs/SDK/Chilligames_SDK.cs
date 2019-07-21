using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
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

        public static  void Initialize(string Token_user,string Token_app)
        {

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
