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
        this.transform.eulerAngles = new Vector3(0f, 0f, this.player.eulerAngles.z);
    }
}
