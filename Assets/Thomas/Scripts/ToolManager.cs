// ToolManager.cs
using UnityEngine;

public enum ToolType
{
    Shovel,
    Pickaxe,
    ElectricDrill,
    Axe,
    Hammer,
    Dinamite
}

public class ToolManager : MonoBehaviour
{
    public ToolType selectedTool = ToolType.Shovel;

    public void SelectTool(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.A:
                selectedTool = ToolType.Shovel;
                Debug.Log("Pala");
                break;
            case KeyCode.S:
                selectedTool = ToolType.Pickaxe;
                Debug.Log("Pickaxe");
                break;
            case KeyCode.D:
                selectedTool = ToolType.ElectricDrill;
                Debug.Log("Electric Drill");
                break;
            case KeyCode.Q:
                selectedTool = ToolType.Axe;
                Debug.Log("Axe");
                break;
            case KeyCode.W:
                selectedTool = ToolType.Hammer;
                Debug.Log("Hammer");
                break;
            case KeyCode.E:
                selectedTool = ToolType.Dinamite;
                Debug.Log("Dinamite");
                break;
        }
    }
}