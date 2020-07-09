using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Game : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       Gamedata.clear = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        //이에스시키누르면종료
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

       
   
        if (Gamedata.clear >3)//이겼을때
        {
            SceneManager.LoadScene("3");
        }
    }
}
