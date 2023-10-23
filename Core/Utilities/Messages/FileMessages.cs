using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
