function msgCreate() {
    var recip = $('#ddlRecipient').val();
    location.href = '/Messages/Create?recip=' + recip;
}

function msgCreate2() {
    var recip = $('#ddlRecipient').val();
    location.href = '/WebPush/Send/' + recip;
}

function filterMsg() {
    var recip = $('#ddlRecipient').val();
    location.href = '/Messages/Index?recip=' + recip;
    $('#ddlRecipient').val(recip);
}

function checkDDL() {
    var recip = $('#ddlRecipient').val();
    $('#recipient').val(recip);
}

