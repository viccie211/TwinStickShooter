using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPUpdate : MonoBehaviour {
    // Use this for initialization
    public Text t;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Enemy e= this.gameObject.GetComponent<Enemy>();
        t.text = e.hp+"";
	}
}
