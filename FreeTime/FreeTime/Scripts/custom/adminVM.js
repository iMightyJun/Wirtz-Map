var adminVM = function (employeeArr) {
    var self = this;
    self.autoCompleteSource = employeeArr;
    self.searchTerm = ko.observable();
    self.listOfEmployees = ko.observableArray([]);
    self.isSearching = ko.observable('none');
    self.currFName = ko.observable('');
    self.currLName = ko.observable('');
    self.currDeskNo = ko.observable('');
    self.isDeskAssigned = ko.observable('');
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

    $('#updateEmployeeAdmin').click(function () {
        checkIfDeskAssigned($('#employeeDeskNo').val());
        if (self.isDeskAssigned() != ' ') {
            var doRemove = confirm('Desk' + $('#employeeDeskNo').val() + ' is assigned to ' + self.isDeskAssigned() + '. Employee will be replaced. Are you sure?');
            if (doRemove) {

                if (self.currDeskNo() != '') {
                    $.ajax({
                        url: "../Admin/clearDesk",
                        type: "DELETE",
                        data: { deskNo: self.currDeskNo() },
                        success: function (res) {
                            alert(res);
                        },
                        error: function (xhr, textStatus, errorThrown) {
                            alert('Update desk number failed.');
                        }

                    });
                }
            }
            else {
                return;
            }
        }

        $.ajax({
            url: "../Admin/updateDeskNumber",
            type: "PUT",
            data: { fName: self.currFName(), lName: self.currLName(), deskNo:  $('#employeeDeskNo').val(), internalPhone: $('#employeeInternalPhone').val(), description:  $('#employeeDescription').val() },
            success: function (res) {
                alert(res);
            },
            error: function (xhr, textStatus, errorThrown) {
                alert('Update desk number failed.');
            }

        });
        closeDialog();

    });

    $('#removeEmployeeAdmin').click(function () {
        if ($('#employeeDeskNo').val() == '') {
            alert('Employee has not been assigned a desk.');
            return;
        }
        checkIfDeskAssigned($('#employeeDeskNo').val());
        if (self.isDeskAssigned() != ' ') {
            var doRemove = confirm('Desk ' + $('#employeeDeskNo').val() + ' is assigned to ' + self.isDeskAssigned() + '. Employee will be removed. Are you sure?');
            if (doRemove) {
                removeEmployee();
            }
            else {

            }
        }
        closeDialog();

    });

    function closeDialog() {
        $('#editEmployeeAdmin').dialog('close');
        self.currFName('');
        self.currLName('');
        self.currDeskNo('');
        self.isDeskAssigned('');
    }

    function removeEmployee() {
        //alert(self.currFName() + ' ' + self.currLName() + ' ' + self.currDeskNo());

        $.ajax({
            url: "../Admin/removeFromMap",
            type: "DELETE",
            data: { fName: self.currFName(), lName: self.currLName(), deskNo: self.currDeskNo() },
            success: function (res) {
                alert(res);
            },
            error: function (xhr, textStatus, errorThrown) {
                alert('Update desk number failed.');
            }

        });
        $('#editEmployeeAdmin').dialog('close');
        
    }

    function checkIfDeskAssigned(desk) {
        $.ajax({
            url: "../Admin/checkIfDeskAssigned",
            type: "GET",
            data: { deskNo: desk },
            async: false,
            success: function (res) {
                self.isDeskAssigned(res);
            },
            error: function (xhr, textStatus, errorThrown) {
                alert('Update desk number failed.');
            }

        });
    }

    self.openEditEmployeeAdmin = function (data) {
        $('#editEmployeeAdmin').dialog({
            autoOpen: false,
            height: 400,
            width: 470,
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
            async: false,
            success: function (res) {
                $('#employeeDeskNo').val(res);
                self.currDeskNo(res);
            },
            error: function (xhr, textStatus, errorThrown) {
                alert(xhr + "\n" + textStatus + "\n" + errorThrown);
            }
        });
        self.currFName(data.fName);
        self.currLName(data.lName);
        $('#employeeFName').val(self.currFName());
        $('#employeeLName').val(self.currLName());
        $('#employeeDescription').val(data.description);
        $('#employeeInternalPhone').val(data.internalPhone);
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
                alert(ko.toJSON(xhr, null, 2) + "\n" + textStatus + "\n" + errorThrown);
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