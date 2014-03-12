using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App15.Annotations;


namespace App15.ViewModel
{
    class Student : INotifyPropertyChanged
    {
        private Model.Student _currentStudent;

        private List<Model.Student> _studentList; 

        private ICommand _addStudent;

        // ctor with fake data
        public Student()
        {
            // Create command instance - use RealyCommand to call AddContact method
            _addStudent = new RelayCommand(AddStudentCommand){IsEnabled = true};
            
            _studentList = new List<Model.Student>();
            _studentList.Add(new Model.Student(){FirstName = "Liv", LastName = "Vang", ExamGroup = "None"});
            _studentList.Add(new Model.Student(){FirstName = "Mikkel", LastName = "vang", ExamGroup = "Lazy"});
            _studentList.Add(new Model.Student() { FirstName = "Ebbe", LastName = "Vang", ExamGroup = "Winners" });
            _studentList.Sort();

            _currentStudent = _studentList[0];
        }

        // expose commmand to UI
        public ICommand AddStudent {
            get { return _addStudent; }
        }
        public Model.Student CurrentStudent {
            get { return _currentStudent; }
            set
            {
                _currentStudent = value;
                // tell MVVM that CurrentCurrentStudent property changed...
                OnPropertyChanged("CurrentStudent");
            }
        }

        //always use obeservable collection when collection is needed
        public ObservableCollection<Model.Student> StudentList {
            get
            {
                ObservableCollection<Model.Student> c = new ObservableCollection<Model.Student>();
                foreach (var student in _studentList)
                {
                    c.Add(student);
                }
                return c;
            }
        }


        private void AddStudentCommand()
        {
            // create Student in StudentList
            _studentList.Add(new Model.Student(){FirstName = "Commands are great"});
            // notify Changes in StudentList
            OnPropertyChanged("StudentList");
        }


        #region Implementation of inotify.. interface
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        
    }
}
