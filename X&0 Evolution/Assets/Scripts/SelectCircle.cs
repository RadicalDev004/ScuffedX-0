using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectCircle : MonoBehaviour
{
    private Button Select;
    public bool shouldSelect;
    public static int selectedIndexBlue = 0, selectedIndexRed = 0;
    public int indB, indR;
    void Start()
    {
        selectedIndexBlue = 0;
        selectedIndexRed = 0;
        Select = GetComponent<Button>();
        Select.onClick.AddListener(OnCircleSelect);
    }

    // Update is called once per frame
    void Update()
    {
        if(GetIndex() != gameObject.transform.GetSiblingIndex())
        {
            OnCircleDisSelect();
        }
        if(transform.parent.name != "Player1" && transform.parent.name != "Player2")
        {
            SetIndex(-1);
            OnCircleDisSelect();
            Debug.Log(transform.parent.name + " " +name + " " + GetIndex());
            enabled = false;
        }
        indB = selectedIndexBlue;
        indR = selectedIndexRed;
    }

    public void OnCircleSelect()
    {
        SetIndex(gameObject.transform.GetSiblingIndex());
        gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 75);
    }
    public void OnCircleDisSelect()
    {
        gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
    }

    public int GetIndex()
    {
        if (transform.parent.name == "Player1")
            return selectedIndexBlue;
        else
            return selectedIndexRed;
    }
    public void SetIndex(int toSet)
    {
        if (transform.parent.name == "Player1")
            selectedIndexBlue = toSet;
        else
            selectedIndexRed = toSet;
    }
}
