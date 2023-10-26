namespace Core.Utilities.Helper.FileHelper
{
    public static class FileTypes
    {
        public static Dictionary<string, string> GetImageTypes()
        {
            Dictionary<string, string> fileTypes = new()
            {
                { "image/bmp", "bmp" },
                { "image/jpeg", "jpg" },
                { "image/png", "png" }
            };

            return fileTypes;
        }

        public static Dictionary<string, string> GetAllFileTypes()
        {
            Dictionary<string, string> fileTypes = new()
            {
                { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx" },
                { "application/vnd.ms-excel", "xls" },
                { "image/bmp", "bmp" },
                { "image/jpeg", "jpg" },
                { "image/png", "png" },
                { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx" },
                { "application/msword", "doc" },
                { "application/pdf", "pdf" }
            };

            return fileTypes;
        }

        public static Dictionary<string, string> GetPdfType()
        {
            Dictionary<string, string> fileTypes = new()
            {
                { "application/pdf", "pdf" }
            };

            return fileTypes;
        }

        public static Dictionary<string, string> GetExcelTypes()
        {
            Dictionary<string, string> fileTypes = new()
            {
                { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx" },
                { "application/vnd.ms-excel", "xls" }
            };

            return fileTypes;
        }

        public static Dictionary<string, string> GetDocTypes()
        {
            Dictionary<string, string> fileTypes = new()
            {
                { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx" },
                { "application/msword", "doc" }
            };

            return fileTypes;
        }

        public static Dictionary<string, string> GetDocAndPdfTypes()
        {
            Dictionary<string, string> fileTypes = new()
            {
                { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx" },
                { "application/msword", "doc" },
                { "application/pdf", "pdf" }
            };

            return fileTypes;
        }

        public static Dictionary<string, string> GetDocAndExcelTypes()
        {
            Dictionary<string, string> fileTypes = new()
            {
                { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx" },
                { "application/msword", "doc" },
                { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx" },
                { "application/vnd.ms-excel", "xls" }
            };

            return fileTypes;
        }

        public static Dictionary<string, string> GetExcelAndPdfTypes()
        {
            Dictionary<string, string> fileTypes = new()
            {
                { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx" },
                { "application/vnd.ms-excel", "xls" },
                { "application/pdf", "pdf" }
            };

            return fileTypes;
        }

        public static Dictionary<string, string> GetDocAndPdfAndExcelTypes()
        {
            Dictionary<string, string> fileTypes = new()
            {  { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx" },
                { "application/vnd.ms-excel", "xls" },
                { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx" },
                { "application/msword", "doc" },
                { "application/pdf", "pdf" }
            };

            return fileTypes;
        }
    }
}
