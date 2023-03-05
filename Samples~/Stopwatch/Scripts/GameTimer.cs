using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ToolKid {
    public class GameTimer : MonoBehaviour {
        // 用於顯示計時器的文字
        public Text timerText;

        // 用於計時的計時器
        private Timer timer;

        // 記錄計時器開始運行的時間
        private DateTime startTime;

        // 記錄計時器目前的運行時間
        private TimeSpan elapsedTime;

        private void Start() {
            // 初始化計時器
            timer = new Timer(float.PositiveInfinity);
            timer.OnTimerTick += UpdateTimerText;

            // 開始計時器
            timer.Start();

            // 記錄計時器開始運行的時間
            startTime = DateTime.Now;
        }

        // 更新計時器的文字
        private async UniTask UpdateTimerText() {
            // 計算目前的運行時間
            elapsedTime = DateTime.Now - startTime;

            // 更新計時器文字
            timerText.text = elapsedTime.ToString(@"hh\:mm\:ss");
        }

        // 停止計時器
        public void StopTimer() {
            timer.Stop();
        }
    }
}