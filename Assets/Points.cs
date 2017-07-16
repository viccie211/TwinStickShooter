using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Points : MonoBehaviour {

    public int points = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Text t = (Text)this.gameObject.GetComponent("Text");
        t.text = "Points: " + points;
	}
}
