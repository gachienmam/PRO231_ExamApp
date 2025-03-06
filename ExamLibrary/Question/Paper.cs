using ExamLibrary.Question.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExamLibrary.Question
{
    public class Paper
    {
        public Paper()
        {
            _testName = string.Empty;
            _testImage = new byte[0];
            _examCode = string.Empty;
            _listAudio = new List<Data.Audio>();
            _notes = string.Empty;
            _listenCode = string.Empty;
            _q_multipleChoice = new List<Types.MultipleChoice>();
            _duration = 600;
        }
        public bool ShuffleMultipleChoice
        {
            get
            {
                return _shuffleMultipleChoice;
            }
            set
            {
                _shuffleMultipleChoice = value;
            }
        }

        public string TestName
        {
            get
            {
                return _testName;
            }
            set
            {
                _testName = value;
            }
        }

        public byte[] ExamImage
        {
            get
            {
                return _testImage;
            }
            set
            {
                _testImage = value;
            }
        }

        public int Duration // in seconds
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
            }
        }

        public string ExamNotes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }
        }

        public string ExamCode
        {
            get
            {
                return _examCode;
            }
            set
            {
                _examCode = value;
            }
        }

        public float Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                _mark = value;
            }
        }

        public int NoOfQuestion
        {
            get
            {
                return _noOfQuestions;
            }
            set
            {
                _noOfQuestions = value;
            }
        }

        public List<Types.MultipleChoice> MultipleChoiceQuestions // in seconds
        {
            get
            {
                return _q_multipleChoice;
            }
            set
            {
                _q_multipleChoice = value;
            }
        }

        public string ListenCode
        {
            get
            {
                return _listenCode;
            }
            set
            {
                _listenCode = value;
            }
        }

        public List<Data.Audio> ListAudio
        {
            get
            {
                return _listAudio;
            }
            set
            {
                _listAudio = value;
            }
        }

        private string _testName;

        private byte[] _testImage;

        private string _examCode;

        private string _notes;

        private int _duration; // in seconds

        private float _mark;

        private int _noOfQuestions;

        private List<Types.MultipleChoice> _q_multipleChoice;

        private bool _shuffleMultipleChoice;

        private string _listenCode;

        private List<Data.Audio> _listAudio;
    }
}