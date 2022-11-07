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
    private string path;
    private DirectoryInfo info;
    private FileInfo[] fileInfos;
    private List<string> saveFileNames;
    private Dictionary<string, string> filenameDictionary;
    // Start is called before the first frame update
    void Start()
    {
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
        File.Delete(Application.persistentDataPath + "/savings/" + filenameDictionary[dropdown.captionText.text]);
        dropdown.ClearOptions();
        ResetDropdown();
    }
}
