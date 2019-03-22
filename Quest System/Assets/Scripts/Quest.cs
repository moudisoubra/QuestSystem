using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [HideInInspector]public List<Objective> objectives;
    public int current = 0;
    public Objective currentObjective;

    // Start is called before the first frame update
    public void StartQuest()
    {
        current = 0;
        objectives[current].Begin();
        currentObjective = objectives[current];
    }

    // Update is called once per frame
    public void Next()
    {
        if (current < objectives.Count - 1)
        {
            current++;
            objectives[current].Begin();
            currentObjective = objectives[current];
        }

    }

    public void Previous()
    {
        if (current > 0)
        {
            current--;
            objectives[current].Begin();
            currentObjective = objectives[current];
        }
    }
}
