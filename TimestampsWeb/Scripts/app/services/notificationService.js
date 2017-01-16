var NotificationService = function() {
    var getNewNotifications = function(success, error) {
        $.get("/api/notifications").done(success).fail(error);
    };
    var markShownNotificationsAsRead = function(success, error) {
        $.post("/api/notifications")
            .done(success)
            .fail(error);
    };
    return {
        getNewNotifications: getNewNotifications,
        markShownNotificationsAsRead: markShownNotificationsAsRead
    }
}();