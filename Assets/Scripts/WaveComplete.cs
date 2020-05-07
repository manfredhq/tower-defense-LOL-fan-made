using System.Collections;
using TMPro;
using UnityEngine;

public class WaveComplete : MonoBehaviour
{
    public TMP_Text wavesText;

    public float timeBetweenImproveText = .05f;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {

        wavesText.text = "0";
        int waves = 0;

        yield return new WaitForSeconds(.7f);

        while (waves < PlayerStats.waves)
        {
            waves++;
            wavesText.text = waves.ToString();
            yield return new WaitForSeconds(timeBetweenImproveText);
        }

    }
}
