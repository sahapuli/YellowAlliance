$(document).ready(function () {
    //
    //*******************************************
    /*  Initialize Events Table
    /********************************************/
    //
    if (!$.fn.dataTable.isDataTable('#events-table')) {
        //Set defaults for page sizes
        var table = $("#events-table").DataTable({
            "lengthMenu": [[20, 25, 50, -1], [20, 25, 50, "All"]],
            "order": [[3,"asc"]],
            "aoColumns": [
            { "sTitle": "Event ID", "sClass": "TYA-left", "sWidth": "80px" },
            { "sTitle": "Name", "sClass": "TYA-left", "sWidth": "320px" },
            { "sTitle": "Location", "sClass": "TYA-left", "sWidth": "250px" },
            { "sTitle": "Date", "sClass": "TYA-left", "sWidth": "180px" },
            { "sTitle": "Status", "sClass": "TYA-center" } 
            ],
        });

        refreshtable();

        //Setup callback function is row on table is clicked
        $('#events-table tbody').on('click', 'tr', function () {
            var aData = table.row(this).data();
            TableitemSelected(aData);
        });
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

    return [item.EventID, item.EventDescription, item.Venue, formatDate(sd), stat];
}

//jump to team table when row is clicked 
function TableitemSelected(item) {
    window.location.href = "\page-dashboard.html?ID=" + item[0];
}


function addLink(item) {
    var linkstr = "";
    linkstr = "<a href=\"page-dashboard.html?ID=" + item + "\">" + item + "</a>";
    return linkstr;
}

function testsecure() {
    var uri = "api/TYASecured/TestSecurity";

    $.getJSON(uri, function (data) {
        if (data.hasOwnProperty('Message')) {
            msgbox(-1, "Security Failed!", "Error Occurred: " + data.Message);
        } else {
            //user has successfully logged out 
            msgbox(0, "Security Completed!", "Returned: " + data);
        }
     
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        ErrorMsgBox("Error Calling Secure Controller!", jqXHR.responseJSON, jqXHR.status);
    }); // end of JSON Error 
}