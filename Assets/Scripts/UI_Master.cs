using UnityEngine;
using UnityEngine.UI;

public class UI_Master : MonoBehaviour
{
    public RawImage pyramidRendO;

    // Update is called once per frame
    void Update()
    {
        pyramidRendO.color = new Color(1f, 1f, 1f, Mathf.Sin(Time.time) + 1f);
    }
}
