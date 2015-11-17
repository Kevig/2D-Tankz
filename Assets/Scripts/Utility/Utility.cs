using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour
{

    public int getDragDirection()
    {
        float x = Input.GetAxis("Mouse X");

        if(x < 0)
        {
            return -1;
        }
        else if(x > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
