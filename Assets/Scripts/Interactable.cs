
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact ()
    {
        // This method is for overwritting for different interactables
    }
    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    public void OnFocused (Transform playerTranform)
    {
        isFocus = true;
        player = playerTranform;
        hasInteracted = false;
    }

    public void OnDefocused ()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);

    }
}
