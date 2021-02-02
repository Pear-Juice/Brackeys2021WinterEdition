using UnityEngine;
using UnityEngine.UI;

public class UI_Master : MonoBehaviour
{
    public RawImage pyramidRendO;
    public RawImage noiseBG;

    public float noiseThreshold;
    public float noiseScrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        noiseBG.texture = CreateNoiseTex(64, 32);
    }

    // Update is called once per frame
    void Update()
    {
        pyramidRendO.color = new Color(1f, 1f, 1f, Mathf.Sin(Time.time) + 1f);

        noiseBG.color = Color.HSVToRGB(Mathf.Repeat(Time.time / 40 + .5f, 1f), 1f, 1f);
        noiseBG.uvRect = new Rect(new Vector2(0f, Time.time * noiseScrollSpeed), Vector2.one);
    }

    Texture2D CreateNoiseTex(int rX, int rY) {
        Texture2D tex = new Texture2D(rX, rY, TextureFormat.RGBAHalf, false);
        tex.filterMode = FilterMode.Point;

        Color[] colBuffer = new Color[rX * rY];
        for(int x = 0; x < rX; x++) {
            for (int y = 0; y < rY; y++) {
                colBuffer[y * rX + x] = Random.value >= noiseThreshold ? Color.white : Color.black;
            }
        }

        tex.SetPixels(colBuffer);
        tex.Apply();
        return tex;
	}
}
