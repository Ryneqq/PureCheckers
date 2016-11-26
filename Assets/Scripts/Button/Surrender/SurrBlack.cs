using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SurrBlack : MonoBehaviour {
    public Image PopUpWindow;
    public Image temp;
    public Canvas GameCanvas;
    public void Clicked()
    { 
        if (Variables.Turn == "Black")
        {
            GameObject[] CheckerList = GameObject.FindGameObjectsWithTag("ButtonTag"); // w taki sposob się dostaje do obiektów
            foreach (GameObject Checker in CheckerList)
            {
                Checker.GetComponent<Button>().enabled = false;
            }
            GameObject[] ActiveList = GameObject.FindGameObjectsWithTag("Active"); // w taki sposob się dostaje do obiektów
            foreach (GameObject Act in ActiveList)
            {
                Destroy(Act.gameObject);
            }
            GameObject[] SDList = GameObject.FindGameObjectsWithTag("SurrDraw"); // w taki sposob się dostaje do obiektów
            foreach (GameObject SD in SDList)
            {
                SD.GetComponent<Button>().enabled = false;
            }
            // pop up
            temp = (Image)Instantiate(PopUpWindow, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            temp.transform.SetParent(GameCanvas.transform, false);
            temp.GetComponent<RectTransform>().eulerAngles = new Vector3(180.0f, 180.0f, 0.0f);
        }
    }
}
