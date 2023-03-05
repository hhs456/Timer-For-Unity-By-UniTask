using System;
using System.Threading;
using Cysharp.Threading.Tasks; // 引入UniTask命名空間
using UnityEngine;

namespace ToolKid {
    public class Timer {
        // 記錄目前已經經過的時間
        private float currentTime;
        // 計時器的總時間
        private float duration;
        // 計時器是否正在運行
        private bool isRunning;
        // 計時器是否為倒數計時器
        private bool isCountdown;
        // 取消Token的Source
        private CancellationTokenSource cts;

        public Timer(float duration) {
            this.Duration = duration;
            IsRunning = false;
            // 初始化 CancellationTokenSource
            cts = new CancellationTokenSource();
        }

        public float CurrentTime { get => currentTime; set => currentTime = value; }
        public float Duration { get => duration; set => duration = value; }
        public bool IsRunning { get => isRunning; set => isRunning = value; }
        public bool IsCountdown { get => isCountdown; set => isCountdown = value; }

        // 計時器的Tick事件
        public event Func<UniTask> OnTimerTick;
        // 計時器完成事件
        public event Func<UniTask> OnTimerComplete;

        // 開始計時器
        public void Start() {
            if (IsRunning) return;
            IsRunning = true;
            CurrentTime = 0f;
            // 開始執行計時器的迴圈
            _ = TimerLoop();
        }

        // 停止計時器
        public void Stop() {
            if (!IsRunning) return;
            IsRunning = false;
            // 取消迴圈中的 await UniTask.Delay()，中斷迴圈
            cts.Cancel();
        }

        // 計時器迴圈
        private async UniTask TimerLoop() {
            while (CurrentTime < Duration && IsRunning) {
                // 等待 0.1 秒
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: cts.Token);
                // 更新目前已經經過的時間
                CurrentTime += 0.1f;
                // 如果有註冊 Tick 事件，呼叫事件
                if (OnTimerTick != null) await OnTimerTick.Invoke();
            }

            // 如果計時器是仍在運行中，並且有註冊 Complete 事件，呼叫事件
            if (IsRunning && OnTimerComplete != null) await OnTimerComplete.Invoke();

            // 計時器運行結束
            IsRunning = false;
        }
    }
}
