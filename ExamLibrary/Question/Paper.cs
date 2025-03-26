using ExamLibrary.Question.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ExamLibrary.Question
{
    public class Paper
    {
        public Paper()
        {
            _examCode = string.Empty;
            _testName = string.Empty;
            _testImage = new byte[0];
            _listAudio = new List<Data.Audio>();
            _notes = string.Empty;
            _mark = 0;
            _listenCode = string.Empty;
            _option_shuffleMultipleChoice = true;
            _q_multipleChoice = new List<Types.MultipleChoice>();
            _duration = 600;
        }

        // Tên đề thi
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

        // Ảnh đề thi
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

        // Thời gian thi (tính bằng giây)
        public int Duration
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

        // Ghi chú từ giảng viên
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

        // Mã đề
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

        // Số câu cần trả lời đúng để Pass
        public int Mark
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

        // Số lượng câu hỏi
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

        // Tùy chọn: Có xáo trộn câu hỏi MultipleChoice hay không?
        public bool option_ShuffleMultipleChoice
        {
            get
            {
                return _option_shuffleMultipleChoice;
            }
            set
            {
                _option_shuffleMultipleChoice = value;
            }
        }

        // Danh sách câu hỏi MultipleChoice
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

        // Chưa dùng
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

        // Chưa dùng
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

        private int _mark; // số câu

        private int _noOfQuestions;

        private List<Types.MultipleChoice> _q_multipleChoice;

        private bool _option_shuffleMultipleChoice;

        private string _listenCode;

        private List<Data.Audio> _listAudio;
    }
}