using System.Collections;
using TMPro;
using UnityEngine;

public class PumpkinManager : MonoBehaviour
{
    public GameObject[] pumpkinStages; // [0]=Stage1, [1]=Stage2, [2]=Stage3
    public ParticleSystem carvingEffect;
    public int currentStage = 0;
    public TextMeshProUGUI winMessage; // Assign in inspector

    private bool hasWon = false;

    public void UseTool(int toolIndex)
    {
        if (currentStage >= pumpkinStages.Length - 1 || hasWon)
            return;

        carvingEffect.Play();
        pumpkinStages[currentStage].SetActive(false);
        currentStage++;
        pumpkinStages[currentStage].SetActive(true);

        // Check if this was the last stage
        if (currentStage == pumpkinStages.Length - 1)
        {
            hasWon = true;
            StartCoroutine(ShowWinMessageAfterDelay(3f)); // 3 second delay
        }
    }

    private IEnumerator ShowWinMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        winMessage.gameObject.SetActive(true);
    }
}