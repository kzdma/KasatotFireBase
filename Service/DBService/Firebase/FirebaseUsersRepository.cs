using Firebase.Database.Query;
using KasatotFireBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasatotFireBase.Service.DBService.Firebase
{
	public class FirebaseUsersRepository : FirebaseRealtimeService, IAppUserRepository
	{
		private IAuthService _authService;
		private IAppLogger _appLogger;

		public FirebaseUsersRepository(IAuthService authService, IAppLogger appLogger)
		{
			_authService = authService;
			_appLogger = appLogger;
		}

		public async Task<string> CreateAsync(AppUser appUser)
		{
			try
			{
				string userId = await _authService.CreateAuth(appUser.UserEmail!, appUser.UserPassword!);

				//Add ID to the user object and save it to the DB
				appUser.Id = userId;
				await RegisterAppUser(appUser);
				_appLogger.LogDebug($"FirebaseUsersRepository {appUser.UserEmail} SignUp successfully");
				return userId;
			}
			catch (Exception ex)
			{
				_appLogger.LogDebug($"FirebaseUsersRepository SignIn failed: {ex.Message}");
				if (!ex.Message.Contains("RealTimeDB"))
					throw new Exception(ex.Message);

				throw new Exception("SignUp new user failed!");
			}
		}

		public async Task RegisterAppUser(AppUser appUser)
		{
			try
			{
				await _firebaseClient!
			   .Child("users")
			   .Child(appUser.Id)
			   .PutAsync(new AppUser()
			   {
				   Id = appUser.Id,
				   FirstName = appUser.FirstName,
				   LastName = appUser.LastName,
				   UserEmail = appUser.UserEmail,
				   UserPassword = appUser.UserPassword,
				   UserMobile = appUser.UserMobile,
				   RegDate = appUser.RegDate,
				   UBDate = appUser.UBDate,
				   IsAdmin = appUser.IsAdmin
			   });
			}
			catch (Exception ex)
			{
				_appLogger.LogDebug($"RealTimeDB SignUp failed: {ex.Message}");
				throw new Exception("RealTimeDB add new user failed");
			}
		}

		public Task DeleteAsync(AppUser appUser)
		{
			throw new NotImplementedException();
		}

		public List<AppUser> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<AppUser> GetUserByIdAsync(string userId)
		{
			throw new NotImplementedException();
		}

		public Task SetToAdmin(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<AppUser> SignInAsync(string userEmail, string userPassword)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(AppUser appUser)
		{
			throw new NotImplementedException();
		}
	}
}
