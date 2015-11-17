using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIAngleClamp : MonoBehaviour
{
    private Slider angleObj;

    void Awake()
    {
        this.angleObj = this.GetComponent<Slider>();
    }

	// Update is called once per frame
	void Update ()
    {
        // Clamp max value of slider to 180
        if(this.angleObj.value > 180f)
        {
            this.angleObj.value = 180f;
        }
	}
}
