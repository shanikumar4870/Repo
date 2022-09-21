
var ID = 0;
$(document).ready(function () {
    isEmail();
    ShowData();
    $("#btn").click(function () {
        InsertUpdateEmployee();
        return false;
    })
})

function InsertUpdateEmployee()
{
    $.post("../Master/InsertUpdateData", {
        ID: ID,
        ID:$("#hfild").val(),
        Name: $("#txtname").val(),
        Mobile: $("#txtmobile").val(),
        Email: $("#txtemail").val(),
        DOB: $("#txtdob").val(),
        Password: $("#txtpassword").val(),
        Designation: $("#txtdesign").val()
    }, function (data) {
            if (data.Message != "") {
               
                alert(data.Message);
                window.location.reload(true);
                ShowData();

           }     
    })
}

function ShowData() {
    $.post("../Master/ShowData/", { ID: ID }, function (data) {
        if (data.Grid != "") {
            $("#Gridview").html(data.Grid)
        }
    })
}
function EditRecord(ID) {
    $.post("../Master/EditRegistratinData/", { ID: ID, },

        function (data) {
            if (data.Message = "") {
                alert(data.Message);
            }
            else {
                $("#hfild").val(data.ID);
                $("#txtname").val(data.Name);
                $("#txtmobile").val(data.Mobile);
                $("#txtemail").val(data.Email);
                $("#txtdob").val(data.DOB);
                $("#txtpassword").val(data.Password);
                $("#txtdesign").val(data.Designation);
            }
    })
}

function DeleteRecord(ID) {
    var res = window.confirm("Are You Record Deleted ?")
    if (res == true) {
        $.post("../Master/DeleteRegistration", { ID: ID }, function (data) {
            if (data.Message != "") {
                alert(data.Message)

                window.location.reload(true);
            }
        })
    }
    else false;
}

function clearData() {
    $("#hfild").val(0);
    $("#txtname").val("");
    $("#txtmobile").val("");
    $("#txtemail").val("");
    $("#txtdob").val("");
    $("#txtpassword").val("");
    $("#txtdesign").val("");
}

function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}
