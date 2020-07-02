using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingText : MonoBehaviour
{
  public  TextMeshProUGUI wintex;
  public TextMeshProUGUI losetex;
    public float SceneTime;
    private float TTime;
    public int token;
    // Start is called before the first frame update
    void Start()
    {
      //해당씬이 시작하면 승패를 토큰에 넣어줌
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {

            SceneManager.LoadScene("1");
        }
        TTime += Time.deltaTime;
        if (TTime > SceneTime) {
            SceneManager.LoadScene("1");
        }
        if (token>0)
        {
            losetex.alpha -= Time.deltaTime/2;
        }
        else
        {
            wintex.alpha -= Time.deltaTime/2;
        }
    }
}
