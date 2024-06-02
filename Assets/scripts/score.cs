using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    public int points = 0;
    public Text showScore;
    int time = 60;
    public Text showTime;

    void end()
    {
        PlayerPrefs.SetInt("points", points);
        int best = PlayerPrefs.GetInt("best");
        if (points > best)
        {
            PlayerPrefs.SetInt("best", points); 
        }
        SceneManager.LoadScene("end");
    }

    void timer()
    {
        time -= 1;
        showTime.text = "Time: " +time.ToString();

        if (time == 0)
        {
            end();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "coin")
        {
            Destroy(other.gameObject);

            int num = Random.Range(1, 6)*100;
            points += num;

            showScore.text = "Score: " + points;
        }

        if(other.name == "enemy")
        {
            end();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("timer", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
