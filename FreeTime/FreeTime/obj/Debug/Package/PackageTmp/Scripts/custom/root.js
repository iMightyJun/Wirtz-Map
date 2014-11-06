var VM = VM || {};


VM.index = (function (ko, $) {

    function home(mapd, optionsd) {
        var self = this;
        self.path = ko.observable('M10 10');
        self.mapData = ko.observableArray(mapd);
        self.selectOptions = ko.observableArray(optionsd);
        self.selectedPerson = ko.observable();
        self.mapMode = ko.observable('search');
        self.startPerson = ko.observable('');
        self.endPerson = ko.observable('');
        self.toggleTravelDots = ko.observable(true);
        self.toggleTravelDots.subscribe(function (newValue) {
            if (newValue)
                self.showTravelDots('visible');
            else
                self.showTravelDots('hidden');
        });

        self.showTravelDots = ko.observable('visible');
        self.isSearching = ko.observable('hidden');
        self.secondFloorPath = ko.observable('');
        self.firstFloorPath = ko.observable('');
        self.firstFloorFirst = ko.observable(true);
        var floor = 0;


        self.showTravel = function () {
            self.toggleTravelDots(!self.toggleTravelDots());

        }

        self.flipFloors = function () {
            self.firstFloorFirst(!self.firstFloorFirst());
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

        var validateSearch = function () {
            if ((self.startPerson() == '' || self.endPerson() == '') || (self.startPerson().info.deskNo == self.endPerson().info.deskNo)) {
                alert('Please enter a start AND destination Pl0X');
                return;
            }

            if (self.startPerson().info.deskNo[0] == '1' && self.endPerson().info.deskNo[0] == '1')
                floor = 11;
            else if (self.startPerson().info.deskNo[0] == '1' && self.endPerson().info.deskNo[0] == '2')
                floor = 12;
            else if (self.startPerson().info.deskNo[0] == '2' && self.endPerson().info.deskNo[0] == '1')
                floor = 21;
            else if (self.startPerson().info.deskNo[0] == '2' && self.endPerson().info.deskNo[0] == '2')
                floor = 22;

            //alert(floor);
        };

        var fixSearch = function () {

            var startNo = self.startPerson().info.deskNo;
            var endNo = self.endPerson().info.deskNo;

            var rooms = ["2007", "1077", "1045", "1009", "1010", "1013", "1006"]
            for (var i = 0; i < rooms.length; i++) {
                if (startNo.indexOf(rooms[i]) == 0) {
                    startNo = rooms[i];
                }
                if (endNo.indexOf(rooms[i]) == 0) {
                    endNo = rooms[i];
                }

            }

            // IF doesn't need collapse
            return { start: startNo, end: endNo };
        };

   
        self.getPath = function () {
            validateSearch();
            self.isSearching('visible');
            var start_ts;
            var fixedNo = fixSearch();
            var startNo = fixedNo.start;
            var endNo = fixedNo.end;

            $.ajax({
                type: "GET",
                url: "../Home/getPath",
                data: { start: startNo, end: endNo, floors: "" },
                beforeSend: function() {
                    start_ts = new Date().getTime();
                },
                success: function (res) {
                    alert(res);
                    self.isSearching('hidden');
                    attachPath(res);
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


        var attachPath = function (path) {
            if (floor == 11) {
                self.firstFloorPath(path);
                self.firstFloorFirst(true);
            }
            if (floor == 22) {
                self.secondFloorPath(path);
                self.firstFloorFirst(false);
            }
            if (floor == 12) {
                var splitPath = path.split('Stair');

                //alert(ko.toJSON(splitPath, null, 2));
                self.firstFloorFirst(true);

                self.firstFloorPath(splitPath[0]);
                self.secondFloorPath(splitPath[1]);
            }
            if (floor == 21) {
                var splitPath = path.split('Stair');
                //alert(ko.toJSON(splitPath, null, 2));
                self.firstFloorFirst(false);

                self.firstFloorPath(splitPath[1]);
                self.secondFloorPath(splitPath[0]);
            }
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
            if (item.info != null) {
                if(item.info.fName.indexOf('Stair') == -1)
                    selectedData.push(item);
            }
        });

        var vm = new home(mapd.nodes, selectedData);
        ko.applyBindings(vm);
        return vm;
    }
    return { initModule: initModule };


})(ko, $);