using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Juridico.Extensions
{
    public static class AlertMessageTypes
    {
        public const string Success = "success";
        public const string Warning = "warning";
        public const string Danger = "danger";
    }


    public static class TempDataExtensions
    {
        public static void AlertSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            var typeMessage = AlertMessageTypes.Success;
            tempData["alertMessage"] = message;
            tempData["typeMessage"] = typeMessage;
        }

        public static void AlertWarningMessage(this ITempDataDictionary tempData, string message)
        {
            var typeMessage = AlertMessageTypes.Warning;
            tempData["alertMessage"] = message;
            tempData["typeMessage"] = typeMessage;
        }

        public static void AlertDangerMessage(this ITempDataDictionary tempData, string message)
        {
            var typeMessage = AlertMessageTypes.Danger;
            tempData["alertMessage"] = message;
            tempData["typeMessage"] = typeMessage;
        }


    }
}
