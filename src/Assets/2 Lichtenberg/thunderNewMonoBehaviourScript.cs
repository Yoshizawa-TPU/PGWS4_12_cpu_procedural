using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderNewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] Material material = default!;
    [SerializeField] MeshFilter meshFilter = default!;
    Texture2D texture = null;
    [SerializeField] int TEX_WIDTH = 128;
    [SerializeField] int TEX_HEIGHT = 64;

    ThunderNewEmptyCSharpScript lichtenberg = null;

    float time = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texture = new Texture2D(TEX_WIDTH, TEX_HEIGHT, TextureFormat.RGBA32, false);
        material.SetTexture("_Texture2D", texture);

        lichtenberg = new ThunderNewEmptyCSharpScript(TEX_HEIGHT, TEX_WIDTH);

        //UpdateTexture();
        int x = TEX_WIDTH / 2;
        int y = TEX_HEIGHT - 1;
        lichtenberg.Initialize(y, x);

        StartCoroutine(Simulate());
    }
    

    void Generate()
    {
        int x = TEX_WIDTH / 2;
        int y = TEX_HEIGHT -1;
        lichtenberg.Initialize(y, x);

        while (lichtenberg.Update() == ThunderNewEmptyCSharpScript.State.Running) ;
        UpdateTexture();
        List<int> path = new List<int>();
        int p = lichtenberg.ArriveIndex;
        while (lichtenberg.Parent[p] != p)
        {

        }
    }

    private IEnumerator Simulate()
    {
        while (lichtenberg.Update() == ThunderNewEmptyCSharpScript.State.Running)
        {
            UpdateTexture();
            yield return null;
        }
    }
    
    void UpdateTexture()
    {
        var pixeData = texture.GetPixelData<Color32>(0);

        ushort[] value = lichtenberg.Value;
        double vMax = (double)lichtenberg.ValueMax;

        int idx = 0;
        for(int y = 0;y< TEX_HEIGHT; y++)
        {
            for (int x = 0; x < TEX_WIDTH; x++)
            {
                byte c = (byte)(256.0 * (double)value[idx] / (vMax + 1));
                pixeData[idx] = new Color32(c, c, c, 255);
                idx++;
            }
        }

        texture.Apply();
    }
    
}
