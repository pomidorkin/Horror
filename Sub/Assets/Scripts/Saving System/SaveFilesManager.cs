using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SaveFilesManager : MonoBehaviour
{
    [SerializeField] SaveManager saveManager;
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] Button loadButton;
    [SerializeField] Button deleteButton;
    [SerializeField] ConfirmationWindow confirmationWindow;
    private string path;
    private DirectoryInfo info;
    private FileInfo[] fileInfos;
    private List<string> saveFileNames;
    private Dictionary<string, string> filenameDictionary;
    // Start is called before the first frame update
    void Start()
    {
        confirmationWindow.yesButton.onClick.AddListener(ConfirmatinYesClicked);
        confirmationWindow.noButton.onClick.AddListener(ConfirmatinNoClicked);

        saveFileNames = new List<string>();
        filenameDictionary = new Dictionary<string, string>();

        if (!Directory.Exists(Application.persistentDataPath + "/savings/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/savings/");
        }

        path = Application.persistentDataPath + "/savings/";
        ResetDropdown();

    }

    private void ResetDropdown()
    {
        //dropdown.ClearOptions();
        info = new DirectoryInfo(path);
        fileInfos = null;
        saveFileNames.Clear();
        filenameDictionary.Clear();
        dropdown.ClearOptions();
        fileInfos = info.GetFiles();
        if (fileInfos.Length > 0)
        {
            foreach (FileInfo item in fileInfos)
            {
                saveFileNames.Add(FilenameToStringConverter(item.Name));
                filenameDictionary.Add(FilenameToStringConverter(item.Name), item.Name);
            }
        }
        else
        {
            saveFileNames.Add("Empty");
            dropdown.interactable = false;
            loadButton.interactable = false;
            deleteButton.interactable = false;
        }

        dropdown.AddOptions(saveFileNames);
    }

    private string FilenameToStringConverter(string filename)
    {
        return DateTime.FromFileTimeUtc(Convert.ToInt64(filename.Remove(filename.Length - 3))).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        saveManager.SetSaveFileName(Application.persistentDataPath + "/savings/" + filenameDictionary[dropdown.captionText.text]);
        SceneManager.LoadScene(0);
        
    }

    public void NewGame()
    {
        saveManager.SetSaveFileName(Application.persistentDataPath + "/savings/" + DateTime.Now.ToFileTime() + ".ss");
        
        //saveManager.Load(dropdown.captionText.text);

        SceneManager.LoadScene(0);
    }

    public void DeleteSavingFile()
    {
        OpenConfirmationWindow("Are you sure you want to delete saving \"" + dropdown.captionText.text + "\"?");
        // ...
        /*File.Delete(Application.persistentDataPath + "/savings/" + filenameDictionary[dropdown.captionText.text]);
        dropdown.ClearOptions();
        ResetDropdown();*/
    }

    private void OpenConfirmationWindow(string message)
    {
        confirmationWindow.gameObject.SetActive(true);
        confirmationWindow.messageText.text = message;
        
    }

    private void ConfirmatinYesClicked()
    {
        confirmationWindow.gameObject.SetActive(false);
        File.Delete(Application.persistentDataPath + "/savings/" + filenameDictionary[dropdown.captionText.text]);
        Debug.Log("Deletenig file: " + filenameDictionary[dropdown.captionText.text]);
        //dropdown.ClearOptions();
        ResetDropdown();
    }

    private void ConfirmatinNoClicked()
    {
        confirmationWindow.gameObject.SetActive(false);
    }
}
