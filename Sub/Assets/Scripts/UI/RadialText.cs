using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text)), ExecuteAlways]
public class RadialText : MonoBehaviour
{
    [Header("Radial Settings")]
    public float radius = 10.0f;
    public float angleOffset = 0.0f;

    private bool hasUpdated = true;

    private TMP_TextInfo textInfo;
    private int characterCount;
    private int materialIndex;
    private int vertexIndex;

    private Vector2 charMidBasline;
    private Vector3 midOffset;
    private Vector3[] charSourceVertices;
    private Vector3[] charDestinationVertices;

    private bool hasCanvas => GetComponentInParent<Canvas>();

    private Matrix4x4 matrix;
    private TMP_MeshInfo[] cachedMeshInfo;

    private int i;

    private TMP_Text m_TextComponent;
    private TMP_Text textComponent 
    {
        get 
        {
            if (!m_TextComponent) m_TextComponent = GetComponent<TMP_Text>();
            return m_TextComponent;
        }
    }

    private RectTransform m_rect;
    public RectTransform rect
    {
        get
        {
            if (!m_rect) m_rect = GetComponent<RectTransform>();
            return m_rect;
        }
    }
    void OnEnable() => TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
    void OnDisable() => TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
    void ON_TEXT_CHANGED(Object obj)
    {
        if (obj == textComponent)
            hasUpdated = true;
    }
    // Start is called before the first frame update
    void Update()
    {
        if(hasUpdated)
            UpdateText();
    }

    private void OnValidate() => hasUpdated = true;

    // Update is called once per frame
    void UpdateText()
    {
        hasUpdated = false;
        rect.sizeDelta = new Vector2(hasCanvas ? radius * 2 : 0.001f, 0.001f);// Needed to work properly with original TMP_Text alignment settings.
        // We force an update of the text object since it would only be updated at the end of the frame. Ie. before this code is executed on the first frame.
        // Alternatively, we could yield and wait until the end of the frame when the text object will be generated.
        textComponent.ForceMeshUpdate();
        textInfo = textComponent.textInfo;

        // Cache the vertex data of the text object as the Jitter FX is applied to the original position of the characters.
        cachedMeshInfo = textInfo.CopyMeshInfoVertexData();
        characterCount = textInfo.characterCount;

        for (i = 0; i < characterCount; i++)
        {
            TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

            // Skip characters that are not visible and thus have no geometry to manipulate.
            if (!charInfo.isVisible)
                continue;

            // Get the index of the material used by the current character.
            materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

            // Get the index of the first vertex used by this text element.
            vertexIndex = textInfo.characterInfo[i].vertexIndex;

            // Get the cached vertices of the mesh used by this text element (character or sprite).
            charSourceVertices = cachedMeshInfo[materialIndex].vertices;

            // Determine the center point of each character at the baseline.
            charMidBasline = new Vector2((charSourceVertices[vertexIndex + 0].x + charSourceVertices[vertexIndex + 2].x) / 2, charInfo.baseLine);
            // Determine the center point of each character.
            //charMidBasline = (charSourceVertices[vertexIndex + 0] + charSourceVertices[vertexIndex + 2]) / 2;

            // Need to translate all 4 vertices of each quad to aligned with middle of character / baseline.
            // This is needed so the matrix TRS is applied at the origin for each character.
            midOffset = charMidBasline;

            charDestinationVertices = textInfo.meshInfo[materialIndex].vertices;
            matrix = Matrix4x4.TRS(-midOffset + localToRadialCordinates(dist2Rad(midOffset.x, radius + midOffset.y) + angleOffset * Mathf.Deg2Rad, radius + midOffset.y), Quaternion.Euler(0, 0, -dist2Rad(midOffset.x * Mathf.Rad2Deg, radius + midOffset.y) - angleOffset), Vector3.one);

            charDestinationVertices[vertexIndex + 0] = charSourceVertices[vertexIndex + 0] - midOffset;
            charDestinationVertices[vertexIndex + 1] = charSourceVertices[vertexIndex + 1] - midOffset;
            charDestinationVertices[vertexIndex + 2] = charSourceVertices[vertexIndex + 2] - midOffset;
            charDestinationVertices[vertexIndex + 3] = charSourceVertices[vertexIndex + 3] - midOffset;



            charDestinationVertices[vertexIndex + 0] = matrix.MultiplyPoint3x4(charDestinationVertices[vertexIndex + 0]);
            charDestinationVertices[vertexIndex + 1] = matrix.MultiplyPoint3x4(charDestinationVertices[vertexIndex + 1]);
            charDestinationVertices[vertexIndex + 2] = matrix.MultiplyPoint3x4(charDestinationVertices[vertexIndex + 2]);
            charDestinationVertices[vertexIndex + 3] = matrix.MultiplyPoint3x4(charDestinationVertices[vertexIndex + 3]);

            charDestinationVertices[vertexIndex + 0] += midOffset;
            charDestinationVertices[vertexIndex + 1] += midOffset;
            charDestinationVertices[vertexIndex + 2] += midOffset;
            charDestinationVertices[vertexIndex + 3] += midOffset;
            
        }

        // Push changes into meshes
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            textComponent.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }

    private float dist2Rad(float distance, float radius) => (distance * 2 * Mathf.PI) / (radius * 2 * Mathf.PI);

    private Vector3 localToRadialCordinates(float x, float y) 
    {
        return new Vector3(Mathf.Sin(x), Mathf.Cos(x), 0) * y;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!UnityEditor.Selection.Contains(gameObject)) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Mathf.Abs(radius));
    }
#endif
}
