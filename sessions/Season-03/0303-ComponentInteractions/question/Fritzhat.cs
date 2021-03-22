using System;

namespace question {

	public classs FritzHat {

		#region Fields

		private Guid _id;

		#endregion

		#region Constructors

		public FritzHat() {
			Id = Guid.NewGuid();
		}

		#endregion
		
		#region Events

		#endregion

		#region Properties

		public Guid Id { 
			get { return _id; }
			private set { _id = value; }
		}

		public string Name { get; set; }

		public string AcquiredDate { get; set; }

		public string Theme { get; set; }

		#endregion

		#region Methods

		public void Clean() { }

		#endregion

	}

}
