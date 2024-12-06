using UnityEngine;

public class DecisionTimeLogger : MonoBehaviour
{
    public void LogDecisionTime(string methodName, System.Action decisionMethod)
    {
        float startTime = Time.realtimeSinceStartup;

        decisionMethod.Invoke();

        float endTime = Time.realtimeSinceStartup;
        float elapsedTime = (endTime - startTime) * 1000f;

        Debug.Log($"{methodName} Decision Time: {elapsedTime:F2} ms");
    }
}