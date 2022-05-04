using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text totalScore, bestResult;
    public SafePfers loadData;
    void Start()
    {
        totalScore.text = loadData.TOTAL_SCORE.ToString();
        bestResult.text = loadData.BEST_RESULT.ToString();
    }
}
