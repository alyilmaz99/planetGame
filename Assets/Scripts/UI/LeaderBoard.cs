using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderBoard : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI rank1Text;
    [SerializeField] private TextMeshProUGUI rank2Text;
    [SerializeField] private TextMeshProUGUI rank3Text;
    [SerializeField] private TextMeshProUGUI rank4Text;

    
    public List<TextMeshProUGUI> rankingTexts = new List<TextMeshProUGUI>();

    void Start()
    {
      

        rankingTexts.Add(rank1Text);
        rankingTexts.Add(rank2Text);
        rankingTexts.Add(rank3Text);
        rankingTexts.Add(rank4Text);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("sssss");
            for(int i=0; i < rankingTexts.Count; i++)
            {
                rankingTexts[i].text = i.ToString();
            }

        }
    }
}
