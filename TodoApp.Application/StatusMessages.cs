namespace TodoApp.Application
{
    public static class StatusMessages
    {
        public static class Task
        {
            public const string Founded = "Task was successfully founded.";
            public const string Deleted = "Task was successfully deleted.";
            public const string TaskListFounded = "Tasks list retrieved successfully.";
            public const string Updated = "Task was successfully updated.";
            public const string Created = "Task was successfully created.";
            public const string NotFound = "Task not found or you don't have permission to access it.";
            public const string NotFoundedTasksList = "No tasks are available for the user.";
            public const string InvalidData = "The provided data is invalid.";
        }

        public static class User
        {
            public const string LoggedIn = "User verified succesfully";
            public const string SuccessfullyRegistered = "User was successfully registered";
            public const string NotFound = "User not found.";
            public const string NotRegistered = "User information not valid for register.";
            public const string UserExists = "Username or email is already in use."
            public const string Unauthorized = "You are not authorized to perform this action.";
        }
    }
}
