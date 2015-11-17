using UnityEngine;
using UnityEngine.UI;

public class UIGunAngle : MonoBehaviour
{
    private Slider angleObj;
    private Transform player;

    private Vector3 angle;

	// Use this for initialization
	void Awake ()
    {
        this.angleObj = GameObject.Find("GunAngleSlider").GetComponent<Slider>();
        this.player = GameObject.Find("Player").transform;
	}
	
    public void Update()
    {
        this.angle = this.transform.eulerAngles;
        // Set transform rotation z axis angle to value of angle control slider
        this.transform.eulerAngles = new Vector3(0f, this.angle.y, this.angleObj.value + this.player.eulerAngles.z);
    }
}
