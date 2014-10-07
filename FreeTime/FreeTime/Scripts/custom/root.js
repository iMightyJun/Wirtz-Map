var VM = VM = {};


VM.index = (function (ko, $) {

    function home(mapd, optionsd) {
        var self = this;
        self.start = ko.observable('');
        self.destination = ko.observable('');
        self.path = ko.observable('M10 10');
        self.mapData = ko.observableArray(mapd);
        self.selectOptions = ko.observableArray(optionsd);
        self.selectedPerson = ko.observable();
        self.mapMode = ko.observable('search');
        self.startPerson = ko.observable();
        self.endPerson = ko.observable();
        self.toggleTravelDots = ko.observable(true);
        self.toggleTravelDots.subscribe(function (newValue) {
            if (newValue)
                self.showTravelDots('visible');
            else
                self.showTravelDots('hidden');
        });

        self.showTravelDots = ko.observable('visible');
        self.isSearching = ko.observable('hidden');

        var floor = 0;


        self.showTravel = function () {
            self.toggleTravelDots(!self.toggleTravelDots());

        }

        self.testFunction = function () {
            alert('adfaf');
        };

        self.getPersonInfo = function () {
            if (self.selectedPerson() == undefined) {
                alert('Select a person');
                return;
            }

            alert(ko.toJSON(self.selectedPerson().info, null, 2));
        };

        //Spin code
        var opts = {
            lines: 13, // The number of lines to draw
            length: 20, // The length of each line
            width: 10, // The line thickness
            radius: 30, // The radius of the inner circle
            corners: 1, // Corner roundness (0..1)
            rotate: 0, // The rotation offset
            direction: 1, // 1: clockwise, -1: counterclockwise
            color: '#000', // #rgb or #rrggbb or array of colors
            speed: 1, // Rounds per second
            trail: 60, // Afterglow percentage
            shadow: false, // Whether to render a shadow
            hwaccel: false, // Whether to use hardware acceleration
            className: 'spinner', // The CSS class to assign to the spinner
            zIndex: 2e9, // The z-index (defaults to 2000000000)
            top: '50%', // Top position relative to parent
            left: '50%' // Left position relative to parent
        };
        var target = document.getElementById('loadingSpin');
        var spinner = new Spinner(opts).spin(target);

        self.getPath = function () {
            self.isSearching('visible');
            var start_ts;
            $.ajax({
                type: "GET",
                url: "../Home/getPath",
                data: { start: self.startPerson().info.deskNo, end: self.endPerson().info.deskNo, floors: "" },
                beforeSend: function() {
                    start_ts = new Date().getTime();
                },
                success: function (res) {
                    //alert(res);
                    self.isSearching('hidden');
                    self.path(res);
                },
                complete: function(jqXHR, textStatus) {
                    var end_ts = new Date().getTime();
                    var diff = (end_ts - start_ts) / 1000;
                    console.log('Path drawing took ' + diff + ' seconds');
                },
                error: function (xhr, textStatus, errorThrown) {
                    alert(xhr + "\n" + textStatus + "\n" + errorThrown);
                }
            });
        };

        self.changeView = function () {
            if (self.mapMode() == 'search')
                self.mapMode('browse');
            else
                self.mapMode('search');
        }


        var validateSearch = function () {
            if ((self.start() == '' || self.destination() == '') || (self.start() == self.destination())) {
                alert('Please enter a start AND destination Pl0X');
                return;
            }

            if (self.start()[0] == '1' && self.destination()[0] == '1')
                floor = 11;
            else if (self.start()[0] == '1' && self.destination()[0] == '2')
                floor = 12;
            else if (self.start()[0] == '2' && self.destination()[0] == '1')
                floor = 21;
            else if (self.start()[0] == '2' && self.destination()[0] == '2')
                floor = 22;

            //alert(floor);

        };

        self.shortestPaths = function () {
            validateSearch();
            $.ajax({
                type: "POST",
                url: "../Home/shortestPaths",
                data: { start: self.start(), end: self.destination(), floors: floor.toString() },
                success: function (res) {
                    //alert(res);
                    self.path(res);
                },
                error: function (xhr, textStatus, errorThrown) {
                    alert(xhr + "\n" + textStatus + "\n" + errorThrown);
                }
            });
        };

        self.flipBool = function () {
            var bool = self.testVirtual();
            self.testVirtual(!bool);

        };

    

       

    }
    function initModule(mapd) {
        var selectedData = [];
        mapd.nodes.forEach(function (item) {
            console.log(ko.toJSON(item, null, 2));
            if (item.info != null)
                selectedData.push(item);
        });

        var vm = new home(mapd.nodes, selectedData);
        ko.applyBindings(vm);
        return vm;
    }
    return { initModule: initModule };


})(ko, $);