using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class TextScroll : BaseMeshEffect
{
    [SerializeField]
    private float _offsetX;

    private List<UIVertex> uiVertexList = new List<UIVertex>();

#if UNITY_EDITOR
    public new void OnValidate()
    {
        gameObject.GetComponent<Graphic>().SetVerticesDirty();
    }
#endif
    public override void ModifyMesh(VertexHelper vertex)
    {
        uiVertexList.Clear();
        vertex.GetUIVertexStream(uiVertexList);
        var count = uiVertexList.Count;
        for (var i = 0; i < count; ++i)
        {
            var vert = uiVertexList[i];
            vert.position.x -= _offsetX;
            uiVertexList[i] = vert;
        }
        vertex.Clear();
        vertex.AddUIVertexTriangleStream(uiVertexList);
    }
}
