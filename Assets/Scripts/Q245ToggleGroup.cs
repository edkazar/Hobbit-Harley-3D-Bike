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

    [SerializeField] private GameObject DrivewayBrakeLights;
    [SerializeField] private GameObject DrivewayBackLights;

    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        source.Play();
    }

    public void Submit()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(toggle.name + ": " + toggle.GetComponentInChildren<Text>().text);
        oops.SetActive(false);
        if (toggle.name=="Toggle" + ans)
        {
            QuizCorrect();
        }
        else
        {
            QuizWrong();
            
        }
    }

    public void QuizCorrect()
    {
        source.clip = correct;
        source.Play();
        quizfin.SetActive(false);
        re.SetActive(true);

        Invoke(nameof(changeCarLights), 0.1f);

    }

    public void QuizWrong()
    {
        source.clip = wrong;
        source.Play();
        oops.SetActive(true);
    }

    public void changeCarLights()
    {
        if (DrivewayBackLights != null)
        {
            DrivewayBrakeLights.SetActive(true);
            DrivewayBackLights.SetActive(false);
        }
    }
}
