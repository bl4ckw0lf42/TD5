require(["libs/pixi.min"], function(PIXI) {
    var renderer = PIXI.autoDetectRenderer(800, 450);

    var stage = new PIXI.Container();

    function mainLoop() {
        requestAnimationFrame(mainLoop);

        renderer.render(stage);
    }

    function startTD5(containerId) {
        var container = document.body;
        if (typeof containerId == "string") {
            var tmp = document.getElementById(containerId);
            if (tmp) {
                container = tmp;
            } else {
                console.log("No element with id: " + containerId + " found!");
            }
        }
        container.appendChild(renderer.view);
        mainLoop();
    }

    startTD5();
});
