using UnityEngine;
using System.Collections;

public class UIPositionTracking : MonoBehaviour
{
    private Transform player;

    public void Awake()
    {
        this.player = GameObject.Find("Player").transform;
    }
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = this.player.position;    
	}
}
