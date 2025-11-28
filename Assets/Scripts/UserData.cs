using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    public string UserName;
    public int Cash;
    public int Balance;

    public UserData(string userName, int cash, int balance)
    {
        UserName = userName;
        Cash = cash;
        Balance = balance;
    }
}
