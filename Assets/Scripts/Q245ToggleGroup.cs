using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Q245ToggleGroup : MonoBehaviour
{
    ToggleGroup toggleGroup;
    public int ans;
    public GameObject re;
    public GameObject oops;
    public GameObject quizfin;

    public AudioSource source;
    public AudioClip correct;
    public AudioClip wrong;
    
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        source.Play();
    }

    public void Submit()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(toggle.name + ": " + toggle.GetComponentInChildren<Text>().text);
        if(toggle.name=="Toggle" + ans)
        {
            QuizCorrect();
        }
        else
        {
            QuizWrong();
            oops.SetActive(true);
        }
    }

    public void QuizCorrect()
    {
        source.clip = correct;
        source.Play();
        re.SetActive(true);
        quizfin.SetActive(false);
    }

    public void QuizWrong()
    {
        source.clip = wrong;
        source.Play();
    }
}
