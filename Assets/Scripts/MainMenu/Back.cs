using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {
	public void Clicked(){
		Application.LoadLevel ("MainMenu");
        Ads.ShowAd();
	}
}
