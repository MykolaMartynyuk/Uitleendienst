using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Uitleendienst.Models;

namespace Uitleendienst
{
    public class Coordinator : DependencyObject
    {
        private Window _window;

        public Window Window
        {
            get
            {
                if (_window == null)
                {
                    _window = new MainWindow();
                    _window.Show();
                }
                return _window;
            }
        }
        
        public void ShowMain()
        {
            MainPage main = new MainPage();
            MainViewModel mainViewModel = new MainViewModel(this);

            main.DataContext = mainViewModel;
            Window.Content = main;
        }
        
        //item pages
        public void ShowItemCreate()
        {
            ItemPage page = new ItemPage();
            ItemCreateViewMode viewModel = new ItemCreateViewMode(this);
            
            page.DataContext = viewModel;
            Window.Content = page;
        }

        public void ShowItemRead(Item item)
        {
            ItemPage page = new ItemPage();
            ItemReadViewMode viewModel = new ItemReadViewMode(this, item);

            page.DataContext = viewModel;
            Window.Content = page;
        }

        public void ShowItemUpdate(Item item)
        {
            ItemPage page = new ItemPage();
            ItemUpdateViewMode viewModel = new ItemUpdateViewMode(this, item);

            page.DataContext = viewModel;
            Window.Content = page;
        }

        //person pages
        public void ShowPersonCreate()
        {
            PersonPage page = new PersonPage();
            PersonCreateViewMode viewModel = new PersonCreateViewMode(this);

            page.DataContext = viewModel;
            Window.Content = page;
        }

        public void ShowPersonRead(Person person)
        {
            PersonPage page = new PersonPage();
            PersonReadViewMode viewModel = new PersonReadViewMode(this, person);

            page.DataContext = viewModel;
            Window.Content = page;
        }

        public void ShowPersonUpdate(Person person)
        {
            PersonPage page = new PersonPage();
            PersonUpdateViewMode viewModel = new PersonUpdateViewMode(this, person);

            page.DataContext = viewModel;
            Window.Content = page;
        }

        //loanrecord pages
        public void ShowLoanRecordCreate()
        {
            LoanRecordPage page = new LoanRecordPage();
            LoanRecordCreateViewMode viewModel = new LoanRecordCreateViewMode(this);

            page.DataContext = viewModel;
            Window.Content = page;
        }

        public void ShowLoanRecordRead(LoanRecord loan)
        {
            LoanRecordPage page = new LoanRecordPage();
            LoanRecordReadViewMode viewModel = new LoanRecordReadViewMode(this, loan);

            page.DataContext = viewModel;
            Window.Content = page;
        }

        public void ShowLoanRecordUpdate(LoanRecord loan)
        {
            LoanRecordPage page = new LoanRecordPage();
            LoanRecordUpdateViewMode viewModel = new LoanRecordUpdateViewMode(this, loan);

            page.DataContext = viewModel;
            Window.Content = page;
        }        

    }
}
