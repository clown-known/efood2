//using Google.Apis.Auth.OAuth2.Flows;
//using Google.Apis.Auth.OAuth2.Responses;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Drive.v3;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
//using static Google.Apis.Drive.v3.DriveService;
//using System.IO;

//namespace EXE02_EFood_API.DAO
//{
//    public class imagee
//    {
//        private static DriveService GetService()
//        {
//            var tokenResponse = new TokenResponse
//            {
//                AccessToken = "...",
//                RefreshToken = "...",
//            };


//            var applicationName = "...";
//            var username = "...";


//            var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
//            {
//                ClientSecrets = new ClientSecrets
//                {
//                    ClientId = "...",
//                    ClientSecret = "..."
//                },
//                Scopes = new[] { Scope.Drive },
//                DataStore = new FileDataStore(applicationName)
//            });


//            var credential = new UserCredential(apiCodeFlow, username, tokenResponse);


//            var service = new DriveService(new BaseClientService.Initializer
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = applicationName
//            });
//            return service;
//        }

//        public string CreateFolder(string parent, string folderName)
//        {
//            var service = GetService();
//            var driveFolder = new Google.Apis.Drive.v3.Data.File();
//            driveFolder.Name = folderName;
//            driveFolder.MimeType = "application/vnd.google-apps.folder";
//            driveFolder.Parents = new string[] { parent };
//            var command = service.Files.Create(driveFolder);
//            var file = command.Execute();
//            return file.Id;
//        }
//        public string UploadFile(Stream file, string fileName, string fileMime, string folder, string fileDescription)
//        {
//            DriveService service = GetService();


//            var driveFile = new Google.Apis.Drive.v3.Data.File();
//            driveFile.Name = fileName;
//            driveFile.Description = fileDescription;
//            driveFile.MimeType = fileMime;
//            driveFile.Parents = new string[] { folder };


//            var request = service.Files.Create(driveFile, file, fileMime);
//            request.Fields = "id";

//            var response = request.Upload();
//            if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
//                throw response.Exception;

//            return request.ResponseBody.Id;
//        }
//    }
//}
