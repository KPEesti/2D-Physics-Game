using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public static bool BookIsOpen = false;
    public List<GameObject> BooksMenu;
    private int Index = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBook()
    {
        BooksMenu[Index].SetActive(true);
        Time.timeScale = 0f;
        BookIsOpen = true;
    }

    public void CloseBook()
    {
        BooksMenu[Index].SetActive(false);
        Time.timeScale = 1f;
        BookIsOpen = false;
    }

    public void NextBook()
    {
        CloseBook();
        Index++;
        if (Index > BooksMenu.Count - 1) Index = 0;
        OpenBook();
    }

    public void PreviousBook()
    {
        CloseBook();
        Index--;
        if (Index < 0) Index = BooksMenu.Count - 1;
        OpenBook();
    }
}
