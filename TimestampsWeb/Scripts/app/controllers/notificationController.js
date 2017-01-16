var NotificationController = function (notificationService) {

    var loadNotifications = function() {
        NotificationService.getNewNotifications(showNotifications,
            function() {
                bootbox.alert("Faild to get notifications from the server.");
            });
    };

    function showNotifications(notifications) {
            if (notifications.length === 0)
                return;
            $('.js-notifications-count').text(notifications.length).removeClass('hide');
            $('.notifications').popover({
                html: true,
                title: "Notifications",
                content: function () {
                    return renderNotifications(notifications);
                },
                placement: "bottom"
            })
                .on("shown.bs.popover", markNotificationsAsRead);
    };

    function renderNotifications(notifications) {
        var ul = document.createElement('ul');
        ul.className = "notifications";
        $.each(notifications,
            function(index, record) {
                var li = renderNotification(record);
                ul.appendChild(li);
            });
        return ul;
    };

    function renderNotification(record) {
        var li = document.createElement('li');
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
        var spanMessage = document.createElement('span');
        var spanTitle = document.createElement('span');
        spanTitle.className = "highlight";
        spanTitle.innerHTML = projectTitle;
        spanMessage.appendChild(spanTitle);
        var spanText = document.createElement('span');
        spanText.innerText = ' moved to archive.';
        spanMessage.appendChild(spanText);
        return spanMessage;
    }

    function createMessageRestoreProject(projectTitle) {
        var spanMessage = document.createElement('span');
        var spanTitle = document.createElement('span');
        spanTitle.className = "highlight";
        spanTitle.innerHTML = projectTitle;
        spanMessage.appendChild(spanTitle);
        var spanText = document.createElement('span');
        spanText.innerText = ' restored from archive.';
        spanMessage.appendChild(spanText);
        return spanMessage;
    }

    function markNotificationsAsRead() {
        NotificationService.markShownNotificationsAsRead(
            function() {
                $('.js-notifications-count')
                    .text("")
                    .addClass('hide');
            },
            function(jqXhr, textStatus, errorThrown) {
                console.error('Ajax request failed', jqXhr, textStatus, errorThrown);
            }
            );
    };

    return {
        loadNotifications: loadNotifications
    }
}(NotificationService)