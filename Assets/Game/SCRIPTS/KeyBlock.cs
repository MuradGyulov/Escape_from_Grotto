using UnityEngine;

public class KeyBlock : MonoBehaviour
{
    public void Unlock()
    {
         this.gameObject.SetActive(false);
    }
}
