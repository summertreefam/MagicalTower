using System;
using System.Collections;
using System.Collections.Generic;

public static class Extention_Method 
{
    public static bool IsNullOrEmpty<T>(this ICollection<T> i_this)
    {
        if(i_this == null)
        {
            return true;
        }

        if(i_this.Count <= 0)
        {
            return true;
        }

        return false;
    }
}
