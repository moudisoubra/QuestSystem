using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [HideInInspector]public List<Objective> objectives;
    public int current = 0;

    // Start is called before the first frame update
    public void StartQuest()
    {
        current = 0;
        objectives[current].Begin();
    }

    // Update is called once per frame
    public void Next()
    {
        current++;
        objectives[current].Begin();
    }

    public void Previous()
    {
        current--;
        objectives[current].Begin();
    }
}
