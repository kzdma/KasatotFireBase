Kasatot ReadMe

1. Create MVVM model construction
2. Create SignIn View
3. Create SignIn View Model
4. Install CommunityToolkit.MvvM
5. Open project in Firebase Console
6. Create Firebase Auth module Email + Password
7. Create IAuthService interface
8. Create FirebaseAuthService class, connect to Firebase Auth

11/3/2026
9. Create SignUpView and SignUpViewModel
10. Create and use CreateAuth method in FirebaseAuthService
11. Create Dependency Injection Conteiner and register FirebaseAuthService as IAuthService
12. Register SignInView,SignInViewModel, SignUpView and SignUpViewModel in DI Container
11. Create Navigation method to navigate to SignUpView and SignInView

18/3/2026
13. Add MaterialIcons-Regular font to the project and use icons in SignUp views
14. Add Helper directory to the project and create FontHelper class to handle fonts icons
15. Add Models directory to the project and create AppUser model with properties for user information
16. Create new SignUpView and SignUpViewModel - Full User Info and default image
17. Create custom style in ResourceDictionary for Border and Entry
18. Add DBService directory to the project and create IDbInstance interface
19. Create IAppUserRepository interface to define User Repository methods
20. Create FirebaseRealtimeService class to implement IDbInstance and connect to Firebase Realtime Database
21. Create FirebaseUsersRepository class to implement IAppUserRepository and connect to Firebase Firestore
22. Create CreateAsync method in FirebaseUsersRepository to create user auth and user document in Realtime Database 
