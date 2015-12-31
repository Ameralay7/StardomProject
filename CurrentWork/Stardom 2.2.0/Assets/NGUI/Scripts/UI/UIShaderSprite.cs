using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIShaderSprite : UISprite
{
    [SerializeField]
    Texture clipMask;

    // Set to null if you just want to restore it to the original NGUI's shader.
    [HideInInspector]
    [SerializeField]
    Shader mShader;
    Material mMaterial;

    // cache materials
    static Dictionary<int, Dictionary<int, Material>> mCachedAtlasMaterials = new Dictionary<int, Dictionary<int, Material>>();

    /// <summary>
    /// Substitute UISprite's material to dynamically change a shader of the given atlas material.
    /// </summary>
    public override Material material
    {
        get
        {
            if (mShader != null)
            {
                if (mMaterial == null || mChanged)
                {
                    Dictionary<int, Material> shaderMaterials;
                    if (!mCachedAtlasMaterials.TryGetValue(atlas.GetInstanceID(), out shaderMaterials))
                        mCachedAtlasMaterials[atlas.GetInstanceID()] = shaderMaterials = new Dictionary<int, Material>();

                    if (!shaderMaterials.TryGetValue(mShader.GetInstanceID(), out mMaterial) || mMaterial == null)
                    {
                        if (mAtlas != null)
                            shaderMaterials[mShader.GetInstanceID()] = mMaterial = new Material(mAtlas.spriteMaterial) { shader = mShader };
                    }
                }
                Debug.Log("qwed");
                mMaterial.SetTexture("_AlphaTex", clipMask);
                //ComputeBuffer b = new ComputeBuffer(4, 0);
                //b.SetData(new Vector2[]{
                //    new Vector2(0,0),   
                //    new Vector2(1,0),
                //    new Vector2(1,1),
                //    new Vector2(0,1),
                //});
                //mMaterial.SetBuffer("TEXCOORD1", b);
                //b.Dispose();

                return mMaterial;
            }
            return (mAtlas != null) ? mAtlas.spriteMaterial : null;
        }
    }

    /// <summary>
    /// Specified sprite to change material with the given shader so enables a shader on each of a sprite. 
    /// Pass null if it needs to be restored and NGUI handles a material.
    /// </summary>
    public void SetShader(Shader shd)
    {
        mShader = shd;
        panel.RebuildAllDrawCalls(); // need to force redraw to prevent not applying the shader on the sprite.
    }


    /// <summary>
    /// Virtual function called by the UIPanel that fills the buffers.
    /// </summary>

    public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
    {
        Texture tex = mainTexture;
        if (tex == null) return;

        if (mSprite == null) mSprite = atlas.GetSprite(spriteName);
        if (mSprite == null) return;

        Rect outer = new Rect(mSprite.x, mSprite.y, mSprite.width, mSprite.height);
        Rect inner = new Rect(mSprite.x + mSprite.borderLeft, mSprite.y + mSprite.borderTop,
            mSprite.width - mSprite.borderLeft - mSprite.borderRight,
            mSprite.height - mSprite.borderBottom - mSprite.borderTop);

        outer = NGUIMath.ConvertToTexCoords(outer, tex.width, tex.height);
        inner = NGUIMath.ConvertToTexCoords(inner, tex.width, tex.height);

        int offset = verts.size;
        Fill(verts, uvs, cols, outer, inner);

        if (onPostFill != null)
            onPostFill(this, offset, verts, uvs, cols);
    }
}
