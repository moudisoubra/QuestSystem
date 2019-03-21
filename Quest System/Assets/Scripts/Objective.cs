using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Objective : MonoBehaviour
{
    [Header ("Begin")]
    public List<GameObject> enabledOnBegin;
    public List<GameObject> disabledOnBegin;
    public UnityEvent OnBegin;
    [Space]
    [Header("Complete")]
    public List<GameObject> enabledOnComplete;
    public List<GameObject> disabledOnComplete;
    public UnityEvent OnEnd;

    public Quest quest;

    public void Begin()
    {
        if (enabledOnBegin != null)
        {
            for (int i = 0; i < enabledOnBegin.Count; i++)
            {
                enabledOnBegin[i].SetActive(true);
            }
        }

        if (disabledOnBegin != null)
        {
            for (int i = 0; i < disabledOnBegin.Count; i++)
            {
                disabledOnBegin[i].SetActive(false);
            }
        }
    }

    public void Complete()
    {
        if (enabledOnComplete != null)
        {
            for (int i = 0; i < enabledOnComplete.Count; i++)
            {
                enabledOnComplete[i].SetActive(true);
            }
        }

        if (disabledOnComplete != null)
        {
            for (int i = 0; i < disabledOnComplete.Count; i++)
            {
                disabledOnComplete[i].SetActive(false);
            }
        }

        quest.Next();
    }

    private void OnDestroy()
    {
        quest = GetComponentInParent<Quest>();
        quest.objectives.Remove(this);
        Debug.Log("REMOVED");
    }

    private void OnDisable()
    {
        quest = GetComponentInParent<Quest>();
        quest.objectives.Remove(this);
        Debug.Log("REMOVED");
    }

}
