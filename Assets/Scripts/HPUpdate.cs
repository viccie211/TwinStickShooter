using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPUpdate : MonoBehaviour {
    // Use this for initialization
    public Text t;
    public PlayerBehaviour Player;
	void Start () {
        t = (Text)this.gameObject.GetComponent("Text");
	}
	
	// Update is called once per frame
	void Update () {
        if(Player!=null)
        {
            t.text = "HP: " + Player.hp;
        }
        else
        {
            t.text = "HP: 0";
        }
	}
}
