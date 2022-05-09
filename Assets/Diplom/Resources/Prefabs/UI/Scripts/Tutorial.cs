using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public List<Text> _textList = new List<Text>();
    int _currentPage = 0;

    public void SetCurrentPage(bool value) {

        if(value)
        {

            if(_currentPage < _textList.Count - 1) 
            {
                _textList[_currentPage].gameObject.SetActive(false);
                _currentPage += 1;
                _textList[_currentPage].gameObject.SetActive(true);
            }
        }
        else 
        {

            if(_currentPage > 0) 
            {
                _textList[_currentPage].gameObject.SetActive(false);
                _currentPage -= 1;
                _textList[_currentPage].gameObject.SetActive(true);
            }
        }
    }

    public void SetFirstPage() => _currentPage = 0;
}
