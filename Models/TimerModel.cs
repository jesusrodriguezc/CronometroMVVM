using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace CronometroAncert.Models {
	public class TimerModel {
		public TimeSpan Tiempo { get; set; }

		public TimerModel () {
			Tiempo = TimeSpan.Zero;
		}

		public void Incrementar () {
			Tiempo = Tiempo.Add(TimeSpan.FromSeconds(1));
		}

		public void Reiniciar () {
			Tiempo = TimeSpan.Zero;
		}
	}
}
