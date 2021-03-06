using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchCharacter : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera knightFollow;
    [SerializeField] GameObject knight;
    [SerializeField] CinemachineVirtualCamera archerFollow;
    [SerializeField] GameObject archer;
    [SerializeField] CinemachineVirtualCamera wizardFollow;
    [SerializeField] GameObject wizard;
    [SerializeField] Animator knightavatar;
    [SerializeField] Animator archeravatar;
    [SerializeField] Animator wizardavatar;
    [SerializeField] CharacterController knightcontroller;
    [SerializeField] CharacterController archercontroller;
    [SerializeField] CharacterController wizardcontroller;
    [SerializeField] ThirdPersonController knight3p;
    [SerializeField] ThirdPersonController archer3p;
    [SerializeField] ThirdPersonController wizard3p;  
    [SerializeField] JoystickThirdPersonController knightjs3p;
    [SerializeField] JoystickThirdPersonController archerjs3p;
    [SerializeField] JoystickThirdPersonController wizardjs3p;
    [SerializeField] BoolSO knightdeath;
    [SerializeField] BoolSO archerdeath;
    [SerializeField] BoolSO wizarddeath;
    [SerializeField] Attacker knightattacker;
    [SerializeField] Attacker archerattacker;
    [SerializeField] Attacker wizardattacker;
    [SerializeField] Transform knightTransform;
    [SerializeField] Transform archerTransform;
    [SerializeField] Transform wizardTransform;
    [SerializeField] Button Action;
    [SerializeField] Sprite sword;
    [SerializeField] Sprite arrow;
    [SerializeField] Sprite magic;
    [SerializeField] Jump jumper;

    private void Update()
    {
        AutoSwitch();
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                // Quit the application
                SceneManager.LoadScene($"LevelSelection");
            }
        }
    }
    public void Switch()
    {
        FindObjectOfType<AudioManager>().playAudio("Switch");
        if (!knightdeath.state && !archerdeath.state && !wizarddeath.state)
        {
            if (knight.activeInHierarchy)
            {
                knightFollow.m_Priority = 10;
                archerFollow.m_Priority = 0;
                wizardFollow.m_Priority = 0;
                knight.SetActive(false);
                archer.SetActive(true);
                Action.image.sprite = sword;
                jumper.controller = knightcontroller;
                knight3p.isActive = true;
                archer3p.isActive = false;
                wizard3p.isActive = false;
                knightjs3p.isActive = true;
                archerjs3p.isActive = false;
                wizardjs3p.isActive = false;
                knightattacker.isActiveController = true;
                archerattacker.isActiveController = false;
                wizardattacker.isActiveController = false;
                wizardavatar.SetBool("isRunning", false);
                archeravatar.SetBool("isRunning", false);
                return;
            }
            else if (archer.activeInHierarchy)
            {
                knightFollow.m_Priority = 0;
                archerFollow.m_Priority = 10;
                wizardFollow.m_Priority = 0;
                archer.SetActive(false);
                wizard.SetActive(true);
                Action.image.sprite = arrow;
                jumper.controller = archercontroller;
                knight3p.isActive = false;
                archer3p.isActive = true;
                wizard3p.isActive = false;
                knightjs3p.isActive = false;
                archerjs3p.isActive = true;
                wizardjs3p.isActive = false;
                knightattacker.isActiveController = false;
                archerattacker.isActiveController = true;
                wizardattacker.isActiveController = false;
                wizardavatar.SetBool("isRunning", false);
                knightavatar.SetBool("isRunning", false);
                return;
            }
            else if (wizard.activeInHierarchy)
            {
                knightFollow.m_Priority = 0;
                archerFollow.m_Priority = 0;
                wizardFollow.m_Priority = 10;
                knight.SetActive(true);
                wizard.SetActive(false);
                Action.image.sprite = magic;
                jumper.controller = wizardcontroller;
                knight3p.isActive = false;
                archer3p.isActive = false;
                wizard3p.isActive = true;
                knightjs3p.isActive = false;
                archerjs3p.isActive = false;
                wizardjs3p.isActive = true;
                knightattacker.isActiveController = false;
                archerattacker.isActiveController = false;
                wizardattacker.isActiveController = true;
                archeravatar.SetBool("isRunning", false);
                knightavatar.SetBool("isRunning", false);
                return;
            }
        }
        else if ((!knightdeath.state && !archerdeath.state && wizarddeath.state))
        {
            if (knight.activeInHierarchy)
            {
                knightFollow.m_Priority = 10;
                archerFollow.m_Priority = 0;
                knight.SetActive(false);
                archer.SetActive(true);
                Action.image.sprite = sword;
                jumper.controller = knightcontroller;
                knight3p.isActive = true;
                archer3p.isActive = false; 
                knightjs3p.isActive = true;
                archerjs3p.isActive = false;
                knightattacker.isActiveController = true;
                archerattacker.isActiveController = false;
                archeravatar.SetBool("isRunning", false);
                return;
            }
            else if (archer.activeInHierarchy)
            {
                knightFollow.m_Priority = 0;
                archerFollow.m_Priority = 10;
                archer.SetActive(false);
                knight.SetActive(true);
                Action.image.sprite = arrow;
                jumper.controller = archercontroller;
                knight3p.isActive = false;
                archer3p.isActive = true;
                knightjs3p.isActive = false;
                archerjs3p.isActive = true;
                knightattacker.isActiveController = false;
                archerattacker.isActiveController = true;
                knightavatar.SetBool("isRunning", false);
                return;
            }
        }
        else if ((!knightdeath.state && archerdeath.state && !wizarddeath.state))
        {
            if (knight.activeInHierarchy)
            {
                knightFollow.m_Priority = 10;
                wizardFollow.m_Priority = 0;
                knight.SetActive(false);
                wizard.SetActive(true);
                Action.image.sprite = sword;
                jumper.controller = knightcontroller;
                knight3p.isActive = true;
                wizard3p.isActive = false;
                knightjs3p.isActive = true;
                wizardjs3p.isActive = false;
                knightattacker.isActiveController = true;
                wizardattacker.isActiveController = false;
                wizardavatar.SetBool("isRunning", false);
                return;
            }
            else if (wizard.activeInHierarchy)
            {
                knightFollow.m_Priority = 0;
                wizardFollow.m_Priority = 10;
                knight.SetActive(true);
                wizard.SetActive(false);
                Action.image.sprite = magic;
                jumper.controller = wizardcontroller;
                knight3p.isActive = false;
                wizard3p.isActive = true;
                knightjs3p.isActive = false;
                wizardjs3p.isActive = true;
                knightattacker.isActiveController = false;
                wizardattacker.isActiveController = true;
                knightavatar.SetBool("isRunning", false);
                return;
            }
        }
        else if (knightdeath.state && !archerdeath.state && !wizarddeath.state)
        {
            if (archer.activeInHierarchy)
            {
                archerFollow.m_Priority = 10;
                wizardFollow.m_Priority = 0;
                archer.SetActive(false);
                wizard.SetActive(true);
                Action.image.sprite = arrow;
                jumper.controller = archercontroller;
                archer3p.isActive = true;
                wizard3p.isActive = false;
                archerjs3p.isActive = true;
                wizardjs3p.isActive = false;
                archerattacker.isActiveController = true;
                wizardattacker.isActiveController = false;
                wizardavatar.SetBool("isRunning", false);
                return;
            }
            else if (wizard.activeInHierarchy)
            {
                archerFollow.m_Priority = 0;
                wizardFollow.m_Priority = 10;
                archer.SetActive(true);
                wizard.SetActive(false);
                Action.image.sprite = magic;
                jumper.controller = wizardcontroller;
                archer3p.isActive = false;
                wizard3p.isActive = true;
                archerjs3p.isActive = false;
                wizardjs3p.isActive = true;
                archerattacker.isActiveController = false;
                wizardattacker.isActiveController = true;
                archeravatar.SetBool("isRunning", false);
                return;
            }
        }
        else if ((!knightdeath.state && archerdeath.state && wizarddeath.state))
        {
            if (knight.activeInHierarchy)
            {
                knightFollow.m_Priority = 10;
                knight.SetActive(false);
                Action.image.sprite = sword;
                jumper.controller = knightcontroller;
                knight3p.isActive = true;
                knightjs3p.isActive = true;
                knightattacker.isActiveController = true;
                return;
            }
        }
        else if ((knightdeath.state && archerdeath.state && !wizarddeath.state))
        {
            if (wizard.activeInHierarchy)
            {
                wizardFollow.m_Priority = 10;
                wizard.SetActive(false);
                Action.image.sprite = magic;
                jumper.controller = wizardcontroller;
                wizard3p.isActive = true;
                wizardjs3p.isActive = true;
                wizardattacker.isActiveController = true;
                return;
            }
        }
        else if (knightdeath.state && !archerdeath.state && wizarddeath.state)
        {
            if (archer.activeInHierarchy)
            {
                archerFollow.m_Priority = 10;
                archer.SetActive(false);
                Action.image.sprite = arrow;
                jumper.controller = archercontroller;
                archer3p.isActive = true;
                archerjs3p.isActive = true;
                archerattacker.isActiveController = true;
                return;
            }
        }
    }

    public void AutoSwitch()
    {
        FindObjectOfType<AudioManager>().playAudio("Switch");
        if ((!knightdeath.state && knight.activeInHierarchy) || (archerdeath.state && !archer.activeInHierarchy && wizarddeath.state && !wizard.activeInHierarchy))
        {
            knightFollow.m_Priority = 10;
            archerFollow.m_Priority = 0;
            wizardFollow.m_Priority = 0;
            knight.SetActive(true);
            archer.SetActive(false);
            wizard.SetActive(false);
            Action.image.sprite = sword;
            jumper.controller = knightcontroller;
            knight3p.isActive = true;
            archer3p.isActive = false;
            wizard3p.isActive = false;
            knightjs3p.isActive = true;
            archerjs3p.isActive = false;
            wizardjs3p.isActive = false;
            knightattacker.isActiveController = true;
            archerattacker.isActiveController = false;
            wizardattacker.isActiveController = false;
            wizardavatar.SetBool("isRunning", false);
            archeravatar.SetBool("isRunning", false);
        }
        if ((!archerdeath.state && archer.activeInHierarchy) || (knightdeath.state && !knight.activeInHierarchy && wizarddeath.state && !wizard.activeInHierarchy))
        {
            knightFollow.m_Priority = 0;
            archerFollow.m_Priority = 10;
            wizardFollow.m_Priority = 0;
            knight.SetActive(false);
            archer.SetActive(true);
            wizard.SetActive(false);
            Action.image.sprite = arrow;
            jumper.controller = archercontroller;
            knight3p.isActive = false;
            archer3p.isActive = true;
            wizard3p.isActive = false;
            knightjs3p.isActive = false;
            archerjs3p.isActive = true;
            wizardjs3p.isActive = false;
            knightattacker.isActiveController = false;
            archerattacker.isActiveController = true;
            wizardattacker.isActiveController = false;
            wizardavatar.SetBool("isRunning", false);
            knightavatar.SetBool("isRunning", false);
        }
        if ((!wizarddeath.state && wizard.activeInHierarchy) || (archerdeath.state && !archer.activeInHierarchy && knightdeath.state && !knight.activeInHierarchy))
        {
            knightFollow.m_Priority = 0;
            archerFollow.m_Priority = 0;
            wizardFollow.m_Priority = 10;
            knight.SetActive(false);
            archer.SetActive(false);
            wizard.SetActive(true);
            Action.image.sprite = magic;
            jumper.controller = wizardcontroller;
            knight3p.isActive = false;
            archer3p.isActive = false;
            wizard3p.isActive = true;
            knightjs3p.isActive = false;
            archerjs3p.isActive = false;
            wizardjs3p.isActive = true;
            knightattacker.isActiveController = false;
            archerattacker.isActiveController = false;
            wizardattacker.isActiveController = true;
            archeravatar.SetBool("isRunning", false);
            knightavatar.SetBool("isRunning", false);
        }
    }
}