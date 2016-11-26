using UnityEngine;
using System.Collections;

public class AcceptB : MonoBehaviour {
    public void Clicked()
    {
        GameObject.Find("Main Camera").GetComponent<Turns>().WonMethod("White");
        Destroy(GameObject.Find("BPopupSurr(Clone)").gameObject);
     }
}
