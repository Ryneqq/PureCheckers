using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Decline : MonoBehaviour {
public void Clicked()
    {
        Destroy(GameObject.Find("Main Camera").GetComponent<Draw>().temp2.gameObject);
        GameObject[] CheckerList = GameObject.FindGameObjectsWithTag("ButtonTag"); // w taki sposob się dostaje do obiektów
        foreach (GameObject Checker in CheckerList)
        {
            Checker.GetComponent<Button>().enabled = true;
        }
        GameObject[] SDList = GameObject.FindGameObjectsWithTag("SurrDraw"); // w taki sposob się dostaje do obiektów
        foreach (GameObject SD in SDList)
        {
            SD.GetComponent<Button>().enabled = true;
        }
    }
}
