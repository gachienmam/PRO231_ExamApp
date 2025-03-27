using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamLibrary.Question.Data
{
    public class Audio : IComparable<Audio>, ICloneable
    {
        private int _audioSize;
        private byte[] _audioData;
        private int _audioLength;
        private byte _repeatTime;
        private int _paddingTime;
        private byte _playOrder;

        public int AudioSize { get => _audioSize; set => _audioSize = value; }
        public byte[] AudioData { get => _audioData; set => _audioData = value?.ToArray(); }
        public int AudioLength { get => _audioLength; set => _audioLength = value; }
        public byte RepeatTime { get => _repeatTime; set => _repeatTime = value; }
        public int PaddingTime { get => _paddingTime; set => _paddingTime = value; }
        public byte PlayOrder { get => _playOrder; set => _playOrder = value; }

        public Audio(int audioSize, byte[] audioData, int audioLength, byte repeatTime, int paddingTime, byte playOrder)
        {
            _audioSize = audioSize;
            _audioData = audioData?.ToArray(); // Tạo bản sao để tránh tham chiếu cái bản cũ
            _audioLength = audioLength;
            _repeatTime = repeatTime;
            _paddingTime = paddingTime;
            _playOrder = playOrder;
        }

        private Audio(Audio other)
        {
            _audioSize = other._audioSize;
            _audioData = other._audioData?.ToArray(); // Tạo bản sao để tránh tham chiếu
            _audioLength = other._audioLength;
            _repeatTime = other._repeatTime;
            _paddingTime = other._paddingTime;
            _playOrder = other._playOrder;
        }

        public object Clone()
        {
            return new Audio(this);
        }

        public int CompareTo(Audio audio)
        {
            return PlayOrder.CompareTo(audio.PlayOrder);
        }
    }
}
