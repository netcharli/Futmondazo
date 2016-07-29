var PlayerService = function() {

    var getPlayer = function(playerId, done, fail) {
        $.get("/api/players/" + playerId)
            .done(done)
            .fail(fail);
    };

    return {
        getPlayer: getPlayer
    }
}();