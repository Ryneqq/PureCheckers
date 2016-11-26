using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Draw : MonoBehaviour {

    private Button temp;
    public Button DrawButt;
    public Image temp2;
    public Image PopupDraw;
    public Canvas GameCanvas;

    public void Clicked()
    {
        Variables.WhiteDraw = false;
        Variables.BlackDraw = false;
        //spawn dialogue window
        // jezeli obie strony wyraza zgode skrypt zespawnuje draw button
        GameObject[] CheckerList = GameObject.FindGameObjectsWithTag("ButtonTag"); // w taki sposob się dostaje do obiektów
        foreach (GameObject Checker in CheckerList)
        {
            Checker.GetComponent<Button>().enabled = false;
        }
        GameObject[] SDList = GameObject.FindGameObjectsWithTag("SurrDraw"); // w taki sposob się dostaje do obiektów
        foreach (GameObject SD in SDList)
        {
            SD.GetComponent<Button>().enabled = false;
        }
        temp2 = (Image)Instantiate(PopupDraw, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        temp2.transform.SetParent(GameCanvas.transform, false);
    }
    public void Spawn()
    {
        Destroy(temp2.gameObject);
        temp = (Button)Instantiate(DrawButt, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        temp.transform.SetParent(GameCanvas.transform, false);
    }
}
