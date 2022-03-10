using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_Text txtscore;
    GameController controller;
    public int Points = 0;
    public int Health = 100;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        txtscore.text = "Score: " + Points.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ArrowPoints")
        {
            controller.Points += 1;
        }
        
    }
}
