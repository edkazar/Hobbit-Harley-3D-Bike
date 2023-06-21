using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    // the image you want to fade, assign in inspector
    [SerializeField] public Image img;

    public void OnClick()
    {
        // fades the image out when you click
        StartCoroutine(FadingImage(true));
    }

    IEnumerator FadingImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            Debug.Log("Here");
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
