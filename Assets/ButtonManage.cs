using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManage : MonoBehaviour
{
    [SerializeField] private BasicMech movementState;
    [SerializeField] private weaponScript throwState;
    private bool isButtonPressed = false;
    [SerializeField] private GameObject[] buttons;
    public bool isPc;

    private void Awake()
    {
        if (Application.platform != RuntimePlatform.Android||Application.platform!=RuntimePlatform.IPhonePlayer)
        {
            foreach (var butandStick  in buttons)
            {
                butandStick.SetActive(false);
            }

            isPc = true;
        }
        else
        {
            isPc = false;
        }
    }



    public void UpdateDashButtonState()
  {
      movementState.isPressedDashB = true;
  }
  public void UpdateAttackButtonState()
  {
      movementState.isPressedAttackButton = true;
  }
  public void UpdateThrowButtonState()
  {
      throwState.isPressedThrowButton = true;
      

  }

  public void ResetThrowButtonState()
  {
      throwState.isPressedThrowButton = false;
      throwState.canShoot = true;
  }








  
}
