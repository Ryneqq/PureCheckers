using UnityEngine;
using System.Collections;

public class AcceptW : MonoBehaviour {
    public void Clicked()
    {
        GameObject.Find("Main Camera").GetComponent<Turns>().WonMethod("Black");
        Destroy(GameObject.Find("PopupSurrW(Clone)").gameObject);
    }
}
