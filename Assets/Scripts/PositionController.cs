using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionController : MonoBehaviour
{
    public Player1 player1;
    public Player2 player2;
    public Image left;
    public Image right;
    private Sprite first;
    private Sprite second;

    // Start is called before the first frame update
    void Start()
    {
        left = GameObject.FindWithTag("PositionLeft").GetComponent<Image>();
        right = GameObject.FindWithTag("PositionRight").GetComponent<Image>();
        first = Resources.Load<Sprite>("1st");
        second = Resources.Load<Sprite>("2nd");
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.getPlayerZ() >= player2.getPlayerZ())
        {
            left.rectTransform.sizeDelta = new Vector2(184, 120);
            right.rectTransform.sizeDelta = new Vector2(224, 120);
            left.sprite = first;
            right.sprite = second;
        }
        else
        {
            left.rectTransform.sizeDelta = new Vector2(224, 120);
            right.rectTransform.sizeDelta = new Vector2(184, 120);
            left.sprite = second;
            right.sprite = first;
        }

        left.transform.position = new Vector3(Screen.width / 2 - 140, 80, 0);
        right.transform.position = new Vector3(Screen.width - 140, 80, 0);
    }
}
