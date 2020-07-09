using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Gamedata
{
    private static int gamestatus;
    private static int Result;
    private static int Clear;

    public static int cown, duckn, chickenn, sheepn;
    public static string str;

    public static int clear
       {
        get
        {
            return Clear;
        }
    set
        {
            Clear = value;
        }
    }
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