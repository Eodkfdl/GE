using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Gamedata
{
    private static int gamestatus;
    private static int Result;
    
    public static int cown, duckn, chickenn, sheepn;
    public static string str;
    public static int clear;
    public static int Gamestatus
   
    {
        get
        {
            return gamestatus;
        }
        set
        {
            gamestatus = value;
        }
    }

    public static int result
    {
        get
        {
            return Result;
        }
        set
        {
            Result = value;
        }
    }
}