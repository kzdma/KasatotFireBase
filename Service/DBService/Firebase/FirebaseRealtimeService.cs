using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasatotFireBase.Service.DBService.Firebase
{
	public class FirebaseRealtimeService : IDbInstance
	{
		protected FirebaseClient? _firebaseClient;

		public FirebaseRealtimeService()
		{
			_firebaseClient = new FirebaseClient("");
		}
		public string Info()
		{
			return "Type: Google Firebase RealTime Database client";
		}
	}
}
