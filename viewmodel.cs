﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace test
{
    public class TestViewModel : INotifyPropertyChanged
    {

        string str;//変数
        string str2;
        int a;
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

        public string Str2
        {
            get
            {
                return this.str;
            }
            set
            {
                str = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Str2"));
            }
        }//プロパティ

        public myCommand command { get; private set; }
        public myCommand command2 { get; private set; }
        public TestViewModel()
        {
            str = "aaa";
            str2 = "bbb";
            a = 0;
            command = new myCommand((bool b)=>func1(b),true);
            command2 = new myCommand((bool b)=>func2(b),false);
            timer = new DispatcherTimer(DispatcherPriority.Normal);
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
        }

        void func1(bool b)
        {
            timer.Start();
        }

        void func2(bool b)
        {
            timer.Stop();
        }
        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            a++;
            str = a.ToString();
            PropertyChanged(this, new PropertyChangedEventArgs("Str"));
        }
    }

    public class myCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<bool> act;
        private bool pram;
        public bool CanExecute(object parameter)
        {
            return true;
            //throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {

            act((bool)pram);
            //throw new NotImplementedException();
        }

        public myCommand(Action<bool> act,bool pram)
        {
            this.act = act;
            this.pram = pram;
        }
    }
}
