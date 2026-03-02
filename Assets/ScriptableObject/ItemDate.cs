using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/ItemDate")]
public class ItemDate : ScriptableObject
{
    public string itemName;
    public int scoreValue;
    public Color itemcolor;
}
