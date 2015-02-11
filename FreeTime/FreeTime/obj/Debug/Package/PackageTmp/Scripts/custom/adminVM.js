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
    self.findDesksOptions = ko.observableArray(['Select...', 'OPEN','Workstation', 'Executive', 'Office', 'Conference Room']);
    self.findDesksValue = ko.observable('');
    self.mapData = ko.observableArray([]);
    self.currentTemplate = ko.observable('None');

    self.stayOpen = false;


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
        if (self.isDeskAssigned() != 'OPEN') {
            var doRemove = confirm('Desk ' + $('#employeeDeskNo').val() + ' is assigned to ' + self.isDeskAssigned() + '. Employee will be replaced. Are you sure?');
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
            }
            else {
                return;
            }
        }

        

        closeDialog();

    });

    $('#removeEmployeeAdmin').click(function () {
        if ($('#employeeDeskNo').val() == '') {
            alert('Employee has not been assigned a desk.');
            return;
        }
        checkIfDeskAssigned($('#employeeDeskNo').val());
        if (self.isDeskAssigned() != 'OPEN') {
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
            url: "../Admin/getDeskInfo",
            type: "GET",
            data: { fName: data.fName, lName: data.lName },
            async: false,
            success: function (res) {
                var retVal = JSON.parse(res);
                alert(res);
                $('#employeeDeskNo').val(retVal.deskNumber);
                self.currDeskNo(retVal.deskNumber);
                $('#employeeDescription').val(retVal.desc);
            },
            error: function (xhr, textStatus, errorThrown) {
                alert(xhr + "\n" + textStatus + "\n" + errorThrown);
            }
        });
        self.currFName(data.fName);
        self.currLName(data.lName);
        $('#employeeFName').val(self.currFName());
        $('#employeeLName').val(self.currLName());
        
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
                $('#adminContentContainer').css('display', 'block');
                $('#findPersonInput').prop("disabled", true);
                $('#findPersonButton').prop("disabled", true);
                self.isSearching('block');
            },
            success: function (res) {
                self.listOfEmployees(res);
                self.isSearching('none');
                $('#findPersonButton').prop("disabled", false);
                $('#findPersonInput').prop("disabled", false);
                self.currentTemplate('findPerson');

            },
            error: function (xhr, textStatus, errorThrown) {
                alert(ko.toJSON(xhr, null, 2) + "\n" + textStatus + "\n" + errorThrown);
            }
        });
    }

    self.findDesks = function () {
        if (self.findDesksValue() == 'Select...')
            return;
        $.ajax({
            url: '../Home/getMapJSON',
            type: 'GET',
            beforeSend: function () {
                $('#adminContentContainer').css('display', 'block');

                $('#findDesksSelect').prop("disabled", true);
                $('#findDesksButton').prop("disabled", true);
                self.isSearching('block');
            },
            success: function (res) {
                var mapD = JSON.parse(res);
                self.mapData(mapD.nodes);
                $('#findDesksSelect').prop("disabled", false);
                $('#findDesksButton').prop("disabled", false);
                self.isSearching('none');
                self.currentTemplate('findDesks');

            },
            error: function (xhr, textStatus, errorThrown) {
                alert(xhr + "\n" + textStatus + "\n" + errorThrown);
            }
        });
    }



    self.getFillColor = function (data) {
        //Office, Conference Room, DM Station
        //if (desc == 'Workstation' || desc == 'Intern Application and Web Design')
        //    return '#D1DBBD';
        //if (desc == 'Office')
        //    return '#91AA9D';
        //if (desc == 'Conference Room')
        //    return '#3E606F';
        //if (desc == 'DM Station')
        //    return '#193441';

        if (data.description == self.findDesksValue() || data.lName == self.findDesksValue())
            return '#91AA9D';
        else
            return 'none';
    }
    

    self.toggleOpenDialog = function () {
        self.stayOpen = !self.stayOpen;
    }

    self.hideDetails = function () {
        if (!self.stayOpen)
            closeDialog();
    }



    self.showDetails = function (data) {

        $('#personInfoDialog').dialog({
            autoOpen: false,
            height: 220,
            width: 300,
            resizable: false,
            title: 'Details',
            open: function () {
                $(this).scrollTop(0);
            },
            close: function () {
                self.stayOpen = false;
            },
            position: [currentMousePos.x, currentMousePos.y]
        });
        $('#personName').text('Name: ' + data.info.fName + ' ' + data.info.lName);
        $('#internalPhone').text('Internal Phone: ' + data.info.internalPhone);
        $('#personDeskNo').text('Desk: ' + data.info.deskNo);

        if ((data.info.fName != '' && data.info.lName != '') && (data.info.fName != 'undefined' && data.info.lName != 'undefined')) {
            $('#personEmail').attr('href', 'mailto:' + data.info.fName + '.' + data.info.lName + '@wirtzbev.com');

            $('#personEmail').text(data.info.fName + '.' + data.info.lName + '@wirtzbev.com');
        }


        $('#personInfoDialog').dialog('open');
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