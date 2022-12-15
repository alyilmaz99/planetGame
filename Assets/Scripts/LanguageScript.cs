using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageScript : MonoBehaviour
{
    public List<Text> Scenetexts;
    public List<SceneTranslater> translaters;

    void Start()
    {
        Debug.Log(Scenetexts.Count);
        
        
        
    }

    public void translate(int x){
        for(int i = 0; i < translaters.Count; i++){
            if(x == 0)
            Scenetexts[i].text = translaters[i].English;
            if(x == 1)
            Scenetexts[i].text = translaters[i].Turkish;
        }
    }

    
    void Update()
    {
        if(Application.systemLanguage == SystemLanguage.English)
        translate(0);
        if(Application.systemLanguage == SystemLanguage.Turkish)
        translate(1);
    }
}
 [System.Serializable]
public class SceneTranslater{
    public string Turkish;
    public string English;

    public SceneTranslater(string turkish, string english){
        Turkish = turkish;
        English = english;
    }
}
