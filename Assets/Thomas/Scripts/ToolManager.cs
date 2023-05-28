// ToolManager.cs
using UnityEngine;
using DG.Tweening;


public enum ToolType
{
    Shovel,
    Pickaxe,
    ElectricDrill,
    Axe,
    Hammer,
    Dinamite
}

/*    public class ToolManager : MonoBehaviour
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
    }*/

public class ToolManager : MonoBehaviour
{

    public ToolType selectedTool = ToolType.Shovel;

    public Transform[] toolPositions; // Posiciones de las herramientas
    public Transform selectionIndicator; // Indicador de selección

    //public Transform toolHolder; // Transformación para colocar los sprites seleccionados
    public GameObject shovelSprite;
    public GameObject pickaxeSprite;
    public GameObject electricDrillSprite;
    //public GameObject axeSprite;
    //public GameObject hammerSprite;
    //public GameObject dinamiteSprite;

    private void Start()
    {
        // Desactivar todos los sprites al inicio
        //DeactivateAllSprites();
    }

    public void SelectTool(KeyCode key)
    {
        // Desactivar todos los sprites
        //DeactivateAllSprites();

        switch (key)
        {
            case KeyCode.A:
                selectedTool = ToolType.Shovel;
                //shovelSprite.SetActive(true);
                PlaceSprite(shovelSprite);
                break;
            case KeyCode.S:
                selectedTool = ToolType.Pickaxe;
                //pickaxeSprite.SetActive(true);
                PlaceSprite(pickaxeSprite);
                break;
            case KeyCode.D:
                selectedTool = ToolType.ElectricDrill;
                //electricDrillSprite.SetActive(true);
                PlaceSprite(electricDrillSprite);
                break;
            /*case KeyCode.Q:
                selectedTool = ToolType.Axe;
                axeSprite.SetActive(true);
                PlaceSprite(axeSprite);
                break;
            case KeyCode.W:
                selectedTool = ToolType.Hammer;
                hammerSprite.SetActive(true);
                PlaceSprite(hammerSprite);
                break;
            case KeyCode.E:
                selectedTool = ToolType.Dinamite;
                dinamiteSprite.SetActive(true);
                PlaceSprite(dinamiteSprite);
                break;*/
        }

        selectionIndicator.position = toolPositions[(int)selectedTool].position;

    }

    private void Update()
    {
        // Interpolar la posición del marco de selección hacia la posición del objeto vacío seleccionado con DOTween
        Vector3 targetPosition = toolPositions[(int)selectedTool].position;
        selectionIndicator.DOMove(targetPosition, 0.3f);
    }


    private void PlaceSprite(GameObject spriteObject)
    {
        // Establecer la posición y escala del sprite seleccionado según la transformación toolHolder
        spriteObject.transform.position = toolPositions[(int)selectedTool].position;
        spriteObject.transform.localScale = toolPositions[(int)selectedTool].localScale;
    }

    private void DeactivateAllSprites()
    {
        shovelSprite.SetActive(false);
        pickaxeSprite.SetActive(false);
        electricDrillSprite.SetActive(false);
        /*axeSprite.SetActive(false);
        hammerSprite.SetActive(false);
        dinamiteSprite.SetActive(false);*/
    }
}
