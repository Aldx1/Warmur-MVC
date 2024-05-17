function getIndicators(leadId, page) {
  const url =
    $("#indicators").data("url") + "?leadId=" + leadId + "&page=" + page;
  $.ajax({
    url: url,
    type: "GET",
    success: function (data) {
      $("#indicators").html(data);
    },
    error: function (error) {
      alert("Error loading indicators");
    },
  });
}

function postIndicator(leadId) {
    const name = document.getElementById('new-indicator-name-' + leadId).value;
    const value = document.getElementById('new-indicator-value-' + leadId).value;

    if (!name || !value || name.length == 0 || value.length == 0) {
        alert("Indicator needs a name and value");
        return;
    }

    $.ajax({
        url: '/Indicators/PostIndicator/?leadId=' + leadId + '&name=' + name + '&value=' + value,
        type: "POST",
        success: function (data) {
            alert("Success");
            getIndicators(leadId, 1);
        },
        error: function (error) {
            alert("Error adding indicator");
        },
    });
}

function putIndicator(leadId, indicatorId) {
    const indicatorValue = document.getElementById('value-textbox-' + indicatorId).value;
    $.ajax({
        url: '/Indicators/PutIndicator/?leadId=' + leadId + '&indicatorId=' + indicatorId + '&value=' + indicatorValue,
        type: 'PUT', 
        success: function (data) {
            alert("Success");
            getIndicators(leadId, 1);
        },
        error: function (error) {
            alert("Error updating indicator");
        },
    });
}

function deleteIndicator(leadId, indicatorId) {
    $.ajax({
        url: '/Indicators/DeleteIndicator/?leadId=' + leadId + '&indicatorId=' + indicatorId,
        type: 'DELETE',
        success: function (data) {
            alert("Success");
            getIndicators(leadId, 1);
        },
        error: function (error) {
            alert("Error deleting indicator");
        },
    });
}

function resetIndicatorValue(originalValue, originalSource, id) {
    const textbox = document.getElementById("value-textbox-" + id);
    textbox.value = originalValue;

    const sourceBox = document.getElementById("value-source-" + id);
    sourceBox.innerHTML = originalSource;
    sourceBox.value = originalSource;
}

function updateIndicatorValue(id) {
    const sourceBox = document.getElementById("value-source-" + id);
    sourceBox.innerHTML = "Provided";
    sourceBox.value = "Provided";
}
