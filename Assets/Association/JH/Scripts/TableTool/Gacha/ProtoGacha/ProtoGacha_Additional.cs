using System;
using UnityEngine;

namespace ProtoGacha_Additional
{
    public class FeverHandler
    {
        public float _feverPer;
        public float _feverTime;
        public DateTime startTime;

        private bool timeStored = false;
        public bool GetIsStored() { return timeStored || IsFeverTime(); }

        bool myBool = false;

        public void AddFeverPercent_byCreateItem(float input)
        {
            do
            {
                if (IsFeverTime())
                    break;

                _feverPer += input; 
                
                if (_feverPer >= 1)
                {                
                    // Fever Sequence
                    if (true)
                    {
                        _feverPer--;
                        SetTimer();
                    }
                }
            } while (false);
        }

        public float GetFeverPercent()
        {
            float returnF = Mathf.Min(_feverPer, 1f);
            return returnF;
        }

        public void SetTimer()
        {
            Debug.Log("SetTimer!");
            startTime = DateTime.UtcNow;
            timeStored = true;
        }

        public bool IsFeverTime()
        {
            if (!timeStored)
            {
                Debug.LogWarning("Time not stored yet. Call StoreTime() first.");
                return false;
            }

            TimeSpan timeElapsed = DateTime.UtcNow - startTime;
            double TimeGap = 10f - timeElapsed.TotalSeconds;
            return TimeGap > 0;
        }
    }
}
