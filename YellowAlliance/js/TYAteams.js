/*
 * The Yellow Alliance v0.1
 * Copyright 2016 The Fera Group and FRC 503 Frog Force 
 *
*/
$(document).ready(function () {
    //
    //*******************************************
    /*  Initialize Team Table
    /********************************************/
    //
    if (!$.fn.dataTable.isDataTable('#team-table')) {
        //Set defaults for page sizes
        var table = $("#team-table").DataTable({
            "lengthMenu": [[15, 25, 50, -1], [15, 25, 50, "All"]],
            "aoColumns": [
            { "sTitle": "Team No", "sClass": "TYA-left", "sWidth": "70px" },
            { "sTitle": "Name", "sClass": "TYA-left", "sWidth": "280px" },
            { "sTitle": "School/Affiliation", "sClass": "TYA-left"},
            { "sTitle": "City", "sClass": "TYA-left", "sWidth": "100px" },
            { "sTitle": "State", "sClass": "TYA-left", "sWidth": "50px" }
            ],
        });

        //Setup callback function is row on table is clicked
        $('#team-table tbody').on('click', 'tr', function () {
            var aData = table.row(this).data();
            TableitemSelected(aData);
        });

        refreshteams();
    }
});  // End of Document Ready function

 
function refreshteams() {
    showrefreshbtn("#gtbtn", "Refreshing...");
    var uri = "api/Team/GetTeamList";
    var tableData = [];

    $.getJSON(uri, function (data) {
        $.each(data, function (key, item) {
            tableData.push(formatrow(item));
        });
        // add row from array to html table
        var t = $("#team-table").DataTable();
        t.clear();
        t.rows.add(tableData).draw();
        hiderefreshbtn("#gtbtn", "Done");
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        ErrorMsgBox("Error Getting Teams!", jqXHR.responseJSON.Message, jqXHR.status);
        hiderefreshbtn("#gtbtn", "Done");
    }); // end of JSON Error 
} // End refreshtable

function formatrow(item) {
    return [item.TeamNumber, item.TeamNameLong, item.TeamNameShort, item.City, item.StateProv];
}

//Show modal window on row click in employee table allowing user to maintain data
function TableitemSelected(item) {
    // document.getElementById("vendorid").value = item[0];            //put vendorurer id on modal page
    document.getElementById("vendorid").value = $('#vendorselect').val();      //get vendor ID from page
    document.getElementById("vendordesc").value = item[1];          //put vendorurer name on modal page
    $('#myModalleaf').modal('show');
}
