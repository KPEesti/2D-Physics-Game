using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public static bool BookIsOpen;
    public List<GameObject> BooksMenu;
    private int index;

    public void OpenBook() => ChangeBookState(true, 0f);

    public void CloseBook() => ChangeBookState(false, 1f);

    public void NextBook() => ChangeBookPage(index + 1 > BooksMenu.Count - 1 ? 0 : index + 1);

    public void PreviousBook() => ChangeBookPage(index - 1 < 0 ? BooksMenu.Count - 1 : index - 1);

    private void ChangeBookState(bool isActive, float timeScale)
    {
        BooksMenu[index].SetActive(isActive);
        Time.timeScale = timeScale;
        BookIsOpen = isActive;
    }

    private void ChangeBookPage(int index)
    {
        CloseBook();

        this.index = index;

        OpenBook();
    }
}