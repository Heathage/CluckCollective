using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    // Start is called before the first frame update

    public string TipText;
    public string Letter;
    public Sprite Icon;

    public GameObject TipRef;
    public GameObject IconRef;
    public GameObject LetterRef;
    public GameObject TextRef;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            StartCoroutine(ShowTooltip());
        }
    }

    IEnumerator ShowTooltip()
    {
        TipRef.SetActive(true);
        IconRef.GetComponent<Image>().sprite = Icon;
        TextRef.GetComponent<TextMeshProUGUI>().text = TipText;
        LetterRef.GetComponent<TextMeshProUGUI>().text = Letter;
        yield return new WaitForSeconds(4);
        TipRef.SetActive(false);
        Destroy(this.gameObject);
    }
}
