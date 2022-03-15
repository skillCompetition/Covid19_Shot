using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUIController : MonoBehaviour
{
    [SerializeField] Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = SystemManager.Instance.GameManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
