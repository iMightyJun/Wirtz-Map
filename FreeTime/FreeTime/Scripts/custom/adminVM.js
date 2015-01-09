var adminVM = function (employeeArr) {
    var self = this;
    self.autoCompleteSource = employeeArr;
    self.searchTerm = ko.observable();
    self.listOfEmployees = ko.observableArray([]);
    self.isSearching = ko.observable('none');
    self.getEmployee = function () {
        $.ajax({
            type: "GET",
            url: "../Admin/testLDAP",
            data: {},
            success: function (res) {
                alert(ko.toJSON(res, null, 2));
            },
            error: function (xhr, textStatus, errorThrown) {
                alert(xhr + "\n" + textStatus + "\n" + errorThrown);
            }

        });
    }
    
    $('#findPersonInput').keypress(function (event) {
        if (event.which == 13) {
            self.findPerson();
        }
    });

    self.openEditEmployeeAdmin = function (data) {
        $('#editEmployeeAdmin').dialog({
            autoOpen: false,
            height: 400,
            width: 400,
            resizable: false,
            title: 'Details',
            open: function () {
                $(this).scrollTop(0);
            },
            close: function () {
                
            }
        });

        $.ajax({
            url: "../Admin/getDeskNumber",
            type: "GET",
            data: { fName: data.fName, lName: data.lName },
            success: function (res) {
                $('#employeeDeskNo').val(res);
            },
            error: function (xhr, textStatus, errorThrown) {
                alert(xhr + "\n" + textStatus + "\n" + errorThrown);
            }
        });

        $('#employeeFName').val(data.fName);
        $('#employeeLName').val(data.lName);
        $('#employeeEmail').attr('href', 'mailto:' + data.email);
        $('#employeeEmail').text(data.email);
        $('#editEmployeeAdmin').dialog('open');
    };

    self.findPerson = function () {

        $.ajax({
            type: "GET",
            url: "../Admin/findPerson",
            data: { searchTerm: self.searchTerm() },
            beforeSend: function () {
                $('#findPersonInput').prop("disabled", true);
                $('#findPersonButton').prop("disabled", true);
                self.isSearching('block');
            },
            success: function (res) {
                self.listOfEmployees(res);
                self.isSearching('none');
                $('#findPersonButton').prop("disabled", false);
                $('#findPersonInput').prop("disabled", false);

            },
            error: function (xhr, textStatus, errorThrown) {
                alert(xhr + "\n" + textStatus + "\n" + errorThrown);
            }
        });
    }


    var opts = {
        lines: 13, // The number of lines to draw
        length: 10, // The length of each line
        width: 5, // The line thickness
        radius: 10, // The radius of the inner circle
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
    var target = document.getElementById('loadingSpinAdmin');
    var spinner = new Spinner(opts).spin(target);

}