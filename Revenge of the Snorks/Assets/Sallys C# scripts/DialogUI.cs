using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace EasyUI.Dialogs
{

    public class Dialog
    {
        public string Title = "Ohno! This level is filled with mobs, you have to kill them to continue! ";
        

    }
    public class DialogUI : MonoBehaviour
    {
        [SerializeField] GameObject canvas;
        [SerializeField] Text titleUIText;
        [SerializeField] Button closeUIButton;
     


        public static DialogUI Instance;
        Dialog dialog = new Dialog();



        private void Awake()
        {
            Instance = this;
            closeUIButton.onClick.RemoveAllListeners();
            closeUIButton.onClick.AddListener(Hide);

        }

        public DialogUI SetTitle(string title)
        {
            dialog.Title = title;
            return Instance;
        }


        public void Show()
        {

            titleUIText.text = dialog.Title;
       
            
            dialog = new Dialog();
            canvas.SetActive(true);
   

        }

        public void Hide()
        {
            canvas.SetActive(false);
        }
    }


    }   
