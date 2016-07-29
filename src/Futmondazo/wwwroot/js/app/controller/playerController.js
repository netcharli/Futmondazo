var PlayerController = function (playerService) {

    var _chartCanvasIdentifier;

    var loadChart = function (playerId, chartCanvasIdentifier) {
        _chartCanvasIdentifier = chartCanvasIdentifier;
        playerService.getPlayer(playerId, done, fail);
    };

    var loadChartInPopup = function (playerSelectorClass, chartCanvasIdentifier, popupId) {
        _chartCanvasIdentifier = chartCanvasIdentifier;
        $("." + playerSelectorClass)
            .on("click",
                function (e) {
                    var button = $(e.target);
                    var playerId = button.data("player-id");

                    $("#" + popupId).modal();

                    playerService.getPlayer(playerId, done, fail);
                });
    };

    var done = function (data) {
        var labels = data.playerHistories.map(function (h) {
            return moment(h.dateTime).format("DD/MM/YYYY");
        });

        var values = data.playerHistories.map(function (h) {
            return h.price;
        });
        var ctx = $("#" + _chartCanvasIdentifier);
        var playerChart = new Chart(ctx,
        {
            type: 'line',
            data: {
                labels: labels,
                datasets: [
                    {
                        label: 'Precio',
                        data: values
                    }
                ]
            },
            options: {
                scales: {
                    yAxes: [
                    {
                       ticks: {
                           callback: function (value, index, values) {
                               // Convert the number to a string and splite the string every 3 charaters from the end
                               value = value.toString();
                               value = value.split(/(?=(?:...)*$)/);

                               // Convert the array to a string and format the output
                               value = value.join('.');
                               return value + " €";
                           }
                       }
                    }]
                },
                tooltips: {
                    enabled: true,
                    mode: 'single',
                    callbacks: {
                        label: function (tooltipItems, data) {
                            var value = tooltipItems.yLabel.toString();
                            value = value.split(/(?=(?:...)*$)/);

                            // Convert the array to a string and format the output
                            value = value.join('.');
                            
                            return value + ' €';
                        }
                    }
                }
            }

        });


    };

    var fail = function () {
        alert("Something failed");
    };

    return {
        loadChart: loadChart,
        loadChartInPopup: loadChartInPopup
    }

}(PlayerService);