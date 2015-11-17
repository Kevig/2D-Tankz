using UnityEngine;
using System.Collections;

public class ClickTrack : MonoBehaviour
{
    private PlayerGUICore playerCore;

    public void Awake()
    {
        this.playerCore = GameObject.Find("Player").GetComponent<PlayerGUICore>();
    }

    public void OnMouseDown()
    {
        this.playerCore.onClick(this.gameObject);   
    }

}
