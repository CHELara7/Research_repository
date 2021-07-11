using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{

    [SerializeField] private Text countdownText;

    public bool endCount = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Countdown");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Countdown()
    {
        Debug.Log("Debug : start count down");
        countdownText.enabled = false;  //　テキスト非表示
        yield return new WaitForSeconds(1);  //　1秒待つ
        countdownText.enabled = true;  //　テキスト表示
        //　カウントダウンするループ
        for (int i = 2; i >= 0; i--)
        {
            countdownText.text = (i + 1).ToString();  //　文字の表示を切り替える
            yield return new WaitForSeconds(1.5f);  //　1秒待つ
        }
        countdownText.color = new Color(1.0f, 0f, 0f, 1.0f);  //　文字を赤色へ
        countdownText.text = "START!";  //　スタート
        yield return new WaitForSeconds(2);  //　1秒待つ
        countdownText.enabled = false;  //　テキスト非表示
        //　ゲーム開始
        endCount = true;
    }
}
