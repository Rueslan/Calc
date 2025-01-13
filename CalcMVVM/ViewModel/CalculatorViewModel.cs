using CalcMVVM.Model;
using System.Windows;

namespace CalcMVVM.ViewModel
{
	public class CalculatorViewModel : ViewModelBase
	{
		private readonly Calculator _calculator;
		private string _result;
		private int _action;

		public CalculatorViewModel()
		{
			_calculator = new Calculator();
		}

		public int A
		{
			get => _calculator.A;
			set => _calculator.A = value;
		}

		public int B
		{
			get => _calculator.B;
			set => _calculator.B = value;			
		}

		public string Result
		{
			get => _result;
			set
			{
				_result = value;
				OnPropertyChanged(nameof(Result));
			}
		}

		public int Action
        {
			get => _action;
            set
            {
				_action = value;
				OnPropertyChanged(nameof(Action));
            }
        }

		private void Calc()
		{
            switch (Action)
            {
				case 0:
					Result = _calculator.Add().ToString();
					break;
				case 1:
					Result = _calculator.Sub().ToString();
					break;
				case 2:
					Result = _calculator.Mul().ToString();
					break;
				case 3:
					Result = _calculator.Div().ToString();
					break;
            }
		}

        #region Commands        

        #region CalcCommand
        private RelayCommand _calcCommand;
		public RelayCommand CalcCommand => _calcCommand ?? (_calcCommand =
											new RelayCommand(ExecuteCalcCommand,
												CanCalcCommand));
		public void ExecuteCalcCommand(object parameter)
		{
			Calc();
		}

		public bool CanCalcCommand(object parameter) => B != 0 && Action > -1;
		#endregion

		#region ExitCommand
		private RelayCommand _exitCommand;
		public RelayCommand ExitCommand => _exitCommand ?? (_exitCommand =
											new RelayCommand(ExecuteExitCommand,
												CanExitCommand));
		public void ExecuteExitCommand(object parameter)
		{
			Application.Current.Shutdown();
		}

		public bool CanExitCommand(object parameter) => true;
		#endregion

		#endregion
	}
}