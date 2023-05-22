using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ImageScrollScript : MonoBehaviour
{
    [SerializeField] public PuzzleElement[] pictures;
    [SerializeField] int myId;
    [SerializeField] GameObject selection;
    private int counter = 0;
    private PuzzleManager puzzleManager;

    private void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
        foreach (PuzzleElement picture in pictures)
        {
            picture.gameObject.SetActive(false);
        }

        pictures[counter].gameObject.SetActive(true);
    }

    public void MakeSelectionActive(bool val)
    {
        selection.SetActive(val);
    }

    public void ActivateNextImage(bool up)
    {
        Debug.Log("counter: " + counter + " pictures.Length: " + pictures.Length);
        if (up)
        {
            if (counter < (pictures.Length - 1))
            {
                counter++;
                foreach (PuzzleElement picture in pictures)
                {
                    picture.gameObject.SetActive(false);
                }
            }
            else
            {
                foreach (PuzzleElement picture in pictures)
                {
                    picture.gameObject.SetActive(false);
                }
                counter = 0;
            }
            pictures[counter].gameObject.SetActive(true);
            Debug.Log("counter: " + counter + " pictures.Length: " + pictures.Length);
        }
        else
        {
            if (counter > 0)
            {
                counter--;
                foreach (PuzzleElement picture in pictures)
                {
                    picture.gameObject.SetActive(false);
                }
            }
            else
            {
                foreach (PuzzleElement picture in pictures)
                {
                    picture.gameObject.SetActive(false);
                }
                counter = pictures.Length - 1;
            }
            pictures[counter].gameObject.SetActive(true);
            Debug.Log("counter: " + counter + " pictures.Length: " + pictures.Length);
        }
        

        puzzleManager.PuzzleInteracted(myId, counter, pictures[counter].storyText);
    }
}
