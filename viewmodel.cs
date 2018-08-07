using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace test
{
    public class TestViewModel : INotifyPropertyChanged
    {

        string str;//変数

        public event PropertyChangedEventHandler PropertyChanged;
        private DispatcherTimer timer;
        public string Str
        {
            get
            {
                return this.str;
            }
            set{
                str = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Str"));
            }
        }//プロパティ

        public myCommand command { get; private set; }
        public TestViewModel()
        {
            str = "aaa";
            command = new myCommand(()=>func1());
            timer = new DispatcherTimer(DispatcherPriority.Normal);
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Start();
        }

        void func1()
        {
            str = str == "bbb" ? "aaa" : "bbb";
            PropertyChanged(this, new PropertyChangedEventArgs("Str"));
        }
        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //str = str=="bbb" ? "aaa" : "bbb";
            //PropertyChanged(this, new PropertyChangedEventArgs("Str"));
        }
    }

    public class myCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action act;
        public bool CanExecute(object parameter)
        {
            return true;
            //throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            act();
            //throw new NotImplementedException();
        }

        public myCommand(Action act)
        {
            this.act = act;
        }
    }
}
