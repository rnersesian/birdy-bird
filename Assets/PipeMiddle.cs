using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PipeMiddle : MonoBehaviour
{

    public LogicManagerScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.Find("Logic Manager").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logicScript.addScore(2);
        }
    }
}
