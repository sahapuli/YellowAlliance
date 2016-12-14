/*
 * The Yellow Alliance v0.1
 * Copyright 2016 The Fera Group and FRC 503 Frog Force 
 *
*/
$(document).ready(function () {
    //
    //*******************************************
    /*  Initialize Events Table
    /********************************************/
    //
    if (!$.fn.dataTable.isDataTable('#events-table')) {
        //Set defaults for page sizes
        var table = $("#events-table").DataTable({
            "lengthMenu": [[15, 25, 50, -1], [15, 25, 50, "All"]],
            "order": [[3,"asc"]],
            "aoColumns": [
            { "sTitle": "Event ID", "sClass": "TYA-left", "sWidth": "100px" },
            { "sTitle": "Name", "sClass": "TYA-left", "sWidth": "300px" },
            { "sTitle": "Location", "sClass": "TYA-left", "sWidth": "250px" },
            { "sTitle": "Date", "sClass": "TYA-left" },
            { "sTitle": "Status", "sClass": "TYA-left" } 
            ],
        });

        //Setup callback function is row on table is clicked
        table.on('click', 'tr', function (e) {
            var aData = table.row(this).data();
            TableitemSelected(aData);
        });

        refreshtable();
    }
});  // End of Document Ready function

 
function refreshtable() {
    showrefreshbtn("#gtbtn", "Refreshing...");
    var uri = "api/TYA/GetEventList";
    var tableData = [];

    $.getJSON(uri, function (data) {
        $.each(data, function (key, item) {
            tableData.push(addRowWFormat(item));
        });
        // add row from array to html table
        var t = $("#events-table").DataTable();
        t.clear();
        t.rows.add(tableData).draw();
        hiderefreshbtn("#gtbtn", "Done");
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        ErrorMsgBox("Error Getting Events!", jqXHR.responseJSON, jqXHR.status);
        hiderefreshbtn("#gtbtn", "Done");
    }); // end of JSON Error 
} // End refreshtable

function addRowWFormat(item) {
   // var parseDate = d3.time.format("%Y-%m-%dT%H:%M:%S").parse;
    var parseDate = d3.timeParse("%Y-%m-%dT%H:%M:%S");
    var formatDate = d3.timeFormat("%B %d, %Y");
    var stat = ""; 
    var sd = parseDate(item.StartDate);
    if (sd < new Date()) {
        stat = "Completed";
    } else {
        stat = "Registered";
    }

    return [addLink(item.EventID), item.EventDescription, item.Venue, formatDate(sd), stat];
}

//Handle when a row in table is clicked 
function TableitemSelected(item) {
    //alert(item[0]);                         //get selected event id
    //document.getElementById("vendorid").value = $('#vendorselect').val();      //get vendor ID from page
    //document.getElementById("vendordesc").value = item[1];          //put vendorurer name on modal page
    //$('#myModalleaf').modal('show');
}

function addLink(item) {
    var linkstr = "";
    linkstr = "<a href=\"page-dashboard.html?ID=" + item + "\">" + item + "</a>";
    return linkstr;
}