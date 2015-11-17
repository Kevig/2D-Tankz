using UnityEngine;
using System.Collections;

public class UIAngleAdjust : MonoBehaviour
{
    private Transform player;

    // Use this for initialization
    void Awake()
    {
        this.player = GameObject.Find("Player").transform;
    }

    public void Update()
    {
        Vector3 rot = this.transform.eulerAngles;
        this.transform.eulerAngles = new Vector3(rot.x, rot.y, this.player.eulerAngles.z);
    }
}
