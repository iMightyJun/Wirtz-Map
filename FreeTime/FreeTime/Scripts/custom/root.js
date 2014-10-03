var VM = VM = {};


VM.index = (function (ko, $) {

    function home(mapd) {
        var self = this;
        self.start = ko.observable('');
        self.destination = ko.observable('');
        self.path = ko.observable('M10 10');
        self.mapData = ko.observableArray(mapd.nodes);
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


        self.getPath = function () {
            $.ajax({
                type: "GET",
                url: "../Home/getPath",
                data: { start: self.startPerson().info.deskNo, end: self.endPerson().info.deskNo, floors: "" },
                success: function (res) {
                    //alert(res);
                    self.path(res);
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

        /*
        self.testVirtual.subscribe(function (newVal) {
            if (newVal)
                self.buttonText('Disappear');
            else
                self.buttonText('Appear');
        });


        self.testFunc = function () {
            $.ajax({
                type: "GET",
                url: "../Home/testAjax",
                success: function (data) {
                    alert(data);
                },
                error: function (xhr, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        };

        self.testAjaxParam = function () {
            $.ajax({
                type: "GET",
                url: "../Home/testParam",
                data: { data: "Hi", data2: 5 },
                success: function (data) {
                    alert(data);
                },
                error: function (xhr, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        }
        */

        

        self.readExcel = function () {
            $.ajax({
                type: "GET",
                url: "../Home/getExcel",
                success: function (res) {
                    alert(res);
                },
                error: function (xhr, textStatus, errorThrown) {
                    alert(xhr + "\n" + textStatus + "\n" + errorThrown);
                }
            });
        };

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
        var vm = new home(mapd);
        ko.applyBindings(new home(mapd));
        return vm;
    }
    return { initModule: initModule };


})(ko, $);