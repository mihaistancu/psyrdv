public class CurrentUser {
    public static string From(HttpRequest request) {
        return (string) request.Headers["X-MS-CLIENT-PRINCIPAL-NAME"] ?? "LocalDev";
    }
}