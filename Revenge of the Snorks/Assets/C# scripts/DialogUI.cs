using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUI.Dialogs
{

    public class Dialog
    {
        public string Title = "Ohno! This level is filled with mobs, you have to kill them to continue! ";
        public string Message;

    }
    public class DialogUI : MonoBehaviour
    {
        [SerializeField] GameObject canvas;
        [SerializeField] Text titleUIText;
        //[SerializeField] Text messageUIText;
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


       /* public DialogUI SetMessage(string message)
        {
            dialog.Message = message;
            return Instance;
        }
       */

        public void Show()
        {

            titleUIText.text = dialog.Title;
           // messageUIText.text = dialog.Message;
            canvas.SetActive(true);

            //Reset dialog

            dialog = new Dialog();

            canvas.SetActive(true);

        }

        public void Hide() {
            canvas.SetActive(false);
         }

    }
}
