using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerBackgroundTexture : MonoBehaviour {

    public Shader shader;

    private Material m_Material;

    protected virtual void Start()
    {
        // Disable if we don't support image effects
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        }

        // Disable the image effect if the shader can't
        // run on the users graphics card
        if (!shader || !shader.isSupported)
            enabled = false;
    }


    protected Material material
    {
        get
        {
            if (m_Material == null)
            {
                m_Material = new Material(shader);
                m_Material.hideFlags = HideFlags.HideAndDontSave;
            }
            return m_Material;
        }
    }


    protected virtual void OnDisable()
    {
        if (m_Material)
        {
            DestroyImmediate(m_Material);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //material.SetTexture("_Vignette", _vignette);
        int rtW = source.width / 4;
        int rtH = source.height / 4;
        RenderTexture buffer = RenderTexture.GetTemporary(rtW, rtH, 0);
        
        Graphics.Blit(buffer, destination);

        RenderTexture.ReleaseTemporary(buffer);
    }
}
