using UnityEngine;

public class ToolClick : MonoBehaviour
{
    public int toolIndex;
    public Material usedMaterial; // Material to swap when used
    private bool isUsed = false;

    private void OnMouseDown()
    {
        if (isUsed) return;

        // Tell the manager to progress
        FindObjectOfType<PumpkinManager>().UseTool(toolIndex);

        // Change the tool's appearance (mark as used)
        GetComponent<Renderer>().material = usedMaterial;
        isUsed = true;
    }
}
