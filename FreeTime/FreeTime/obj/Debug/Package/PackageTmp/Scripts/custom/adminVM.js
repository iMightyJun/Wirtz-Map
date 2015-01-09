var adminVM = function (employeeArr) {
    var self = this;
    self.autoCompleteSource = employeeArr;
    self.searchTerm = ko.observable();
    self.listOfEmployees = ko.observableArray([]);
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
            height: 200,
            width: 300,
            resizable: false,
            title: 'Details',
            open: function () {
                $(this).scrollTop(0);
            },
            close: function () {
                
            }
        });
        $('#employeeFName').val(data.fName);

        $('#editEmployeeAdmin').dialog('open');
    };

    self.findPerson = function () {

        $.ajax({
            type: "GET",
            url: "../Admin/findPerson",
            data: { searchTerm: self.searchTerm() },
            success: function (res) {
                self.listOfEmployees(res);
            },
            error: function (xhr, textStatus, errorThrown) {
                alert(xhr + "\n" + textStatus + "\n" + errorThrown);
            }
        });
    }
}