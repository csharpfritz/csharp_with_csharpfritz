using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
	public partial class Form1 : Form
	{
		private HubConnection _Connection;

		public Form1()
		{
			InitializeComponent();

			_Connection = new HubConnectionBuilder()
				.WithUrl("https://localhost:5001/hub/shape")
				.WithAutomaticReconnect()
				.Build();

			_Connection.On<int, int>("ClientMoveShape", (x, y) =>
			{
				panel1.Top = y;
				panel1.Left = x;
			});

			_Connection.On<int>("Count", c =>
			{
				lblConnections.Text = $"Connection Count: {c}";
			});

			_Connection.On<string>("timer", t =>
			{
				lblTimestamp.Text = t;
			});

			_Connection.StartAsync();

		}

	}
}
