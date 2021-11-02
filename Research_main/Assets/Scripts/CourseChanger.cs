using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseChanger : MonoBehaviour
{

    private int rnd;

    // Start is called before the first frame update
    void Start()
    {

        // 初期化
        GetComponent<Scooter>().enabled = false;
        GetComponent<Scooter1>().enabled = false;
        GetComponent<Scooter2>().enabled = false;

        rnd = Random.Range(0, 3);

        // ランダムな３パターン
        if (rnd == 0)
        {
            GetComponent<Scooter>().enabled = true;
        }
        else if (rnd == 1)
        {
            GetComponent<Scooter1>().enabled = true;
        }
        if (rnd == 2)
        {
            GetComponent<Scooter2>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
