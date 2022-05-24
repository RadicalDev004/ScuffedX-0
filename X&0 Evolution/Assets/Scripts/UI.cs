using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class UI : MonoBehaviour
{
    public GameObject EndScreen, EndBkgr;

    private static UI instance;


    void Start()
    {
        instance = gameObject.GetComponent<UI>();
    }


    void EndUI(Table.Winner winner)
    {
        StartCoroutine(WaitToShowEndUI(winner));
    }


    public static void EndGame(Table.Winner winner)
    {
        Handheld.Vibrate();
        instance.EndUI(winner);
    }


    IEnumerator WaitToShowEndUI(Table.Winner winner)
    {
        yield return new WaitForSecondsRealtime(2);

        LeanTween.scale(EndScreen, Vector3.one, 0.3f).setIgnoreTimeScale(true);
        EndBkgr.SetActive(true);

        if (winner == Table.Winner.blue)
        {
            EndScreen.GetComponentInChildren<TMP_Text>().text = "BLUE Wins!!!";
            EndScreen.GetComponentInChildren<TMP_Text>().color = Color.blue;
        }
        else if (winner == Table.Winner.red)
        {
            EndScreen.GetComponentInChildren<TMP_Text>().text = "RED Wins!!!";
            EndScreen.GetComponentInChildren<TMP_Text>().color = Color.red;
        }
        else if (winner == Table.Winner.draw)
        {
            EndScreen.GetComponentInChildren<TMP_Text>().text = "Draw?";
            EndScreen.GetComponentInChildren<TMP_Text>().color = Color.gray;
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
