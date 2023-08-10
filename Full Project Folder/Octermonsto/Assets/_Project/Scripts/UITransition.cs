using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransition : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    
    public void OpenProfile()
    {
        _canvas.transform.LeanScale(new Vector2(9.5f,9.5f) , 1f).setEaseOutExpo();
    }

    public void OpenSetting()
    {
        _canvas.transform.LeanScale(Vector2.one , 1f).setEaseOutExpo();
    }
    
    public void OpenOctomonInfo()
    {
        _canvas.transform.LeanScale(new Vector2(1.415f,1.415f) , 1f).setEaseOutExpo();
    }
    public void OpenOctomonInfoClose()
    {
        _canvas.transform.LeanScale(Vector2.zero , 1f).setEaseOutExpo();
    }

    public void OpenOctomonInventory()
    {
        _canvas.transform.LeanScale(new Vector2(0.87f,0.99f) , 1f).setEaseOutExpo();
    }
    
    public void OpenInventory()
    {
        _canvas.transform.LeanScale(new Vector2(0.87f,0.99f) , 1f).setEaseOutExpo();
    }
    
    public void OpenShop()
    {
        _canvas.transform.LeanScale(new Vector2(0.87f,0.99f) , 1f).setEaseOutExpo();
    }
    

}

