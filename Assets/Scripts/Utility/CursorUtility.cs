using UnityEngine;
using System.Collections;

public static class CursorUtility
{
    public static void toggleCursorLock(bool aBool)
    {
        if(aBool)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
