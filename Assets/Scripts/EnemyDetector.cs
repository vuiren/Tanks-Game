using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private Image warnSignImage;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private GameObject player1, player2;
    [SerializeField] private float maxDetectDistance = 100f, beepCoef = 10f;

    // Update is called once per frame
    void Update()
    {
        var currentColor = warnSignImage.color;
        var rawDistance = Vector3.Distance(player1.transform.position, player2.transform.position);

        distanceText.text = rawDistance> maxDetectDistance? ">" + maxDetectDistance.ToString("0") + "m" : "<" + maxDetectDistance.ToString("0") + "m";
        warnSignImage.enabled = (rawDistance <= maxDetectDistance);

        var sin = Mathf.Sin(Time.time * beepCoef);

        warnSignImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, sin);
    }
}
