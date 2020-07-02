using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Game : MonoBehaviour
{
    public RawImage cow,sheep,duck, chicken;
    public TextMeshProUGUI Day;

    // Start is called before the first frame update
    void Start()
    {

        cow.CrossFadeAlpha(1, 4, true);
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
