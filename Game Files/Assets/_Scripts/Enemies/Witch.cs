using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         GameUICanvas.Instance.creditPanel.SetActive(true);
         GameUICanvas.Instance.dialoguePanel.SetActive(false);
         GameUICanvas.Instance.gameUIPanel.SetActive(false);
         GameUICanvas.Instance.mainMenuPanel.SetActive(false);
         GameUICanvas.Instance.optionsPanel.SetActive(false);
         GameUICanvas.Instance.pausePanel.SetActive(false);
         BackgroundMusicManager.Instance.PauseMusic();
      }
   }
}
