using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayMenu : MonoBehaviour
{

    public Button PlayBot;
    public Button PlayFriend;
    public GameObject B;
    int s;
    int t;

    public GameObject Bot;
    public GameObject Friend;
    public GameObject Online;

    public GameObject Rules;
    public GameObject CloseRules;

    public GameObject cog;
    public GameObject closeSet;

    public GameObject settingz;

    public GameObject BeforeOnline;
    // Start is called before the first frame update
    public void OpenBedoreOnline()
    {
        BeforeOnline.SetActive(true);
    }

    public void GoOnline(TMP_InputField name)
    {
       

        string scene = "JocChestieOnline";
        if(name.text==null)
        {
        return;
        }

        PlayerPrefs.SetString("username", name.text);

        SceneManager.LoadScene(scene);

    }

    void Start()
    {
        closeSet.gameObject.SetActive(false);
        CloseRules.gameObject.SetActive(false);

        B.gameObject.SetActive(false);

        Rules.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        settingz.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void Openplay()
    {
        B.gameObject.SetActive(true);
        LeanTween.scale(Bot, new Vector3(1, 1, 1), 0.2f);
        LeanTween.scale(Friend, new Vector3(1, 1, 1), 0.2f);
        LeanTween.scale(Online, new Vector3(1, 1, 1), 0.2f);

        LeanTween.move(Bot.GetComponent<RectTransform>(), new Vector3(-217.83f, -850f, 0), 0.2f);
        LeanTween.move(Friend.GetComponent<RectTransform>(), new Vector3(229.17f, -850f, 0), 0.2f);
        LeanTween.move(Online.GetComponent<RectTransform>(), new Vector3(0, -475f, 0), 0.2f);
    }
    public void ClosePlay()
    {
        B.gameObject.SetActive(false);

        LeanTween.scale(Bot, new Vector3(0, 0, 0), 0.2f);
        LeanTween.scale(Friend, new Vector3(0, 0, 0), 0.2f);
        LeanTween.scale(Online, new Vector3(0, 0, 0), 0.2f);

        LeanTween.move(Bot.GetComponent<RectTransform>(), new Vector3(0, -659.5398f, 0), 0.2f);
        LeanTween.move(Friend.GetComponent<RectTransform>(), new Vector3(0, -659.5398f, 0), 0.2f);
        LeanTween.move(Online.GetComponent<RectTransform>(), new Vector3(0, -659.5398f, 0), 0.2f);
    }
    
    public void openRules()
    {
        CloseRules.gameObject.SetActive(true);
        LeanTween.scale(Rules.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.2f);
        LeanTween.move(Rules.GetComponent<RectTransform>(), new Vector3(-3.135f, -30.956f, 0), 0.2f);
    }
    public void closeRules()
    {
        CloseRules.gameObject.SetActive(false);
        LeanTween.scale(Rules.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.2f);
        LeanTween.move(Rules.GetComponent<RectTransform>(), new Vector3(436.08f, 863.69f, 0), 0.2f);
    }
    public void openSettingz()
    {
        LeanTween.scale(settingz, new Vector3(1, 1, 1), 0.2f);
        LeanTween.move(settingz.GetComponent<RectTransform>(), new Vector3(0, 105.9f, 0), 0.2f);
        closeSet.gameObject.SetActive(true);
        LeanTween.rotateAround(cog, Vector3.forward, -180, 0.2f);
    }
    public void closeSettingz()
    {
        LeanTween.scale(settingz, new Vector3(0, 0, 0), 0.2f);
        LeanTween.move(settingz.GetComponent<RectTransform>(), new Vector3(-439.89f, 863.69f, 0), 0.2f);
        closeSet.gameObject.SetActive(false);
        LeanTween.rotateAround(cog, Vector3.forward, 180, 0.2f);
    }
}
