using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Game : MonoBehaviour
{
    public RawImage cow,sheep,duck, chicken;
    public TextMeshProUGUI Day;
    [SerializeField] float gamestatus;
    
    public GameObject temp;
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

        if(Gamedata.str != null)
        {
            temp = GameObject.Find("ani" + Gamedata.str);
            
        }

        if (Gamedata.str=="cow")
        {
            Gamedata.cown = 1;

            Gamedata.str = "";
            cow.CrossFadeAlpha(0, 4, true);
            Gamedata.clear += 1;
        }
        if (Gamedata.str == "duck")
        {

            duck.CrossFadeAlpha(0, 4, true);
            Gamedata.duckn = 1;
          
            Gamedata.str = "";
            Gamedata.clear += 1;
        }
        if (Gamedata.str == "sheep")
        {

            sheep.CrossFadeAlpha(0, 4, true);
            Gamedata.sheepn = 1;
        
            Gamedata.str = "";
            Gamedata.clear += 1;
        }
        if (Gamedata.str == "chicken")
        {

            chicken.CrossFadeAlpha(0, 4, true);
            Gamedata.chickenn = 1;
            
            Gamedata.str = "";
            Gamedata.clear += 1;
        }
       

        if (Gamedata.clear >3)//이겼을때
        {
            SceneManager.LoadScene("3");
        }
    }
}
