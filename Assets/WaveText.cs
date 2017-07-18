using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveText : MonoBehaviour {
    public Text t;
    public SpawnEnemies se;
    void Start()
    {
        t = (Text)this.gameObject.GetComponent("Text");
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Wave: " + se.wave;
    }
}
