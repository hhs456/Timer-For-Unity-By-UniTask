using System;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace ToolKid {
    public class Stopwatch : MonoBehaviour {
        [SerializeField] private Text timerText; // 顯示計時器時間的UI Text
        [SerializeField] private float duration = 60f; // 計時器時間
        [SerializeField] private bool isCountdown = true; // 是否為倒數計時
        [SerializeField] private bool hasEndTime = true; // 是否有結束時間
        [SerializeField] private bool destroyOnComplete = true; // 計時完成後是否自行銷毀
        private Timer timer;

        private void Start() {
            // 設定計時器時間
            SetTimer(duration, hasEndTime);
            if (!timerText) return;
        }

        // 設定計時器時間
        public void SetTimer(float duration, bool isCountdown = true) {
            if (isCountdown) {
                timer = new Timer(duration);
            }
            else {
                timer = new Timer(float.PositiveInfinity);
            }
            UpdateTimeUI();
            // 設定 Tick 事件
            timer.OnTimerTick += () => {
                // 更新顯示時間
                UpdateTimeUI();
                return UniTask.CompletedTask;
            };

            // 設定 Complete 事件
            timer.OnTimerComplete += () => {
                // 更新顯示時間
                UpdateTimeUI();
                if (destroyOnComplete) {
                    Destroy(gameObject);
                }

                return UniTask.CompletedTask;
            };
        }

        // 更新顯示時間
        private void UpdateTimeUI() {
            if (timerText == null) return;

            // 取得計時器時間
            float time = timer.IsRunning ? timer.CurrentTime : timer.Duration;
            // 決定是否顯示為倒數的時間
            time = isCountdown ? timer.Duration - timer.CurrentTime : time;

            // 轉換為時間格式
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);

            // 更新 UI 文字            
            timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }

        // 開始計時器
        public void StartTimer() {
            if (timer == null) return;
            timer.Start();
        }

        // 停止計時器
        public void StopTimer() {
            if (timer == null) return;
            timer.Stop();
        }

        // 銷毀物件時，停止計時器
        private void OnDestroy() {
            StopTimer();
        }
    }
}