using CronometroAncert.Commands;
using CronometroAncert.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace CronometroAncert.ViewModels {
	public class TimerViewModel : INotifyPropertyChanged {
		private Timer timer;
		private TimerModel timerModel;
		private string _timeString = "00::00::00";

		public TimerViewModel () {
			timerModel = new TimerModel ();
			timer = new Timer(1000);
			timer.Elapsed += OnTimedEvent;

			StartCommand = new RelayCommand(StartTimer, () => !timer.Enabled);
			PauseCommand = new RelayCommand(StopTimer, () => timer.Enabled);
			StopCommand = new RelayCommand(ResetTimer);
		}

		public string TimeString {
			get { return _timeString; }
			set {
				if (_timeString != value) {
					_timeString = value;
					OnPropertyChanged(nameof(TimeString));
				}
			}
		}

		public ICommand StartCommand { get; private set; }
		public ICommand PauseCommand { get; private set; }
		public ICommand StopCommand { get; private set; }

		private void StartTimer () {
			timer.Start();
			CommandManager.InvalidateRequerySuggested();
		}

		private void StopTimer () {
			timer.Stop();
			CommandManager.InvalidateRequerySuggested();
		}

		private void ResetTimer () {
			timer.Stop();
			timerModel.Reiniciar(); 
			TimeString = "00::00::00";
			CommandManager.InvalidateRequerySuggested();
		}

		private void OnTimedEvent (object? source, ElapsedEventArgs e) {
			timerModel.Incrementar();
			TimeString = timerModel.Tiempo.ToString(@"hh\:\:mm\:\:ss");
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected virtual void OnPropertyChanged (string propertyName) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
