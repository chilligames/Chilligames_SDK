using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading;
using System.Threading.Tasks;
public class HTTP : MonoBehaviour
{

    #region Dashboard

    public static async Task<bool> Admin_requst(Requsts.Req_Admin requsts, Action<Result> result, Action<Error> Err)
    {

        UnityWebRequest www = UnityWebRequest.Put("http://127.0.0.1:3333/reg_admin", requsts.body);
         
        www.SetRequestHeader("Password", requsts.Password);
        www.SetRequestHeader("Email", requsts.Email);

        www.SendWebRequest();


        await Task.Delay(3000);

        if (www.isDone)
        {
            Debug.Log("send");

            Debug.Log(www.downloadHandler.text);

            www.Abort();
            return true;
        }
        else
        {
            www.SendWebRequest();
            await Task.Delay(2000);
            return false;
        }

    }

    #endregion
}



/// <summary>
/// All Requst raw here
/// </summary>
public class Requsts
{

    /// <summary>
    /// admin raw requst
    /// </summary>
    public class Req_Admin
    {
        public readonly string body = "Admin";
        public string Email;
        public string Password;
        public string Nickname;
    }



}


/// <summary>
/// All result raw
/// </summary>
public class Result
{
    public bool Result_back;

}


/// <summary>
/// all ERR raw
/// </summary>
public class Error
{

    enum ERRS
    {

    }
}
