var NotificationService = function() {
    var getNewNotifications = function(success, error) {
        $.get("/api/notifications/new").done(success).fail(error);
    };
    var markShownNotificationsAsRead = function(success, error) {
        $.post("/api/notifications")
            .done(success)
            .fail(error);
    };
    var getAllNotifications = function(success, error) {
        $.get("/api/notifications/all").done(success).fail(error);
    };
    return {
        getNewNotifications: getNewNotifications,
        markShownNotificationsAsRead: markShownNotificationsAsRead,
        getAllNotifications: getAllNotifications
    };
}();