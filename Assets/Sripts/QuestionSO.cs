using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Compound", fileName = "New Compound")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string compound = "Enter new compound name here";
    [SerializeField] int answerIndex;

    public string GetCompundName()
    {
        return compound;
    }

    public int GetAnswerIndex()
    {
        return answerIndex;
    }
}
//commenting commenting
