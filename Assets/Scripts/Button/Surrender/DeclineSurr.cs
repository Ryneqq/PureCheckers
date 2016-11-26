using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeclineSurr : MonoBehaviour {
    public void Clicked()
    {
        //Destroy(GameObject.Find("Main Camera").GetComponent<Draw>().temp2.gameObject);
        GameObject[] CheckerList = GameObject.FindGameObjectsWithTag("ButtonTag"); 
        foreach (GameObject Checker in CheckerList)
        {
            Checker.GetComponent<Button>().enabled = true;
        }
        GameObject[] SDList = GameObject.FindGameObjectsWithTag("SurrDraw"); // w taki sposob się dostaje do obiektów
        foreach (GameObject SD in SDList)
        {
            SD.GetComponent<Button>().enabled = true;
        }
        if (Variables.Turn == "White")
        {
            Destroy(GameObject.Find("PopupSurrW(Clone)").gameObject);
        }
        if (Variables.Turn == "Black")
        {
            Destroy(GameObject.Find("BPopupSurr(Clone)").gameObject);
        }
    }
}
