namespace Core.Utilities.Messages
{
    public class FileMessages
    {
        public static string FileUploadSuccessMessage { get; } = "File upload successful.";
        public static string FileUploadFailureMessage { get; } = "File upload failed.";

        public static string FileDeletionSuccessMessage { get; } = "File deletion successful.";
        public static string FileDeletionFailureMessage { get; } = "File deletion failed.";

        public static string FileUpdateSuccessMessage { get; } = "File update successful.";
        public static string FileUpdateFailureMessage { get; } = "File update failed.";

        public static string FileRetrievalSuccessMessage { get; } = "File retrieval successful.";
        public static string FileRetrievalFailureMessage { get; } = "File retrieval failed.";

        public static string FilePathNotFoundMessage { get; } = "File path not found.";
        public static string OldFileDeletionFailureMessage { get; } = "An error occurred while deleting the old file.";
        public static string InvalidFileTypeMessage { get; } = "Invalid file type";
        public static string FileSuccessMessage { get; } = "Operation completed successfully.";
        public static string FileFailureMessage { get; } = "Operation failed.";
        public static string FileSizeExceededMessage { get; } = "The file size should not exceed {0} MB.";
    }
}
