using ExamLibrary.Question.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace ExamLibrary.Question
{
    public class Paper : ICloneable
    {
        private string _testName;
        private string _examCode;
        private string _examImageLink;
        private string _notes;
        private int _duration; // giây
        private List<Types.MultipleChoice> _q_multipleChoice;
        private bool _option_shuffleMultipleChoice;
        //private string _listenCode;
        //private List<Data.Audio> _listAudio;

        public string TestName { get => _testName; set => _testName = value; }
        public string ExamCode { get => _examCode; set => _examCode = value; }
        public string ExamImageLink { get => _examImageLink; set => _examImageLink = value; }
        public string Notes { get => _notes; set => _notes = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public List<Types.MultipleChoice> QMultipleChoice { get => _q_multipleChoice; set => _q_multipleChoice = value?.Select(mc => (Types.MultipleChoice)mc.Clone()).ToList(); }
        public bool OptionShuffleMultipleChoice { get => _option_shuffleMultipleChoice; set => _option_shuffleMultipleChoice = value; }
        //public string ListenCode { get => _listenCode; set => _listenCode = value; }
        //public List<Data.Audio> ListAudio { get => _listAudio; set => _listAudio = value?.Select(audio => (Data.Audio)audio.Clone()).ToList(); }

        public Paper(string testName, string examCode, string examImageBase64, string notes, int duration, List<Types.MultipleChoice> q_multipleChoice, bool option_shuffleMultipleChoice)
        {
            _testName = testName;
            _examCode = examCode;
            _examImageLink = examImageBase64;
            _notes = notes;
            _duration = duration;
            _q_multipleChoice = q_multipleChoice?.Select(mc => (Types.MultipleChoice)mc.Clone()).ToList(); // Tạo bản sao
            _option_shuffleMultipleChoice = option_shuffleMultipleChoice;
            //_listenCode = listenCode;
            //_listAudio = listAudio?.Select(audio => (Data.Audio)audio.Clone()).ToList(); // Tạo bản sao
        }

        private Paper(Paper other)
        {
            _testName = other._testName;
            _examCode = other._examCode;
            _examImageLink = other._examImageLink;
            _notes = other._notes;
            _duration = other._duration;
            _q_multipleChoice = other._q_multipleChoice?.Select(mc => (Types.MultipleChoice)mc.Clone()).ToList(); // Tạo bản sao
            _option_shuffleMultipleChoice = other._option_shuffleMultipleChoice;
            //_listenCode = other._listenCode;
            //_listAudio = other._listAudio?.Select(audio => (Data.Audio)audio.Clone()).ToList(); // Tạo bản sao
        }

        public object Clone()
        {
            return new Paper(this);
        }
    }
}