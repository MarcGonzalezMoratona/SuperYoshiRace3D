using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDancerYoshi : MonoBehaviour
{
    public GameObject dancerYoshiGreen;
    public GameObject dancerYoshiYellow;
    int winner;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj;
        if (Player1.isWinner())
        {
            obj = (GameObject)Instantiate(dancerYoshiGreen, new Vector3(0f, -0.3f, -1f), dancerYoshiGreen.transform.rotation);
            obj.transform.Rotate(0, -180, 0);
            obj.transform.parent = transform;
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("IsDancingSalsa", true);
        }
        else if (Player2.isWinner())
        {
            obj = (GameObject)Instantiate(dancerYoshiYellow, new Vector3(0f, -0.3f, -1f), dancerYoshiYellow.transform.rotation);
            obj.transform.Rotate(0, -180, 0);
            obj.transform.parent = transform;
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("IsDancingSalsa", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
