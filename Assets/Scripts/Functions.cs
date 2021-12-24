using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine;

public class Functions : MonoBehaviour
{
    private const float CAMERA_TRANSITION_SPEED = 10.0f;

    // Tree data elements
    public string[] array1 = new string[1365];
    public string[] array2 = new string[1365];
    public string[] array3 = new string[1365];
    public string[] array4 = new string[1365];
    public string[] array5 = new string[1365];

    // Load, Create, and Play panels
    public Transform loadPanel;
    public Transform createPanel;
    public Transform playPanel;

    // Main Menu and Load Panel titles
    // public Text appTitle, loadTitle;

    // Parent node index, current Layer of tree, current Tree being used
    private int parent = 0;
    private int layer = 1;
    private int current = 0;

    // Load panel: tree titles
    public Text title1, title2, title3, title4, title5;
    // Create panel: tree title, current parent, and current children input fields
    public InputField create, par, c1, c2, c3, c4;
    // Keep track of current layer
    public Text layerCounter;

    // Create panel: options menu and delete yes/no menu
    private bool optionsShowing = false;
    public GameObject optionsMenu;
    private bool deleteShowing = false;
    public GameObject deleteConfirm;

    // Play panel: title, parent, children
    public Text playTitle, playParent, playC1, playC2, playC3, playC4;

    // Camera stuff
    private Transform cameraTransform;
    private Transform cameraDesiredLookAt;

    private void Start()
    {
        if (PlayerPrefs.HasKey("tree1"))
            array1 = PlayerPrefsX.GetStringArray("tree1");
        if (PlayerPrefs.HasKey("tree2"))
            array2 = PlayerPrefsX.GetStringArray("tree2");
        if (PlayerPrefs.HasKey("tree3"))
            array3 = PlayerPrefsX.GetStringArray("tree3");
        if (PlayerPrefs.HasKey("tree4"))
            array4 = PlayerPrefsX.GetStringArray("tree4");
        if (PlayerPrefs.HasKey("tree5"))
            array5 = PlayerPrefsX.GetStringArray("tree5");

        if (PlayerPrefs.HasKey("title1"))
            title1.text = PlayerPrefs.GetString("title1");
        if (PlayerPrefs.HasKey("title2"))
            title2.text = PlayerPrefs.GetString("title2");
        if (PlayerPrefs.HasKey("title3"))
            title3.text = PlayerPrefs.GetString("title3");
        if (PlayerPrefs.HasKey("title4"))
            title4.text = PlayerPrefs.GetString("title4");
        if (PlayerPrefs.HasKey("title5"))
            title5.text = PlayerPrefs.GetString("title5");

        cameraTransform = Camera.main.transform;

        optionsMenu.SetActive(optionsShowing);
        deleteConfirm.SetActive(deleteShowing);
    }

    private void Update()
    {
        if (cameraDesiredLookAt != null)
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLookAt.rotation, CAMERA_TRANSITION_SPEED * Time.deltaTime);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Save()
    {
        if (current == 1)
        {
            PlayerPrefsX.SetStringArray("tree1", array1);
            PlayerPrefs.SetString("title1", title1.text);
        }
        if (current == 2)
        {
            PlayerPrefsX.SetStringArray("tree2", array2);
            PlayerPrefs.SetString("title2", title2.text);
        }
        if (current == 3)
        {
            PlayerPrefsX.SetStringArray("tree3", array3);
            PlayerPrefs.SetString("title3", title3.text);
        }
        if (current == 4)
        {
            PlayerPrefsX.SetStringArray("tree4", array4);
            PlayerPrefs.SetString("title4", title4.text);
        }
        if (current == 5)
        {
            PlayerPrefsX.SetStringArray("tree5", array5);
            PlayerPrefs.SetString("title5", title5.text);
        }
    }

    //PATREON
    public void Patreon()
    {
        Application.OpenURL("https://www.patreon.com/thenerdherd6254");
    }
    
    //ADS
    public void PlayAd()
    {
        if (Advertisement.IsReady())
        {
            System.Random random = new System.Random();
            // play = 1, 2, 3, 4
            int play = random.Next(4);
            if (play == 0)
                Advertisement.Show();
        }
    }
    
    public void LookAtMenu(Transform menuTransform)
    {
        cameraDesiredLookAt = menuTransform;
    }

    //PLAY PANEL: Restart button, Update Screen
    public void SetParentZero()
    {
        parent = 0;
        layer = 1;
        UpdatePlay();
    }
    public void UpdatePlay()
    {
        if (current == 1)
        {
            playTitle.text = title1.text;
            playParent.text = array1[parent];
            playC1.text = array1[(parent * 4) + 1];
            playC2.text = array1[(parent * 4) + 2];
            playC3.text = array1[(parent * 4) + 3];
            playC4.text = array1[(parent * 4) + 4];
        }
        if (current == 2)
        {
            playTitle.text = title2.text;
            playParent.text = array2[parent];
            playC1.text = array2[(parent * 4) + 1];
            playC2.text = array2[(parent * 4) + 2];
            playC3.text = array2[(parent * 4) + 3];
            playC4.text = array2[(parent * 4) + 4];
        }
        if (current == 3)
        {
            playTitle.text = title3.text;
            playParent.text = array3[parent];
            playC1.text = array3[(parent * 4) + 1];
            playC2.text = array3[(parent * 4) + 2];
            playC3.text = array3[(parent * 4) + 3];
            playC4.text = array3[(parent * 4) + 4];
        }
        if (current == 4)
        {
            playTitle.text = title4.text;
            playParent.text = array4[parent];
            playC1.text = array4[(parent * 4) + 1];
            playC2.text = array4[(parent * 4) + 2];
            playC3.text = array4[(parent * 4) + 3];
            playC4.text = array4[(parent * 4) + 4];
        }
        if (current == 5)
        {
            playTitle.text = title5.text;
            playParent.text = array5[parent];
            playC1.text = array5[(parent * 4) + 1];
            playC2.text = array5[(parent * 4) + 2];
            playC3.text = array5[(parent * 4) + 3];
            playC4.text = array5[(parent * 4) + 4];
        }
    }
    public void PlayMoveDown1()
    {
        if (parent < 341)
        {
            parent = (parent * 4) + 1;
            layer++;
        }
        UpdatePlay();
    }
    public void PlayMoveDown2()
    {
        if (parent < 341)
        {
            parent = (parent * 4) + 2;
            layer++;
        }
        UpdatePlay();
    }
    public void PlayMoveDown3()
    {
        if (parent < 341)
        {
            parent = (parent * 4) + 3;
            layer++;
        }
        UpdatePlay();
    }
    public void PlayMoveDown4()
    {
        if (parent < 341)
        {
            parent = (parent * 4) + 4;
            layer++;
        }
        UpdatePlay();
    }

    // CREATE PANEL: Initialize Play panel
    public void PlayTree()
    {
        LookAtMenu(playPanel);
        if (optionsShowing)
            OptionsButtonPress();
        SetParentZero();
    }

    // MAIN MENU: New button pressed
    public void NewTree()
    {
        if (array1[0] == "")
        {
            Create1();
            LookAtMenu(createPanel);
        }
        else if (array2[0] == "")
        {
            Create2();
            LookAtMenu(createPanel);
        }
        else if (array3[0] == "")
        {
            Create3();
            LookAtMenu(createPanel);
        }
        else if (array4[0] == "")
        {
            Create4();
            LookAtMenu(createPanel);
        }
        else if (array5[0] == "")
        {
            Create5();
            LookAtMenu(createPanel);
        }
        else
            LookAtMenu(loadPanel);
    }

    // LOAD PANEL: user picks a tree
    public void Create1()
    {
        parent = 0;
        layer = 1;
        current = 1;
        if (title1.text == "New Tree" && array1[0] == "" && array1[1] == "" && array1[2] == "" && array1[3] == "" && array1[4] == "")
            create.text = "";
        else
            create.text = title1.text;
        UpdateScreen();
    }
    public void Create2()
    {
        parent = 0;
        layer = 1;
        current = 2;
        if (title2.text == "New Tree" && array2[0] == "" && array2[1] == "" && array2[2] == "" && array2[3] == "" && array2[4] == "")
            create.text = "";
        else
            create.text = title2.text;
        UpdateScreen();
    }
    public void Create3()
    {
        parent = 0;
        layer = 1;
        current = 3;
        if (title3.text == "New Tree" && array3[0] == "" && array3[1] == "" && array3[2] == "" && array3[3] == "" && array3[4] == "")
            create.text = "";
        else
            create.text = title3.text;
        UpdateScreen();
    }
    public void Create4()
    {
        parent = 0;
        layer = 1;
        current = 4;
        if (title4.text == "New Tree" && array4[0] == "" && array4[1] == "" && array4[2] == "" && array4[3] == "" && array4[4] == "")
            create.text = "";
        else
            create.text = title4.text;
        UpdateScreen();
    }
    public void Create5()
    {
        parent = 0;
        layer = 1;
        current = 5;
        if (title5.text == "New Tree" && array5[0] == "" && array5[1] == "" && array5[2] == "" && array5[3] == "" && array5[4] == "")
            create.text = "";
        else
            create.text = title5.text;
        UpdateScreen();
    }

    // CREATE PANEL: buttons for children
    public void Child1Press()
    {
        if (parent < 341)
        {
            layer++;
            parent = (parent * 4) + 1;
            UpdateScreen();
        }
    }
    public void Child2Press()
    {
        if (parent < 341)
        {
            layer++;
            parent = (parent * 4) + 2;
            UpdateScreen();
        }
    }
    public void Child3Press()
    {
        if (parent < 341)
        {
            layer++;
            parent = (parent * 4) + 3;
            UpdateScreen();
        }
    }
    public void Child4Press()
    {
        if (parent < 341)
        {
            layer++;
            parent = (parent * 4) + 4;
            UpdateScreen();
        }
    }

    // CREATE PANEL: up button is pressed
    public void UpButtonPress()
    {
        if (parent > 0)
        {
            layer--;
            parent = (parent - 1) / 4;
            UpdateScreen();
        }
    }

    // CREATE PANEL: options and delete menus
    public void OptionsButtonPress()
    {
        optionsShowing = !optionsShowing;
        optionsMenu.SetActive(optionsShowing);
    }
    public void DeleteButtonPress()
    {
        deleteShowing = !deleteShowing;
        deleteConfirm.SetActive(deleteShowing);
    }
    public void DeleteTree()
    {
        if (current == 1)
        {
            title1.text = "New Tree";
            create.text = "";
            for (int i = 0; i < 1364; i++)
                array1[i] = "";

            UpdateScreen();
        }
        if (current == 2)
        {
            title2.text = "New Tree";
            create.text = "";
            for (int i = 0; i < array2.Length; i++)
                array2[i] = "";
            UpdateScreen();
        }
        if (current == 3)
        {
            title3.text = "New Tree";
            create.text = "";
            for (int i = 0; i < array3.Length; i++)
                array3[i] = "";
            UpdateScreen();
        }
        if (current == 4)
        {
            title4.text = "New Tree";
            create.text = "";
            for (int i = 0; i < array4.Length; i++)
                array4[i] = "";
            UpdateScreen();
        }
        if (current == 5)
        {
            title5.text = "New Tree";
            create.text = "";
            for (int i = 0; i < array5.Length; i++)
                array5[i] = "";
            UpdateScreen();
        }

        parent = 0;
        layer = 1;
        layerCounter.text = layer.ToString();


        OptionsButtonPress();
        DeleteButtonPress();
    }

    // Update parent and children text boxes
    public void UpdateScreen()
    {
        layerCounter.text = layer.ToString();

        if (current == 1)
        {
            par.text = array1[parent];
            c1.text = array1[(parent * 4) + 1];
            c2.text = array1[(parent * 4) + 2];
            c3.text = array1[(parent * 4) + 3];
            c4.text = array1[(parent * 4) + 4];
        }
        if (current == 2)
        {
            par.text = array2[parent];
            c1.text = array2[(parent * 4) + 1];
            c2.text = array2[(parent * 4) + 2];
            c3.text = array2[(parent * 4) + 3];
            c4.text = array2[(parent * 4) + 4];
        }
        if (current == 3)
        {
            par.text = array3[parent];
            c1.text = array3[(parent * 4) + 1];
            c2.text = array3[(parent * 4) + 2];
            c3.text = array3[(parent * 4) + 3];
            c4.text = array3[(parent * 4) + 4];
        }
        if (current == 4)
        {
            par.text = array4[parent];
            c1.text = array4[(parent * 4) + 1];
            c2.text = array4[(parent * 4) + 2];
            c3.text = array4[(parent * 4) + 3];
            c4.text = array4[(parent * 4) + 4];
        }
        if (current == 5)
        {
            par.text = array5[parent];
            c1.text = array5[(parent * 4) + 1];
            c2.text = array5[(parent * 4) + 2];
            c3.text = array5[(parent * 4) + 3];
            c4.text = array5[(parent * 4) + 4];
        }
    }

    // CREATE PANEL: edit title/parent/children
    public void EditTitle()
    {
        if (create.text == "")
        {
            if (current == 1)
                title1.text = "New Tree";
            if (current == 2)
                title2.text = "New Tree";
            if (current == 3)
                title3.text = "New Tree";
            if (current == 4)
                title4.text = "New Tree";
            if (current == 5)
                title5.text = "New Tree";
        }
        else
        {
            if (current == 1)
                title1.text = create.text;
            if (current == 2)
                title2.text = create.text;
            if (current == 3)
                title3.text = create.text;
            if (current == 4)
                title4.text = create.text;
            if (current == 5)
                title5.text = create.text;
        }
    }
    public void EditParent()
    {
        if (current == 1)
            array1[parent] = par.text;
        if (current == 2)
            array2[parent] = par.text;
        if (current == 3)
            array3[parent] = par.text;
        if (current == 4)
            array4[parent] = par.text;
        if (current == 5)
            array5[parent] = par.text;
    }
    public void EditChild1()
    {
        if (current == 1)
            array1[(parent * 4) + 1] = c1.text;
        if (current == 2)
            array2[(parent * 4) + 1] = c1.text;
        if (current == 3)
            array3[(parent * 4) + 1] = c1.text;
        if (current == 4)
            array4[(parent * 4) + 1] = c1.text;
        if (current == 5)
            array5[(parent * 4) + 1] = c1.text;
    }
    public void EditChild2()
    {
        if (current == 1)
            array1[(parent * 4) + 2] = c2.text;
        if (current == 2)
            array2[(parent * 4) + 2] = c2.text;
        if (current == 3)
            array3[(parent * 4) + 2] = c2.text;
        if (current == 4)
            array4[(parent * 4) + 2] = c2.text;
        if (current == 5)
            array5[(parent * 4) + 2] = c2.text;
    }
    public void EditChild3()
    {
        if (current == 1)
            array1[(parent * 4) + 3] = c3.text;
        if (current == 2)
            array2[(parent * 4) + 3] = c3.text;
        if (current == 3)
            array3[(parent * 4) + 3] = c3.text;
        if (current == 4)
            array4[(parent * 4) + 3] = c3.text;
        if (current == 5)
            array5[(parent * 4) + 3] = c3.text;
    }
    public void EditChild4()
    {
        if (current == 1)
            array1[(parent * 4) + 4] = c4.text;
        if (current == 2)
            array2[(parent * 4) + 4] = c4.text;
        if (current == 3)
            array3[(parent * 4) + 4] = c4.text;
        if (current == 4)
            array4[(parent * 4) + 4] = c4.text;
        if (current == 5)
            array5[(parent * 4) + 4] = c4.text;
    }
}