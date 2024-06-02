using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    public Text points;
    public Text best;

    public void tryagain() {
        SceneManager.LoadScene("game"); 
    }

    // Start is called before the first frame update
    void Start()
    {
        best.text = "Best Score: " + PlayerPrefs.GetInt("best");
        points.text = "My Score: " + PlayerPrefs.GetInt("points");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
