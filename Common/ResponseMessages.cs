namespace ZipZop.Common
{
    public static class ResponseMessages
    {
        // ✅ Success
        public const string UserRegistered = "User registered successfully.";
        public const int UserRegisteredCode = 200;

        public const string VehicleAdded = "Vehicle added successfully.";
        public const int VehicleAddedCode = 200;

        public const string VehicleUpdated = "Vehicle updated successfully.";
        public const int VehicleUpdatedCode = 200;

        public const string BookingCompleted = "Booking completed successfully.";
        public const int BookingCompletedCode = 200;

        public const string BookingCancelled = "Booking cancelled successfully.";
        public const int BookingCancelledCode = 200;

        // ❌ Errors
        public const string UserAlreadyExists = "User already exists.";
        public const int UserAlreadyExistsCode = 409;

        public const string VehicleNotFound = "Vehicle not found.";
        public const int VehicleNotFoundCode = 404;

        public const string BookingFailed = "Booking failed. Vehicle may not be available.";
        public const int BookingFailedCode = 400;

        public const string BookingNotFound = "Booking not found or already cancelled.";
        public const int BookingNotFoundCode = 404;

        public const string InvalidCredentials = "Invalid email or password.";
        public const int InvalidCredentialsCode = 401;

        public const string InvalidInput = "Invalid input.";
        public const int InvalidInputCode = 400;

        public const string UnauthorizedAccess = "Unauthorized access.";
        public const int UnauthorizedAccessCode = 401;

        public const string UnexpectedError = "An unexpected error occurred.";
        public const int UnexpectedErrorCode = 500;
    }
}
