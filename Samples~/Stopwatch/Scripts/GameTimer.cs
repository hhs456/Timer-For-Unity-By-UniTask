using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ToolKid {
    public class GameTimer : MonoBehaviour {
        // �Ω���ܭp�ɾ�����r
        public Text timerText;

        // �Ω�p�ɪ��p�ɾ�
        private Timer timer;

        // �O���p�ɾ��}�l�B�檺�ɶ�
        private DateTime startTime;

        // �O���p�ɾ��ثe���B��ɶ�
        private TimeSpan elapsedTime;

        private void Start() {
            // ��l�ƭp�ɾ�
            timer = new Timer(float.PositiveInfinity);
            timer.OnTimerTick += UpdateTimerText;

            // �}�l�p�ɾ�
            timer.Start();

            // �O���p�ɾ��}�l�B�檺�ɶ�
            startTime = DateTime.Now;
        }

        // ��s�p�ɾ�����r
        private async UniTask UpdateTimerText() {
            // �p��ثe���B��ɶ�
            elapsedTime = DateTime.Now - startTime;

            // ��s�p�ɾ���r
            timerText.text = elapsedTime.ToString(@"hh\:mm\:ss");
        }

        // ����p�ɾ�
        public void StopTimer() {
            timer.Stop();
        }
    }
}