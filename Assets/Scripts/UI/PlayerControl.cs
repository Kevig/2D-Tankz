using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    private PlayerGUICore playerGUICore;

    // Note:    Max slope traction angle 22'degrees
    //          Player angle 21.33065 -> 100% traction

    private float moveValue = .02f;

    public void Awake()
    {
        this.playerGUICore = this.GetComponent<PlayerGUICore>();
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // Moves player object grouping left.
    // TODO: Add smoothing
    public void moveLeft()
    {
        Vector3 pos = this.transform.position;
        this.flipFacing(-1);
        this.transform.position = new Vector3(pos.x - this.moveValue, pos.y, pos.z);
    }

    // Moves player object grouping right.
    // TODO: Add smoothing
    public void moveRight()
    {
        Vector3 pos = this.transform.position;
        this.flipFacing(1);
        this.transform.position = new Vector3(pos.x + this.moveValue, pos.y, pos.z);
    }

    private void flipFacing(int anInt)
    {
        Vector3 tankRot = this.transform.eulerAngles;

        if(anInt < 0)
        {
            this.transform.eulerAngles = new Vector3(tankRot.x, 180f, tankRot.z);
        }
        else
        {
            this.transform.eulerAngles = new Vector3(tankRot.x, 0f, tankRot.z);
        }
        this.playerGUICore.flipFacing(anInt);
    }
}
