using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ExpenseTracker.Commands;
using ExpenseTracker.Models;
using System.Xml.Schema;
using Newtonsoft.Json;
using System.IO;
namespace ExpenseTracker.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _title;
        private decimal _amount;
        private string _category;
        private decimal _totalExpense;
        private Expense _selectedExpense;

        public Expense SelectedExpense
        {
            get => _selectedExpense;
            set { _selectedExpense = value; OnPropertyChanged(); }
        }
        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }
        public decimal Amount
        {
            get => _amount;
            set { _amount = value; OnPropertyChanged(); }
        }

        public string Category
        {
            get => _category;
            set { _category = value; OnPropertyChanged(); }

        }

        public decimal TotalExpense
            {
            get => _totalExpense;
            set { _totalExpense = value; OnPropertyChanged(); }

        }

        public ObservableCollection<Expense> Expenses { get; set; }

        public RelayCommand AddCommand {  get; set; }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand LoadCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public MainViewModel()
        {
            SaveCommand = new RelayCommand(SaveToFile);
            LoadCommand = new RelayCommand(LoadFromFile);
            Expenses =  new ObservableCollection<Expense>();
            AddCommand = new RelayCommand(AddExpense);
            DeleteCommand = new RelayCommand(DeleteExpense);

        }
        private void SaveToFile()
        {
            string json = JsonConvert.SerializeObject(Expenses, Formatting.Indented);
            File.WriteAllText("expenses.json", json);
        }

        private void LoadFromFile()
        {
            if (File.Exists("expenses.json"))
            {
                string json = File.ReadAllText("expenses.json");
                var list = JsonConvert.DeserializeObject<List<Expense>>(json);

                Expenses.Clear();
                TotalExpense = 0;

                foreach (var expense in list)
                {
                    Expenses.Add(expense);
                    TotalExpense += expense.Amount;
                }
            }
        }
        private void AddExpense()
        {
            Expenses.Add(new Expense
            {

                Title = Title,
                Amount = Amount,
                Category = Category,
                Date = DateTime.Now
            });

            TotalExpense = TotalExpense + Amount;
            Title = "";
            Amount = 0;
            Category = "";
            

        }

        private void DeleteExpense()
        {
           if (SelectedExpense != null) 
            {
                TotalExpense = TotalExpense - SelectedExpense.Amount;
                Expenses.Remove(SelectedExpense);
                SelectedExpense = null;
            }

            TotalExpense = TotalExpense + Amount;
            

        }

    }
}
