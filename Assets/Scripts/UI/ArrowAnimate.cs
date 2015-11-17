using UnityEngine;
using System.Collections;

public class ArrowAnimate : MonoBehaviour
{
    private float newScale = 1.75f;

    // Increase scale of UI object to newScale
    // TODO: Animate interpolation between values
    public void animateScale()
    {
        this.transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    // Revert object scale to 111
    // TODO: Animate interpolation between values
    public void revertScale()
    {
        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
