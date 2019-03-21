using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Objective))]
public class RemoveObjective : Editor
{
    public Objective objective;

    private void OnEnable()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (objective != null)
        {
            objective.quest.objectives.Remove(objective);
            Debug.Log("REMOVED");
        }

    }
}
