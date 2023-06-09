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
    public Transform selectionIndicator; // Indicador de selecci�n

    //public Transform toolHolder; // Transformaci�n para colocar los sprites seleccionados
    public GameObject A;
    public GameObject S;
    public GameObject D;
    public GameObject Q;
    public GameObject W;
    public GameObject E;

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
                PlaceSprite(A);
                break;
            case KeyCode.S:
                selectedTool = ToolType.Pickaxe;
                //pickaxeSprite.SetActive(true);
                PlaceSprite(S);
                break;
            case KeyCode.D:
                selectedTool = ToolType.ElectricDrill;
                //electricDrillSprite.SetActive(true);
                PlaceSprite(D);
                break;
            case KeyCode.Q:
                selectedTool = ToolType.Axe;
                Q.SetActive(true);
                PlaceSprite(Q);
                break;
            case KeyCode.W:
                selectedTool = ToolType.Hammer;
                W.SetActive(true);
                PlaceSprite(W);
                break;
            case KeyCode.E:
                selectedTool = ToolType.Dinamite;
                E.SetActive(true);
                PlaceSprite(E);
                break;
        }

        selectionIndicator.position = toolPositions[(int)selectedTool].position;

    }

    private void Update()
    {
        // Interpolar la posici�n del marco de selecci�n hacia la posici�n del objeto vac�o seleccionado con DOTween
        Vector3 targetPosition = toolPositions[(int)selectedTool].position;
        selectionIndicator.DOMove(targetPosition, 0.3f);
    }


    private void PlaceSprite(GameObject spriteObject)
    {
        // Establecer la posici�n y escala del sprite seleccionado seg�n la transformaci�n toolHolder
        spriteObject.transform.position = toolPositions[(int)selectedTool].position;
        spriteObject.transform.localScale = toolPositions[(int)selectedTool].localScale;
    }

    /*private void DeactivateAllSprites()
    {
        shovelSprite.SetActive(false);
        pickaxeSprite.SetActive(false);
        electricDrillSprite.SetActive(false);
        /*axeSprite.SetActive(false);
        hammerSprite.SetActive(false);
        dinamiteSprite.SetActive(false);
    }*/
}
