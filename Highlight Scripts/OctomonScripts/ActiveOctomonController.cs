using UnityEngine;

public class ActiveOctomonController : MonoBehaviour
{
    [Header("Slots")]
    public GameObject octomonSlot;

    [Header("Info")]
    public RuntimeAnimatorController activeOctomonAnimatorCTRL;
    
    private void Start()
    {
        octomonSlot.GetComponent<Animator>().runtimeAnimatorController = activeOctomonAnimatorCTRL;
    }
}