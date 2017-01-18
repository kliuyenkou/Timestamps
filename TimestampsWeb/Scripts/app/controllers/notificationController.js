var NotificationController = function(notificationService) {

    var loadNotifications = function() {
        notificationService.getNewNotifications(showNotifications,
            function() {
                bootbox.alert("Failed to get notifications from the server.");
            });
    };

    function showNotifications(notifications) {
        if (notifications.length > 0) {
            var badge = $(".js-notifications-count");
            badge.attr("data-has-new-notifications", true);
            badge.text(notifications.length).removeClass("hide");
        }
        $(".notifications").popover({
                html: true,
                title: "Notifications",
                content: function() {
                    return renderPopoverContent(notifications, true);
                },
                placement: "bottom"
            })
            .on("hidden.bs.popover", markNotificationsAsRead);
    };

    function renderPopoverContent(notifications, showButton) {
        var div = document.createElement("div");
        var ul = document.createElement("ul");
        ul.className = "notifications";
        if (notifications.length > 0) {
            $.each(notifications,
                function(index, record) {
                    var li = renderNotification(record);
                    ul.appendChild(li);
                });
            div.appendChild(ul);
        } else {
            var spanMessage = document.createElement("p");
            spanMessage.innerText = "You don't have new notifications.";
            spanMessage.className = "text-info";
            div.appendChild(spanMessage);
        }
        if (showButton) {
            var btn = renderButtonShowAll(showAllMessages);
            div.appendChild(btn);
        }
        return div;
    };

    function renderNotification(record) {
        var li = document.createElement("li");
        var spanMessage;
        if (record.Type === 1) {
            spanMessage = createMessageArchiveProject(record.Project.Title);
            li.appendChild(spanMessage);
        }
        if (record.Type === 2) {
            spanMessage = createMessageRestoreProject(record.Project.Title);
            li.appendChild(spanMessage);
        }
        return li;
    }

    function createMessageArchiveProject(projectTitle) {
        var spanMessage = document.createElement("span");
        var spanTitle = document.createElement("span");
        spanTitle.className = "highlight";
        spanTitle.innerHTML = projectTitle;
        spanMessage.appendChild(spanTitle);
        var spanText = document.createElement("span");
        spanText.innerText = " moved to archive.";
        spanMessage.appendChild(spanText);
        return spanMessage;
    }

    function createMessageRestoreProject(projectTitle) {
        var spanMessage = document.createElement("span");
        var spanTitle = document.createElement("span");
        spanTitle.className = "highlight";
        spanTitle.innerHTML = projectTitle;
        spanMessage.appendChild(spanTitle);
        var spanText = document.createElement("span");
        spanText.innerText = " restored from archive.";
        spanMessage.appendChild(spanText);
        return spanMessage;
    }

    function renderButtonShowAll(onclickHandler) {
        var btn = document.createElement("a");
        btn.className = "btn btn-default";
        btn.innerText = "Show all";
        btn.onclick = onclickHandler;
        return btn;
    }

    function showAllMessages(e) {
        e.preventDefault();
        notificationService.getAllNotifications(updateNotificatinsList,
            function() {
                bootbox.alert("Failed to get notifications from the server.");
            });
    }

    function updateNotificatinsList(notifications) {
        var popover = $(".notifications").data("bs.popover");
        var content = renderPopoverContent(notifications, false);
        popover.options.content = content;
        popover.show();
    }

    function markNotificationsAsRead() {
        var badge = $(".js-notifications-count");
        var hasNew = badge.attr("data-has-new-notifications");
        if (hasNew === "true") {
            notificationService.markShownNotificationsAsRead(
                function() {
                    badge.text("").addClass("hide").attr("data-has-new-notifications", false);
                },
                function(jqXhr, textStatus, errorThrown) {
                    console.error("Ajax request failed", jqXhr, textStatus, errorThrown);
                }
            );
        }
    };

    return {
        loadNotifications: loadNotifications
    };
}(NotificationService)