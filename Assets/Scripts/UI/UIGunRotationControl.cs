using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGunRotationControl : MonoBehaviour
{
    private PlayerGUICore coreUi;
    private GameObject locked;
    private GameObject unlocked;

    private Slider angleObj;
    private Text angleText;

    private float angleSliderSensitivity = 2f;
    public bool displayAngleText = false;

    private int direction = 1;

    public void Awake()
    {
        this.coreUi = GameObject.Find("Player").GetComponent<PlayerGUICore>();
        this.locked = GameObject.Find("UICrossHair").gameObject;
        this.unlocked = GameObject.Find("UICrossHairUnlocked").gameObject;

        this.angleObj = GameObject.Find("GunAngleSlider").GetComponent<Slider>();
        this.angleText = GameObject.Find("GunAngleText").GetComponent<Text>();
    }

    public void Start()
    {
        this.updateAngleText(0f);
    }

	// Update is called once per frame
	public void Update ()
    {

	}

    public void FixedUpdate()
    {
        this.angleText.gameObject.SetActive(displayAngleText);

        if(this.displayAngleText)
        {
            this.updateAngleText(this.angleObj.value);
        }
    }

    public void LateUpdate()
    {
        if(this.coreUi.getGunRotationLock())
        {
            this.locked.SetActive(true);
            this.unlocked.SetActive(false); 
        }
        else
        {
           this.unlocked.SetActive(true);
           this.locked.SetActive(false);
        }  
    }

    public void updateRotationAngle(int anInt)
    {
        if(this.direction == 1)
        {
            this.angleObj.value -= anInt * this.angleSliderSensitivity;
        }
        else
        {
            this.angleObj.value += anInt * this.angleSliderSensitivity;
        }
    }

    private void updateAngleText(float aValue)
    {
        this.angleText.text = aValue.ToString() + "\u00B0";
    }

    public void flipFacing(int anInt)
    {
        if(anInt == 1)
        {
            this.angleObj.SetDirection(Slider.Direction.RightToLeft, false);
            this.direction = 1;
        }
        else
        {
            this.angleObj.SetDirection(Slider.Direction.LeftToRight, false);
            this.direction = -1;
        } 
    }
}

