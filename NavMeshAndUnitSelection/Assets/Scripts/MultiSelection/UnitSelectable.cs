using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSelectable : MonoBehaviour, ISelectHandler, IPointerClickHandler, IDeselectHandler
{

    public static HashSet<UnitSelectable> allSelectables = new HashSet<UnitSelectable>();
    public static HashSet<UnitSelectable> currentlySelected = new HashSet<UnitSelectable>();

    public bool IsSelected = false;

    Renderer myRenderer;

    [SerializeField]
    Material unselectedMaterial;
    [SerializeField]
    Material selectedMaterial;

    void Awake()
    {
        allSelectables.Add(this);
        myRenderer = GetComponent<Renderer>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            DeselectAll(eventData);
        }
        OnSelect(eventData);
    }

    private void Selected()
    {
        myRenderer.material = selectedMaterial;
        IsSelected = true;
    }
    private void DeSelected()
    {
        myRenderer.material = unselectedMaterial;
        IsSelected = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (currentlySelected.Contains(this) && Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentlySelected.Remove(this);
            myRenderer.material = unselectedMaterial;
            return;
        }
        currentlySelected.Add(this);
        Selected();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        DeSelected();
    }

    public static void DeselectAll(BaseEventData eventData)
    {
        foreach (UnitSelectable selectable in currentlySelected)
        {
            selectable.OnDeselect(eventData);
        }
        currentlySelected.Clear();
    }
}
