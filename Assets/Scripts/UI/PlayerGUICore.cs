using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerGUICore : MonoBehaviour
{
    // Define

    // Links
    private PlayerControl player;
    private Utility util;
    private UIGunRotationControl gunRotationControl;

    private GameObject clickTarget;
    private Transform uiAngleControl;
    private Transform uiGunAngleControl;
    private ArrowAnimate moveLeftArrow;
    private ArrowAnimate moveRightArrow;

    // Controls
    public bool gunRotationLock;
    public bool moveLeft;
    public bool moveRight;
    public bool fireButton;

    public void Awake()
    {
        // Assign Links
        this.player = this.GetComponent<PlayerControl>();
        this.util = this.GetComponent<Utility>();
        this.gunRotationControl = GameObject.Find("rotationPoint").GetComponent<UIGunRotationControl>();

        this.moveLeftArrow = GameObject.Find("ArrowLeft").GetComponent<ArrowAnimate>();
        this.moveRightArrow = GameObject.Find("ArrowRight").GetComponent<ArrowAnimate>();
        this.uiAngleControl = GameObject.Find("rotationPoint").transform;
        this.uiGunAngleControl = GameObject.Find("GunAngleSlider").transform;

        // Set controls
        this.gunRotationLock = true;
        this.moveLeft = false;
        this.moveRight = false;
        this.fireButton = false;
    }

    // Returns rotation lock
    public bool getGunRotationLock()
    {
        return this.gunRotationLock;
    }

    // Returns fire button state
    public bool getFireBtnState()
    {
        return this.fireButton;
    }

    // Tracks clicks / activation of UI Gameobjects, receives gameobject reference
    public void onClick(GameObject anObj)
    {
        string objName = anObj.name;
        bool hideCursor = false;

        // Switch state using gameObject names as trigger
        switch(objName)
        {
            // Crosshair activation unlocks gun rotation
            case "UICrossHair":
                gunRotationLock = false;
                hideCursor = true;
                break;
            
            // Left move arrow allows player movement 
            case "ArrowLeft":
                this.moveLeft = true;
                this.moveLeftArrow.animateScale();
                hideCursor = true;
                break;

            // Right move arrow allows player movement 
            case "ArrowRight":
                this.moveRight = true;
                this.moveRightArrow.animateScale();
                hideCursor = true;
                break;

            case "RedButton":
                this.fireButton = true;
                hideCursor = false;
                break;
        }

        if(hideCursor)
        {
            // Cursor utility class -> lock n hide
            CursorUtility.toggleCursorLock(true);
        }
    }

    // Removes, reverts all locks / bools and reverts any animated elements
    public void onClickUp()
    {
        this.gunRotationLock = true;
        this.moveLeft = false;
        this.moveRight = false;
        this.fireButton = false;

        this.moveLeftArrow.revertScale();
        this.moveRightArrow.revertScale();

        CursorUtility.toggleCursorLock(false);
    }

    public void Update()
    {
        // If rotation is NOI locked, update rotation angle tracking mouse direction axis
        if(!this.gunRotationLock)
        {
            this.gunRotationControl.updateRotationAngle(this.util.getDragDirection());
        }

        if(this.moveLeft)
        {
            this.player.moveLeft();
        }

        if(this.moveRight)
        {
            this.player.moveRight();
        }
    }

    public void LateUpdate()
    {
        // Track left mouse button state and fire onClickUp on release
        if(Input.GetMouseButtonUp(0))
        {
            this.onClickUp();
        }
    }

    public void flipFacing(int anInt)
    {
        Vector3 rot = this.uiAngleControl.eulerAngles;
        if(anInt == 1)
        {
            this.uiAngleControl.eulerAngles = new Vector3(rot.x, 0f, rot.z);
            this.uiGunAngleControl.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else
        {
            this.uiAngleControl.eulerAngles = new Vector3(rot.x, 180f, rot.z);
            this.uiGunAngleControl.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        this.gunRotationControl.flipFacing(anInt);
    }
}
